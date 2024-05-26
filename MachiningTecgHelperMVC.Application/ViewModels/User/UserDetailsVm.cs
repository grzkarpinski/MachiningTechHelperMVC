using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.User
{
    public class UserDetailsVm
    {
        public IdentityUser User { get; set; }
        public IList<string> Roles { get; set; }
        public IList<string> AllRoles { get; set; }
        public string SelectedRole { get; set; }
    }
}
