using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BTS.SP.API.ENTITY;
using System.ComponentModel;

namespace BTS.SP.API.ENTITY.Models.Dm
{
    [Table("DM_IDBUILDER")]
    public class DM_IDBUILDER : DataInfoEntity
    {
        [Column("MA_CHUNGTU")]
        [StringLength(50)]
        [Description("Mã chứng từ")]
        public string MA_CHUNGTU { get; set; }

        [Column("NGAY_CHUNGTU")]
        [Description("Ngày chứng từ")]
        public Nullable<DateTime> NGAY_CHUNGTU { get; set; }

        [Column("TYPE")]
        [StringLength(100)]
        public string Type { get; set; }

        [Column("CODE")]
        [StringLength(100)]
        public string Code { get; set; }

        [Column("CURRENT")]
        [StringLength(10)]
        public string Current { get; set; }

        public string GenerateNumber()
        {
            var result = "";
            int number;
            var length = Current.Length;
            if (int.TryParse(Current, out number))
            {
                result = string.Format("{0}", number + 1);
                result = AddString(result, length, "0");
            }
            return result;
        }
        public string GenerateChar()
        {
            var result = "";
            char newChar = Convert.ToChar(Current);
            newChar++;
            if ((int)newChar > 90)
            {
                return result;
            }
            result = newChar.ToString();
            return result;
        }
        public string AddString(string input, int length, string character)
        {
            var result = input;
            while (result.Length < length)
            {
                result = string.Format("{0}{1}", character, result);
            }
            return result;
        }
    }
}