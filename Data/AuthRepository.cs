using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace rpc.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AuthRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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
                // response.Data = user.Id.ToString();
                response.Data = CreateToken(user);
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
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    
        // method to verify the password
        private static bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            // apply using statement to dispose of the object after it is used
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                // set the hash to the computed hash of the password
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);

            }
        } 

        private string CreateToken(User user)
        {

            // create the list of claims
            /* 
                claims in JWT Tokens are used to store information about the user
                e.g. the user id, username, etc. in the token payload, as well as
                the expiration date of the token and iAt (issued at) date
            */
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)

            };

            // create the key, obtaining the Secret Key from the AppSettings
            var appSettingsToken = _config.GetSection("AppSettings:Token").Value;
            if (appSettingsToken is null)
            {
                throw new ArgumentNullException("AppSettings Token is null");

            }
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsToken));

            // create the signing credentials
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // create the token descriptor that contains the claims, expiration date, and signing credentials
            // (a placeholder for all the attributes related to the final issued token)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), // token expires in 1 day
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            // serialize the token into a JSONWebToken string
            return tokenHandler.WriteToken(token);
    
    }
}
}  // end of namespace