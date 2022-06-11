using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Response
{
    public class ListStudent
    {
        public static explicit operator ListStudent(DomainModel.Student input)
        {
            PersianCalendar pc = new PersianCalendar();
            var student = new ListStudent
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
