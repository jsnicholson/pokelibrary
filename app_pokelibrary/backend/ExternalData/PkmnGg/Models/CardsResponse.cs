namespace ExternalData.PkmnGg.Models {
    public class CardsResponse {
        public PageProps pageProps { get; set; }
        public bool __N_SSG { get; set; }

        public class HighestCard {
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
            public Variants variantMap { get; set; }
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
            public long releaseDateSortKey { get; set; }
            public int rarityRank { get; set; }
            public string setIconUrl { get; set; }
        }

        public class Variant {
            public double price { get; set; }
            public string priceDisplay { get; set; }
            public string type { get; set; }
            public string key { get; set; }
            public string description { get; set; }
            public string tcgPlayerId { get; set; }
            public string tcgPlayerSubtype { get; set; }
        }

        public class PageProps {
            public string key { get; set; }
            public List<Cards> cardData { get; set; }
            public SetData setData { get; set; }
            public HighestCard highestCard { get; set; }
            public string setMarketValue { get; set; }
            public object error { get; set; }
        }

        public class SetData {
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

        public class Variants {
            public Variant normal { get; set; }
            public Variant reverseHolofoil { get; set; }
            public Variant holofoil { get; set; }
            public Variant playPokemonStampHolofoil { get; set; }
            public Variant holofoilAlternate { get; set; }
        }
    }
}
