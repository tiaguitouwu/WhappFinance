using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhappFinance.Core.Data.Repository.IRepository;
using WhappFinance.Models;

namespace WhappFinance.Core.Data.Repository
{
    public class ClientDataRepository : Repository<ClientData>, IClientDataRepository
    {
        private readonly AppDbContext _context;

        public ClientDataRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ClientData client)
        {
            var clientDB = _context.ClientData.FirstOrDefault(m => m.Id == client.Id);

            if (clientDB != null)
            {
                clientDB.IdPhoneNumber = client.IdPhoneNumber > 0 ? client.IdPhoneNumber : clientDB.IdPhoneNumber;
                clientDB.Id_WA = client.Id_WA;
                clientDB.Message = client.Message;
            }


        }
    }
}
