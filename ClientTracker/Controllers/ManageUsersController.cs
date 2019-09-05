using ClientTracker.Models;
using ClientTracker.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTracker.Controllers
{
    [Authorize(Roles = "Therapist")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser>
            _userManager;

        public ManageUsersController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var therapists = (await _userManager
                .GetUsersInRoleAsync("Therapist"))
                .ToArray();

            var intakeSpecialists = (await _userManager
                .GetUsersInRoleAsync("Intake Specialist"))
                .ToArray();


            var model = new ManageUsersViewModel
            {
                Therapists = therapists,
                IntakeSpecialists = intakeSpecialists
            };

            return View(model);
        }
    }
}
