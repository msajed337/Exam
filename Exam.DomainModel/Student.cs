using System;

namespace Exam.DomainModel
{
    public class Student
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public string Orientation { get; set; }
        public float Average { get; set; }
        public DateTime UniversityEntryDate { get; set; }
        public DateTime UniversityEndDate { get; set; }

        public University University { get; set; }
        public int UniversityId { get; set; }
    }
}
