using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Strategies
{
    /// <summary>
    /// Strategy for ConfidentialInvoiceDiscount app and service.
    /// </summary>
    public class ConfidentialInvoiceDiscountStrategy : BaseSubmitApplicationStrategy<ConfidentialInvoiceDiscount, IConfidentialInvoiceService>, IGetApplication
    {
        /// <inheritdoc/>
        public ConfidentialInvoiceDiscountStrategy(IConfidentialInvoiceService service) : base(service)
        {
        }

        /// <inheritdoc cref="IGetApplication"/>
        public int GetApplication(ISellerApplication application)
        {
            base.SetProduct(application);
            var result = Service.SubmitApplicationFor(
                new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, Product.TotalLedgerNetworth, Product.AdvancePercentage, Product.VatRate);

            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}
