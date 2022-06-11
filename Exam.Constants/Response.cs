using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace Exam.Constants
{
    public class Response
    {
        [Description("عملیات با موفقیت انجام شد")]
        public const int SucceededOk = (int)HttpStatusCode.OK;

        [Description("عملیات با موفقیت انجام شد")]
        public const int SucceededCreated = (int)HttpStatusCode.Created;

        [Description("خطای سیستمی رخ داده است.")]
        public const int SystemError = (int)HttpStatusCode.InternalServerError;

        [Description("پارامترهای ورودی معتبر نمی باشد.")]
        public const int InvalidParameters = (int)HttpStatusCode.BadRequest;

        [Description("داده ای برای انجام عملیات درخواستی یافت نشد.")]
        public const int NotFound = (int)HttpStatusCode.NotFound;

        [Description("تنظیمات سامانه یافت نشد")]
        public const int ApplicationSettingNotFound = (int)HttpStatusCode.NotImplemented;

        [Description("عملیات درخواستی مجاز نمی باشد")]
        public const int InvalidOperation = (int)HttpStatusCode.Forbidden;

        [Description("مقادیر ارسالی تکراری می باشد.")]
        public const int DuplicateData = (int)HttpStatusCode.BadRequest;

        [Description("شما دسترسی به انجام عملیات درخواستی را ندارید")]
        public const int Unauthorized = (int)HttpStatusCode.Unauthorized;

        [Description("برای انجام عملیات درخواستی باید وارد سامانه شده باشید")]
        public const int Forbidden = (int)HttpStatusCode.Forbidden;
    }
}
