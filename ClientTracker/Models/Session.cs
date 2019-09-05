using System;
using System.ComponentModel.DataAnnotations;

namespace ClientTracker.Models
{
    public class Session
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime SessionDate { get; set; }
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}