using Exam.Common.Dto.ApiModel.Request;
using Exam.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Dto.ServiceModel
{
    public class UniversityData
    {
        public static explicit operator UniversityData(UniversityCreate input) =>
            new UniversityData
            {
                Name = input.Name,
                Type = input.Type,
                Address = input.Address
            };

        public string Name { get; set; }
        public UniversityType? Type { get; set; }
        public string Address { get; set; }
    }
}
