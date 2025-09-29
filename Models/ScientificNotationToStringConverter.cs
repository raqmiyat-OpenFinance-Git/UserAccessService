using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace OpenFinanceWebApi.Models
{
    public class ScientificNotationToStringConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (double.TryParse(text, out double numericValue))
            {
                // If parsing succeeds, convert the numeric value to a string without scientific notation
                return numericValue.ToString("0", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                // Parsing failed, return the original text
                return text;
            }
        }
    }
}
