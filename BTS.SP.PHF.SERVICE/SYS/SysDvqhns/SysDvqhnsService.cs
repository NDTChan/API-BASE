using BTS.SP.PHF.ENTITY.Helper;
using BTS.SP.PHF.ENTITY.Sys;
using BTS.SP.PHF.SERVICE.DM;
using BTS.SP.PHF.SERVICE.SERVICES;
using BTS.SP.TOOLS.BuildQuery.Result;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using static BTS.SP.PHF.SERVICE.SYS.SysDvqhns.SysDvqhnsVm;

namespace BTS.SP.PHF.SERVICE.SYS.SysDvqhns
{
    public interface ISysDvqhnsService : IService<SYS_DVQHNS>
    {
        List<DM_SYS_TUDIENVm.DM_DBHCVm> GetAllDBHC();
        PagedObj<ChoiceObj> GetCTMT(JObject jsonData, SysDvqhnsVm.ParamInput tblName);


    }
    public class SysDvqhnsService : Service<SYS_DVQHNS>, ISysDvqhnsService
    {
        private readonly IRepositoryAsync<SYS_DVQHNS> _repository;

        public SysDvqhnsService(IRepositoryAsync<SYS_DVQHNS> repository) : base(repository)
        {
            _repository = repository;
        }


        public List<DM_SYS_TUDIENVm.DM_DBHCVm> GetAllDBHC()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT * FROM DM_DBHC DM_DBHC ";

                        using (OracleDataReader oracleDataReader =
                            command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return null;
                            List<DM_SYS_TUDIENVm.DM_DBHCVm> lst = new List<DM_SYS_TUDIENVm.DM_DBHCVm>();
                            while (oracleDataReader.Read())
                            {
                                DM_SYS_TUDIENVm.DM_DBHCVm item = new DM_SYS_TUDIENVm.DM_DBHCVm();
                                item.MA_DBHC = oracleDataReader["MA_DBHC"].ToString();
                                item.MA_DBHC_CHA = oracleDataReader["MA_DBHC_CHA"].ToString();
                                item.TEN_DBHC = oracleDataReader["TEN_DBHC"].ToString();
                                item.Value = oracleDataReader["MA_DBHC"].ToString();
                                item.Text = oracleDataReader["TEN_DBHC"].ToString();

                                lst.Add(item);
                            }
                            return lst;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PagedObj<ChoiceObj> GetCTMT(JObject jsonData, SysDvqhnsVm.ParamInput objInput)
        {
            var result = new PagedObj<ChoiceObj>();
            var postData = ((dynamic)jsonData);
            var filtered = ((JObject)postData.filtered).ToObject<FilterObj<SysDvqhnsVm.SearchCTMT>>();
            var paged = ((JObject)postData.paged).ToObject<PagedObj<SYS_DVQHNS>>();
            try
            {
                using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["STCConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {

                        OracleCommand cmdCOUNT = connection.CreateCommand();
                        cmdCOUNT.CommandText = @"SELECT COUNT(" + objInput.FieldValue + ") FROM " + objInput.TableName + " WHERE 1=1 " + objInput.WhereClause;
                        // other codes
                        object countObj = cmdCOUNT.ExecuteScalar();
                        int numberOfRecords = 0;
                        if (countObj != null)
                        {
                            numberOfRecords = Convert.ToInt32(countObj);
                        }
                        result.currentPage = paged.currentPage;
                        result.itemsPerPage = paged.itemsPerPage;
                        result.takeAll = paged.takeAll;
                        result.totalItems = numberOfRecords;

                        var whereSubQuerry = "";
                        if (!string.IsNullOrEmpty(filtered.Summary))
                        {
                            whereSubQuerry += " AND (MA_CTMTQG = " + filtered.Summary + " OR TEN_CTMTQG = " + filtered.Summary + " )";
                        }
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"SELECT * FROM " + objInput.TableName
                            + " WHERE 1 = 1 " + whereSubQuerry
                            + " " + objInput.WhereClause
                            + " ORDER BY " + objInput.FieldValue
                            + " offset " + (paged.fromItem - 1) + " rows"
                            + " fetch next " + paged.itemsPerPage + " rows only";

                        using (OracleDataReader oracleDataReader =
                            command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (!oracleDataReader.HasRows) return null;
                            List<ChoiceObj> lst = new List<ChoiceObj>();
                            while (oracleDataReader.Read())
                            {
                                ChoiceObj item = new ChoiceObj();
                                item.Id  = int.Parse(oracleDataReader["ID"].ToString()) ;
                                item.Value = oracleDataReader[objInput.FieldValue].ToString();
                                item.Text = oracleDataReader[objInput.FieldText].ToString();
                                lst.Add(item);
                            }
                            result.Data = lst;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
