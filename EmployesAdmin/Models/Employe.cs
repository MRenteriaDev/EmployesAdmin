using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployesAdmin.Models
{
    public class Employe
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es Requerido")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string FirstLastName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string SecondLastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string BloodType { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        public string NoEmployee { get; set; } = string.Empty;
        [Required]
        public string IdentificationNumber { get; set; } = string.Empty;
        [Required]
        public string RFC { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string ImagePublicId { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<PositionEmployee> Positions { get; set; } = new List<PositionEmployee>();
        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();
        public ICollection<EmployeesDocument> Documents { get; set; } = new List<EmployeesDocument>();
    }
}
