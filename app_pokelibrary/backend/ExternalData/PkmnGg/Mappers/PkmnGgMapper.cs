using ExternalData.PkmnGg.Models;

namespace ExternalData.PkmnGg.Mappers {
    public class PkmnGgMapper : IExternalDataMapper<Series, Set, Card> {
        public Data.Models.Card ToCard(Card card) {
            Data.Models.Card.Variant[] variants = new Data.Models.Card.Variant[card.variantMap.Length];
            for (int i = 0; i < card.variantMap.Length; i++) {
                
            }

            return new Data.Models.Card() {
                id = card.id,
                name = card.name,
                number = card.number,
                rarity = card.rarity,
                artist = card.artist,
                variants = variants
            };
        }

        public Data.Models.Series ToSeries(Series series) {
            throw new NotImplementedException();
        }

        public Data.Models.Set ToSet(Set set) {
            throw new NotImplementedException();
        }
    }
}
