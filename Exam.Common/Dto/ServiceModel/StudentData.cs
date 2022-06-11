using Exam.Common.Dto.ApiModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Dto.ServiceModel
{
    public class StudentData
    {
        public static explicit operator StudentData(StudentCreate input) =>
            new StudentData
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                NationalCode = input.NationalCode,
                Grade = input.Grade,
                Major = input.Major,
                Orientation = input.Orientation,
                Average = input.Average,
                UniversityEntryDate = input.UniversityEntryDate,
                UniversityEndDate = input.UniversityEndDate,
                UniversityId = input.UniversityId
            };

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public string Orientation { get; set; }
        public float? Average { get; set; }
        public string UniversityEntryDate { get; set; }
        public string UniversityEndDate { get; set; }
        public int UniversityId { get; set; }
    }
}
