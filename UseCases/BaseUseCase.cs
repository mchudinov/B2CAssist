using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace UseCases
{
    public abstract class BaseUseCase
    {
        protected static ILogger _logger;

        public BaseUseCase(ILogger<BaseUseCase> logger = null)
        {
            if (null == logger)
            {
                logger = new NullLogger<BaseUseCase>();
            }

            _logger = logger;
        }
    }
}
