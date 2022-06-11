using Exam.Common.Dto.ServiceModel;
using Exam.Common.Resources;
using Exam.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Request
{
    public class UniversityFilter : PagingModel
    {
        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public UniversityType? Type { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string Address { get; set; }
    }
}
