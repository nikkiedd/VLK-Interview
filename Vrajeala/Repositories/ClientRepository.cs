using VLK_Interview.Models;

namespace VLK_Interview.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private List<ClientAccount> clients;

        public ClientRepository() {
            this.clients = new List<ClientAccount>();
            ClientAccount client = new ClientAccount( "Diana Dolot", 600400);
            this.clients.Add(client);
        }


        public bool ChangeBalance(Guid clientId, float newBalance)
        {
            ClientAccount? client = clients.Find(acc => acc.Id == clientId);
            if (client == null)
            {
                return false;
            }
            else
            {
                client.Balance = newBalance;
                return true;
            }
        }

        public ClientAccount? GetClient(Guid clientId) {
        ClientAccount? foundClient = clients.Find(acc => acc.Id == clientId);
        if (foundClient == null)
        {
            return null;
        }
        else return foundClient;
        }

        public ClientAccount GetOnlyClient() {
            return clients[0];
        }
    }

    
}
