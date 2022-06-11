using Exam.Common.Dto.ApiModel.Request;
using Exam.Common.Dto.ApiModel.Response;
using Exam.Common.Dto.ApiModel.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.Contract.BusinessRule
{
    public interface IUniversityBusinessRule
    {
        Task<ListResponseBase<University>> GetList(UniversityFilter input);
        Task<ResponseBase<University>> GetById(int id);
        Task<ResponseBase<University>> Add(UniversityCreate input);
    }
}
