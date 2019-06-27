
using TestCommon;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ServicePlugin
{
    public class Plugin : IPlugin
    {   
        private static ConcurrentDictionary<int,Client> _list = new ConcurrentDictionary<int,Client>();


        public Plugin()
        {
            Seed();
        }
        public Client GetClient(int id)
        {
            Client client;
            _list.TryGetValue(id, out client);
            return client;
        }


        public void UpdateClient(Client client)
        {
            _list[client.Id]= client;
        }

        private void Seed()
        {
            _list.TryAdd(1, new Client { Age = 31, Id = 1, INN = 123456789,
                Name = "Client_Test", Prof = "C# developer", Stage = 0 });
        }
    }
}
