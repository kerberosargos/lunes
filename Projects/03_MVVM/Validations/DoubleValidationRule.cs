using System.Globalization;
using System.Windows.Controls;

namespace _03_MVVM.Validations
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var stringData = value as string;

            if (string.IsNullOrEmpty(stringData))
            {
                return new ValidationResult(false, "This can not be empty");
            }
            
            double doubleData;
            if (!double.TryParse(stringData, out doubleData))
            {
                return new ValidationResult(false, "You must enter integer value");
            }

            return ValidationResult.ValidResult;
        }
    }
}
