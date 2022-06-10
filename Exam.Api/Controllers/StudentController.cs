using Exam.Common.Configuration;
using Exam.Common.Contract.BusinessRule;
using Exam.Common.Dto.ApiModel.Request;
using Exam.Common.Dto.ApiModel.Response;
using Exam.Common.Dto.ApiModel.Response.Base;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Api.Controllers
{
    public class StudentController : Controller
    {
        #region Override

        #region ctor
        public StudentController(IStudentBusinessRule service)
        {
            _service = service;
        }
        #endregion

        #region fields
        private readonly IStudentBusinessRule _service;
        #endregion

        #region public
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] StudentFilter input)
        {
            var resp = new ListResponseBase<Student>();
            try
            {
                resp = await _service.GetList(input);
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                resp.ResponseCode = Constants.Response.SystemError;
            }
            return View(resp);
        }
        #endregion


        #endregion
    }
}
