using System.Globalization;
using System.Windows.Data;

namespace Avilesa
{
    class MunicipioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int codMunicipio = (int)value;
            string nombreMunicipio = LogicaNegocio.findMunicipioByCod(codMunicipio).nombre;
            return nombreMunicipio;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
