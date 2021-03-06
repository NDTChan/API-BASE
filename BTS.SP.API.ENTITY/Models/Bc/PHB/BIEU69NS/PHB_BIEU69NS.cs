﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY.Models.Bc.PHB.BIEU69NS
{
    public class PHB_BIEU69NS:DataInfoEntity
    {
        [Required]
        [StringLength(50)]
        public string REFID { get; set; }

        [StringLength(3)]
        [Required]
        public string MA_CHUONG { get; set; }

        [StringLength(10)]
        [Required]
        public string MA_QHNS { get; set; }

        [StringLength(255)]
        public string TEN_QHNS { get; set; }

        [StringLength(10)]
        public string MA_QHNS_CHA { get; set; }

        public int NAM_BC { get; set; }

        [Description("0:Năm  | 101:Quý 1 | 102:Quý 2 | 103:Quý 3 | 104:Quý 4 | 201:6 tháng đầu năm | 202 : 6 tháng cuối năm")]
        public int KY_BC { get; set; }

        [Description("1: Đã duyệt | 0:chưa duyệt")]
        public int TRANG_THAI { get; set; }

        public DateTime NGAY_TAO { get; set; }

        [StringLength(150)]
        [Required]
        public string NGUOI_TAO { get; set; }

        public DateTime? NGAY_SUA { get; set; }

        [StringLength(150)]
        public string NGUOI_SUA { get; set; }
    }
}
