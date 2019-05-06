using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DataProviders
{
    public class RandomProvider : IDataProvider
    {
        private const int NumberOfKeys = 15;
        private static Random _random = new Random();

        public List<PolicyKey> GetPolicyKeys()
        {
            List<PolicyKey> keys = new List<PolicyKey>();

            for (int i = 0; i < NumberOfKeys; i++)
            {                
                keys.Add(new PolicyKey
                {
                    StorageKeyId = "B2C_1A_" + GetRandomString(10),
                    CreatedDateTimeOffset = GetRandomCreatedDate(),
                    ExpirationTimeStamp = GetRandomExpirationDate().ToUnixTimeSeconds()
                });
            }            

            return keys;
        }            

        private static DateTimeOffset GetRandomDate(DateTime minDt, DateTime maxDt)
        {                    
            int minutesDiff = Convert.ToInt32(maxDt.Subtract(minDt).TotalMinutes + 1);
            int r = _random.Next(1, minutesDiff);
            return minDt.AddMinutes(r);
        }

        private static DateTimeOffset GetRandomCreatedDate()
        {
            DateTime minDt = new DateTime(2015, 1, 1, 10, 0, 0);
            DateTime maxDt = new DateTime(2019, 1, 1, 17, 0, 0);
            return GetRandomDate(minDt, maxDt);
        }

        private static DateTimeOffset GetRandomExpirationDate()
        {
            DateTime minDt = new DateTime(2020, 1, 1, 10, 0, 0);
            DateTime maxDt = new DateTime(2025, 1, 1, 17, 0, 0);
            return GetRandomDate(minDt, maxDt);
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
