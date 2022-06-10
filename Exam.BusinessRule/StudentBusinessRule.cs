using Exam.Common.Configuration;
using Exam.Common.Contract.BusinessRule;
using Exam.Common.Dto.ApiModel.Request;
using Exam.Common.Dto.ApiModel.Response;
using Exam.Common.Dto.ApiModel.Response.Base;
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
    public class StudentBusinessRule : IStudentBusinessRule
    {
        #region Override

        #region ctor
        public StudentBusinessRule(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region fields
        private readonly ApplicationContext _context;
        #endregion

        #region private
        private Expression<Func<DomainModel.Student, bool>> GetExpression(StudentFilter input)
        {
            var expression = PredicateBuilder.True<DomainModel.Student>();
            if (!string.IsNullOrEmpty(input.FromDate))
            {
                var Date = input.FromDate.ToGregorian();
                var Date2 = input.FromDate.ToGregorianVer2();
            }
            if (!string.IsNullOrEmpty(input.ToDate))
            {
                var Date = input.ToDate.ToGregorian();
                var Date2 = input.ToDate.ToGregorianVer2();
            }
            if (!string.IsNullOrEmpty(input.FullName))
                expression = expression.And(s => $"{s.FirstName} {s.LastName}" == input.FullName);
            if (!string.IsNullOrEmpty(input.NationalCode))
                expression = expression.And(s => s.NationalCode == input.FullName);
            return expression;
        }
        #endregion

        #region public
        public async Task<ListResponseBase<Student>> GetList(StudentFilter input)
        {
            var response = new ListResponseBase<Student>();
            try
            {
                var expr = GetExpression(input);

                var list = new List<DomainModel.Student>();
                if (input.PageNumber != -1)
                    list = await _context.Students
                        .Where(expr)
                        .Skip(input.SkipCount)
                        .Take(input.PageSize)
                        .OrderBy(x => input.OrderBy)
                        .ToListAsync();
                else
                    list = await _context.Students
                        .Where(expr)
                        .OrderBy(x => input.OrderBy)
                        .ToListAsync();

                response.Data = list.Select(c => (Student)c).ToList();
                response.Count = list.Count;
                response.TotalCount = await _context.Students.CountAsync(expr);
                response.PageNumber = input.PageNumber;
                response.PageSize = input.PageSize;
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
