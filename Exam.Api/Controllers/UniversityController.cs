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
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class UniversityController : ControllerBase
    {
        #region Override

        #region ctor
        public UniversityController(IUniversityBusinessRule service)
        {
            _service = service;
        }
        #endregion

        #region fields
        private readonly IUniversityBusinessRule _service;
        #endregion

        #region public
        [HttpGet, MapToApiVersion("1.0")]
        public async Task<IActionResult> List([FromQuery] UniversityFilter input)
        {
            var resp = new ListResponseBase<University>();
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
            var resp = new ResponseBase<University>();
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
        public async Task<IActionResult> Add(UniversityCreate input)
        {
            var resp = new ResponseBase<University>();
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
