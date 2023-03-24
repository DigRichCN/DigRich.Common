using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DigRich.Common.Extension {
    public static partial class ClassExtension {
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyname"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T SetPropertyValue<T>(this T t, string propertyname, object value) where T : class {
            PropertyInfo[] fields = t.GetType().GetProperties();//获取指定对象的所有公共属性
            foreach (PropertyInfo item in fields) {
                if (propertyname == item.Name) {
                    if (value != DBNull.Value) {
                        value = Convert.ChangeType(value, (Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType));
                        item.SetValue(t, value, null);//给对象赋值
                    }
                    break;
                }
            }
            return t;
        }
        /// <summary>
        /// 批量设置属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static T SetPropertyValue<T>(this T t, Dictionary<string, object> dc) where T : class {
            PropertyInfo[] fields = t.GetType().GetProperties();//获取指定对象的所有公共属性
            foreach (var kv in dc) {
                foreach (PropertyInfo item in fields) {
                    if (kv.Key == item.Name) {
                        object value;
                        if (kv.Value != DBNull.Value) {
                            value = Convert.ChangeType(kv.Value, (Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType));
                            item.SetValue(t, value, null);//给对象赋值
                        }
                        break;
                    }
                }
            }

            return t;
        }
    }
}
