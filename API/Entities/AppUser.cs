using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        //Used for Entity Framework Id and UserName is format in Entity Framework
        public int Id { get; set; }
        public string UserName { get; set; }
        
    }
}