using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTracker.Models
{
    public class ClientDisorder
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public Disorder Disorder { get; set; }
        [Required]
        public Client Client { get; set; }
    }
}
