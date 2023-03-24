using System;
using System.Collections.Generic;
using System.Text;

namespace DigRich.Common.Extension {
    public static partial class DateTimeExtension {
        private static readonly long startTicks = new DateTime(1970, 1, 1).Ticks;


        /// <summary>
        /// 获取距离 1970-01-01（格林威治时间）的秒数
        /// </summary>
        /// <param name="localTime"></param>
        /// <returns></returns>
        public static long ToUtcSeconds(this DateTime localTime) {
            return (localTime.ToUniversalTime().Ticks - startTicks) / 10000000;
        }

        /// <summary>
        /// 距离 1970-01-01（格林威治时间）的秒数转换为当前时间
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTime FromUtcSeconds(this long seconds) {
            return DateTimeOffset.FromUnixTimeSeconds(seconds)
                .LocalDateTime; // new DateTime(1970, 1, 1).AddSeconds(seconds).ToLocalTime();
        }


        /// <summary>
        /// 获取距离 1970-01-01（格林威治时间）的毫秒数
        /// </summary>
        /// <param name="localTime"></param>
        /// <returns></returns>
        public static long ToUtcMilliseconds(this DateTime localTime) {
            return (localTime.ToUniversalTime().Ticks - startTicks) / 10000;
        }

        /// <summary>
        /// 距离 1970-01-01（格林威治时间）的秒数转换为当前时间
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime FromUtcMilliseconds(this long milliseconds) {
            return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).LocalDateTime;
        }


        /// <summary>
        /// 获取距离 1970-01-01（格林威治时间）Ticks  精确到0.1微秒（千万分之一秒）
        /// </summary>
        /// <param name="localTime"></param>
        /// <returns></returns>
        public static long ToUtcTicks(this DateTime localTime) {
            return localTime.ToUniversalTime().Ticks - startTicks;
        }



        /// <summary>
        /// 获取距离 1970-01-01（本地/北京时间）的秒数
        /// </summary>
        /// <param name="localTime"></param>
        /// <returns></returns>
        public static long ToLocalSeconds(this DateTime localTime) {
            return (localTime.Ticks - startTicks) / 10000000;
        }

        /// <summary>
        /// 距离 1970-01-01（本地/北京时间）的秒数转换为当前时间
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTime FromLocalSeconds(this long seconds) {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }
    }
}
