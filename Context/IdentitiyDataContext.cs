using Eticaret01.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret01.Context
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext():base("Server=MSI\\SQL; Database=Eticaret; Integrated Security=true")
        {

        }
    }
}