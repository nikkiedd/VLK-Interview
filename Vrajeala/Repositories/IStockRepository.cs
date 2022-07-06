namespace VLK_Interview.Repositories
{
    public interface IStockRepository
    {
        public float? GetPrice(Guid id);

        public Guid? GetId(string name);
    }
}
