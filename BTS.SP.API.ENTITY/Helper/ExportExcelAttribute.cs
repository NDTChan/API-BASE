using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Helper
{
    public class ExportExcelAttribute: DescriptionAttribute
    {
        public ExportExcelAttribute()
        {
            
        }
        public ExportExcelAttribute(string description)
        {
            this.DescriptionValue = description;
        }
    }
}
