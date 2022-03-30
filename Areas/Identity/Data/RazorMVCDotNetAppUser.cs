using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RazorMVCDotNetApp.Areas.Identity.Data
{
  
// Add profile data for application users by adding properties to the RazorMVCDotNetAppUser class
    public class RazorMVCDotNetAppUser : IdentityUser
    {
        private string FirstName { set; get; }
        private string LastName { set; get; }
        private string Gender { set; get; }
    }  
}


