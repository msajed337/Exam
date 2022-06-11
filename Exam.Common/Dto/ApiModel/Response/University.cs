using Exam.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Response
{
    public class University
    {
        public static explicit operator University(DomainModel.University input) =>
            new University
            {
                Name=input.Name,
                Type=input.Type,
                Address=input.Address
            };

        public string Name { get; set; }
        public UniversityType Type { get; set; }
        public string Address { get; set; }
    }
}
