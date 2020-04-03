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
        /// <para>default:100</para>
        /// </summary>
        public int TimeoutSeconds { get; set; } = 100;

        /// <summary>
        /// RetryCount
        /// <para>default:3</para>
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// SleepDurationSeconds
        /// <para>default:2</para>
        /// </summary>
        public int SleepDurationSeconds { get; set; } = 2;

        /// <summary>
        /// HandledEventsAllowedBeforeBreaking
        /// <para>default:10</para>
        /// </summary>
        public int HandledEventsAllowedBeforeBreaking { get; set; } = 10;

        /// <summary>
        /// DurationOfBreakSeconds
        /// <para>default:60</para>
        /// </summary>
        public int DurationOfBreakSeconds { get; set; } = 60;
    }
}
