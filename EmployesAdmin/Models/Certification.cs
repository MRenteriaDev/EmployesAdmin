using System.ComponentModel.DataAnnotations;

namespace EmployesAdmin.Models
{
    public class Certification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Institution { get; set; } = string.Empty;
        [Required]
        public DateTime DateGet { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; }
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
