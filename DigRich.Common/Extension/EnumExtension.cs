using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DigRich.Common.Extension {
    public static partial class EnumExtension {

        /// <summary>
        /// 根据枚举类型和枚举值获取枚举描述
        /// </summary>
        /// <returns></returns>
        public static string ToDescription(this System.Enum value) {
            if (value == null) return "";

            Type type = value.GetType();
            string enumText = System.Enum.GetName(type, value);
            return GetDescription(type, enumText);
        }



        #region 内部成员

        /// <summary>
        /// 转化枚举及其描述为字典类型
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static Dictionary<int, string> ToDescriptionDictionary<TEnum>() {
            Type type = typeof(TEnum);
            var values = Enum.GetValues(type);
            var enums = new Dictionary<int, string>();
            foreach (Enum item in values) {
                enums.Add(Convert.ToInt32(item), item.ToDescription());
            }

            return enums;
        }


        /// <summary>
        /// 转化枚举及其Text值转为字典类型
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns>返回枚举项和值</returns>
        public static Dictionary<string, string> ToDictionary(this Type enumType) {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (int item in Enum.GetValues(enumType)) {
                list.Add(Enum.GetName(enumType, item), item.ToEString());
            }
            return list;
        }

        //public static SelectList ToSelectList<TEnum>(this TEnum enumObj,bool perfix=true,bool onlyFlag=false)
        //{
        //    var values = from TEnum e in Enum.GetValues(typeof(TEnum))
        //                 select new { Id = Convert.ToInt32(e), Name = GetDescription(typeof(TEnum),e.ToString()) };
        //    //if (onlyFlag)
        //    //    values = values.Where(v => IsIntType(Math.Log(v.Id, 2)));
        //   var t= values.ToList();
        //   var item = new { Id = 0, Name = "请选择..." };
        //   if (perfix)
        //   {
        //       t.Insert(0, item);
        //   }
        // return  new SelectList(t, "Id", "Name", enumObj);
        //} 

        static Hashtable enumDesciption = GetDescriptionContainer();

        static Hashtable GetDescriptionContainer() {
            enumDesciption = new Hashtable();
            return enumDesciption;
        }

        static void AddToEnumDescription(Type enumType) {
            enumDesciption.Add(enumType, GetEnumDic(enumType));
        }


        ///<summary>
        /// 返回 Dic&lt;枚举项，描述&gt;
        ///</summary>
        ///<param name="enumType">枚举的类型</param>
        ///<returns>Dic&lt;枚举项，描述&gt;</returns>
        public static Dictionary<string, string> GetEnumDic(Type enumType) {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            FieldInfo[] fieldinfos = enumType.GetFields();
            foreach (FieldInfo field in fieldinfos) {
                if (field.FieldType.IsEnum) {
                    Object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    dic.Add(field.Name, ((DescriptionAttribute)objs[0]).Description);
                }

            }

            return dic;
        }

        /// <summary>
        /// 根据枚举类型和枚举值获取枚举描述
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="enumText">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, string enumText) {
            if (String.IsNullOrEmpty(enumText))
                return null;
            if (!enumDesciption.ContainsKey(enumType))
                AddToEnumDescription(enumType);

            object value = enumDesciption[enumType];

            if (value != null && !String.IsNullOrEmpty(enumText)) {
                Dictionary<string, string> description = (Dictionary<string, string>)value;
                return description[enumText];
            }
            else
                throw new ApplicationException("不存在枚举的描述");

        }
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="enumName">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumName) {
            string _description = string.Empty;
            FieldInfo _fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] _attributes = _fieldInfo.GetDescriptAttr();
            if (_attributes != null && _attributes.Length > 0)
                _description = _attributes[0].Description;
            else
                _description = enumName.ToString();
            return _description;
        }
        /// <summary>
        /// 根据Description获取枚举
        /// 说明：
        /// 单元测试-->通过
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举</returns>
        public static T GetEnumName<T>(string description) {
            Type _type = typeof(T);
            foreach (FieldInfo field in _type.GetFields()) {
                DescriptionAttribute[] _curDesc = field.GetDescriptAttr();
                if (_curDesc != null && _curDesc.Length > 0) {
                    if (_curDesc[0].Description == description)
                        return (T)field.GetValue(null);
                }
                else {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }
        /// <summary>
        /// 将枚举转换为ArrayList
        /// 说明：
        /// 若不是枚举类型，则返回NULL
        /// 单元测试-->通过
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>ArrayList</returns>
        public static ArrayList ToArrayList(this Type type) {
            if (type.IsEnum) {
                ArrayList _array = new ArrayList();
                Array _enumValues = Enum.GetValues(type);
                foreach (Enum value in _enumValues) {
                    _array.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
                }
                return _array;
            }
            return null;
        }

        #endregion
    }
}
