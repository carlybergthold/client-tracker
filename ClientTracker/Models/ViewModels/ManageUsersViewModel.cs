using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTracker.Models.ViewModels
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Therapists { get; set; }

        public ApplicationUser[] IntakeSpecialists { get; set; }
    }
}