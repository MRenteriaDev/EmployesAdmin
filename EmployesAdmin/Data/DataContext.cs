using EmployesAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployesAdmin.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<PositionEmployee> PositionEmployees { get; set; }
        public DbSet<Employe> Employes { get; set; }
    }
}
