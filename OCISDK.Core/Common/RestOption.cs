using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// RandomProvider
    /// </summary>
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

        /// <summary>
        /// GetThreadRandom
        /// </summary>
        /// <returns></returns>
        public static Random GetThreadRandom()
        {
            return RandomWrapper.Value;
        }
    }

    /// <summary>
    /// RestOption
    /// </summary>
    public class RestOption
    {
        /// <summary>
        /// TimeoutSeconds
        /// </summary>
        public int TimeoutSeconds { get; set; } = 100;

        /// <summary>
        /// RetryCount
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// SleepDurationSeconds
        /// </summary>
        public int SleepDurationSeconds { get; set; } = 2;

        /// <summary>
        /// HandledEventsAllowedBeforeBreaking
        /// </summary>
        public int HandledEventsAllowedBeforeBreaking { get; set; } = 10;

        /// <summary>
        /// DurationOfBreakSeconds
        /// </summary>
        public int DurationOfBreakSeconds { get; set; } = 60;
    }
}
