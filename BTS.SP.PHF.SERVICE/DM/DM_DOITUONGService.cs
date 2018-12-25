using BTS.SP.PHF.ENTITY.Dm;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Repository.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.PHF.SERVICE.DM
{
    public interface IDM_DOITUONGService : IBaseService<PHF_DM_DOITUONG>
    {
        //Add function here
        void BindingDataToExcel(ExcelWorksheet ws, List<PHF_DM_DOITUONG> listDoiTuong);
    }

    public class DM_DOITUONGService : BaseService<PHF_DM_DOITUONG>, IDM_DOITUONGService
    {
        private readonly IRepositoryAsync<PHF_DM_DOITUONG> _repository;
        public DM_DOITUONGService(IRepositoryAsync<PHF_DM_DOITUONG> repository) : base(repository)
        {
            _repository = repository;
        }

        public void BindingDataToExcel(ExcelWorksheet ws, List<PHF_DM_DOITUONG> listDoiTuong)
        {
            ws.Cells[1, 1].Value = "STT";
            ws.Cells[1, 2].Value = "Mã đối tượng";
            ws.Cells[1, 3].Value = "Tên đối tượng";
            ws.Cells[1, 4].Value = "Năm";
            ws.Cells[1, 5].Value = "Mã ĐVQHNS";
            ws.Cells[1, 1, 1, 6].Style.Font.Size = 12;
            ws.Cells[1, 1, 1, 6].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 6].Style.Font.Name = "Time New Roman";
            ws.Cells[1, 1, 1, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            var NumOfRow = (listDoiTuong.Count + 1).ToString();
            string modelRange = "A1:D" + NumOfRow;
            var modelTable = ws.Cells[modelRange];
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Font.Name = "Time New Roman";
            int r = 2;
            for (int i = 0; i < listDoiTuong.Count; i++)
            {
                var item = listDoiTuong[i];
                ws.Cells[r + i, 1].Value = i + 1;
                ws.Cells[r + i, 2].Value = item.MA_DOITUONG;
                ws.Cells[r + i, 3].Value = item.TEN_DOITUONG;
                ws.Cells[r + i, 4].Value = item.NAM.ToString();
                //ws.Cells[r + i, 4].Style.Numberformat.Format = "0.00";
                ws.Cells[r + i, 5].Value = item.MA_DVQHNS;
            }
            ws.Column(1).AutoFit();
            ws.Column(2).AutoFit();
            ws.Column(3).AutoFit();
            ws.Column(4).AutoFit();
            ws.Column(5).AutoFit();
        }
    }
}
