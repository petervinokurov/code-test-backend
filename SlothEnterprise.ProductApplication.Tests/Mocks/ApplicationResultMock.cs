using System.Collections.Generic;
using SlothEnterprise.External;

namespace SlothEnterprise.ProductApplication.Tests.Mocks
{
    public class ApplicationResultMock : IApplicationResult
    {
        public int? ApplicationId { get; set; } = 0;
        public bool Success { get; set; }
        public IList<string> Errors { get; set; } = new List<string>();
    }
}
