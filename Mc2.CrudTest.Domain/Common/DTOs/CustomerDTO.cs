using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mc2.CrudTest.Common.Validators;

namespace Mc2.CrudTest.Common.DTOs
{


    public class CustomerDTO : BaseEntityDTO
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
        public PhoneNumberDTO PhoneNumberDto
        {
            get
            {
                return new PhoneNumberDTO
                {
                    CountryCode = CountryCode,
                    PhoneNumber = PhoneNumber,
                };
            }
        }

    }
}
