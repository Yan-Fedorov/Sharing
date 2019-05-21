using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sharing.DataAccessCore.Realization
{
    public class AuthRepository : IAuthRepository
    {
        public SharingContext _dataContext { get; }
        public AuthRepository(SharingContext dataContext)
        {
            _dataContext = dataContext;
        }       

        public async Task<Lessor> LoginAsLessor(string userName, string password)
        {
            if(userName == null || password == null)
            {
                throw new ArgumentNullException("userName or password", "userName or password in login is null");
            }
            var user = await _dataContext.Lessors.FirstOrDefaultAsync(x => x.UserName == userName);
            

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null while login");
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public async Task<Customer> LoginAsRenter(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException("userName or password", "userName or password in login is null");
            }
            
            var user = await _dataContext.Renters.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null while login");
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i< computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<Customer> RegisterAsRenter(Customer user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.Renters.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<Lessor> RegisterAsLessor(Lessor user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.Lessors.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> LessorExists(string userName)
        {
            if(await _dataContext.Lessors.AnyAsync(X => X.UserName == userName))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> RenterExists(string userName)
        {
            if (await _dataContext.Renters.AnyAsync(X => X.UserName == userName))
            {
                return true;
            }

            return false;
        }
    }
}
