using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", schema: "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("EmployeeId");
                entity.Property(e => e.JobTitle).IsUnicode(false);
                entity.Property(e => e.BusinessPhone).IsUnicode(false);
                entity.Property(e => e.MobilePhone).IsUnicode(false);
                entity.Property(e => e.EmailAddress).IsUnicode(false);
                entity.Property(e => e.CreatedBy).IsUnicode(false);
                entity.Property(e => e.LastModifiedBy).IsUnicode(false);
            });
        }
    }
}