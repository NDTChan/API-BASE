using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.UTILS
{
    public static class ClassHelper
    {
        public static string GetTableName<T>()
        {
            var type = typeof(T);
            return type.GetTableName();
        }

        public static string GetTableName(this Type _type)
        {
            var result = _type.Name;
            var dataFieldAttributes = _type.GetCustomAttributes(typeof(TableAttribute), false) as TableAttribute[];
            if (dataFieldAttributes.Length > 0)
            {
                result = dataFieldAttributes[0].Name;
            }
            return result;
        }

        public static string GetColumnName(this PropertyInfo _property)
        {
            var result = _property.Name;
            if (Attribute.IsDefined(_property, typeof(ColumnAttribute)))
            {
                var attribute = Attribute.GetCustomAttribute(_property, typeof(ColumnAttribute)) as ColumnAttribute;
                result = attribute.Name;
            }
            return result;
        }

        public static string GetColumnName<T>(Expression<Func<T>> _propertyExpression)
        {
            var property = (_propertyExpression.Body as MemberExpression).Member as PropertyInfo;
            var result = property.GetColumnName();
            return result;
        }

        #region Property & Attribute

        /// <summary>
        /// get property's PropertyInfo
        /// use: GetProperty(()=>obj.property)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_propertyExpression"></param>
        /// <returns></returns>
        public static PropertyInfo GetProperty<T>(Expression<Func<T>> _propertyExpression)
        {
            var result = (_propertyExpression.Body as MemberExpression).Member as PropertyInfo;
            return result;
        }

        /// <summary>
        /// get property's PropertyInfo and it's value
        /// use: GetPropertyAndValue(()=>obj.property)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_propertyExpression"></param>
        /// <returns>ExpandoObject{Property, Value}</returns>
        public static dynamic GetPropertyAndValue<T>(Expression<Func<T>> _propertyExpression)
        {
            var property = (_propertyExpression.Body as MemberExpression).Member as PropertyInfo;
            var value = _propertyExpression.Compile()();
            /*dynamic result = new { Property = property, Value = value };*/
            dynamic result = new ExpandoObject();
            result.Property = property;
            result.Value = value;
            return result;
        }

        /// <summary>
        /// get property name
        /// use: GetPropertyName(()=>obj.property)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_propertyExpression"></param>
        /// <returns>property name</returns>
        public static string GetPropertyName<T>(Expression<Func<T>> _propertyExpression)
        {
            return (_propertyExpression.Body as MemberExpression).Member.Name;
        }

        /// <summary>
        /// get property value
        /// </summary>
        /// <param name="_object"></param>
        /// <param name="_propertyName"></param>
        /// <returns></returns>
        public static dynamic GetPropertyValue(this object _object, string _propertyName)
        {
            if (_object == null || String.IsNullOrEmpty(_propertyName))
            {
                return null;
            }
            else
            {
                Type type = _object.GetType();
                PropertyInfo property = type.GetProperty(_propertyName);
                if (property == null)
                {
                    return null;
                }
                else
                {
                    object result = property.GetValue(_object, null);
                    return result;
                }
            }
        }

        #endregion
    }
}
