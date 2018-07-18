using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Configurations
{
    public class ExpressionConfiguration : EntityTypeConfiguration<MathExpression>
    {
        public ExpressionConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ArrivedAt).IsRequired();
            Property(x => x.ExitedAt).IsRequired();
            Property(x => x.IsSuccessful).IsRequired();
            HasRequired(x => x.Owner).WithMany(x => x.ExpressionHistory);


            //HasRequired(x => x.ExpressionHistory).WithRequired();
        }
    }
}