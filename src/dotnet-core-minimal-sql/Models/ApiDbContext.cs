using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<EmployeeGroupAssoc> EmployeeGroupAssocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact", schema: "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ContactId");
            });
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
            //EmployeeGroupAssoc
            modelBuilder.Entity<EmployeeGroupAssoc>(entity => {
                entity.ToTable("EmployeeGroupAssoc", schema: "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("EmployeeGroupAssocId");
                entity.Property(e => e.CreatedBy).IsUnicode(false);
                entity.Property(e => e.LastModifiedBy).IsUnicode(false);
                entity.HasOne(e => e.Employee).WithMany(e => e.EmployeeGroupAssocs).HasForeignKey(e => e.EmployeeId);
                entity.HasOne(e => e.Group).WithMany(e => e.EmployeeGroupAssocs).HasForeignKey(e => e.GroupId);
            });
            //Group
            modelBuilder.Entity<Group>(entity => {
                entity.ToTable("Group", schema: "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("GroupId");
                entity.Property(e => e.CreatedBy).IsUnicode(false);
                entity.Property(e => e.LastModifiedBy).IsUnicode(false);
            });
        }
    }
}