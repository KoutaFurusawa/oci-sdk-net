using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace OCISDK.Core.src.Common
{
    public static class RandomProvider
    {
        private static ThreadLocal<Random> RandomWrapper = new ThreadLocal<Random>(() =>
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                return new Random(seed);
            }
        });

        public static Random GetThreadRandom()
        {
            return RandomWrapper.Value;
        }
    }

    public class RestOption
    {
        public int TimeoutSeconds { get; set; } = 100;
        public int RetryCount { get; set; } = 3;
        public int SleepDurationSeconds { get; set; } = 2;
        public int HandledEventsAllowedBeforeBreaking { get; set; } = 10;
        public int DurationOfBreakSeconds { get; set; } = 60;
    }
}
