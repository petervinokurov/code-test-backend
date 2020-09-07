using SlothEnterprise.ProductApplication.Applications;

namespace SlothEnterprise.ProductApplication.Strategies
{
    /// <summary>
    /// Interface for execution of strategies
    /// </summary>
    public interface IGetApplication
    {
        /// <summary>
        /// Return result of service on input data
        /// </summary>
        /// <param name="application">Target application</param>
        /// <returns></returns>
        int GetApplication(ISellerApplication application);
    }
}
