using Microsoft.EntityFrameworkCore;
using PersonalFinance.Models;

namespace PersonalFinance.Helpers
{
    public class PersonalFinanceContext : DbContext
    {
    //protected readonly IConfiguration Configuration;
    //public PersonalFinanceContext(IConfiguration configuration)
    //{
    //    Configuration = configuration;
    //}

    public PersonalFinanceContext(DbContextOptions<PersonalFinanceContext> options)
            : base(options)
        { }

               public DbSet<Categories> Category_Details { get; set; } = null!;
               public DbSet<Items> Item_Details { get; set; } = null!;

               public DbSet<Expenses> Expense_Details { get; set; } = null!;

               public DbSet<Revenues> Revenue_Details { get; set; } = null!;

    }
}
