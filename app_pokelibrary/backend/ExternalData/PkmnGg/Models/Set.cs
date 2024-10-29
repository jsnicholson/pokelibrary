namespace ExternalData.PkmnGg.Models {
    public class Set {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime releaseDate { get; set; }
        public string series { get; set; }
        public string seriesDisplay { get; set; }
        public int total { get; set; }
        public int printedTotal { get; set; }
        public string logo { get; set; }
        public string symbol { get; set; }
        public string background { get; set; }
        public string og { get; set; }
        public string slug { get; set; }
        public object relatedSet { get; set; }
        public DateTime lastSynced { get; set; }
        public bool isReleased { get; set; }
        public int tcgGroupId { get; set; }
        public string tcgLiveCode { get; set; }
        public string tcgPlayerShopUrl { get; set; }
        public string tcgPlayerSetCode { get; set; }
        public string psaHeadingId { get; set; }
        public bool isPromoSet { get; set; }
        public DateTime releaseDateValue { get; set; }
    }
}
