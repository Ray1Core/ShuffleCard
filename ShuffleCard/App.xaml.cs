using System.Globalization;
using Microsoft.Maui.Graphics;

namespace ShuffleCard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MVVM.Views.ShufflePage();
        }
    }

    // Simple converters added directly in App.xaml.cs
    public class AnswerBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Color.FromArgb("#F5F5F5");

            bool? isCorrect = value as bool?;
            if (isCorrect.HasValue)
            {
                return isCorrect.Value ? Color.FromArgb("#E8F5E9") : Color.FromArgb("#FFEBEE");
            }
            return Color.FromArgb("#F5F5F5");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AnswerTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Color.FromArgb("#2C3E50");

            bool? isCorrect = value as bool?;
            if (isCorrect.HasValue)
            {
                return isCorrect.Value ? Color.FromArgb("#2E7D32") : Color.FromArgb("#C62828");
            }
            return Color.FromArgb("#2C3E50");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}