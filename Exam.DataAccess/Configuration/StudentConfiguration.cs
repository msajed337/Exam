using Exam.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.DataAccess.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("(getdate())");
            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.NationalCode).IsRequired(true);
            builder.Property(x => x.Grade).IsRequired(false);
            builder.Property(x => x.Major).IsRequired(false);
            builder.Property(x => x.Orientation).IsRequired(false);
            builder.Property(x => x.Average).IsRequired(true);
            builder.Property(x => x.UniversityEntryDate).IsRequired(true);
            builder.Property(x => x.UniversityEntryDate).IsRequired(true);
            builder.HasOne(x => x.University).WithMany(x => x.Students).HasForeignKey(x => x.UniversityId);
        }



        /*
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public string Orientation { get; set; }
        public string Average { get; set; }
        public string UniversityEntryDate { get; set; }
        public string UniversityEndDate { get; set; }
        public University University { get; set; }
        public int UniversityId { get; set; }
         */
    }
}
