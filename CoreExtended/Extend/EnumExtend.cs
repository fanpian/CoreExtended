using System;
using System.Collections.Generic;
using System.Text;

namespace CoreExtended.Extend
{
    /// <summary>
    /// 枚举类型扩展
    /// </summary>
    public static class EnumExtend
    {
        /// <summary>
        /// 获取枚举类型文本值
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="enum">枚举</param>
        /// <param name="value">枚举值</param>
        /// <returns>存在就返回正确值，不存在返回未知</returns>
        public static string GetEnumText(this Enum @enum)
        {
            return @enum?.ToString("G");
        }

        /// <summary>
        /// 获取枚举类型文本值
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns>存在就返回正确值，不存在返回未知</returns>
        public static string GetEnumText<TEnum>(int value)
        {
            return GetEnumText(typeof(TEnum), value);
        }

        /// <summary>
        /// 获取枚举类型文本值
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
        /// <returns>存在就返回正确值，不存在返回未知</returns>
        public static string GetEnumText<TEnum>(string value)
        {
            return GetEnumText(typeof(TEnum), value);
        }

        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="value">枚举值或者枚举的常数</param>
        /// <returns>存在就返回正确值，不存在返回未知</returns>
        public static string GetEnumText(Type type, string value)
        {
            if (!int.TryParse(value, out int result))
            {
                result = -1;
            }
            return GetEnumText(type, result);
        }

        /// <summary>
        /// 获取枚举类型文本值
        /// </summary>
        /// <returns>存在就返回正确值，不存在返回未知</returns>
        public static string GetEnumText(Type type, int value)
        {
            return type?.GetEnumName(value) ?? "未知";
        }

        /// <summary>
        /// 获取枚举类型的字典数据
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictionary<TEnum>()
        {
            return GetDictionary(typeof(TEnum));
        }

        /// <summary>
        /// 获取枚举类型的字典数据
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictionary(Type type)
        {
            if (type == null || !type.IsEnum)
            {
                throw new Exception($"{type?.FullName},不是枚举类型");
            }
            Array array = type.GetEnumValues();
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (int val in array)
            {
                dic.Add(val, type.GetEnumName(val));
            }
            return dic;
        }
    }
}
