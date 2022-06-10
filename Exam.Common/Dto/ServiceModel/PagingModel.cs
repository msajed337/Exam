using Exam.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exam.Common.Dto.ServiceModel
{
    public class PagingModel
    {
        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public int PageNumber { get; set; }

        [Required(ErrorMessageResourceName = "IsRequired", ErrorMessageResourceType = typeof(Messages))]
        public int PageSize { get; set; }

        public string OrderBy { get; set; }

        public DateTime? CreationStartDate { get; set; }

        public DateTime? CreationEndDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModificationStartDate { get; set; }

        public DateTime? ModificationEndDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        public int SkipCount { get { return (PageNumber - 1) * PageSize; } }
    }
}
