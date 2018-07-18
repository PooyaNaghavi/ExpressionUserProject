using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication.Configurations;
using WebApplication.Models;

namespace WebApplication
{
    public class Context : DbContext
    {
        public Context() : base("name=ExpressionContext") { }
        public DbSet<User> Users { get; set; }           
        public DbSet<MathExpression> MathExpressions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ExpressionConfiguration());
        }

    }
}