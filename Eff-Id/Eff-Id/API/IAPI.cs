using Eff_Id.Models;
using EffId.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eff_Id.API
{
    internal interface IEffApi
    {
        [Get("/salles")]
        Task<List<RoomViewModel>> GetClassRoomList();

        
        [Post("/inscription")]
        Task<UserViewModel> CreateUser(UserViewModel user);
    }
}