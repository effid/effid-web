using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eff_Id.Models;
using Refit;
using Eff_Id.API;
using EffId.Models;

namespace Eff_Id.Controllers
{

    public class HomeController : Controller
    {

        public async Task<IActionResult> Index(
            UserViewModel input)
        {
            var effApi = RestService.For<IEffApi>("http://82.64.156.248:10000");

            if(input.Email != null && input.Password != null)
            {
                var test = await effApi.GetUser(input.Email, input.Password);
                return View("Schedules");

            }

            return View();
        }

        public async Task<IActionResult> AccountCreationAsync(
            UserViewModel input)
        {
            var effApi = RestService.For<IEffApi>("http://82.64.156.248:10000");

            if (input.Prenom != null && input.Nom != null && input.Email != null && input.Password != null)
            {

                UserViewModel user = new UserViewModel()
                {
                    Email = input.Email,
                    Nom = input.Nom,
                    Password = input.Password,
                    Prenom = input.Prenom,
                    id_classe = null,
                    id_puce = 0, 
                    id_type = 1,
                };

                var test = await effApi.CreateUser(user);
                return View("Index");
            }

            return View();
        }

        public IActionResult Schedules()
        {
            return View();
        }

        public async Task<IActionResult> Room()
        {
            var effApi = RestService.For<IEffApi>("http://82.64.156.248:10000");
            var test = await effApi.GetClassRoomList();

            RoomViewModel classe = new RoomViewModel()
            {
                Rooms = test,
            };


            return View(classe);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
