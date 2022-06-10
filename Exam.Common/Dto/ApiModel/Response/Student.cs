using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Response
{
    public class Student
    {
        public static explicit operator Student(DomainModel.Student input)
        {
            PersianCalendar pc = new PersianCalendar();
            var student = new Student
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                NationalCode = input.NationalCode,
            };
            student.Date = $"{pc.GetYear(input.CreationDate)}/{pc.GetMonth(input.CreationDate)}/{pc.GetDayOfMonth(input.CreationDate)}";

            return student;
        }



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Date { get; set; }
    }
}
