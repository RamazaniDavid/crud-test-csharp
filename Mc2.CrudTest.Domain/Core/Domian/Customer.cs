using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.CrudTest.Core.Domian
{
    public class Customer : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public virtual string CountryCode { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Email { get; set; }

        public virtual string BankAccountNumber { get; set; }   

    }
}
