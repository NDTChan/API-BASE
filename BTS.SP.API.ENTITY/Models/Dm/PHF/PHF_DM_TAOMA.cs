using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTS.SP.API.ENTITY.Models.Dm.PHF
{
        [Table("PHF_DM_TAOMA")]
        public class PHF_DM_TAOMA : DataInfoEntityPHF
        {
            [Column("LOAIMA")]
            [StringLength(50)]
            public string LoaiMa { get; set; }

            [Column("MA")]
            [StringLength(50)]
            public string Ma { get; set; }

            [Column("HIENTAI")]
            [StringLength(10)]
            public string HienTai { get; set; }

            [Column("MADONVI")]
            [StringLength(50)]
            public string MaDonVi { get; set; }
            public string GenerateNumber()
            {
                var result = "";
                int number;
                var length = HienTai.Length;
                if (int.TryParse(HienTai, out number))
                {
                    result = string.Format("{0}", number + 1);
                    result = AddString(result, length, "0");
                }
                return result;
            }
            public string GenerateChar()
            {
                var result = "";
                char newChar = Convert.ToChar(HienTai);
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