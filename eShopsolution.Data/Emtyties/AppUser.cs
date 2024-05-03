using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Emtyties
{
    public class AppUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
