using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";
        public int RoleId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
