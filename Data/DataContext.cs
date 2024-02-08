using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using SWAPP.Entities;

namespace SWAPP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
{ }
        
        public DbSet<Sale> S_SALMA { get; set; }
        public DbSet<Customer> Vendor { get; set; }

        public DbSet<Return> C_BAL { get; set; }

        public DbSet<Appointment> tb_appoinments { get; set; }

        public DbSet<Item> s_mas { get; set; }

              

         
    }

   
}