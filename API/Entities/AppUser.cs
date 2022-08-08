using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        //Adds the data to sqlite database using Entity Framework
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public byte[] PasswardHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}