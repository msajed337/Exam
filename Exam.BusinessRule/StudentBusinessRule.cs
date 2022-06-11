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
            if (!string.IsNullOrEmpty(input.FromDate) && !string.IsNullOrEmpty(input.ToDate))
                expression = expression.And(s => s.UniversityEndDate >= input.FromDate.ToGregorian() || s.UniversityEndDate< input.ToDate.ToGregorian());
            if (!string.IsNullOrEmpty(input.FullName))
                expression = expression.And(s => s.FirstName + " " + s.LastName == input.FullName);
            if (!string.IsNullOrEmpty(input.NationalCode))
                expression = expression.And(s => s.NationalCode == input.NationalCode);
            return expression;
        }

        private StudentValidation ValidateForCreate(StudentData input)
        {
            if (string.IsNullOrEmpty(input.FirstName))
                return StudentValidation.FirstNameIsEmpty;
            if (string.IsNullOrEmpty(input.LastName))
                return StudentValidation.LastNameIsEmpty;
            if (string.IsNullOrEmpty(input.NationalCode))
                return StudentValidation.NationalCodeIsEmpty;
            if (!input.Average.HasValue)
                return StudentValidation.AverageIsEmpty;
            if (string.IsNullOrEmpty(input.UniversityEntryDate))
                return StudentValidation.UniversityEntryDateIsEmpty;
            if (string.IsNullOrEmpty(input.UniversityEndDate))
                return StudentValidation.UniversityEndDateIsEmpty;
            return StudentValidation.IsValid;
        }
        #endregion

        #region public
        public async Task<ListResponseBase<ListStudent>> GetList(StudentFilter input)
        {
            var response = new ListResponseBase<ListStudent>();
            try
            {
                var expr = GetExpression(input);

                var list = new List<DomainModel.Student>();
                if (input.PageNumber != -1)
                    list = await _context.Students
                        .Where(expr)
                        .OrderBy(x => input.OrderBy)
                        .Skip(input.SkipCount)
                        .Take(input.PageSize)
                        .ToListAsync();
                else
                    list = await _context.Students
                        .Where(expr)
                        .OrderBy(x => input.OrderBy)
                        .ToListAsync();

                response.Data = list.Select(c => (ListStudent)c).ToList();
                response.Count = list.Count;
                response.TotalCount = await _context.Students.CountAsync(expr);
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

        public async Task<ResponseBase<Student>> GetById(int id)
        {
            var response = new ResponseBase<Student>();
            try
            {
                var student = await _context.Students.Include(s => s.University).SingleOrDefaultAsync(s => s.Id == id);

                if (student == null)
                {
                    response.ResponseCode = Response.NotFound;
                    return response;
                }

                response.Data = (Student)student;
                response.ResponseCode = Response.SucceededOk;
            }
            catch (Exception ex)
            {
                Log.Error(ex, LogTemplates.Exception, LogTemplates.HostName);
                response.ResponseCode = Response.SystemError;
            }
            return response;
        }

        public async Task<ResponseBase<Student>> Add(StudentCreate input)
        {
            var response = new ResponseBase<Student>();
            try
            {
                var isValid = ValidateForCreate((StudentData)input);
                if (isValid != StudentValidation.IsValid)
                {
                    response.ResponseCode = Response.InvalidParameters;
                    return response;
                }

                var university = await _context.Universities.FindAsync(input.UniversityId);
                if (university == null)
                {
                    response.ResponseCode = ExamResponse.UniversityNotFound;
                    return response;
                }

                var student = new DomainModel.Student()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    NationalCode = input.NationalCode,
                    Grade = input.Grade,
                    Major = input.Major,
                    Orientation = input.Orientation,
                    Average = input.Average,
                    UniversityEntryDate = input.UniversityEntryDate.ToGregorian(),
                    UniversityEndDate = input.UniversityEndDate.ToGregorian(),
                    University = university,
                    CreationDate = DateTime.Now
                };

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                response.Data = (Student)student;
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
