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
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            // get the user from the database
            var user = await  _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            // check if the user exists
            if(user is null)
            {
                response.Success = false;
                response.Message = "User not found.";
            } else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password.";
            } else
            {
                response.Data = user.Id.ToString();
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            // check if the user exists
            if(await UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            // create the password hash and salt
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            // set the password hash and salt
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
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
    
        // method to verify the password
        private bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            // apply using statement to dispose of the object after it is used
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                // set the hash to the computed hash of the password
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);

            }
        } 
    
    
    }
}