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
using Microsoft.AspNetCore.Http;
using EffId.API;

namespace Eff_Id.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
            UserViewModel input)
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login(
            UserViewModel input)
        {
            var effApi = RestService.For<IUserApi>("http://82.64.156.248:10000");
            var apiResponse = effApi.GetUser(input.Email, input.Password);

            var responseStatus = apiResponse.IsCompletedSuccessfully;

            if (responseStatus)
            {
                if (input.Email != null && input.Password != null)
                {
                    HttpContext.Session.SetString("username", input.Email);
                    return View("Schedules");
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
                }
            }
            ViewBag.error = "Invalid Account";
            return View("Index");

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

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
