using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Constants
{
    public enum StudentValidation
    {
        FirstNameIsEmpty = 1,
        LastNameIsEmpty = 2,
        NationalCodeIsEmpty = 3,
        AverageIsEmpty = 4,
        UniversityEntryDateIsEmpty = 5,
        UniversityEndDateIsEmpty = 6,
        UniversityIdIsEmpty = 7,
        IsValid = 8
    }

    public enum UniversityValidation
    {
        NameIsEmpty = 1,
        TypeIsEmpty = 2,
        AddressIsEmpty = 3,
        IsValid = 4
    }
}
