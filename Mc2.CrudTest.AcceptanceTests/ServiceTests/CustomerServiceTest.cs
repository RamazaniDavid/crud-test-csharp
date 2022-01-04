using System;
using Mc2.CrudTest.Core.Domain;
using Mc2.CrudTest.Data;
using Mc2.CrudTest.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mc2.CrudTest.AcceptanceTests.ServiceTests
{
    [TestClass()]
    public class CategoryServiceTests
    {
        private CustomerService _customerService;
        private Mock<IRepository<Customer>> _customerRepositoryMock;
        [TestInitialize()]
        public void Init()
        {
            _customerRepositoryMock = new Mock<IRepository<Customer>>();
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
