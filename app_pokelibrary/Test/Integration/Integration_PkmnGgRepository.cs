using ExternalData.PkmnGg.Repositories;
using ExternalData.PkmnGg.Models;
using Moq;
using RestSharp;

namespace pokelibrary.Test.Integration {
    [Collection("SeriesData collection")]
    public class Integration_PkmnGgRepository {
        private readonly SeriesDataFixture _fixture;

        public Integration_PkmnGgRepository(SeriesDataFixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public async Task PkmnGgRepository_BuildId_Success() {
            var buildId = await PkmnGgRepository.GetBuildIdentifier();

            Assert.NotNull(buildId);
        }

        [Fact]
        public void PkmnGgRepository_GetAllSeries_Success() {
            var serieses = _fixture.listSerieses;

            Assert.NotNull(serieses);
            Assert.NotEmpty(serieses);
        }

        [Theory]
        [InlineData("base")]
        [InlineData("gym")]
        [InlineData("neo")]
        [InlineData("platinum")]
        [InlineData("xy")]
        [InlineData("scarlet-violet")]
        public void PkmnGgRepository_GetAllSeries_ContainsKnownValues(string knownSeries) {
            var serieses = _fixture.listSerieses;

            Assert.Contains(serieses, s => s.id == knownSeries);
        }

        public class SeriesDataFixture : IDisposable {
            public List<Series> listSerieses { get; set; }
            public IRestClient restClient;
            public PkmnGgRepository pkmnGgRepository;

            public SeriesDataFixture() {
                PkmnGgRepository.EnsureBrowserDownloaded().GetAwaiter().GetResult();
                restClient = new RestClient(PkmnGgRepository.Constants.PKMNGG_BASEURL);
                pkmnGgRepository = new PkmnGgRepository(restClient);
                listSerieses = GetAllSeries().GetAwaiter().GetResult();
            }

            public void Dispose() {
                GC.SuppressFinalize(this);
            }

            private async Task<List<Series>> GetAllSeries() {
                return await pkmnGgRepository.GetAllSeries();
            }
        }

        [CollectionDefinition("SeriesData collection")]
        public class SeriesDataCollection : ICollectionFixture<SeriesDataFixture> {
            // This class has no code, it's just used for xUnit's fixture infrastructure
        }
    }
}