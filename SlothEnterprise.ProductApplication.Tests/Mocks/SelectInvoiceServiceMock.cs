using SlothEnterprise.External.V1;

namespace SlothEnterprise.ProductApplication.Tests.Mocks
{
    public class SelectInvoiceServiceMock : ISelectInvoiceService
    {
        private readonly int _result;

        public SelectInvoiceServiceMock(int result)
        {
            _result = result;
        }

        public int SubmitApplicationFor(string companyNumber, decimal invoiceAmount, decimal advancePercentage)
        {
            return _result;
        }
    }
}
