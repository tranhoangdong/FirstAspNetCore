using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Emtyties
{
    public  class Roles : IdentityRole
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
