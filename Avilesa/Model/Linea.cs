using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using CsvHelper.Configuration.Attributes;

namespace Avilesa.Model
{
    public class Linea : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Propiedades
        [Key]
        private int numLinea { get; set; }
        private int codMunicipioOrigen { get; set; }
        private int codMunicipioDestino { get; set; }
        [Format("HH:MM")]
        private TimeSpan horaSalida { get; set; }
        [Format("HH:MM")]
        private TimeSpan intervalo { get; set; }
        #endregion


        #region Constructores
        public Linea() { }

        public Linea(int numLinea, int codMunicipioOrigen, int codMunicipioDestino, TimeSpan horaSalida, TimeSpan intervalo)
        {
            NumLinea=numLinea;
            CodMunicipioOrigen=codMunicipioOrigen;
            CodMunicipioDestino=codMunicipioDestino;
            HoraSalida=horaSalida;
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

        public int CodMunicipioOrigen
        {
            get
            {
                return codMunicipioOrigen;
            }
            set
            {
                if (codMunicipioOrigen!=value)
                {
                    codMunicipioOrigen = value;
                    OnPropertyChanged(nameof(CodMunicipioOrigen));
                }
            }
        }

        public int CodMunicipioDestino
        {
            get
            {
                return codMunicipioDestino;
            }
            set
            {
                if (codMunicipioDestino!=value)
                {
                    codMunicipioDestino = value;
                    OnPropertyChanged(nameof(CodMunicipioDestino));
                }
            }
        }

        public TimeSpan HoraSalida
        {
            get { return horaSalida; }
            set
            {
                if (horaSalida != value)
                {
                    horaSalida = value; 
                    OnPropertyChanged(nameof(HoraSalida));
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
                if (columnName==(nameof(horaSalida)))
                {
                    TimeSpan time;
                    if (!TimeSpan.TryParseExact(horaSalida.ToString(), "hh\\:mm", CultureInfo.InvariantCulture, out time))
                        result = "Debe introducir un intervalo válido";
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
