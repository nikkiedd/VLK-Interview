namespace VLK_Interview.Models
{
    public class Transaction
    {
        private readonly Guid clientId;
        private readonly Guid stockId;
        private int numberOfStocks;

        public Transaction(Guid clientId, Guid stockId, int numberOfStocks)
        {
            this.clientId = clientId;
            this.stockId = stockId;
            this.numberOfStocks = numberOfStocks;
        }

        public Guid StockId { get { return this.stockId; } }
        public Guid ClientId { get { return this.clientId; } }
        public int NumberOfStocks { get { return this.numberOfStocks; } }
    }
}
