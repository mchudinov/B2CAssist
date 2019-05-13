using System;

namespace Models
{
    public class PolicyKey
    {
        public string Name { get; set; }

        public long ExpirationTimestamp { get; set; }

        public long ExpirationSeconds { get; set; }

        public DateTimeOffset ExpirationDateTimeOffset { get; set; }

        public DateTimeOffset CreatedDateTimeOffset { get; set; }
    }
}
