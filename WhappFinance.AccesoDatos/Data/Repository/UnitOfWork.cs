using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhappFinance.Core.Data.Repository.IRepository;
using WhappFinance.Models;

namespace WhappFinance.Core.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ClientData = new ClientDataRepository(_context);
            PhoneNumber = new PhoneNumberRepository(_context);
        }

        public IClientDataRepository ClientData { get; private set; }
        public IPhoneNumberRepository PhoneNumber { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
