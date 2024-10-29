using System.Text.Json.Serialization;

namespace ExternalData.PkmnGg.Models {
    public class SeriesResponse {
        public PageProps pageProps { get; set; }
        public bool __N_SSG { get; set; }

        public class MetaTags {
            [JsonPropertyName("og:title")]
            public string ogtitle { get; set; }

            [JsonPropertyName("og:description")]
            public string ogdescription { get; set; }
        }

        public class PageProps {
            public string key { get; set; }
            public List<Series> serieses { get; set; }
            public MetaTags metaTags { get; set; }
        }
    }


}
