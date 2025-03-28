using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhappFinance.Core.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IClientDataRepository ClientData { get; }
        IPhoneNumberRepository PhoneNumber { get; }

        void Save();

    }
}
