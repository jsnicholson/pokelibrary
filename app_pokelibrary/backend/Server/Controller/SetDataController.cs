using ExternalData.PkmnGg.Models;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using RestSharp;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace pokelibrary.Server.Controller {
    [ApiController]
    [Route("[controller]")]
    public partial class SetDataController {
        [HttpGet]
        public async Task<string> UpdateSetData() {
            string buildIdentifier = string.Empty;
            List<string> requestUrls = new();
            // get data from external
            BrowserFetcher browserFetcher = new();
            await browserFetcher.DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions {
                Headless = true
            });
            using (var page = await browser.NewPageAsync()) {
                
                await page.SetRequestInterceptionAsync(true);
                page.Request += async (sender, e) => {
                    Console.WriteLine(e.Request.Url);
                    if(e.Request.Url.Contains("_next/data")) {
                        buildIdentifier = m_regexPkmnGgBuildIdentifier().Match(e.Request.Url).Value;
                    }
                    requestUrls.Add(e.Request.Url);
                    await e.Request.ContinueAsync();
                };
                await page.GoToAsync("https://www.pkmn.gg/series/base/base", waitUntil: WaitUntilNavigation.Networkidle2);
            }
            await browser.CloseAsync();
            RestClient client = new();
            RestRequest request = new($"https://www.pkmn.gg/_next/data/{buildIdentifier}/series.json", Method.Get);
            var response = await client.ExecuteAsync(request);
            List<Series> series = JsonSerializer.Deserialize<SeriesResponse>(response?.Content).pageProps.serieses;
            return response?.Content;
            // update in local
        }

        [GeneratedRegex(@"(?<=\/_next\/data\/)[^\/]+")]
        private static partial Regex m_regexPkmnGgBuildIdentifier();
    }
}
