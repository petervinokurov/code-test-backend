using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication.Strategies
{
    /// <summary>
    /// Base strategy class for applications.
    /// </summary>
    /// <typeparam name="T">Target data type.</typeparam>
    /// <typeparam name="T1">Target service type.</typeparam>
    public abstract class BaseSubmitApplicationStrategy<T, T1> where T: IProduct
    {
        private ISellerApplication _sellerApplication;

        protected T1 Service { get; }

        protected T Product => (T) _sellerApplication.Product;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">Target service</param>
        protected BaseSubmitApplicationStrategy(T1 service)
        {
            Service = service;
        }

        /// <summary>
        /// Set target product (should be executed in start of implementation of IGetApplication)
        /// </summary>
        /// <param name="sellerApplication">Target data</param>
        protected virtual void SetProduct(ISellerApplication sellerApplication)
        {
            _sellerApplication = sellerApplication;
        }
    }
}
