using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogWebApplication.BusinessManagers.Interfaces;
using BlogWebApplication.Models.AdminViewModels;

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

        public async Task<IActionResult> About()
        {
            return View(await _adminBusinessManager.GetAboutViewModel(User));
        }

        public async Task<IActionResult> UpdateAbout(AboutViewModel aboutViewModel)
        {
            await _adminBusinessManager.UpdateAbout(aboutViewModel, User);
            return RedirectToAction("About");
        }
    }
}
