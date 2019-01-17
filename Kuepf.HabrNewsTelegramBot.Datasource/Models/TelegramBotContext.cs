using Microsoft.EntityFrameworkCore;

namespace Kuepf.HabrNewsTelegramBot.Datasource.Models
{
    public class TelegramBotContext : DbContext
    {
        public TelegramBotContext(DbContextOptions<TelegramBotContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Objects> Objects { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Parameters> Parameters { get; set; }


    }
}
