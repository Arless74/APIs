using System.ComponentModel.DataAnnotations;

namespace APIsRest.Models
{
    public class UserInsert
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
