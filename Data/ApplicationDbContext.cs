using GitHubPagesDemo.Attributie;
using Microsoft.EntityFrameworkCore;

namespace GitHubPagesDemo.Data
{
    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee1> Employee1 { get; set; } = default!;
    }

    public class Employee1
    {
        [Report] public int Id { get; set; }
        [Report, ExcelColumn] public string? Name { get; set; }
        [Report, ExcelColumn] public string? Designation { get; set; }
        [Report, ExcelColumn] public DateOnly? DOJ { get; set; }
        [Report, ExcelColumn] public TimeOnly? TOJ { get; set; }
        [Suspend, Report, ExcelColumn] public bool IsActive { get; set; }
    }
    public class Category
    {
        [ExcelColumn] public string? Title { get; set; } = default!;
        public string? Subtitle { get; set; } = default!;
        public string? Description { get; set; } = default!;
    }
}