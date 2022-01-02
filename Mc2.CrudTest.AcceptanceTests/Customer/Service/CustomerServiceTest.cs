
using Mc2.CrudTest.Data;
using Mc2.CrudTest.Service.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Customer.Service
{
    [TestClass()]
    public class CategoryServiceTests
    {
        private CustomerService _customerService;
        private Mock<IRepository<Mc2.CrudTest.Core.Domian.Customer>> _customerRepositoryMock;
        [TestInitialize()]
        public void Init()
        {
            _customerRepositoryMock = new Mock<IRepository<Mc2.CrudTest.Core.Domian.Customer>>();
            _customerService = new CustomerService(_customerRepositoryMock.Object);
        }
        [TestMethod()]
        public void RegisterCustomer_NullArgument_ThrowException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _customerService.RegisterCustomerAsync(null),"customer");
        }
        [TestMethod()]
        public void UpdateCustomer_NullArgument_ThrowException()
        {
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _customerService.UpdateCustomerAsync(null), "customer");
        }


        [TestMethod()]
        public void GetCustomerById_ShouldReturnNull()
        {
            //var allCategory = GetMockCategoryList();
            //var category = new Grand.Domain.Catalog.Category() { ParentCategoryId = "3" };
            //_aclServiceMock.Setup(a => a.Authorize<Grand.Domain.Catalog.Category>(It.IsAny<Grand.Domain.Catalog.Category>(), It.IsAny<Customer>())).Returns(() => true);
            //_aclServiceMock.Setup(a => a.Authorize<Grand.Domain.Catalog.Category>(It.IsAny<Grand.Domain.Catalog.Category>(), It.IsAny<string>())).Returns(() => true);
            //var result = _categoryService.GetCategoryBreadCrumb(category, allCategory);
            //Assert.IsTrue(result.Count == 0);
        }
    }
}
