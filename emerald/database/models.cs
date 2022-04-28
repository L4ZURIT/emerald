using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace data
{

    public class ApplicationContext : DbContext
    {
        public DbSet<sources> sources => Set<sources>();
        public DbSet<phones> phones => Set<phones>();
        public DbSet<emails> emails => Set<emails>();
        public DbSet<webs> webs => Set<webs>();
        public DbSet<employee> employee => Set<employee>();
        public DbSet<customer> customer => Set<customer>();
        public DbSet<users> users => Set<users>();
        public DbSet<admission> preferences => Set<admission>();
        public DbSet<appeals> appeals => Set<appeals>();
        public DbSet<appeal_statuses> appeal_statuses => Set<appeal_statuses>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=erp_system;Username=postgres;Password=5924");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<users>().HasKey(users => new { users.person_id });

            //builder.Entity<appeals>().HasKey(appeals => new { appeals.id, appeals.customer_id });
        }
    }

    public class sources
    {
        public int id { get; set; }
        public string source_name { get; set; }
    }

    public class phones
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string phone { get; set; }
        public string note { get; set; }     
    }

    public class emails
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string email { get; set; }
        public string note { get; set; }

    }


    public class webs
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public string web { get; set; }
        public string note { get; set; }

    }


    public class employee
    {
        public int id { get; set; }
        public string fio { get; set; }
    }

    public class customer
    {
        public int id { get; set; }
        public string fio { get; set; }
        public DateTime appear_date { get; set; }
        public string desc { get; set; }
        public int employee_id { get; set; }
        public int? checked_manager_id { get; set; }
        public int source_id { get; set; }

    }



    public class users
    {
        public int person_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int admission_id { get; set; }

    }

    public class admission
    {
        public int id { get; set; }
    }

    public class appeals
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int employee_id { get; set; }
        public int status { get; set; }
        public string content { get; set; }
        public string price { get; set; }
        public DateOnly date { get; set; }
    }

    public class appeal_statuses
    {
        public int id { get; set; }
        public string status { get; set; }  
    }

}
