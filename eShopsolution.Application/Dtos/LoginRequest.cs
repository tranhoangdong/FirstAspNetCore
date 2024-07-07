using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public  class LoginRequest
    {
        public string UserName  { get; set; }
        public string PasswordHash { get; set; }
        public bool Rememberme { get; set; }
    }
}
