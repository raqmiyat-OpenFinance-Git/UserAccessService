
using Entities.Master;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.Services
{
    public class CountryMasterMakerService : ICountryMasterMakerService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public CountryMasterMakerService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<CountryMakerModel> GetDetails()
        {
            List<CountryMakerModel> countryList = new List<CountryMakerModel>();
            try
            {


                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_select_country_master", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        CountryMakerModel objUser = new CountryMakerModel();
                        objUser.COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString());
                        objUser.COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString();
                        objUser.COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString();
                        objUser.CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString();
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.STATUS = objReader["STATUS"].ToString();
                        countryList.Add(objUser);
                    }

                }
                return countryList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_Insert_Details_Charge_Master_Maker");
            }
            return countryList;


        }
        public string AddCountry(CountryMakerModel country)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand? Command = null;


                Command = sqlHelper.GetCommandObject("frm_sp_insert_update_country_master", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = country.COUNTRY_CODE;

                Command.Parameters.Add(new SqlParameter("@COUNTRY_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = country.COUNTRY_NAME;

                Command.Parameters.Add(new SqlParameter("@currency_code", SqlDbType.VarChar));
                Command.Parameters[2].Value = country.CURRENCY_CODE;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[3].Value = country.ACTION;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[4].Value = country.ACTION_BY;

                Command.Parameters.Add(new SqlParameter("@COUNTRY_ID", SqlDbType.Int));
                Command.Parameters[5].Value = 0;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_insert_update_country_master");
                Output_Desc = ex.Message;
            }
            return Output_Desc;

        }

        public IEnumerable<CountryMakerModel> GetCheckerDetails()
        {
            List<CountryMakerModel> countryList = new List<CountryMakerModel>();

            try
            {


                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_country_master_check", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        CountryMakerModel objUser = new CountryMakerModel();
                        objUser.COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString());
                        objUser.COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString();
                        objUser.COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString();
                        objUser.CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["CREATED_On"].ToString());
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.Created_By = objReader["CREATED_By"].ToString();
                        countryList.Add(objUser);
                    }

                }
                return countryList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_country_master_check");
            }
            return countryList;
        }

        public CountryMakerModel GetCheckIndividualDetails(string Id)
        {
            CountryMakerModel objUser = new CountryMakerModel();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_Country_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.NVarChar));
                Command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objUser.COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString());
                        objUser.COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString();
                        objUser.COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString();
                        objUser.CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["CREATED_On"].ToString());
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.Created_By = objReader["CREATED_By"].ToString();

                    }

                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_Country_master_check");
            }
            return objUser;


        }


        public string ApproveOrRejectCountry(CountryMakerModel country)
        {
            var Output_Desc = string.Empty;
            try
            {
                DbCommand Command = null;

                Command = sqlHelper.GetCommandObject("frm_sp_approve_country_master_check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_ID", SqlDbType.Int));
                Command.Parameters[0].Value = country.COUNTRY_ID;

                Command.Parameters.Add(new SqlParameter("@country_code", SqlDbType.VarChar));
                Command.Parameters[1].Value = country.COUNTRY_CODE;

                Command.Parameters.Add(new SqlParameter("@country_name", SqlDbType.VarChar));
                Command.Parameters[2].Value = country.COUNTRY_NAME;

                Command.Parameters.Add(new SqlParameter("@currency_code", SqlDbType.VarChar));
                Command.Parameters[3].Value = country.CURRENCY_CODE;

                Command.Parameters.Add(new SqlParameter("@ACTION", SqlDbType.VarChar));
                Command.Parameters[4].Value = country.ACTION;

                Command.Parameters.Add(new SqlParameter("@Approved_By", SqlDbType.VarChar));
                Command.Parameters[5].Value = country.APPROVED_BY;

                Command.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));
                Command.Parameters[6].Value = country.ISAPPROVED;

                SqlParameter prm1 = new SqlParameter("@Output_Desc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                Output_Desc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_approve_country_master_check");
            }
            return Output_Desc;
        }

        public CountryMakerModel GetMakerIndividualDetails(string Id)
        {
            CountryMakerModel objUser = new CountryMakerModel();
            try
            {


                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_ind_country_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.NVarChar));
                Command.Parameters[0].Value = Id;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        objUser.COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString());
                        objUser.COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString();
                        objUser.COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString();
                        objUser.CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString();
                        objUser.Created_On = Convert.ToDateTime(objReader["CREATED_On"].ToString());
                        objUser.ACTION = objReader["ACTION"].ToString();
                        objUser.Created_By = objReader["CREATED_By"].ToString();

                    }
                }
                return objUser;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_ind_country_master");
            }
            return objUser;
        }
        public string DeleteCountry(CountryMakerModel country)
        {
            var OutputDesc = string.Empty;
            try
            {
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_delete_country_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = country.COUNTRY_CODE;

                Command.Parameters.Add(new SqlParameter("@COUNTRY_NAME", SqlDbType.VarChar));
                Command.Parameters[1].Value = country.COUNTRY_NAME;

                Command.Parameters.Add(new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar));
                Command.Parameters[2].Value = country.CURRENCY_CODE;

                Command.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar));
                Command.Parameters[3].Value = country.ACTION;

                Command.Parameters.Add(new SqlParameter("@ACTION_BY", SqlDbType.VarChar));
                Command.Parameters[4].Value = country.ACTION_BY;

                SqlParameter prm1 = new SqlParameter("@OutputDesc", SqlDbType.VarChar, 500);
                prm1.Direction = ParameterDirection.Output;
                Command.Parameters.Add(prm1);

                int i = sqlHelper.ExecuteNonQuery(Command);
                OutputDesc = prm1.Value == null ? string.Empty : Convert.ToString(prm1.Value);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_delete_country_master");
                OutputDesc = ex.Message;
            }
            return OutputDesc;
        }

        public IEnumerable<CountryMakerModel> GetFilterMaker(string Search_Country_Code)
        {
            List<CountryMakerModel> countryMakers = new List<CountryMakerModel>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_filter_details_country_master", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = Search_Country_Code;



                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                        countryMakers.Add(new CountryMakerModel
                        {
                            COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString()),
                            COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString(),
                            COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString(),
                            CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString(),
                            ACTION = objReader["ACTION"].ToString(),
                            STATUS = objReader["STATUS"].ToString(),
                        });
                }

                return countryMakers;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_filter_details_country_master");
            }
            return countryMakers;

        }
        public IEnumerable<CountryMakerModel> GetFilterCheck(string Search_Country_Code)
        {
            List<CountryMakerModel> countryChecker = new List<CountryMakerModel>();
            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;
                Command = sqlHelper.GetCommandObject("frm_sp_get_filter_details_country_master_Check", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar));
                Command.Parameters[0].Value = Search_Country_Code;



                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                        countryChecker.Add(new CountryMakerModel
                        {
                            COUNTRY_ID = Convert.ToInt32(objReader["COUNTRY_ID"].ToString()),
                            COUNTRY_CODE = objReader["COUNTRY_CODE"].ToString(),
                            COUNTRY_NAME = objReader["COUNTRY_NAME"].ToString(),
                            CURRENCY_CODE = objReader["CURRENCY_CODE"].ToString(),
                            ACTION = objReader["ACTION"].ToString(),
                        });
                }

                return countryChecker;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_filter_details_country_master_Check");
            }
            return countryChecker;

        }
        public IEnumerable<CurrencyCode> getCurrencyCode()
        {
            List<CurrencyCode> objCurrencyList = new List<CurrencyCode>();


            try
            {
                IDataReader objReader = null;
                DbCommand Command = null;


                Command = sqlHelper.GetCommandObject("frm_sp_get_Currency_List", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {

                        CurrencyCode objCurrencyDtls = new CurrencyCode();

                        objCurrencyDtls.CURRENCY_CODE = Convert.ToString(objReader["Currency_Code"]);

                        objCurrencyList.Add(objCurrencyDtls);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frm_sp_get_Currency_List");
            }
            return objCurrencyList;
        }
    }
}



