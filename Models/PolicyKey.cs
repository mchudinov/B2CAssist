using System;

namespace Models
{
    public class PolicyKey
    {
        public string StorageKeyId { get; set; }

        public long ExpirationTimeStamp { get; set; }

        public DateTimeOffset ExpirationDateTimeOffset { get; set; }

        public DateTimeOffset CreatedDateTimeOffset { get; set; }
    }
}
