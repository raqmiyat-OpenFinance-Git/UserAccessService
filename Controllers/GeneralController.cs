using Entities.GeneralModel;
using Microsoft.AspNetCore.Mvc;
using OpenFinanceWebApi.IServices;
using Entities.General;
using OpenFinanceWebApi.NLogService;

namespace OpenFinanceWebApi.Controllers
{
    [Route("api/General")]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralService generalService;
        private readonly NLogWebApiService _logger;
        public GeneralController(IGeneralService general, NLogWebApiService logger)
        {
            generalService = general;
            _logger = logger;
        }

        [HttpGet("GetGeneralList")]
        public IEnumerable<General> GetGeneralList(string generalType)
        {
            try
            {
                return generalService.GetGeneralList(generalType);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet("GetGeneralListforchargeMaster")]
        public IEnumerable<General> GetGeneralListforchargeMaster(string generalType, string ActionType)
        {
            try
            {
                return generalService.GetGeneralListforChrgMaster(generalType, ActionType);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetNextMesageID")]
        public string GetNextMesageID(string instrName)
        {
            try
            {
                return generalService.GetNextMesageID(instrName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetUserProductIds")]
        public IEnumerable<UserProductId> GetUserProductIds()
        {
            try
            {
                return generalService.GetUserProductIds();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetRoleids")]
        public IEnumerable<Roleid> GetRoleId()
        {
            try
            {
                return generalService.GetRoleId();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetNextENQSEQ")]
        public string GetNextENQSEQ(string instrName)
        {
            try
            {
                return generalService.GetNext_ENQ_SEQ(instrName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetBankSwiftCode")]
        public IEnumerable<BankSwiftCode> GetBankSwiftCde()
        {
            try
            {
                return generalService.GetBankSwiftCode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetRealTimeBankSwiftCode")]
        public IEnumerable<BankSwiftCode> GetRealTimeBankSwiftCode()
        {
            try
            {
                return generalService.GetRealTimeBankSwiftCode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetCategoryPurposeCodes")]
        public IEnumerable<CategoryPurposeCode> GetCategoryPurposeCodes()
        {
            try
            {
                return generalService.GetCategoryPurposeCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetIssuerTypeCodes")]
        public IEnumerable<IssuerTypeCodes> GetIssuerTypeCodes()
        {
            try
            {
                return generalService.GetIssuerTypeCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetEconomicActivityCodes")]
        public IEnumerable<EconomicActivityCodes> GetEconomicActivityCodes()
        {
            try
            {
                return generalService.GetEconomicActivityCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetChannelInformationIdentifierCodes")]
        public IEnumerable<ChannelInformationIdentifierCodes> GetChannelInformationIdentifierCodes()
        {
            try
            {
                return generalService.GetChannelInformationIdentifierCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetAccountTypeIdentifierCodes")]
        public IEnumerable<AccountTypeIdentifierCodes> GetAccountTypeIdentifierCodes()
        {
            try
            {
                return generalService.GetAccountTypeIdentifierCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetMasterCurrencyCodes")]
        public IEnumerable<MasterCurrencyCodes> GetMasterCurrencyCodes()
        {
            try
            {
                return generalService.GetMasterCurrencyCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetReversalReasonIdentifierCodes")]
        public IEnumerable<ReversalReasonIdentifierCodes> GetReversalReasonIdentifierCodes()
        {
            try
            {
                return generalService.GetReversalReasonIdentifierCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetIsoCountries")]
        public IEnumerable<IsoCountry> GetIsoCountries()
        {
            try
            {
                return generalService.GetIsoCountries();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetOnBoardBankList")]
        public IEnumerable<BankSwiftCode> GetOnBoardBankLst()
        {
            try
            {
                return generalService.GetOnBoardBankList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetReversalRejectionCodes")]
        public IEnumerable<ReversalRejectionCodes> GetReversalRejectionCodes()
        {
            try
            {
                return generalService.GetReversalRejectionCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet("GetReturnReasonCodes")]
        public IEnumerable<ReturnReasonCodes> GetReturnReasonCodes()
        {
            try
            {
                return generalService.GetReturnReasonCodes();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        
        [HttpGet("GetFileNameList")]
        public IEnumerable<GeneralFileName> GetFileNameList(string fromDate, string toDate, string transName)
        {
            try
            {
                return generalService.GetFileNameList(fromDate, toDate, transName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetAckNakFileNameList")]
        public IEnumerable<GeneralFileName> GetAckNakFileNameList(string fromDate, string toDate, string transactionprocesstype, string transactiontype)
        {
            try
            {
                return generalService.GetAckNakFileNameList(fromDate, toDate, transactionprocesstype, transactiontype);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        [HttpGet("GetGeneralUserNameList")]
        public IEnumerable<GeneralUserName> GetTransUserName()
        {
            try
            {
                return generalService.GetTransUserName();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        [HttpGet("GetGeneralBranchlist")]
        public async Task<IEnumerable<GeneralBranchlist>> GetGeneralBranchlist(string TransactionName)
        {
            try
            {
                return await generalService.GetGeneralBranchlist(TransactionName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
           
        }
    }
}
