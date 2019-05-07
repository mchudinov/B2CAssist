using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace DataProviders
{
    public abstract class BaseDataProvider
    {
        protected static ILogger _logger;

        public BaseDataProvider(ILogger<BaseDataProvider> logger = null)
        {
            if (null == logger)
            {
                logger = new NullLogger<BaseDataProvider>();
            }

            _logger = logger;
        }
    }
}
