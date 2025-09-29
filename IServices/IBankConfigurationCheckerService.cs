using Entities.BankConfigurationChecker;

namespace OpenFinanceWebApi.IServices
{
    public interface IBankConfigurationCheckerService
    {
        bool ApproveRejectBankConfiguration(BankConfigurationCheckerModel bankConfigurationCheckerModel);

        BankConfigurationCheckerModel GetBankConfiguration();
    }
}

