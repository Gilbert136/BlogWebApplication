using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogWebApplication.BusinessManagers.Interfaces;

namespace BlogWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBusinessManager _adminBusinessManager;

        public AdminController(IAdminBusinessManager adminBusinessManager){
            _adminBusinessManager = adminBusinessManager;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _adminBusinessManager.GetAdminDashboard(User));
        }
    }
}
