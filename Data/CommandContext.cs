using DockerApi.Models;
using Microsoft.EntityFrameworkCore;
namespace DockerApi.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) :base(options)
        {

        }

        public DbSet<Commands> Commands { get; set; }
    }
}