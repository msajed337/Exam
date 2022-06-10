using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Common.Configuration
{
    public static class LogTemplates
    {
        public static string Request = "Request InstanceName: {@HostName}, Host: {@Host}, Path: {@Path}, QueryString: {@QueryString}, Body: {@Body}, Header: {@Header}, UserData: {@UserData}";
        public static string Response = "Response InstanceName: {@HostName}, Host: {@Host}, Path: {@Path}, HttpStatus: {@HttpStatus}, Body: {@Body}, UserData: {@UserData}";
        public static string Exception = "InstanceName: {@HostName}, UserData: {@UserData}";
        public static string Information = "InstanceName: {@HostName}, ClassName: {@ClassName}, MethodName: {@MethodName}, ExtraData: {@ExtraData}, UserData: {@UserData}";
        public static string HostName => Environment.GetEnvironmentVariable("HOSTNAME");
    }
}
