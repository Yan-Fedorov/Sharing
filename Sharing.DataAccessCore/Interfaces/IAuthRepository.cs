using Sharing.DataAccessCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharing.DataAccessCore.Interfaces
{
    public interface IAuthRepository
    {
        Task<Lessor> RegisterAsLessor(Lessor user, string password);
        Task<Customer> RegisterAsRenter(Customer user, string password);
        Task<Lessor> LoginAsLessor(string userName, string password);
        Task<Customer> LoginAsRenter(string userName, string password);
        Task<bool> LessorExists(string userName);
        Task<bool> RenterExists(string userName);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
