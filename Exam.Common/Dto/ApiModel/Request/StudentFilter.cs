using Exam.Common.Dto.ServiceModel;
using Exam.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Request
{
    public class StudentFilter : PagingModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
    }
}
