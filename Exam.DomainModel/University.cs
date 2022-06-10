using Exam.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.DomainModel
{
    public class University
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public UniversityType Type { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
