using Microsoft.EntityFrameworkCore;
using MessagingService.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace MessagingService.Data
{
    public class MessagingDbContext : DbContext
    {
        public MessagingDbContext()
        {

        }

        public MessagingDbContext(DbContextOptions<MessagingDbContext> options) : base(options)
        {

        }

        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
