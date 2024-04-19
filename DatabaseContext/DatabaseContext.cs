using DataFlow.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext;

public sealed class Database : DbContext
{
    private const string SqlServer = "Host=localhost; Port=5432; Database=SHACT; Username=postgres; Password=root";
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Chakaton> Chakatons { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;

    public Database(DbContextOptions<Database> options) : base(options)
    {
        Console.WriteLine("Database initialized");
        Database.EnsureCreated();        
    }
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Database>
    {
        public Database CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Database>();
            optionsBuilder.UseNpgsql(SqlServer);
        
            return new Database(optionsBuilder.Options);
        }
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(SqlServer);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasKey(d => d.Id);
        modelBuilder.Entity<User>().Property(d => d.Name).IsRequired();

        modelBuilder.Entity<User>().Property(d => d.Email).IsRequired();
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<User>().Property(d => d.Password).IsRequired();
        modelBuilder.Entity<User>().Property(d => d.Organization).IsRequired();
        modelBuilder.Entity<User>().Property(d => d.Post);
        modelBuilder.Entity<User>().Property(d => d.City);
        modelBuilder.Entity<User>().Property(d => d.HardSkills);
        modelBuilder.Entity<User>().Property(d => d.Links);
        
        modelBuilder.Entity<Chakaton>().HasKey(d => d.Id);
        modelBuilder.Entity<Chakaton>().Property(d => d.Name).IsRequired();
        modelBuilder.Entity<Chakaton>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<Chakaton>().Property(d => d.Dates).IsRequired();
        modelBuilder.Entity<Chakaton>().Property(d => d.Type);
        modelBuilder.Entity<Chakaton>().Property(d => d.Direction);
        modelBuilder.Entity<Chakaton>().Property(d => d.Links).IsRequired();
        modelBuilder.Entity<Chakaton>().Property(d => d.Info);
        
        modelBuilder.Entity<Team>().HasKey(d => d.Id);
        modelBuilder.Entity<Team>().Property(d => d.Name).IsRequired();
        modelBuilder.Entity<Team>().Property(d => d.Image);
        modelBuilder.Entity<Team>().Property(d => d.Direction);
        modelBuilder.Entity<Team>().Property(d => d.Requirements);
        modelBuilder.Entity<Team>().Property(d => d.LeaderId).IsRequired();
        
        modelBuilder.Entity<Request>().HasKey(d => d.Id);
        modelBuilder.Entity<Request>().Property(d => d.UserId).IsRequired();
        modelBuilder.Entity<Request>().Property(d => d.TeamId).IsRequired();
        modelBuilder.Entity<Request>().Property(d => d.RequestText);


        modelBuilder.Entity<User>().HasMany<Team>().WithOne(d => d.Leader).IsRequired().HasForeignKey(t => t.LeaderId);
        
        modelBuilder.Entity<Team>().HasMany(d => d.Members).WithMany(t => t.Teams);
        modelBuilder.Entity<Team>().HasMany(d => d.Chakatons).WithMany(t => t.Teams);
        modelBuilder.Entity<Request>().HasMany(d => d.Teams).WithMany(t => t.Requests);
        
        modelBuilder.Entity<User>().HasMany<Request>().WithOne(d => d.Candidate).HasForeignKey(t => t.UserId);
        modelBuilder.Entity<Team>().HasMany<Request>().WithOne(d => d.Team).HasForeignKey(t => t.TeamId);
        
    }
}