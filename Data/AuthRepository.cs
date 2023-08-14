using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpc.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            // create the password hash and salt
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            // set the password hash and salt
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<int>
            {
                Data = user.Id
            };
            return response;
        
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }

        // method to hash the password
        private static void CreatePasswordHash(
            string password, 
            out byte[] passwordHash, 
            out byte[] passwordSalt)
        {
            // apply using statement to dispose of the object after it is used
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // set the salt to the randomly generated key
                passwordSalt = hmac.Key;
                // set the hash to the computed hash of the password
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}