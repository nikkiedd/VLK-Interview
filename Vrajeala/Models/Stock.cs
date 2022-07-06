namespace VLK_Interview.Models
{
    public class Stock
    {
        private readonly Guid id;
        private string name;
        private float price;

        public Stock(string name, float price) {
            this.id = Guid.NewGuid();
            this.name = name;
            this.price = price;
        }

        public float Price { get { return this.price; } }
        public Guid Id { get { return this.id; } }  

        public string Name { get { return this.name; } }
    }
}
