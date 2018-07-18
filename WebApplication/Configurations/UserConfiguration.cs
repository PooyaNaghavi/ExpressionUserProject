using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace WebApplication.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).IsOptional().HasMaxLength(32);
            Property(x => x.Password).IsOptional();
            //Property(x => x.UserName).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute { IsUnique = true }));
            Property(x => x.FirstName).IsRequired();
            Property(x => x.LastName).IsRequired();
            HasMany(x => x.ExpressionHistory).WithRequired(x => x.Owner);
        }
    }
}