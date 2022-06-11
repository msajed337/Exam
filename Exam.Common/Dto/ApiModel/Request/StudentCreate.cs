using Exam.Common.Resources;
using Exam.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.Common.Dto.ApiModel.Request
{
    public class StudentCreate
    {
        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string NationalCode { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public string Orientation { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public float Average { get; set; }        

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string UniversityEntryDate { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public string UniversityEndDate { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public int UniversityId { get; set; }
    }
}
