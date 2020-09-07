using FluentAssertions;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests.StrategiesTests
{
    public class BusinessLoansStrategyTests
    {
        [Fact]
        public void BusinessLoansAppShouldBe0()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new BusinessLoans() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(0);
        }

        [Fact]
        public void BusinessLoansAppShouldBeNegative1()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(false, 0));
            var app = new SellerApplication { Product = new BusinessLoans() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
        }

        [Fact]
        public void BusinessLoansAppShouldBeAlwaysNegative1IfAppIdIsNull()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(false, null));
            var app = new SellerApplication { Product = new BusinessLoans() };
            var result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
            service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, null));
            result = service.SubmitApplicationFor(app);
            result.Should().Be(-1);
        }
    }
}
