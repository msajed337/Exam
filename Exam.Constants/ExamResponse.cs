using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Exam.Constants
{
    public class ExamResponse : Response
    {
        [Description("فیلد نام مقدار ندارد")]
        public const int EmptyName = 10001;

        [Description("فیلد نام خانوادگی مقدار ندارد")]
        public const int EmptyLastName = 10002;

        [Description("فیلد کد ملی مقدار ندارد")]
        public const int EmptyNationalCode = 10003;

        [Description("فیلد معدل مقدار ندارد")]
        public const int EmptyAverage = 10004;

        [Description("فیلد تاریخ ورود به دانشگاه مقدار ندارد")]
        public const int EmptyUniversityEntryDate = 10005;

        [Description("فیلد تاریخ اتمام دانشگاه مقدار ندارد")]
        public const int EmptyUniversityEndDate = 10006;

        [Description("فیلد شناسه دانشگاه مقدار ندارد")]
        public const int EmptyUniversityId = 10007;

        [Description("دانشگاه یافت نشد")]
        public const int UniversityNotFound = 10008;

        [Description("فیلد نوع دانشگاه مقدار ندارد")]
        public const int EmptyUniversityType= 10009;

        [Description("فیلد آدرس دانشگاه مقدار ندارد")]
        public const int EmptyUniversityAddress= 10010;


        public static int FromValidationResponse(StudentValidation input) =>
            input switch
            {
                StudentValidation.FirstNameIsEmpty => EmptyName,
                StudentValidation.LastNameIsEmpty => EmptyLastName,
                StudentValidation.NationalCodeIsEmpty => EmptyNationalCode,
                StudentValidation.AverageIsEmpty => EmptyAverage,
                StudentValidation.UniversityEntryDateIsEmpty => EmptyUniversityEntryDate,
                StudentValidation.UniversityEndDateIsEmpty => EmptyUniversityEndDate,
                StudentValidation.UniversityIdIsEmpty => EmptyUniversityId,
                _ => SucceededOk
            };

        public static int FromValidationResponse(UniversityValidation input) =>
            input switch
            {
                UniversityValidation.NameIsEmpty => EmptyName,
                UniversityValidation.TypeIsEmpty => EmptyUniversityType,
                UniversityValidation.AddressIsEmpty => EmptyUniversityAddress,
                _ => SucceededOk
            };
    }
}
