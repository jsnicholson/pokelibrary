namespace Data.Models
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string rarity { get; set; }
        public string artist { get; set; }
        public Variant[] variants { get; set; }
        public string primaryVariant { get; set; }

        public class Variant
        {
            public string name { get; set; }
            public string description { get; set; }
            public bool inMainSet { get; set; }
        }
    }
}
