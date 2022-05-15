using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Context
{
    public class TMContext: DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TheTask> TheTasks { get; set; }
        public DbSet<Assigment> Assigment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=taskmanager;user=root;password=malvina");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Employee>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.TeamId).IsRequired();
                entity.HasOne<Team>(e => e.Team)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.TeamId);
            });


            modelBuilder.Entity<State>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
            });


            modelBuilder.Entity<Team>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired();
            });
            

            modelBuilder.Entity<TheTask>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Priority).IsRequired();
                entity.Property(e => e.StateId).IsRequired();
                entity.HasOne<State>(e => e.State)
                .WithMany(e => e.TheTasks)
                .HasForeignKey(e => e.StateId);
            });


            modelBuilder.Entity<Assigment>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.TheTaskId).IsRequired();
                entity.Property(e => e.EmployeeId).IsRequired();
                entity.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.Assignments)
                .HasForeignKey(e => e.EmployeeId);
                entity.HasOne<TheTask>(e => e.TheTask)
                .WithMany(e => e.Assignments)
                .HasForeignKey(e => e.TheTaskId);
            });
        }
    }
}
