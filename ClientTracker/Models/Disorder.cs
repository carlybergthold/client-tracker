using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientTracker.Models
{
    public class Disorder
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        public ICollection<ClientDisorder> ClientDisorders { get; set; }

    }
}