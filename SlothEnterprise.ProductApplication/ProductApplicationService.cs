using System;
using System.Collections.Generic;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Strategies;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService
    {
        private readonly IDictionary<Type, IGetApplication> _strategies = new Dictionary<Type, IGetApplication>();

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            if (selectInvoiceService != null)
                _strategies.Add(typeof(SelectiveInvoiceDiscount),
                    new SelectiveInvoiceDiscountStrategy(selectInvoiceService));
            if (confidentialInvoiceWebService != null)
                _strategies.Add(typeof(ConfidentialInvoiceDiscount), 
                    new ConfidentialInvoiceDiscountStrategy(confidentialInvoiceWebService));
            if (businessLoansService != null)
                _strategies.Add(typeof(BusinessLoans), 
                    new BusinessLoansStrategy(businessLoansService));
        }

        /// <summary>
        /// Open closed principle violated
        /// </summary>
        /// <param name="application">Target application</param>
        /// <returns></returns>
        public int SubmitApplicationFor(ISellerApplication application)
        {

            if (application?.Product != null && _strategies.TryGetValue(application.Product.GetType(), out var strategy))
            {
                return strategy.GetApplication(application);
            }

            // Exception isn't meaningful
            throw new InvalidOperationException($"Product type '{application?.Product?.GetType().Name}' isn't found or corresponded service is null.");
        }
    }
}
