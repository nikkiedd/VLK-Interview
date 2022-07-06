using VLK_Interview.Models;

namespace VLK_Interview.Repositories
{
    public interface IClientRepository
    {
        public bool ChangeBalance(Guid clientId, float newBalance);

        public ClientAccount? GetClient(Guid clientId);

        public ClientAccount GetOnlyClient();
    }
}
