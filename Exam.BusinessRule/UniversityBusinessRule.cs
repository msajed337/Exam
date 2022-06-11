using Exam.Common.Configuration;
using Exam.Common.Contract.BusinessRule;
using Exam.Common.Dto.ApiModel.Request;
using Exam.Common.Dto.ApiModel.Response;
using Exam.Common.Dto.ApiModel.Response.Base;
using Exam.Common.Dto.ServiceModel;
using Exam.Common.Extension;
using Exam.Constants;
using Exam.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BusinessRule
{
    public class UniversityBusinessRule : IUniversityBusinessRule
    {
        #region Override

        #region ctor
        public UniversityBusinessRule(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region fields
        private readonly ApplicationContext _context;
        #endregion

        #region private
        private Expression<Func<DomainModel.University, bool>> GetExpression(UniversityFilter input)
        {
            var expression = PredicateBuilder.True<DomainModel.University>();
            if (!string.IsNullOrEmpty(input.Name))
                expression = expression.And(u => u.Name == input.Name);
            if (input.Type.HasValue)
                expression = expression.And(u => u.Type == input.Type);
            if (!string.IsNullOrEmpty(input.Address))
                expression = expression.And(u => u.Address.Contains(input.Address));
            return expression;
        }

        private UniversityValidation ValidateForCreate(UniversityData input)
        {
            if (string.IsNullOrEmpty(input.Name))
                return UniversityValidation.NameIsEmpty;
            if (!input.Type.HasValue)
                return UniversityValidation.TypeIsEmpty;
            if (string.IsNullOrEmpty(input.Address))
                return UniversityValidation.AddressIsEmpty;
            return UniversityValidation.IsValid;
        }
        #endregion

        #region public
        public async Task<ListResponseBase<University>> GetList(UniversityFilter input)
        {
            var response = new ListResponseBase<University>();
            try
            {
                var expr = GetExpression(input);

                var list = new List<DomainModel.University>();

                if (input.PageNumber != -1)
                    list = await _context.Universities
                        .Where(expr)
                        .OrderBy(x => input.OrderBy)
                        .Skip(input.SkipCount)
                        .Take(input.PageSize)
                        .ToListAsync();
                else
                    list = await _context.Universities
                        .Where(expr)
                        .OrderBy(x => input.OrderBy)
                        .ToListAsync();

                response.Data = list.Select(c => (University)c).ToList();
                response.Count = list.Count;
                response.TotalCount = await _context.Universities.CountAsync(expr);
                response.PageNumber = input.PageNumber;
                response.PageSize = input.PageSize;
                response.ResponseCode = Response.SucceededOk;
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                response.ResponseCode = Response.SystemError;
            }
            return response;
        }

        public async Task<ResponseBase<University>> GetById(int id)
        {
            var response = new ResponseBase<University>();
            try
            {
                var university = await _context.Universities.FindAsync(id);

                if (university == null)
                {
                    response.ResponseCode = ExamResponse.UniversityNotFound;
                    return response;
                }

                response.Data = (University)university;
                response.ResponseCode = Response.SucceededOk;
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                response.ResponseCode = Response.SystemError;
            }
            return response;
        }

        public async Task<ResponseBase<University>> Add(UniversityCreate input)
        {
            var response = new ResponseBase<University>();
            try
            {
                var isValid = ValidateForCreate((UniversityData)input);
                if (isValid != UniversityValidation.IsValid)
                {
                    response.ResponseCode = Response.InvalidParameters;
                    return response;
                }

                var university = new DomainModel.University()
                {
                    Name = input.Name,
                    Type = input.Type,
                    Address = input.Address,
                    CreationDate=DateTime.Now
                };

                await _context.Universities.AddAsync(university);
                await _context.SaveChangesAsync();

                response.Data = (University)university;
                response.ResponseCode = Response.SucceededCreated;
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                response.ResponseCode = Response.SystemError;
            }
            return response;
        }
        #endregion


        #endregion
    }
}
