using Microsoft.EntityFrameworkCore;

namespace consultorio.Models
{
    public class ConsultorioDbContext : DbContext
    {
        public ConsultorioDbContext() { }
        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : base(options)
        {
        }
        public DbSet<Sure> Sures { get; set; }
        public DbSet<Insured> Insureds { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<SureInsured> SureInsureds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SureInsured>()
                .HasKey(ec => new { ec.Idsure, ec.Idinsured });

            modelBuilder.Entity<SureInsured>()
                .HasOne(ec => ec.Sure)
                .WithMany(e => e.SureInsureds)
                .HasForeignKey(ec => ec.Idsure);

            modelBuilder.Entity<SureInsured>()
                .HasOne(ec => ec.Insured)
                .WithMany(c => c.SureInsureds)
                .HasForeignKey(ec => ec.Idinsured);
        }


    }
}
