using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mc2.CrudTest.Common.Validators;

namespace Mc2.CrudTest.Common.DTOs
{


    public class CustomerDto : BaseEntityDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string CountryCode { get; set; }
        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

        [MobileNumberValidation]
        [NotMapped]
        public PhoneNumberDto PhoneNumberDto
        {
            get
            {
                return new PhoneNumberDto
                {
                    CountryCode = CountryCode,
                    PhoneNumber = PhoneNumber,
                };
            }
        }

    }
}
