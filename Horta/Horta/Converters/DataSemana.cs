using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Horta2.Converters
{
    public class WhatsAppDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = value as DateTime?;
            if (!dateTime.HasValue)
                return string.Empty;

            var now = DateTimeOffset.Now;

            if (dateTime.Value.Date == DateTime.Today)
                return "Hoje, " + dateTime.Value.ToString("t");

            var diffDays = (now.Date - dateTime.Value.Date).Days;
            if (diffDays <= 6 && diffDays >=-6)
            {
                if (diffDays == 1)
                {
                    return "Ontem " + dateTime.Value.ToString("t");
                }

                switch (dateTime.Value.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return $"Domingo ({dateTime.Value.ToString("dd")}), ";
                    case DayOfWeek.Monday:
                        return $"Segunda ({dateTime.Value.ToString("dd")})";
                    case DayOfWeek.Tuesday:
                        return $"Terça ({dateTime.Value.ToString("dd")})";
                    case DayOfWeek.Wednesday:
                        return $"Quarta ({dateTime.Value.ToString("dd")}) , {dateTime.Value.ToString("t")}";
                    case DayOfWeek.Thursday:
                        return $"Quinta ({dateTime.Value.ToString("dd")})";
                    case DayOfWeek.Friday:
                        return $"Sexta ({dateTime.Value.ToString("dd")})";
                    case DayOfWeek.Saturday:
                        return $"Sábado ({dateTime.Value.ToString("dd")})";
                }
            }

            return "em " + dateTime.Value.ToString("dd/MM/yyyy HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
