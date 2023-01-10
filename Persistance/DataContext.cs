using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; } = null!;

        public DbSet<ActivityAttendee> ActivityAttendees { get; set; } = null!;

        public DbSet<Photo> Photos {get;set;}

        public DbSet<Comment> Comments {get;set;}


        //My App

        public DbSet<Category> Category_Details { get; set; } = null!;

         public DbSet<Item> Item_Details { get; set; } = null!;

        public DbSet<Expense> Expense_Details { get; set; } = null!;

        public DbSet<Revenue> Revenue_Details { get; set; } = null!;

        //additioanl

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new {aa.AppUserId, aa.ActivityId}));

            builder.Entity<ActivityAttendee>()
            .HasOne(u => u.AppUser)
            .WithMany(a => a.Activities)
            .HasForeignKey(aa => aa.AppUserId);

             builder.Entity<ActivityAttendee>()
            .HasOne(u => u.Activity)
            .WithMany(a => a.Attendees)
            .HasForeignKey(aa => aa.ActivityId);

            // Cascade DElete Relations.
            builder.Entity<Comment>()
                .HasOne(a => a.Activity)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
