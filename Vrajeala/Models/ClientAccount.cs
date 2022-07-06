namespace VLK_Interview.Models
{
    public class ClientAccount
    {
        private Guid id;
        private string name;
        private float balance;

        public ClientAccount(string name, float balance)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.balance = balance;
        }

        public string Name { get { return name; } }
        public Guid Id { get { return id; } }
        public float Balance { get { return balance; } set { balance = value; } }
    }
}
