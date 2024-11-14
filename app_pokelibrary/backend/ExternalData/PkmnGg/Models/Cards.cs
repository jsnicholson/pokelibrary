using pokelibrary.ExternalData.PkmnGg.Converters;
using System.Text.Json.Serialization;

namespace ExternalData.PkmnGg.Models {
    public class Cards {
        public string id { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string rarity { get; set; }
        public string numberKey { get; set; }
        public string sortPrice { get; set; }
        public string formattedPrice { get; set; }
        public string setId { get; set; }
        public string artist { get; set; }
        public string primaryVariant { get; set; }
        public bool hideNumber { get; set; }
        public string supertype { get; set; }
        public string dbId { get; set; }
        [JsonConverter(typeof(VariantsConverter))]
        public Variant[] variantMap { get; set; }
        public string largeImagePath { get; set; }
        public string thumbImagePath { get; set; }
        public string largeImageUrl { get; set; }
        public string thumbImageUrl { get; set; }
        public string series { get; set; }
        public string set { get; set; }
        public bool isFullCard { get; set; }
        public string numberDisplay { get; set; }
        public string totalDisplay { get; set; }
        public string releaseDate { get; set; }
        public string numberNameKey { get; set; }
        public string numberRarityKey { get; set; }
        public string numberPriceKey { get; set; }
        public string numberArtistKey { get; set; }
        public string tcgPlayerMassEntry { get; set; }
        public object releaseDateSortKey { get; set; }
        public int rarityRank { get; set; }
        public string setIconUrl { get; set; }

        public class Variant {
            public decimal price { get; set; }
            public string type { get; set; }
            public string key { get; set; }
            public string description { get; set; }
            public long tcgPlayedId { get; set; }
            public string tcgPlayerSubtype { get; set; }
        }
    }
}
