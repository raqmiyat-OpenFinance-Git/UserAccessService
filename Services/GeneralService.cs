using Dapper;
using Entities.General;
using Entities.GeneralModel;
using OpenFinanceWebApi.NLogService;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace OpenFinanceWebApi.IServices
{
    public class GeneralService : IGeneralService
    {
        readonly SqlHelper sqlHelper = new SqlHelper(ConfigManager.getDBConnection());
        readonly SqlHelper sqlHelperFrameWrk = new SqlHelper(ConfigManager.getFrameworkDBConnection());
        private readonly NLogWebApiService _logger;
        public GeneralService(NLogWebApiService logger)
        {
            _logger = logger;
        }
        public IEnumerable<General> GetGeneralList(string generalType)
        {
            List<General> generalList = new List<General>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("ipp_sp_sel_generallist_netcore", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@GeneralType", SqlDbType.VarChar));
                Command.Parameters[0].Value = generalType;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        General general = new General();
                        general.general_list_code = objReader["General_List_Code"] == null ? string.Empty : Convert.ToString(objReader["General_List_Code"]);
                        general.general_desc = objReader["General_Desc"] == null ? string.Empty : Convert.ToString(objReader["General_Desc"]);
                        generalList.Add(general);
                    }
                    return generalList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_sel_generallist_netcore");
            }
            return generalList;
        }
        public IEnumerable<General> GetGeneralListforChrgMaster(string generalType, string ActionType)
        {
            List<General> generalList = new List<General>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("ipp_sp_sel_generallist_netcore_For_ChrgMaster", CommandType.StoredProcedure);

                Command.Parameters.Add(new SqlParameter("@GeneralType", SqlDbType.VarChar));
                Command.Parameters[0].Value = generalType;
                Command.Parameters.Add(new SqlParameter("@ActionType", SqlDbType.VarChar));
                Command.Parameters[1].Value = ActionType;

                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        General general = new General();
                        general.general_list_code = objReader["General_List_Code"] == null ? string.Empty : Convert.ToString(objReader["General_List_Code"]);
                        general.general_desc = objReader["General_Desc"] == null ? string.Empty : Convert.ToString(objReader["General_Desc"]);
                        generalList.Add(general);
                    }
                    return generalList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_sel_generallist_netcore_For_ChrgMaster");
            }
            return generalList;
        }
        public string GetNext_ENQ_SEQ(string instrName)
        {
            string returnValue = string.Empty;
            try
            {
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("IPP_sp_get_next_ENQ_SEQ_No", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@InstrName", SqlDbType.VarChar));
                Command.Parameters[0].Value = instrName;
                returnValue = (string)sqlHelper.ExecuteScalar(Command);
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
                _logger.Error(ex, "IPP_sp_get_next_ENQ_SEQ_No");
                //throw ex;
            }
            return returnValue;
        }
        public string GetNextMesageID(string instrName)
        {
            string returnValue = string.Empty;
            try
            {
                DbCommand? Command;

                Command = sqlHelper.GetCommandObject("IPP_sp_get_next_messageid", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@InstrName", SqlDbType.VarChar));
                Command.Parameters[0].Value = instrName;
                returnValue = (string)sqlHelper.ExecuteScalar(Command);
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
                _logger.Error(ex, "IPP_sp_get_next_messageid");
            }
            return returnValue;
        }

        public IEnumerable<BankSwiftCode> GetBankSwiftCode()
        {
            List<BankSwiftCode> bankSwiftCodeList = new List<BankSwiftCode>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Bank_Swift_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankSwiftCode bankSwiftCode = new BankSwiftCode();
                        bankSwiftCode.BankCode = Convert.ToString(objReader["Value1"]);
                        bankSwiftCode.SwiftCode = Convert.ToString(objReader["Text1"]);
                        bankSwiftCode.ElevenCode = Convert.ToString(objReader["ElevenCode"]);
                        //bankSwiftCode.IsOnBoardBatch = Convert.ToString(objReader["IsOnBoardBatch"]);
                        //bankSwiftCode.IsOnBoardRealTime =Convert.ToString(objReader["IsOnBoardRealTime"]);
                        bankSwiftCodeList.Add(bankSwiftCode);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Bank_Swift_Codes");
            }
            return bankSwiftCodeList;
        }

        public IEnumerable<BankSwiftCode> GetRealTimeBankSwiftCode()
        {
            List<BankSwiftCode> bankSwiftCodeList = new List<BankSwiftCode>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Realtime_Bank_Swift_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankSwiftCode bankSwiftCode = new BankSwiftCode();
                        bankSwiftCode.BankCode = Convert.ToString(objReader["Value1"]);
                        bankSwiftCode.SwiftCode = Convert.ToString(objReader["Text1"]);
                        bankSwiftCode.ElevenCode = Convert.ToString(objReader["ElevenCode"]);
                        //bankSwiftCode.IsOnBoardBatch = Convert.ToString(objReader["IsOnBoardBatch"]);
                        //bankSwiftCode.IsOnBoardRealTime =Convert.ToString(objReader["IsOnBoardRealTime"]);
                        bankSwiftCodeList.Add(bankSwiftCode);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Bank_Swift_Codes");
            }
            return bankSwiftCodeList;
        }
        public IEnumerable<CategoryPurposeCode> GetCategoryPurposeCodes()
        {
            List<CategoryPurposeCode> categoryPurposeCodesList = new List<CategoryPurposeCode>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Category_Purpose_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        CategoryPurposeCode categoryPurposeCodes = new CategoryPurposeCode();
                        categoryPurposeCodes.Code = objReader["Value1"].ToString();
                        categoryPurposeCodes.Description = objReader["Text1"].ToString();
                        categoryPurposeCodesList.Add(categoryPurposeCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Category_Purpose_Codes");
            }
            return categoryPurposeCodesList;
        }
        public IEnumerable<IssuerTypeCodes> GetIssuerTypeCodes()
        {
            List<IssuerTypeCodes> issuerTypeCodesList = new List<IssuerTypeCodes>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Issuer_Type_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        IssuerTypeCodes issuerTypeCodes = new IssuerTypeCodes();
                        issuerTypeCodes.Code = objReader["Value1"].ToString();
                        issuerTypeCodes.Description = objReader["Text1"].ToString();
                        issuerTypeCodesList.Add(issuerTypeCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Issuer_Type_Codes");
            }
            return issuerTypeCodesList;
        }
        public IEnumerable<EconomicActivityCodes> GetEconomicActivityCodes()
        {
            List<EconomicActivityCodes> economicActivityCodesList = new List<EconomicActivityCodes>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Economic_Activity_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        EconomicActivityCodes economicActivityCodes = new EconomicActivityCodes();
                        economicActivityCodes.Code = objReader["Value1"].ToString();
                        economicActivityCodes.Description = objReader["Text1"].ToString();
                        economicActivityCodesList.Add(economicActivityCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Economic_Activity_Codes");
            }
            return economicActivityCodesList;
        }
        public IEnumerable<ChannelInformationIdentifierCodes> GetChannelInformationIdentifierCodes()
        {
            List<ChannelInformationIdentifierCodes> channelInformationIdentifierCodesList = new List<ChannelInformationIdentifierCodes>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Channel_Information_Identifier_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ChannelInformationIdentifierCodes channelInformationIdentifierCodes = new ChannelInformationIdentifierCodes();
                        channelInformationIdentifierCodes.Code = objReader["Value1"].ToString();
                        channelInformationIdentifierCodes.Description = objReader["Text1"].ToString();
                        channelInformationIdentifierCodesList.Add(channelInformationIdentifierCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Channel_Information_Identifier_Codes");
            }
            return channelInformationIdentifierCodesList;
        }
        public IEnumerable<AccountTypeIdentifierCodes> GetAccountTypeIdentifierCodes()
        {
            List<AccountTypeIdentifierCodes> accountTypeIdentifierCodesList = new List<AccountTypeIdentifierCodes>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Account_Type_Identifier_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        AccountTypeIdentifierCodes accountTypeIdentifierCodesv = new AccountTypeIdentifierCodes();
                        accountTypeIdentifierCodesv.Code = objReader["Value1"].ToString();
                        accountTypeIdentifierCodesv.Description = objReader["Text1"].ToString();
                        accountTypeIdentifierCodesList.Add(accountTypeIdentifierCodesv);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Account_Type_Identifier_Codes");
            }
            return accountTypeIdentifierCodesList;
        }
        public IEnumerable<MasterCurrencyCodes> GetMasterCurrencyCodes()
        {
            List<MasterCurrencyCodes> masterCurrencyCodesList = new List<MasterCurrencyCodes>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Master_Currency_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        MasterCurrencyCodes masterCurrencyCodes = new MasterCurrencyCodes();
                        masterCurrencyCodes.Code = objReader["Value1"].ToString();
                        masterCurrencyCodes.Name = objReader["Text1"].ToString();
                        masterCurrencyCodesList.Add(masterCurrencyCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Master_Currency_Codes");
            }
            return masterCurrencyCodesList;
        }
        public IEnumerable<ReversalReasonIdentifierCodes> GetReversalReasonIdentifierCodes()
        {
            List<ReversalReasonIdentifierCodes> reversalReasonIdentifierCodesList = new List<ReversalReasonIdentifierCodes>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Reversal_Reason_Identifier_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ReversalReasonIdentifierCodes reversalReasonIdentifierCodes = new ReversalReasonIdentifierCodes();
                        reversalReasonIdentifierCodes.Code = objReader["Value1"].ToString();
                        reversalReasonIdentifierCodes.Description = objReader["Text1"].ToString();
                        reversalReasonIdentifierCodesList.Add(reversalReasonIdentifierCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Reversal_Reason_Identifier_Codes");
            }
            return reversalReasonIdentifierCodesList;
        }
        public IEnumerable<IsoCountry> GetIsoCountries()
        {
            List<IsoCountry> isoCountry = new List<IsoCountry>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_ISO_Country_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        IsoCountry country = new IsoCountry();
                        country.Code = objReader["Value1"].ToString();
                        country.Description = objReader["Text1"].ToString();
                        isoCountry.Add(country);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_ISO_Country_Codes");
            }
            return isoCountry;
        }
        public IEnumerable<BankSwiftCode> GetOnBoardBankList()
        {
            List<BankSwiftCode> bankSwiftCodeList = new List<BankSwiftCode>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Bank_Onboard_List", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        BankSwiftCode bankSwiftCode = new BankSwiftCode();
                        bankSwiftCode.BankCode = Convert.ToString(objReader["BankCode"]);
                        bankSwiftCode.BankName = Convert.ToString(objReader["BankName"]);
                        bankSwiftCode.SwiftCode = Convert.ToString(objReader["SwiftCode"]);
                        // bankSwiftCode.IsOnBoardBatch = Convert.ToString(objReader["IsOnBoardBatch"]);
                        bankSwiftCode.IsOnBoardRealTime = Convert.ToString(objReader["IPP_Real_Time"]);
                        bankSwiftCodeList.Add(bankSwiftCode);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Bank_Onboard_List");
            }
            return bankSwiftCodeList;
        }
        public IEnumerable<ReversalRejectionCodes> GetReversalRejectionCodes()
        {
            List<ReversalRejectionCodes> list = new List<ReversalRejectionCodes>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Reversal_Rejection_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ReversalRejectionCodes reversalRejectCodes = new ReversalRejectionCodes();
                        reversalRejectCodes.Code = objReader["Value1"].ToString();
                        reversalRejectCodes.Description = objReader["Text1"].ToString();
                        list.Add(reversalRejectCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Reversal_Rejection_Codes");
            }
            return list;
        }

        public IEnumerable<ReturnReasonCodes> GetReturnReasonCodes()
        {
            List<ReturnReasonCodes> list = new List<ReturnReasonCodes>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("IPP_sp_select_Return_Reason_Codes", CommandType.StoredProcedure);
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        ReturnReasonCodes returnReasonCodes = new ReturnReasonCodes();
                        returnReasonCodes.Code = objReader["Value1"].ToString();
                        returnReasonCodes.Description = objReader["Text1"].ToString();
                        list.Add(returnReasonCodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Return_Reason_Codes");
            }
            return list;
        }
        public IEnumerable<UserProductId> GetUserProductIds()
        {
            List<UserProductId> UserProductIdList = new List<UserProductId>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelperFrameWrk.GetCommandObject("IPP_sp_select_User_list_Id", CommandType.StoredProcedure);
                using (objReader = sqlHelperFrameWrk.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        UserProductId UserProductId = new UserProductId();
                        UserProductId.ProductId = objReader["Value1"].ToString();
                        UserProductId.ProductName = objReader["Text1"].ToString();
                        UserProductIdList.Add(UserProductId);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_User_list_Id");
            }
            return UserProductIdList;
        }
        public IEnumerable<Roleid> GetRoleId()
        {
            List<Roleid> RoleidList = new List<Roleid>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelperFrameWrk.GetCommandObject("IPP_sp_select_Role_list_Id", CommandType.StoredProcedure);
                using (objReader = sqlHelperFrameWrk.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        Roleid Roleid = new Roleid();
                        Roleid.RoleDescription = objReader["Value1"].ToString();
                        Roleid.RoleName = objReader["Text1"].ToString();
                        RoleidList.Add(Roleid);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_Role_list_Id");
            }
            return RoleidList;
        }

        public IEnumerable<GeneralFileName> GetFileNameList(string fromDate, string toDate, string transName)
        {
            List<GeneralFileName> FileNameList = new List<GeneralFileName>();
            try
            {
                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("ipp_sp_sel_filenamelist_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar));
                Command.Parameters[0].Value = transName;
                Command.Parameters.Add(new SqlParameter("@Frm_Date", SqlDbType.NVarChar));
                Command.Parameters[1].Value = fromDate;
                Command.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.NVarChar));
                Command.Parameters[2].Value = toDate;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        GeneralFileName Filename = new GeneralFileName();
                        Filename.Filename_code = objReader["FileName_Code"].ToString();
                        Filename.Filename_desc = objReader["Filename_desc"].ToString();
                        FileNameList.Add(Filename);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_sel_filenamelist_netcore");
            }
            return FileNameList;
        }
        public IEnumerable<GeneralFileName> GetAckNakFileNameList(string fromDate, string toDate, string transactionprocesstype, string transactiontype)
        {
            List<GeneralFileName> FileNameList = new List<GeneralFileName>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelper.GetCommandObject("ipp_sp_sel_Ack_Nak_filenamelist_netcore", CommandType.StoredProcedure);
                Command.Parameters.Add(new SqlParameter("@TransProcessName", SqlDbType.NVarChar));
                Command.Parameters[0].Value = transactionprocesstype;
                Command.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar));
                Command.Parameters[1].Value = transactiontype;
                Command.Parameters.Add(new SqlParameter("@Frm_Date", SqlDbType.NVarChar));
                Command.Parameters[2].Value = fromDate;
                Command.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.NVarChar));
                Command.Parameters[3].Value = toDate;
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        GeneralFileName Filename = new GeneralFileName();
                        Filename.Filename_code = objReader["FileName_Code"].ToString();
                        Filename.Filename_desc = objReader["Filename_desc"].ToString();
                        FileNameList.Add(Filename);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_sel_Ack_Nak_filenamelist_netcore");
            }
            return FileNameList;
        }
        public IEnumerable<GeneralUserName> GetTransUserName()
        {
            List<GeneralUserName> UserNameList = new List<GeneralUserName>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;
                Command = sqlHelperFrameWrk.GetCommandObject("[IPP_sp_select_User_name_Id]", CommandType.StoredProcedure);
                using (objReader = sqlHelperFrameWrk.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        GeneralUserName UserName = new GeneralUserName();
                        UserName.User_code = objReader["Value1"].ToString();
                        UserName.User_name = objReader["Text1"].ToString();
                        UserNameList.Add(UserName);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "IPP_sp_select_User_name_Id");
            }
            return UserNameList;
        }
        public async Task<IEnumerable<GeneralBranchlist>> GetGeneralBranchlist(string TransactionName)
        {
            List<GeneralBranchlist> list = new List<GeneralBranchlist>();
            try
            {
                using (IDbConnection con = new SqlConnection(ConfigManager.getDBConnection()))
                {
                    var dp_Param = new DynamicParameters();
                    dp_Param.Add("TransactionName", TransactionName);
                    CommandType commandType = CommandType.StoredProcedure;
                    var result = await con.QueryAsync<GeneralBranchlist>("ipp_sp_get_BranchNameList", dp_Param, commandType: commandType);
                    if (result != null)
                    {
                        list = result.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "ipp_sp_get_BranchNameList");
            }
            return list;
        }
    }
}
