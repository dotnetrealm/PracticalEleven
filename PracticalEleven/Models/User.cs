using System.ComponentModel.DataAnnotations;

namespace PracticalEleven.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [MaxLength(50, ErrorMessage = "The max lenght of 50 characters is reached!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Birthdate field is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Range(typeof(DateOnly), "1800-01-01", "2022-12-31", ErrorMessage = "Please select valid Birthdate (1800/01/01 - 2022/12/31)")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Address field is required")]
        [MaxLength(100, ErrorMessage = "The max lenght of 100 characters is reached!")]
        public string Address { get; set; } = null!;
    }
}
