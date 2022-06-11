using Exam.Common.Extension;
using Exam.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Response
{
    public class Student
    {
        public static explicit operator Student(DomainModel.Student input) =>
            new Student
            {
                Fullname = $"{input.FirstName} {input.LastName}",
                Grade = input.Grade,
                Major = input.Major,
                Orientation = input.Orientation,
                Average = input.Average,
                University= (University)input.University,
                UniversityEntryDate = input.UniversityEntryDate.ToPersian(),
                UniversityEndDate = input.UniversityEndDate.ToPersian()
            };
        public string Fullname { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public string Orientation { get; set; }
        public float Average { get; set; }
        public University University { get; set; }
        public string UniversityEntryDate { get; set; }
        public string UniversityEndDate { get; set; }
    }
}
