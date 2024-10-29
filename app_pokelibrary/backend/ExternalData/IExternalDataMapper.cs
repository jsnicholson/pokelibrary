namespace ExternalData {
    public interface IExternalDataMapper<TSeries, TSet, TCard> {
        Data.Models.Series ToSeries(TSeries series);
        Data.Models.Set ToSet(TSet set);
        Data.Models.Card ToCard(TCard card);
    }
}