using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Exam.Common.Dto.ApiModel.Response.Base
{
    public class ResponseBase<TClass>
    {
        [JsonIgnore]
        public int ResponseCode { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public Guid ReferenceNumber { get; set; }
        public string TraceNumber { get; set; }
        public TClass Data { get; set; }
    }

    public class ResponseBase
    {
        public int ResponseCode { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public Guid ReferenceNumber { get; set; }
        public string TraceNumber { get; set; }
    }

    public class ListResponseBase<TClass>
    {
        public int ResponseCode { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public Guid ReferenceNumber { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string TraceNumber { get; set; }
        public List<TClass> Data { get; set; }
    }
}
