using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpc.DTOs.User
{
    // split the UserDTO into two DTOs for login and register
    // this is because we may add more information to registration later on.
    public class UserLoginDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}