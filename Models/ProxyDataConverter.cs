using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace OpenFinanceWebApi.Models
{
    public class ProxyDataConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var proxyData = text.Split(',').Select(value => value.Trim()).ToList();
            var proxyDictionary = new Dictionary<string, string>
        {
            { "EmirateId", proxyData[0] },
            { "MobileNumber", proxyData[1] },
            { "Email", proxyData[2] }
        };
            return proxyDictionary;
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is Dictionary<string, string> proxyDictionary)
            {
                return $"{proxyDictionary["EmirateId"]}, {proxyDictionary["MobileNumber"]}, {proxyDictionary["Email"]}";
            }
            return null;
        }
    }
}
