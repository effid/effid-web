using Eff_Id.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffId.API
{
    public interface IUserApi
    {
        [Get("/connexion/{email}/{password}")]
        Task<ApiResponse<UserViewModel>> GetUser(string email, string password);
    }
}
