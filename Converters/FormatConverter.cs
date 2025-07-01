using System.Globalization;
using FinanceTracker.MVVM.Models;

namespace FinanceTracker.Converters;

public class FormatConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Transaction transaction)
        {
            return transaction.IsIncome ? $"+ {transaction.Value:C0}" : $"- {transaction.Value:C0}";
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}