using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BTS.SP.API.PHF.Utils
{
    public class DataReaderMap
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                        else if (prop.PropertyType == typeof(Int32))
                        {
                            prop.SetValue(obj, Int32.Parse(dr[prop.Name].ToString()), null);
                        }
                        else if (prop.PropertyType == typeof(Decimal))
                        {
                            prop.SetValue(obj, Decimal.Parse(dr[prop.Name].ToString()), null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}