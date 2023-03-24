using System;
using System.Collections.Generic;
using System.Text;

namespace DigRich.Common.Extension {
    public static partial class DictionaryExtension {
        /// <summary>
        /// 字典取值，如果不存在，则返回默认值
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T2 GetEValueOrDefault<T1, T2>(this Dictionary<T1, T2> dc, T1 key, T2 defaultValue) {
            if (dc != null && dc.ContainsKey(key)) {
                return dc[key];
            }
            return defaultValue;
        }
        //字典设置值，如果key不存在则添加，存在则修改
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="isReplaceValue">如果键存在，是否需要替换值</param>
        public static void SetValue<T1, T2>(this Dictionary<T1, T2> dc, T1 key, T2 value, bool isReplaceValue = true) {
            if (dc == null) {
                dc = new Dictionary<T1, T2>();
            }
            if (!dc.ContainsKey(key)) {
                dc.Add(key, value);
            }
            else if (isReplaceValue) {
                dc[key] = value;
            }
        }
        //字典移除值
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveKey<T1, T2>(this Dictionary<T1, T2> dc, T1 key) {
            if (dc == null) {
                dc = new Dictionary<T1, T2>();
            }
            if (!dc.ContainsKey(key)) {
                dc.Remove(key);
            }
        }
    }
}
