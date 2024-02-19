using System.ComponentModel.DataAnnotations;

namespace EmployesAdmin.Models
{
    public class PositionEmployee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; } = string.Empty;
        [Required]
        public string StudyGrade { get; set; } = string.Empty;
        [Required]
        public DateTime AdmissionDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; }
        public int EmployeeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
