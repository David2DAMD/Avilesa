using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Avilesa.Model
{
    public class Parada : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Propiedades
        [Key]
        private int numLinea { get; set; }
        private int codMunicipio { get; set; }
        [Format ("HH:mm")]
        private TimeSpan intervalo { get; set; }

        #endregion

        #region Constructores
        public Parada() { }

        public Parada(int numLinea, int codMunicipio, TimeSpan intervalo)
        {
            NumLinea=numLinea;
            CodMunicipio=codMunicipio;
            Intervalo=intervalo;
        }

        public int NumLinea
        {
            get
            {
                return numLinea;
            }
            set
            {
                if (numLinea!=value)
                {
                    numLinea = value;
                    OnPropertyChanged(nameof(NumLinea));

                }
            }
        }

        public int CodMunicipio
        {
            get
            {
                return codMunicipio;
            }
            set
            {
                if (codMunicipio!=value)
                {
                    codMunicipio = value;
                    OnPropertyChanged(nameof(CodMunicipio));
                }
            }
        }

        public TimeSpan Intervalo
        {
            get { return intervalo; }
            set
            {
                if (intervalo != value)
                {
                    intervalo = value;
                    OnPropertyChanged(nameof(Intervalo));
                }
            }
        }


        #endregion

        #region Notify Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Data error info
        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName==(nameof(numLinea)) && int.IsEvenInteger(numLinea))
                {
                    result = "Debe introducir un número de línea válido";
                }
                if(columnName==(nameof(codMunicipio))) {
                    if (codMunicipio==0)
                    {
                        result = "Debe seleccionar un municipio";
                    }
                }
                if (columnName==(nameof(intervalo)))
                {
                    TimeSpan time;
                    if (!TimeSpan.TryParseExact(intervalo.ToString(), "hh\\:mm", CultureInfo.InvariantCulture, out time))
                    result = "Debe introducir un intervalo válido";
                }
                return result;

            }
        }

        #endregion

    }


}
