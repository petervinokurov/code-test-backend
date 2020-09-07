using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Strategies
{
    /// <summary>
    /// Strategy for SelectiveInvoiceDiscount app and service.
    /// </summary>
    public class SelectiveInvoiceDiscountStrategy : BaseSubmitApplicationStrategy<SelectiveInvoiceDiscount, ISelectInvoiceService>, IGetApplication
    {
        /// <inheritdoc/>
        public SelectiveInvoiceDiscountStrategy(ISelectInvoiceService service)
            :base(service)
        {
        }

        /// <inheritdoc cref="IGetApplication"/>
        public int GetApplication(ISellerApplication application)
        {
            base.SetProduct(application);
            return Service.SubmitApplicationFor(application.CompanyData.Number.ToString(), Product.InvoiceAmount, Product.AdvancePercentage);
        }
    }
}