using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DigRich.Common.Extension {
    /// <summary>
    /// 专门处理扩张方法类
    /// </summary>
    public static partial class ObjectExtension {

        /// <summary>
        /// 扩张方法 转换字符串默认为 ""
        /// </summary>
        /// <returns></returns>
        public static string ToEString(this object s) {
            if (s == null) {
                return "";
            }
            else {
                return s.ToString();
            }
        }

        /// <summary>
        /// 扩张方法 转换字符串默认为 ""
        /// </summary>
        /// <returns></returns>
        public static string ToEString(this object s, string defaultStr) {
            if (s == null) {
                return defaultStr;
            }
            else {
                return s.ToString();
            }
        }

        /// <summary>
        /// 扩张方法 转换bool
        /// </summary>
        /// <returns></returns>
        public static bool ToEBoolean(this object s) {
            if (s == null) {
                return false;
            }
            else {
                return Convert.ToBoolean(s);
            }
        }

        /// <summary>
        /// 判断字符串或对象是否为空或null
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object s) {
            if (s == null) {
                return true;
            }
            else {
                return string.IsNullOrEmpty(s.ToEString().Trim());
            }
        }

        /// <summary>
        /// 给前端展示的保留小数用
        /// </summary>
        /// <returns></returns>
        public static string ToMoney(this decimal? s) {
            if (s == null) {
                return Decimal.Parse("0").ToString("f2");
            }
            else {
                return Decimal.Parse(s.ToEString()).ToString("f2");
            }
        }

        public static string ToStringDigit(this object s, string x) {
            if (s != null) {
                decimal t = 0;
                if (decimal.TryParse(s.ToString(), out t)) {
                    return x == "f2" ? t.ToString("f2") : t.ToString("0");
                }
                else return s.ToString();
            }
            else return "";
            //return x == "f2" ? Decimal.Parse("0").ToString("f2") : "0";
        }

        /// <summary>
        /// 给前端展示的保留小数用
        /// </summary>
        /// <returns></returns>
        public static string ToMoney(this decimal s) {
            return s.ToString("f2");
        }

        /// <summary>
        /// 转换 int  默认为 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int ToEInt(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                try {
                    return Convert.ToInt32(t);
                }
                catch {
                    return 0;
                }

            }
        }
        /// <summary>
        /// 转换 int  默认为 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static long ToEInt64(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                try {
                    return Convert.ToInt64(t);
                }
                catch {
                    return 0;
                }

            }
        }
        /// <summary>
        /// 转换 guid  默认为 Guid.Empty
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Guid ToEGuid(this object t) {
            if (t == null) {
                return Guid.Empty;
            }
            else {
                try {
                    return Guid.Parse(t.ToEString());
                }
                catch {
                    return Guid.Empty;
                }

            }
        }
        /// <summary>
        /// 转换 int  默认为 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int ToEInt(this object t, int defaultValue) {
            if (t == null) {
                return 0;
            }
            else {
                try {
                    return Convert.ToInt32(t);
                }
                catch {
                    return defaultValue;
                }

            }
        }
        public static long ToLong(this object t, long defaultValue = 0) {
            if (t == null) {
                return defaultValue;
            }
            else {
                try {
                    return Convert.ToInt64(t);
                }
                catch {
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// 转换 Short  默认为 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static short ToEShort(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                return Convert.ToInt16(t);
            }
        }

        /// <summary>
        /// 转换 byte  默认为 0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static byte ToEByte(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                return Convert.ToByte(t.ToString());
            }
        }

        /// <summary>
        /// 转换 DateTime  默认为 DateTime.MinValue
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DateTime ToEDate(this object t) {
            if (t == null) {
                return DateTime.MinValue;
            }
            else {
                var rt = DateTime.MinValue;
                DateTime.TryParse(t.ToEString(), out rt);
                return rt;
            }
        }

        /// <summary>
        /// 转换 DateTime  默认为 DateTime.MinValue
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToEShortDate(this object t) {
            if (t == null) {
                return DateTime.MinValue.ToString("yyyy-MM-dd");
            }
            else {
                return DateTime.Parse(t.ToEString()).ToString("yyyy-MM-dd");
            }
        }


        /// <summary>
        /// 转换 DateTime  默认为 DateTime.MinValue
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DateTime ToEDateFormat(this DateTime? t) {
            return DateTime.Parse(t.ToEDate().ToString("yyyy-MM-dd HH:mm:ss"));
        }

        /// <summary>
        /// 转换 Decimal  默认为 0;
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Decimal ToEDecimal(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                try {
                    return decimal.Parse(t.ToEString());
                }
                catch {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 转换 Double  默认为 0;
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Double ToEDouble(this object t) {
            if (t == null) {
                return 0;
            }
            else {
                try {
                    return double.Parse(t.ToEString());
                }
                catch {
                    return 0;
                }
            }
        }

        /// <summary>  
        /// 非法字符转换  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static bool IsHasCheckVar(this object t) {
            string input = t.ToEString().Trim();
            string checkvar = "｀＂；：％☆？！〈（＆＃";
            foreach (char c in checkvar) {
                if (input.Contains(c))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取字段Description
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>DescriptionAttribute[] </returns>
        public static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo) {
            if (fieldInfo != null) {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }
       
        
        

        /// <summary> 
        /// 将 Stream 转成 byte[] 
        /// </summary> 
        public static byte[] StreamToBytes(this Stream stream) {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public static Stream BytesToStream(this byte[] bytes) {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        /// <summary>
        /// 通过反射实现深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">需要拷贝的对象</param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T obj) {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields) {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }
        /// <summary>
        /// 对象转Json串
        /// </summary>
        /// <param name="data">json对象</param>
        /// <param name="indented">是否缩进</param>
        /// <param name="jsonSerializerSettings">序列化设置</param>
        /// <returns></returns>
        public static string ToJson(this object data, bool indented = false, JsonSerializerSettings jsonSerializerSettings = null) {
            Formatting formatting = (indented ? Formatting.Indented : Formatting.None);
            return JsonConvert.SerializeObject(data, formatting, jsonSerializerSettings);
        }

    }
}
