using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace OpenFinanceWebApi.Models
{
    public class CsvListConverter<T> : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var values = text.Split('\n').Select(value => value.Trim()).ToList();
            return values;
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is IEnumerable<T> valueList)
            {
                return string.Join(", ", valueList);
            }
            return null;
        }
    }
}
