using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.DM
{
    public interface IDM_SYS_TUDIENService : IBaseService<PHF_SYS_TUDIEN>
    {
        //Add function here
        void BindingDataToExcel(string TenSysTuDien, ExcelWorksheet ws, List<PHF_SYS_TUDIEN> listSysTuDien);
    }

    public class DM_SYS_TUDIENService : BaseService<PHF_SYS_TUDIEN>, IDM_SYS_TUDIENService
    {
        private readonly IRepositoryAsync<PHF_SYS_TUDIEN> _repository;
        public DM_SYS_TUDIENService(IRepositoryAsync<PHF_SYS_TUDIEN> repository) : base(repository)
        {
            _repository = repository;
        }

        public void BindingDataToExcel(string TenSysTuDien, ExcelWorksheet ws, List<PHF_SYS_TUDIEN> listSysTuDien)
        {
            ws.Cells[1, 1].Value = "STT";
            ws.Cells[1, 2].Value = "Mã " + TenSysTuDien;
            ws.Cells[1, 3].Value = "Tên " + TenSysTuDien;
            ws.Cells[1, 1, 1, 6].Style.Font.Size = 12;
            ws.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 6].Style.Font.Name = "Time New Roman";
            ws.Cells[1, 1, 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            var NumOfRow = (listSysTuDien.Count + 1).ToString();
            string modelRange = "A1:D" + NumOfRow;
            var modelTable = ws.Cells[modelRange];
            // Assign borders
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Font.Name = "Time New Roman";
            int r = 2;
            for (int i = 0; i < listSysTuDien.Count; i++)
            {
                var item = listSysTuDien[i];
                ws.Cells[r + i, 1].Value = i + 1;
                ws.Cells[r + i, 2].Value = item.MA_TUDIEN;
                ws.Cells[r + i, 3].Value = item.TEN_TUDIEN;
            }
            ws.Column(1).AutoFit();
            ws.Column(2).AutoFit();
            ws.Column(3).AutoFit();
            ws.Column(4).AutoFit();
            ws.Column(5).AutoFit();
        }
    }
}