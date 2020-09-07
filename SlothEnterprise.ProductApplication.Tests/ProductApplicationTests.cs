using System;
using FluentAssertions;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Tests.Mocks;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        [Fact]
        public void UnknownProductShouldRaiseException()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new UnknownProduct()};
            Action act = () => service.SubmitApplicationFor(app);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '{app.Product?.GetType().Name}' isn't found or corresponded service is null.");
        }

        [Fact]
        public void NullProductShouldRaiseException()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = null };
            Action act = () => service.SubmitApplicationFor(app);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '' isn't found or corresponded service is null.");
        }

        [Fact]
        public void NullAppShouldRaiseException()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            Action act = () => service.SubmitApplicationFor(null);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '' isn't found or corresponded service is null.");
        }

        [Fact]
        public void SelectInvoiceServiceIsNullAppShouldRaiseException()
        {
            var service = new ProductApplicationService(
                null,
                new ConfidentialInvoiceServiceMock(true, 0),
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new SelectiveInvoiceDiscount() };
            Action act = () => service.SubmitApplicationFor(app);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '{app.Product?.GetType().Name}' isn't found or corresponded service is null.");
        }

        [Fact]
        public void ConfidentialInvoiceServiceIsNullAppShouldRaiseException()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                null,
                new BusinessLoansServiceMock(true, 0));
            var app = new SellerApplication { Product = new ConfidentialInvoiceDiscount() };
            Action act = () => service.SubmitApplicationFor(app);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '{app.Product?.GetType().Name}' isn't found or corresponded service is null.");
        }

        [Fact]
        public void BusinessLoansServiceIsNullAppShouldRaiseException()
        {
            var service = new ProductApplicationService(
                new SelectInvoiceServiceMock(1),
                new ConfidentialInvoiceServiceMock(true, 0),
                null);
            var app = new SellerApplication { Product = new BusinessLoans() };
            Action act = () => service.SubmitApplicationFor(app);
            act.Should().Throw<InvalidOperationException>().WithMessage($"Product type '{app.Product?.GetType().Name}' isn't found or corresponded service is null.");
        }
    }
}
