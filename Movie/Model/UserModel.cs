using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Model
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
    }
}
