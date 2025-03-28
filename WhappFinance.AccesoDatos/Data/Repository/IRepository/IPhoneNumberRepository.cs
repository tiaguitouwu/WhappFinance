using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhappFinance.Models;

namespace WhappFinance.Core.Data.Repository.IRepository
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumber> 
    {
        void Update(PhoneNumber phone);
    }
}
