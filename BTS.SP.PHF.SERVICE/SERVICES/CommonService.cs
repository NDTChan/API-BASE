using BTS.SP.PHF.ENTITY.Helper;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BTS.SP.PHF.SERVICE.Services
{
    public class CommonService
    {
        public static ExcelPackage ExportData<T>(string urlFile,List<T> listData) where T : class
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof(ExportExcelAttribute);
            List<string> lstHeader = new List<string>();
            List<PropertyInfo> lstPropertis =new List<PropertyInfo>();
            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ExportExcelAttribute)customAttribute;
                    lstHeader.Add(validationAttribute.Description);
                    lstPropertis.Add(propertyInfo);
                }
            }
            using (var excelPackage = new ExcelPackage(new FileInfo(urlFile)))
            {
                ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add("export");
                int i = 0;
                foreach (var header in lstHeader)
                {
                    sheet.Cells[1, ++i].Value = header;
                }
                i = 2;
                sheet.InsertRow(i,listData.Count);
                foreach (var item in listData)
                {
                    int j = 0;
                    foreach (var pro in lstPropertis)
                    {
                        ++j;
                        sheet.Cells[i,j].Value = pro.GetValue(item);
                        if (pro.PropertyType == typeof(DateTime?) || pro.PropertyType == typeof(DateTime))
                        {
                            sheet.Cells[i, j].Style.Numberformat.Format = "dd-mm-yyyy";
                        }
                    }
                    i++;
                }
                excelPackage.Save();
                return excelPackage;
            }
        }

        public static MemoryStream ExportXML<T> (List<T> listData) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, listData);
            return stream;
        }
    }
}
