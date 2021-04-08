using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class UpdateUserPermissions
    {
        public IdentityUser User { get; set; }
        public IEnumerable<IdentityRole> Permissions { get; set; }
        public IEnumerable<IdentityRole> NonPermissions { get; set; }
    }
}
