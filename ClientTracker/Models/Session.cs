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
        [MyDate(ErrorMessage ="This date is in the past.")]
        public DateTime SessionDate { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }

    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now; //Dates Greater than or equal to today are valid (true)

        }
    }
}