
using SharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Machinewebapi.DTO;

namespace Machinewebapi.EfCore
{
    public class LaverieAppDbContext : DbContext
    {
        public DbSet<Laverie> Laveries { get; set; }
        public DbSet<Machine> Machines { get; set; }
     

        public LaverieAppDbContext(DbContextOptions<LaverieAppDbContext> options) : base(options)
        {
            
        }
    }
}
