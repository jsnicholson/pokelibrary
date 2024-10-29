namespace Data.Models
{
    public class Set
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateOnly releaseDate { get; set; }
        public string seriesId { get; set; }
        public int totalCardCount { get; set; }
        public int mainCardCount { get; set; }
        public string logoPath { get; set; }
        public string symbolPath { get; set; }
        public string backgroundPath { get; set; }
        public string tcgLiveCode { get; set; }
        public bool isPromoSet { get; set; }
        public string[] relatedSetIds { get; set; }
    }
}
