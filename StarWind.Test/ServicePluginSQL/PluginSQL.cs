using TestCommon;
using System.Linq;
using System.Collections.Concurrent;
using ServicePluginSQL.DAL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ServicePluginSQL
{
    public class PluginSQL : IPlugin
    {
        private readonly ClientRepo _clientRepo;
        public PluginSQL()
        {
            _clientRepo = new ClientRepo();
        }
        //must be async, but for the purpuse of the test-it is not
        public Client GetClient(int id)
        {
            return  _clientRepo.GetClient(id).GetAwaiter().GetResult();
        }

        //must be async, but for the purpuse of the test-it is not
        public void UpdateClient(Client client)
        {
             _clientRepo.UpdateClient(client);
        }

    }
}

