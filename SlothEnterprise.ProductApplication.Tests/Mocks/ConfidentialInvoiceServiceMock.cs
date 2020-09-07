using SlothEnterprise.External;
using SlothEnterprise.External.V1;

namespace SlothEnterprise.ProductApplication.Tests.Mocks
{
    public class ConfidentialInvoiceServiceMock : IConfidentialInvoiceService
    {
        private readonly bool _result;
        private readonly int? _applicationId;

        public ConfidentialInvoiceServiceMock(bool result, int? applicationId)
        {
            _result = result;
            _applicationId = applicationId;
        }

        public IApplicationResult SubmitApplicationFor(CompanyDataRequest applicantData, decimal invoiceLedgerTotalValue,
            decimal advantagePercentage, decimal vatRate)
        {
            return new ApplicationResultMock { Success = _result, ApplicationId = _applicationId };
        }
    }
}
