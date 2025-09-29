using OpenFinanceWebApi.Custom;
using Raqmiyat.Infrastructure.Data;
using Raqmiyat.Infrastructure.Utils;
using System.Data;
using System.Data.Common;
using UserAccessService.IServices;
using UserAccessService.Models;

namespace UserAccessService.Services
{
    public class DataValidateService: IDataValidateService
    {
        SqlHelper sqlHelper = new SqlHelper(ConfigManager.getFrameworkDBConnection());

        public IEnumerable<OwdBankSwiftCode> ValidateCreditorIBAN(string IBAN_NO)
        {
            NLogger.GetNLogger.Debug("-----------------DataValidateService Invoked - ValidateCreditorIBAN() was started--------------------");
            List<OwdBankSwiftCode> bankSwiftCodeList = new List<OwdBankSwiftCode>();
            var list = new List<OwdBankSwiftCode>();
            try
            {

                IDataReader? objReader = null;
                DbCommand? Command = null;

                Command = sqlHelper.GetCommandObject("IPP_sp_select_Bank_Swift_Codes", CommandType.StoredProcedure);
                NLogger.GetNLogger.Debug("----SQL Stored Procedure (IPP_sp_select_Bank_Swift_Codes) ---");
                using (objReader = sqlHelper.ExecuteDataReader(Command))
                {
                    while (objReader.Read())
                    {
                        OwdBankSwiftCode bankSwiftCode = new OwdBankSwiftCode();
                        bankSwiftCode.BankCode = Convert.ToString(objReader["Value1"]);
                        bankSwiftCode.SwiftCode = Convert.ToString(objReader["Text1"]);
                        //  bankSwiftCode.ElevenCode = Convert.ToString(objReader["ElevenCode"]);
                        bankSwiftCodeList.Add(bankSwiftCode);
                    }
                }
                list = bankSwiftCodeList.Where(r => r.BankCode == Convert.ToString(IBAN_NO.Substring(4, 3))).ToList();

            }
            catch (Exception ex)
            {
                NLogger.GetNLogger.Error("Exception Ocurred in  DataValidateService ValidateCreditorIBAN():" + ex.Message);

            }
            NLogger.GetNLogger.Debug("-----------------DataValidateService - ValidateCreditorIBAN() was ended--------------------");
            return list;


        }
    }
}
