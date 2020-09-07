using FluentAssertions;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests.StrategiesTests
{
    public class SelectiveInvoiceDiscountStrategyTests
    {
        [Fact]
        public void SelectInvoiceAppShouldBe1()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new SelectiveInvoiceDiscount() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(1);
        }

        [Fact]
        public void SelectInvoiceAppShouldBeNegative1()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(-1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new SelectiveInvoiceDiscount() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
        }
    }
}
