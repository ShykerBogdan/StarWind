
using System.Threading.Tasks;
using TestCommon;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServicePluginSQL.DAL
{
    class ClientRepo : ICLientRepo
    {
        private readonly DbClientContext _context;

        public ClientRepo()
        {
            _context = new DbClientContext();
        }
        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients
               .FirstOrDefaultAsync(x => x.Id == id);               
        }

        public async Task UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
