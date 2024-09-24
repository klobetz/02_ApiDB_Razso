using System.ComponentModel.DataAnnotations;

namespace ConsolaApp_To_API.ViewModel

{
    public class UserVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LName { get; set; }= string.Empty;
        
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W]{1,})$")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")]
        public string Password { get; set; } = string.Empty;

        public string FullName => $"{FName} {LName}";

    }
}
