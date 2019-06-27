using Microsoft.EntityFrameworkCore;
using TestCommon;

namespace ServicePluginSQL.DAL
{
    class DbClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("postgres://fcaankjgndjmfi:e8de19e6ede7869cb35d805085df3df53ab93dfed13e5d9154543b5fd34d0909@ec2-174-129-18-42.compute-1.amazonaws.com:5432/d9b26ragtophov",
                builder =>
                {
                    builder.MigrationsAssembly(typeof(DbClientContext).Assembly.FullName);
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client
            {
                Age = 31,
                Id = 1,
                INN = 123456789,
                Name = "Client_Test",
                Prof = "C# developer",
                Stage = 2
            });

            modelBuilder.Entity<Client>(typeBuilder =>
            {
                typeBuilder.ToTable("Client", "test");
                typeBuilder.HasKey(z => z.Id);
            });
        }
    }
}
