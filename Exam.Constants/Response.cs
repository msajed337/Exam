using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Exam.Constants
{
    public class Response
    {
        [Description("عملیات با موفقیت انجام شد")]
        public const int SucceededOk = 0;

        [Description("عملیات با موفقیت انجام شد")]
        public const int SucceededCreated = 1;

        [Description("خطای سیستمی رخ داده است.")]
        public const int SystemError = 2;

        [Description("پارامترهای ورودی معتبر نمی باشد.")]
        public const int InvalidParameters = 3;

        [Description("داده ای برای انجام عملیات درخواستی یافت نشد.")]
        public const int NotFound = 4;

        [Description("تنظیمات سامانه یافت نشد")]
        public const int ApplicationSettingNotFound = 5;

        [Description("عملیات درخواستی مجاز نمی باشد")]
        public const int InvalidOperation = 6;

        [Description("مقادیر ارسالی تکراری می باشد.")]
        public const int DuplicateData = 7;

        [Description("شما دسترسی به انجام عملیات درخواستی را ندارید")]
        public const int Unauthorized = 8;

        [Description("برای انجام عملیات درخواستی باید وارد سامانه شده باشید")]
        public const int Forbidden = 9;
    }
}
