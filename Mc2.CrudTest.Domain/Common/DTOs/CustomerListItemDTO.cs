namespace Mc2.CrudTest.Common.DTOs
{


    public class CustomerListItemDTO : BaseEntityDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }


    }
}
