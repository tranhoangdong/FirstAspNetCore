using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Emtyties
{
    class AppUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserID { get; set; }
    }
}
