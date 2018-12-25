using BTS.SP.API.ENTITY;
using BTS.SP.PHF.ENTITY.Nv;
using BTS.SP.PHF.SERVICE.NV.BIEU06;
using BTS.SP.PHF.SERVICE.SERVICES;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BTS.SP.API.PHF.Controllers.NGHIEPVU
{
    [RoutePrefix("api/nv/bieu06")]
    [Route("{id?}")]
    public class Bieu06Controller : ApiController
    {
        private readonly IBIEU06Service _service;

        public Bieu06Controller(IBIEU06Service service)
        {
            _service = service;
        }
        [Route("GetData")]
        [HttpPost]
        public IHttpActionResult GetData(BIEU06Vm.InputPara parameter)
        {
            var result = new TransferObj();
            var data = new List<PHF_BIEU06>();
            try
            {
                data = ProcessingData(parameter);
                if (data.Count > 0)
                {
                    var p = new BIEU06Vm.Paged();
                    var obj = new BIEU06Vm.OutputData<PHF_BIEU06>();
                    var datapaged = data.OrderBy(x => x.Id).Skip((parameter.paged.currentPage - 1) * parameter.paged.itemsPerPage).Take(parameter.paged.itemsPerPage).ToList();
                    obj.lstdata = datapaged.OrderBy(x => x.MA_NGUON_NSNN).ThenBy(x => x.MA_CHUONG).ThenBy(x => x.MA_LOAI).ThenBy(x => x.MA_KHOAN).ThenBy(x => x.MA_MUC).ThenBy(x => x.MA_TIEUMUC).ThenBy(x => x.MA_DVQHNS).ToList();
                    p = parameter.paged;
                    p.totalItems = data.Count();
                    p.totalPage = (parameter.paged.totalItems / parameter.paged.itemsPerPage) + (parameter.paged.totalItems % parameter.paged.itemsPerPage == 0 ? 0 : 1);
                    p.fromItem = (parameter.paged.currentPage - 1) * parameter.paged.itemsPerPage + 1;
                    p.toItem = parameter.paged.currentPage * parameter.paged.itemsPerPage;
                    if (p.toItem > p.totalItems)
                    {
                        p.toItem = p.totalItems;
                    }

                    obj.paged = p;

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

        private List<PHF_BIEU06> ProcessingData(BIEU06Vm.InputPara p)
        {
            var result = new List<PHF_BIEU06>();
            try
            {
                using (STCContext context = new STCContext())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {

                        var pCongThuc = new OracleParameter("P_CONGTHUC", OracleDbType.NVarchar2, null, ParameterDirection.Input);
                        var pTuNgayHL = new OracleParameter("TUNGAY_HL", OracleDbType.Date, p.para.P_TUNGAY_HL, ParameterDirection.Input);
                        var pDenNgayHL = new OracleParameter("DENNGAY_HL", OracleDbType.Date, p.para.P_DENNGAY_HL, ParameterDirection.Input);
                        var pTuNgayKS = new OracleParameter("TUNGAY_KS", OracleDbType.Date, p.para.P_TUNGAY_KS, ParameterDirection.Input);
                        var pDenNgayKS = new OracleParameter("DENNGAY_KS", OracleDbType.Date, p.para.P_DENNGAY_KS, ParameterDirection.Input);
                        var outRef = new OracleParameter("outRef", OracleDbType.RefCursor, ParameterDirection.Output);
                        var str = "BEGIN PHF_TT_BIEU06(:P_CONGTHUC, :TUNGAY_KS, :DENNGAY_KS, :TUNGAY_HL, :DENNGAY_HL,:outRef); END;";
                        context.Database.ExecuteSqlCommand(str, pCongThuc, pTuNgayKS, pDenNgayKS, pTuNgayHL, pDenNgayHL, outRef);
                        OracleDataReader reader = ((OracleRefCursor)outRef.Value).GetDataReader();
                        while (reader.Read())
                        {
                            decimal giaTriHachToan = 0;
                            PHF_BIEU06 record = new PHF_BIEU06();
                            if (reader["ID"] != DBNull.Value) record.Id = int.Parse(reader["ID"].ToString());
                            if (reader["TEN_DVQHNS"] != DBNull.Value) record.TEN_DVQHNS = reader["TEN_DVQHNS"].ToString();
                            if (reader["MA_DVQHNS"] != DBNull.Value) record.MA_DVQHNS = reader["MA_DVQHNS"].ToString();
                            if (reader["MA_NGUON_NSNN"] != DBNull.Value) record.MA_NGUON_NSNN = reader["MA_NGUON_NSNN"].ToString();
                            if (reader["MA_CHUONG"] != DBNull.Value) record.MA_CHUONG = reader["MA_CHUONG"].ToString();
                            if (reader["MA_LOAI"] != DBNull.Value) record.MA_LOAI = reader["MA_LOAI"].ToString();
                            if (reader["MA_KHOAN"] != DBNull.Value) record.MA_KHOAN = reader["MA_KHOAN"].ToString();
                            if (reader["MA_MUC"] != DBNull.Value) record.MA_MUC = reader["MA_MUC"].ToString();
                            if (reader["MA_TIEUMUC"] != DBNull.Value) record.MA_TIEUMUC = reader["MA_TIEUMUC"].ToString();
                            if (reader["NOI_DUNG"] != DBNull.Value) record.NOI_DUNG = reader["NOI_DUNG"].ToString();
                            decimal.TryParse(reader["SO_TIEN"].ToString(), out giaTriHachToan);
                            record.SO_TIEN = giaTriHachToan;
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
    }
}