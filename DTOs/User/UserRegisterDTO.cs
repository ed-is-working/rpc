using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpc.DTOs.User
{
    public class UserRegisterDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}