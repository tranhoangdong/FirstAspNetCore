using eShopSolution.Application.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public  interface IUserServices
    {
        Task<string> Authecate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
