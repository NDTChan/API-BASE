using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY
{
    public enum TypeVoucher
    {
        PHC_NCT //PHC - Nhập chứng từ kế 
    }
    public enum DAU
    {
        CONG = 1,
        TRU = 2
    }
    public enum CODERECIPE
    {
        CH = 1,
        L = 2,
        KH = 3,
        TM = 5,
        MC = 4,
    }
    public enum CHITIEUBAOCAOTHEONDKT
    {
        THU =1,
        CHI =2
    }
    public enum LOAIDUTOAn
    {
        DAUNAM = 1,
        BOSUNG = 2,
        DIEUCHINH = 3,
        HUY = 4,
    }
    public enum PHANHE
    {
        A,
        B,
        C,
        D,
    }
    public enum CONGCHA
    {
        CO = 1,
        KHONG = 2,
    }
    public enum ANHIEN
    {
        AN = 1,
        HIEN= 2,
    }
    public enum TRANGTHAICHITIEU
    {
        S , // sum(cha)
        C, // con
    }
    public enum TRANGTHAICHITIEUCOL
    {
        A, // sum(cha)
        B, // con
    }
}
