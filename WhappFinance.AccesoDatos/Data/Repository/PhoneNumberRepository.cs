using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhappFinance.Core.Data.Repository.IRepository;
using WhappFinance.Models;

namespace WhappFinance.Core.Data.Repository
{
    public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        private readonly AppDbContext _context;

        public PhoneNumberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(PhoneNumber phone)
        {
            var phoneDB = _context.PhoneNumber.FirstOrDefault(m => m.Id == phone.Id);

            if (phoneDB != null)
            {
                phoneDB.Number = phone.Number;
                phoneDB.ContactName = phone.ContactName;
            }


        }
    }
}
