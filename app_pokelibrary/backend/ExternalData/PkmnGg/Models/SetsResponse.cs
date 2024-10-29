namespace ExternalData.PkmnGg.Models {
    public class SetsResponse {
        public PageProps pageProps { get; set; }
        public bool __N_SSG { get; set; }

        public class PageProps {
            public List<Set> sets { get; set; }
            public Series seriesData { get; set; }
            public object error { get; set; }
        }
    }
}