using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Configuration
{
    public class ApplicationSettings
    {
        public DataBaseSettings DataBaseSettings { get; set; }
    }
    public class DataBaseSettings
    {
        public string DBConnection { get; set; }
    }
}
