using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        // save hash and salt of password
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        
        // a user can manage a number of characters
        public List<Character>? Characters { get; set; }
    }
}