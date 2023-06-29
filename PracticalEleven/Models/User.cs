using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace PracticalEleven.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Birthdate field is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateOnly), "1800-01-01", "2010-12-31", ErrorMessage = "Please select valid Birthdate")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Address field is required")]
        public string Address { get; set; } = null!;
    }
}
