using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Strategies
{
    /// <summary>
    /// Strategy for BusinessLoans app and service.
    /// </summary>
    public class BusinessLoansStrategy : BaseSubmitApplicationStrategy<BusinessLoans, IBusinessLoansService>, IGetApplication
    {
        /// <inheritdoc/>
        public BusinessLoansStrategy(IBusinessLoansService service) : base(service)
        {
        }

        /// <inheritdoc cref="IGetApplication"/>
        public int GetApplication(ISellerApplication application)
        {
            base.SetProduct(application);
            var result = Service.SubmitApplicationFor(new CompanyDataRequest
            {
                CompanyFounded = application.CompanyData.Founded,
                CompanyNumber = application.CompanyData.Number,
                CompanyName = application.CompanyData.Name,
                DirectorName = application.CompanyData.DirectorName
            }, new LoansRequest
            {
                InterestRatePerAnnum = Product.InterestRatePerAnnum,
                LoanAmount = Product.LoanAmount
            });
            return (result.Success) ? result.ApplicationId ?? -1 : -1;
        }
    }
}
