using Exam.Common.Dto.ApiModel.Request;
using Exam.Common.Dto.ApiModel.Response;
using Exam.Common.Dto.ApiModel.Response.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.Contract.BusinessRule
{
    public interface IStudentBusinessRule
    {
        Task<ListResponseBase<ListStudent>> GetList(StudentFilter input);
        Task<ResponseBase<Student>> GetById(int id);
        Task<ResponseBase<Student>> Add(StudentCreate input);
    }
}
