using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class RoleFormViewModel
    {
        [Required (ErrorMessage ="Name is required !")]
        [MaxLength(255)]
        public string Name {  get; set; }
    }
}
