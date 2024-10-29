using ExternalData.PkmnGg.Models;
using PuppeteerSharp;
using RestSharp;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ExternalData.PkmnGg.Repositories {
    public partial class PkmnGgRepository {
        private readonly string m_buildIdentifier = string.Empty;
        [GeneratedRegex(@"(?<=\/_next\/data\/)[^\/]+")]
        private static partial Regex m_regexPkmnGgBuildIdentifier();
        private readonly IRestClient m_restClient;

        public PkmnGgRepository(IRestClient restClient) {
            m_restClient = restClient;
            EnsureBrowserDownloaded().GetAwaiter().GetResult();
            // cant operate without build identifier
            m_buildIdentifier = GetBuildIdentifier().GetAwaiter().GetResult();
        }

        public static async Task EnsureBrowserDownloaded() {
            await new BrowserFetcher().DownloadAsync();
        }

        public static async Task<string> GetBuildIdentifier() {
            string? buildIdentifier = null;
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.SetRequestInterceptionAsync(true);
            page.Request += async (sender, e) => {
                if (e.Request.Url.Contains("_next/data")) {
                    buildIdentifier = m_regexPkmnGgBuildIdentifier().Match(e.Request.Url).Value;
                }
                await e.Request.ContinueAsync();
            };
            await page.GoToAsync("https://www.pkmn.gg/series/base/base", waitUntil: WaitUntilNavigation.Networkidle2);
            await browser.CloseAsync();

            if (buildIdentifier == null) {
                // custom exception for no upstream connection
                throw new Exception("");
            }

            return buildIdentifier;
            // need to handle case of not getting buildIdentifier
            // exception? just log it?
        }

        public async Task<List<ExternalData.PkmnGg.Models.Series>> GetAllSeries() {
            RestRequest request = new($"https://www.pkmn.gg/_next/data/{m_buildIdentifier}/series.json", Method.Get);
            RestResponse response = await m_restClient.ExecuteAsync(request);

            if(!response.IsSuccessStatusCode || response.Content == null) {
                // custom exception for connection failure?
                throw new Exception("");
            }

            // custom exception for upstream unexpected format?
            var seriesResponse = JsonSerializer.Deserialize<SeriesResponse>(response.Content) ?? throw new Exception("");

            return seriesResponse.pageProps.serieses;
        }

        public async Task<List<ExternalData.PkmnGg.Models.Set>?> GetAllSetsInSeries(string seriesId) {
            RestRequest request = new($"{m_buildIdentifier}/series/{seriesId}.json");
            RestResponse response = await m_restClient.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode || response.Content == null) {
                // custom exception for connection failure?
                throw new Exception("");
            }

            // custom exception for upstream unexpected format?
            var seriesResponse = JsonSerializer.Deserialize<SetsResponse>(response.Content) ?? throw new Exception("");

            return seriesResponse.pageProps.sets;
        }

        public async Task<List<ExternalData.PkmnGg.Models.Card>> GetAllCardsInSet(string seriesId, string setId) {
            RestRequest request = new(string.Format(Constants.PKMNGG_CARDS, m_buildIdentifier, seriesId, setId));
            RestResponse response = await m_restClient.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode || response.Content == null) {
                // custom exception for connection failure?
                throw new Exception("");
            }

            // custom exception for upstream unexpected format?
            var seriesResponse = JsonSerializer.Deserialize<CardsResponse>(response.Content) ?? throw new Exception("");

            return seriesResponse.pageProps.cardData;
        }

        public static class Constants {
            public const string PKMNGG_BASEURL = "https://www.pkmn.gg/_next/data/";
            public const string PKMNGG_SERIES = "{0}/series.json";
            public const string PKMNGG_SETS = "{0}/series/{1}.json";
            public const string PKMNGG_CARDS = "{0}/series/{1}/{2}.json";
        }
    }
}
