using BTS.SP.API.ENTITY;
using BTS.SP.PHF.ENTITY;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.BIEU02;
using BTS.SP.PHF.SERVICE.SERVICES;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/bieu02")]
    [Route("{id?}")]
    public class Bieu02Controller : ApiController
    {
        private readonly IBIEU02Service _service;

        public Bieu02Controller(IBIEU02Service service)
        {
            _service = service;
        }
        [Route("Sumreport_HTML")]
        [HttpPost]
        public IHttpActionResult Sumreport_HTML(BIEU02Vm.InputPara parameter)
        {
            var result = new TransferObj();
            var data = new List<PHF_BIEU02>();
            try
            {
                data = ProcessingData(parameter);
                if (data.Count > 0)
                {
                    var obj = new BIEU02Vm.OutputData<PHF_BIEU02>();
                    var datapaged = data.OrderBy(x => x.Id).ToList();
                    obj.lstdata = datapaged.OrderBy(x => x.MA_DVQHNS).ThenBy(x => x.MA_CTMTQG).ThenBy(x => x.MA_CHUONG).ThenBy(x => x.MA_LOAI).ThenBy(x => x.MA_NGANHKT).ThenBy(x => x.MA_MUC).ThenBy(x =>x.MA_TIEUMUC).ToList();
                    result.Data = obj;
                    result.Status = true;
                    result.Message = "Ok";
                }
            }
            catch (Exception e)
            {
            }

            return Ok(result);
        }

        private List<PHF_BIEU02> ProcessingData(BIEU02Vm.InputPara p)
        {
            var result = new List<PHF_BIEU02>();
            try
            {
                using (STCContext context = new STCContext())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {

                        var pCongThuc = new OracleParameter("P_CONGTHUC", OracleDbType.NVarchar2, null, ParameterDirection.Input);
                        var pMaDBHC = new OracleParameter("P_MA_DBHC", OracleDbType.NVarchar2, p.para.P_MA_DBHC, ParameterDirection.Input);
                        var pTuNgayHL = new OracleParameter("P_TUNGAY_HL", OracleDbType.Date, p.para.P_TUNGAY_HL, ParameterDirection.Input);
                        var pDenNgayHL = new OracleParameter("P_DENNGAY_HL", OracleDbType.Date, p.para.P_DENNGAY_HL, ParameterDirection.Input);
                        var pTuNgayKS = new OracleParameter("P_TUNGAY_KS", OracleDbType.Date, p.para.P_TUNGAY_KS, ParameterDirection.Input);
                        var pDenNgayKS = new OracleParameter("P_DENNGAY_KS", OracleDbType.Date, p.para.P_DENNGAY_KS, ParameterDirection.Input);
                        var outRef = new OracleParameter("outRef", OracleDbType.RefCursor, ParameterDirection.Output);
                        var str = "BEGIN THANHTRA_B02(:P_CONGTHUC, :P_MA_DBHC, :P_TUNGAY_HL, :P_DENNGAY_HL, :P_TUNGAY_KS, :P_DENNGAY_KS,:outRef); END;";
                        context.Database.ExecuteSqlCommand(str, pCongThuc, pMaDBHC, pTuNgayHL, pDenNgayHL, pTuNgayKS, pDenNgayKS, outRef);
                        OracleDataReader reader = ((OracleRefCursor)outRef.Value).GetDataReader();
                        while (reader.Read())
                        {
                            decimal giaTriHachToan = 0;
                            PHF_BIEU02 record = new PHF_BIEU02();
                            //if (reader["ID"] != DBNull.Value) record.ID = int.Parse(reader["ID"].ToString());
                            if (reader["TEN_DVQHNS"] != DBNull.Value) record.TEN_DVQHNS = reader["TEN_DVQHNS"].ToString();
                            if (reader["MA_DVQHNS"] != DBNull.Value) record.MA_DVQHNS = reader["MA_DVQHNS"].ToString();
                            if (reader["MA_CTMTQG"] != DBNull.Value) record.MA_CTMTQG = reader["MA_CTMTQG"].ToString();
                            if (reader["MA_CHUONG"] != DBNull.Value) record.MA_CHUONG = reader["MA_CHUONG"].ToString();
                            if (reader["MA_LOAI"] != DBNull.Value) record.MA_LOAI = reader["MA_LOAI"].ToString();
                            if (reader["MA_NGANHKT"] != DBNull.Value) record.MA_NGANHKT = reader["MA_NGANHKT"].ToString();
                            if (reader["MA_MUC"] != DBNull.Value) record.MA_MUC = reader["MA_MUC"].ToString();
                            if (reader["MA_TIEUMUC"] != DBNull.Value) record.MA_TIEUMUC = reader["MA_TIEUMUC"].ToString();
                            decimal.TryParse(reader["SOTIEN"].ToString(), out giaTriHachToan);
                            record.SOTIEN = giaTriHachToan;
                            result.Add(record);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        [Route("ExportReport")]
        [HttpPost]
        public async Task<IHttpActionResult> ExportReport(List<PHF_BIEU02> exp)
        {
            if (exp != null && exp.Count > 0)
            {
                string urlFile = System.Web.Hosting.HostingEnvironment.MapPath("~/Template/BIEU02/Template.xlsx");
                string exportUrlFile = System.Web.Hosting.HostingEnvironment.MapPath("~/UploadFile/ExcelTemp/" + RequestContext.Principal.Identity.Name
                                                                                     + "_" + DateTime.Now.Ticks + ".xlsx");
                try
                {
                    using (var excelPackage = new ExcelPackage(new FileInfo(urlFile)))
                    {
                        ExcelWorksheet sheet = excelPackage.Workbook.Worksheets[1];
                        var startrow = 6;
                        for (int i = 0; i < exp.Count; i++)
                        {
                            var item = exp[i];
                            sheet.Cells[startrow + i, 1].Value = i + 1;
                            sheet.Cells[startrow + i, 2].Value = item.MA_DVQHNS;
                            sheet.Cells[startrow + i, 3].Value = item.TEN_DVQHNS;
                            sheet.Cells[startrow + i, 4].Value = item.MA_CTMTQG;
                            sheet.Cells[startrow + i, 5].Value = item.MA_CHUONG;
                            sheet.Cells[startrow + i, 6].Value = item.MA_LOAI;
                            sheet.Cells[startrow + i, 7].Value = item.MA_NGANHKT;
                            sheet.Cells[startrow + i, 8].Value = item.MA_MUC;
                            sheet.Cells[startrow + i, 9].Value = item.MA_TIEUMUC;
                            sheet.Cells[startrow + i, 10].Value = item.SOTIEN;
                        }

                        excelPackage.SaveAs(new FileInfo(exportUrlFile));
                        var result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(excelPackage.GetAsByteArray())
                        };
                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "export_THANHTRA_BIEU02.xlsx"
                        };
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        var response = ResponseMessage(result);
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    WriteLogs.LogError(ex);
                    return InternalServerError();
                }
            }
            return Ok(exp);
        }
    }
}