using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Console;
using SWAPP.Entities;

namespace SWAPP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
{ this.ChangeTracker.LazyLoadingEnabled = false;  }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            //Enabling Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Default(WarningBehavior.Ignore)
                .Log( CoreEventId.NavigationBaseIncludeIgnored)
                );
            
        }
        public DbSet<Sale> S_SALMA { get; set; }
        public DbSet<Customer> Vendor { get; set; }

        public DbSet<Return> C_BAL { get; set; }

        public DbSet<Appointment> tb_appoinments { get; set; }




        public DbSet<Item> s_mas { get; set; }

              
 public DbSet<Commision> s_comm { get; set; }
          public DbSet<SpDiscount> sp_discount_trn  { get; set; }
         
        public virtual DbSet<DepositMaster> dep_cheq_mas  { get; set; }
        public virtual DbSet<DepositTran> dep_cheq_trn  { get; set; }

        public virtual DbSet<Settlment> s_crec  { get; set; }
        public virtual DbSet<SettlmentTran> s_sttr  { get; set; }

        public DbSet<Company> company  { get; set; }


         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepositMaster>()
            .HasMany(o => o.DepositTrans)
            .WithOne(oi => oi.DepositMaster)
            .HasForeignKey(oi => oi.depositid);
     
        modelBuilder.Entity<Settlment>()
            .HasMany(o => o.SettlmentTrans)
            .WithOne(oi => oi.Settlment)
            .HasForeignKey(oi => oi.settlmentid);
            
    }
      
    
        
    }



     public class GlDataContext : DbContext
    {
        public GlDataContext()
        {
        }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.1.57;Database=CENTRAL;User Id=sa;Password=123;TrustServerCertificate=true;")
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored, CoreEventId.NavigationBaseIncluded));
        }
 
         public DbSet<Ledger> ledger  { get; set; }

    }


   
}