
using TestCommon;
using System.Linq;
using System.Collections.Generic;

namespace ServicePlugin
{
    public class Plugin : IPlugin
    {   
        private static List<Client> _list = new List<Client>();
        public Plugin()
        {
            Seed();
        }
        public Client GetClient(int id)
        {
            return (Client)_list.FirstOrDefault(x => x.Id == id);
        }

        
        public void UpdateClient(Client client)
        {
            _list[_list.FindIndex(x => x.Id == client.Id)] = client;
        }

        private void Seed()
        {
            _list.Add( new Client { Age = 31, Id = 1, INN = 123456789,
                Name = "Client_Test", Prof = "C# developer", Stage = 0 });
        }
    }
}
