using FluentAssertions;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests.StrategiesTests
{
    public class ConfidentialInvoiceDiscountStrategyTests
    {
        [Fact]
        public void ConfidentialInvoiceAppShouldBe0()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new ConfidentialInvoiceDiscount() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(0);
        }

        [Fact]
        public void ConfidentialInvoiceAppShouldBeNegative1()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(false, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new ConfidentialInvoiceDiscount() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
        }

        [Fact]
        public void ConfidentialInvoiceAppShouldBeAlwaysNegative1IfAppIdIsNull()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(false, null),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new ConfidentialInvoiceDiscount() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
            service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, null),
                new BusinessLoansServiceMock(true, 0));
            result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
        }
    }
}
