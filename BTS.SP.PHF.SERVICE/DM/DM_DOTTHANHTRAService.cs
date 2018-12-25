using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Repository.Pattern.Repositories;
using System.Collections.Generic;

namespace BTS.SP.PHF.SERVICE.DM
{
     public interface IDM_DOTTHANHTRAService : IBaseService<PHF_DM_DOTTHANHTRA>
    {
        //Add function here
        void BindingDataToExcel(ExcelWorksheet ws, List<PHF_DM_DOTTHANHTRA> listDotThanhTra);
    }

    public class DM_DOTTHANHTRAService : BaseService<PHF_DM_DOTTHANHTRA>, IDM_DOTTHANHTRAService
    {
        private readonly IRepositoryAsync<PHF_DM_DOTTHANHTRA> _repository;
        public DM_DOTTHANHTRAService(IRepositoryAsync<PHF_DM_DOTTHANHTRA> repository) : base(repository)
        {
            _repository = repository;
        }

        public void BindingDataToExcel(ExcelWorksheet ws, List<PHF_DM_DOTTHANHTRA> listDotThanhTra)
        {
            ws.Cells[1, 1].Value = "STT";
            ws.Cells[1, 2].Value = "Mã đợt";
            ws.Cells[1, 3].Value = "Tên đợt";
            ws.Cells[1, 4].Value = "Từ ngày";
            ws.Cells[1, 5].Value = "Đến ngày";
            ws.Cells[1, 1, 1, 6].Style.Font.Size = 12;
            ws.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 6].Style.Font.Name = "Time New Roman";
            ws.Cells[1, 1, 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            var NumOfRow = (listDotThanhTra.Count + 1).ToString();
            string modelRange = "A1:D" + NumOfRow;
            var modelTable = ws.Cells[modelRange];
            // Assign borders
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Font.Name = "Time New Roman";
            int r = 2;
            for (int i = 0; i < listDotThanhTra.Count; i++)
            {
                var item = listDotThanhTra[i];
                ws.Cells[r + i, 1].Value = i + 1;
                ws.Cells[r + i, 2].Value = item.MA_DOT;
                ws.Cells[r + i, 3].Value = item.TEN_DOT;
                ws.Cells[r + i, 4].Value = item.TU_NGAY.GetValueOrDefault().ToString("dd/MM/yyyy");
                ws.Cells[r + i, 5].Value = item.DEN_NGAY.GetValueOrDefault().ToString("dd/MM/yyyy");
            }
            ws.Column(1).AutoFit();
            ws.Column(2).AutoFit();
            ws.Column(3).AutoFit();
            ws.Column(4).AutoFit();
            ws.Column(5).AutoFit();
        }
    }
}
