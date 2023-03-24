using System;
using System.Collections.Generic;
using System.Text;

namespace DigRich.Common.Extension {
    public static partial class StringExtension {

        /// <summary>
        /// 字符串截取从第一位截取
        /// </summary>
        /// <returns></returns>
        public static string ESubStart(this string s, int length) {
            string temp = s.ToEString();
            if (temp.Length <= length) {
                return temp;
            }
            else {
                return temp.Substring(0, length);
            }
        }

        /// <summary>
        /// 字符串截取从最后一位截取
        /// </summary>
        /// <returns></returns>
        public static string ESubEnd(this string s, int length) {
            string temp = s.ToEString();
            if (temp.Length <= length) {
                return temp;
            }
            else {
                return temp.Substring(temp.Length - length, length);
            }
        }
    }
}
