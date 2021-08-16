using Microsoft.EntityFrameworkCore;

namespace SimpleCRUD
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("Student","dbo");
            });
        }
        public virtual DbSet<Student> Students { get; set; }
    }
}
