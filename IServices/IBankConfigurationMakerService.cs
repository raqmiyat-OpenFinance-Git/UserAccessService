using Entities.BankConfiguration;
using Entities.BankConfigurationChecker;

namespace OpenFinanceWebApi.IServices
{
    public interface IBankConfigurationMakerService
    {
        bool AddBankConfiguration(BankConfigurationMakerModel bankconfigurationmodel);
      
        BankConfigurationMakerModel GetBankConfiguration();

        IEnumerable<IntegrationTypeList> GetIntegrationTypes();

        IEnumerable<EnableMessageForwarding> GetEnableMessageForwardingList();
    }
}
