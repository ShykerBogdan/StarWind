using System.Threading.Tasks;
using TestCommon;

namespace ServicePluginSQL.DAL
{
    interface ICLientRepo
    {
        Task<Client> GetClient(int id);

        Task UpdateClient(Client client);
    }
}
