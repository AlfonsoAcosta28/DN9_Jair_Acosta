﻿using GymManager.ApplicationServices.Members;
using Microsoft.AspNetCore.Mvc;

namespace GymMananger.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
