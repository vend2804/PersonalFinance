using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; } = null!;
         public DbSet<Category> Category_Details { get; set; } = null!;
         public DbSet<Item> Item_Details { get; set; } = null!;

        public DbSet<Expense> Expense_Details { get; set; } = null!;

        public DbSet<Revenue> Revenue_Details { get; set; } = null!;

    }
}
