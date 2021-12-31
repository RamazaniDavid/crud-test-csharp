using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Common.Validators
{
    public class MobileNumberValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
                return new ValidationResult(ErrorMessage);

            if (value is PhoneNumberDTO pn)
            {

                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phoneNumber = phoneNumberUtil.Parse(pn.PhoneNumber, pn.CountryCode);

                if(phoneNumber == null || !phoneNumberUtil.IsValidNumberForRegion(phoneNumber,pn.CountryCode))
                    return new ValidationResult(ErrorMessage);

                return ValidationResult.Success;
            }
            return new ValidationResult("It's Not Phone Number");
        }
    }
}
