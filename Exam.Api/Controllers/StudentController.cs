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
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
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
        [HttpGet, MapToApiVersion("1.0")]
        public async Task<IActionResult> List([FromQuery] StudentFilter input)
        {
            var resp = new ListResponseBase<ListStudent>();
            try
            {
                resp = await _service.GetList(input);
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                resp.ResponseCode = Constants.Response.SystemError;
            }
            return StatusCode(resp.ResponseCode, resp);
        }

        [HttpGet("{id}"), MapToApiVersion("1.0")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var resp = new ResponseBase<Student>();
            try
            {
                resp = await _service.GetById(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                resp.ResponseCode = Constants.Response.SystemError;
            }
            return StatusCode(resp.ResponseCode, resp);
        }

        [HttpPost, MapToApiVersion("1.0")]
        public async Task<IActionResult> Add(StudentCreate input)
        {
            var resp = new ResponseBase<Student>();
            try
            {
                resp = await _service.Add(input);
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                resp.ResponseCode = Constants.Response.SystemError;
            }
            return StatusCode(resp.ResponseCode, resp);
        }
        #endregion


        #endregion
    }
}
