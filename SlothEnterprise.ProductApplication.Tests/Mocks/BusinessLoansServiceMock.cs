using SlothEnterprise.External;
using SlothEnterprise.External.V1;

namespace SlothEnterprise.ProductApplication.Tests.Mocks
{
    public class BusinessLoansServiceMock : IBusinessLoansService
    {
        private readonly bool _result;
        private readonly int? _applicationId;
        public BusinessLoansServiceMock(bool result, int? applicationId)
        {
            _result = result;
            _applicationId = applicationId;
        }

        public IApplicationResult SubmitApplicationFor(CompanyDataRequest applicantData, LoansRequest businessLoans)
        {
            return new ApplicationResultMock { Success = _result, ApplicationId = _applicationId };
        }
    }
}
