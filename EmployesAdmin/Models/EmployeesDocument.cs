using System.ComponentModel.DataAnnotations;

namespace EmployesAdmin.Models
{
    public class EmployeesDocument
    {
        [Key]
        public int Id { get; set; }
        public string BlobName { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public Employe? Employee { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; }
    }
}
