using VLK_Interview.Models;

namespace VLK_Interview.Repositories
{
    public class StockRepository : IStockRepository
    {
        private List<Stock> stocks;

        public StockRepository() {

            this.stocks = new List<Stock>();
            Stock appleStock = new Stock("Apple", 330);
            this.stocks.Add(appleStock);
        }

        public Guid? GetId(string name)
        {
            Stock? stock = this.stocks.Find(stock => stock.Name == name);
            if (stock is null)
                return null;
            else
                return stock.Id;
        }

        public float? GetPrice(Guid id) {
            Stock? stock = stocks.Find(stock => stock.Id == id);
            if (stock is null)
                return null;
            else
                return stock.Price; 
        }

    }
}
