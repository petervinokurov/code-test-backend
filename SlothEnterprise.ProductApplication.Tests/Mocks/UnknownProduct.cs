using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Tests.Mocks
{
    public class UnknownProduct : IProduct
    {
        public int Id { get; } = 1;
    }
}
