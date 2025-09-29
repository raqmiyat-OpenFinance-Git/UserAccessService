using CsvHelper.Configuration;
using Pacs008.Request.Model;

namespace OpenFinanceWebApi.Models
{
    public class CustomerDataMap : ClassMap<CustomerData>
    {
        public CustomerDataMap()
        {
            Map(m => m.CustomerName).Name("Customer Name");
            Map(m => m.SurName).Name("Sur Name");
            Map(m => m.BankUserId).Name("Bank User ID").TypeConverter<ScientificNotationToStringConverter>();
            Map(m => m.MobileNumber).Name("Mobile Number").TypeConverter<ScientificNotationToStringConverter>();

            Map(m => m.BankAccounts).Name("Bank Accounts").TypeConverter<CsvListConverter<string>>();
            Map(m => m.Currencies).Name("Currencies").TypeConverter<CsvListConverter<string>>();

            Map(m => m.ProxyEmirateId).Name("Proxy (Emirate Id)");
            Map(m => m.ProxyMobileNumber).Name("Proxy (Mobile Number)").TypeConverter<ScientificNotationToStringConverter>();
            Map(m => m.ProxyEmailId).Name("Proxy (Email Id)");

            //Map(m => m.ProxyData).Name("Proxy (Emirate Id, Mobile Number, Email)").TypeConverter<ProxyDataConverter>();
        }
    }
}
