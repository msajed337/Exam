using Exam.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.DataAccess.Configuration
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("(getdate())");
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Type).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true);
            builder.HasMany(x => x.Students).WithOne(x => x.University);
        }


        /*
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public UniversityType Type { get; set; }
        public string Address { get; set; }
         */
    }
}
