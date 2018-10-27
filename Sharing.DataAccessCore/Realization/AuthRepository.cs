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

        public async Task<User> Login(string userName, string password)
        {
            if(userName == null || password == null)
            {
                throw new ArgumentNullException("userName or password", "userName or password in login is null");
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if(user == null)
            {
                throw new ArgumentNullException(nameof(user), "user is null while login");
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
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

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.Users.AddAsync(user);
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

        public async Task<bool> UserExists(string userName)
        {
            if(await _dataContext.Users.AnyAsync(X => X.UserName == userName))
            {
                return true;
            }

            return false;
        }
    }
}
