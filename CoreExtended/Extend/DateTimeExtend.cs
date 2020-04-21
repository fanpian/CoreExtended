using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreExtended.Extend
{
    /// <summary>
    /// DateTime自定义扩展
    /// </summary>
    public static class DateTimeExtend
    {
        /// <summary>
        /// DateTime默认输出字符串,如果失败则返回空
        /// 格式:yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <returns>yyyy-MM-dd HH:mm:ss,如果失败则返回空</returns>
        public static string ToStringDefalut(this DateTime dt)
        {
            return ToStringCustom_LongFull(dt, "-");
        }

        /// <summary>
        /// DateTime输出字符串,如果失败则返回空
        /// 格式：yyyy{0}MM{0}dd HH:mm:ss
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="connector">日期连接字符串</param>
        /// <returns>yyyy{0}MM{0}dd HH:mm:ss,如果失败则返回空</returns>
        public static string ToStringCustom_LongFull(this DateTime dt, string connector)
        {
            return DateTimeToString(dt, string.Format("yyyy{0}MM{0}dd HH:mm:ss", connector));
        }

        /// <summary>
        /// DateTime输出字符串,如果失败则返回空
        /// 格式：yyyy{0}MM{0}dd
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="connector">日期连接字符串</param>
        /// <returns>yyyy{0}MM{0}dd,如果失败则返回空</returns>
        public static string ToStringCustom_LongDate(this DateTime dt, string connector)
        {
            return DateTimeToString(dt, string.Format("yyyy{0}MM{0}dd", connector));
        }

        /// <summary>
        /// DateTime输出字符串,如果失败则返回空
        /// 格式：yy{0}MM{0}dd
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="connector">日期连接字符串</param>
        /// <returns>yy{0}MM{0}dd,如果失败则返回空</returns>
        public static string ToStringCustom_ShortDate(this DateTime dt, string connector)
        {
            return DateTimeToString(dt,string.Format("yy{0}MM{0}dd", connector));
        }

        /// <summary>
        /// DateTime输出字符串,如果失败则返回空
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="connector">输出字符串的格式</param>
        /// <returns></returns>
        private static string DateTimeToString(DateTime dt,string connector)
        {
            string dateStr = string.Empty;
            try
            {
                dateStr = dt.ToString(connector);
            }
            catch (Exception e)
            {
            }
            return dateStr;
        }

        /// <summary>
        /// 判断时间是不是今天
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>如果是今天返回true</returns>
        public static bool IsToday(this DateTime dt)
        {
            return dt.Date == DateTime.Today;
        }

        /// <summary>
        /// 判断时间是不是为Null
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsNull(this DateTime dt)
        {
            return dt == null;
        }

        /// <summary>
        /// 判断时间是不是初始时间
        /// 0000-1-1或者1900-1-1
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>true表示是初始时间.为null也表示是初始时间</returns>
        public static bool IsInitialTime(this DateTime dt)
        {
            return IsNull(dt) || dt == new DateTime() || dt == new DateTime(1900, 1, 1);
        }

        /// <summary>
        /// 如果时间为Null，则返回当前时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime IfNull(this DateTime dt)
        {
            return IfNull(dt, DateTime.Now);
        }

        /// <summary>
        /// 如果时间为Null，则返回默认时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="defalut">默认时间</param>
        /// <returns></returns>
        public static DateTime IfNull(this DateTime dt, DateTime defalut)
        {
            return IsNull(dt) ? defalut : dt;
        }

        /// <summary>
        /// 如果是初始时间返回当前时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime IfInitialTime(this DateTime dt)
        {
            return IfInitialTime(dt, DateTime.Now);
        }

        /// <summary>
        /// 如果是初始时间返回默认时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="defalut">默认时间</param>
        /// <returns></returns>
        public static DateTime IfInitialTime(this DateTime dt, DateTime defalut)
        {
            return IsInitialTime(dt) ? defalut : dt;
        }

        /// <summary>
        /// 将时间设置为这天的最后一秒钟
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SetEndOfDay(this DateTime dt)
        {
            return dt.Date.Add(new TimeSpan(0, 23, 59, 59, 999));
        }

        /// <summary>
        /// 当前日期的第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SetMonthFirstDay(this DateTime dt)
        {
            dt = IfNull(dt);
            return dt.AddDays(1 - dt.Day);
        }

        /// <summary>
        /// 当前日期的最后一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SetMonthLastDay(this DateTime dt)
        {
            dt = IfNull(dt);
            dt = SetMonthFirstDay(dt);
            return dt.AddMonths(1).AddDays(-1);
        }
    }
}
