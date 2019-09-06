using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientTracker.Models
{
    public class Client
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string TherapistId { get; set; }
        public ApplicationUser Therapist { get; set; }
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<ClientDisorder> ClientDisorders { get; set; }

    }
}