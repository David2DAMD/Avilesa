using Avilesa.Model;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;

namespace Avilesa
{
    public static class LogicaNegocio
    {

        public static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            Delimiter = ";",
            Encoding = Encoding.UTF8
        };

        #region Logica de municipios

        public static ObservableCollection<Municipio> lstMunicipios { get; set; } = new ObservableCollection<Municipio>();

        private static string nombreArchivoMunicipios = "municipios.csv";
        private static string rutaMunicipios = AppDomain.CurrentDomain.BaseDirectory;
        public static string RutaArchivoMunicipios = Path.Combine(rutaMunicipios, "../../../Data", nombreArchivoMunicipios);

        public static void readMunicipios()
        {
            using (var reader = new StreamReader(RutaArchivoMunicipios))
            using (var csv = new CsvReader(reader, CsvConfig))
                while (csv.Read())
                {
                    var municipio = new Municipio
                    {
                        codigoMunicipio = csv.GetField<int>(0),
                        nombre = csv.GetField<String>(1)
                    };
                    lstMunicipios.Add(municipio);
                }
        }
        
        public static Municipio findMunicipioByCod(int codMunicipio)
        {
            Municipio municipioByCod = new Municipio();
            foreach(var municipio in lstMunicipios)
            {
                if(municipio.codigoMunicipio == codMunicipio)
                {
                    municipioByCod = municipio;
                    return municipioByCod;
                }
            }
            return null;
        }


        #endregion

        #region Logica de paradas

        public static ObservableCollection<Parada> lstParadas { get; set; } = new ObservableCollection<Parada>();
        public static ObservableCollection<Parada> lstParadasByLinea { get; set; } = new ObservableCollection<Parada>();

        private static string nombreArchivoParadas = "paradas.csv";
        private static string rutaParadas = AppDomain.CurrentDomain.BaseDirectory;
        public static string RutaArchivoParadas = Path.Combine(rutaParadas, "../../../Data", nombreArchivoParadas);

        public static void removeParada(Parada parada)
        {
            lstParadas.Remove(parada);
        }

        public static void listParadaByLinea(int numLinea)
        {
            lstParadasByLinea.Clear();
            foreach (var parada in lstParadas)
            {
                if (parada.NumLinea == numLinea)
                {
                    lstParadasByLinea.Add(parada);
                }
            }
        }

        public static Parada findParadaByLinea(int numLinea)
        {
            Parada paradaByLinea = new Parada();
            foreach (var parada in lstParadas)
            {
                if (parada.NumLinea == numLinea)
                {
                    paradaByLinea = parada;
                    return paradaByLinea;
                }
            }
            return null;
        }

        public static void readParadas()
        {
            using (var reader = new StreamReader(RutaArchivoParadas))
            using (var csv = new CsvReader(reader, CsvConfig))
                while (csv.Read())
                {
                    var parada = new Parada
                    {
                        NumLinea = csv.GetField<int>(0),
                        CodMunicipio = csv.GetField<int>(1),
                        Intervalo = TimeSpan.Parse(csv.GetField<string>(2))
                    };
                    lstParadas.Add(parada);
                }
        }

        public static void saveParadas()
        {
            using (var writer = new StreamWriter(RutaArchivoParadas))
            using (var csv = new CsvWriter(writer, CsvConfig))
            {
                foreach (var parada in lstParadas)
                {
                    int numLinea = parada.NumLinea;
                    int codMunicipio = parada.CodMunicipio;
                    String intervaloStr = parada.Intervalo.ToString();

                    csv.WriteField(numLinea);
                    csv.WriteField(codMunicipio);
                    csv.WriteField(intervaloStr);
                    csv.NextRecord();
                }
            }
        }

        #endregion

        #region Logica de líneas

        public static ObservableCollection<Linea> lstLineas { get; set; } = new ObservableCollection<Linea>();

        private static string nombreArchivoLineas = "lineas.csv";
        private static string rutaLineas = AppDomain.CurrentDomain.BaseDirectory;
        public static string RutaArchivoLineas = Path.Combine(rutaLineas, "../../../Data", nombreArchivoLineas);

        public static void removeLinea(Linea linea)
        {
            lstLineas.Remove(linea);
        }

        public static Linea findLineaByNumLinea(int numLinea)
        {
            lstParadasByLinea.Clear();
            foreach (var linea in lstLineas)
            {
                if (linea.NumLinea == numLinea)
                {
                    return linea;
                }
            }
            return null;
        }

        public static void readLineas()
        {
            using (var reader = new StreamReader(RutaArchivoLineas))
            using (var csv = new CsvReader(reader, CsvConfig))
                while (csv.Read())
                {
                    var newlinea = new Linea
                    {
                        NumLinea = csv.GetField<int>(0),
                        CodMunicipioOrigen = csv.GetField<int>(1),
                        CodMunicipioDestino = csv.GetField<int>(2),
                        HoraSalida = TimeSpan.Parse(csv.GetField<string>(3)),
                        Intervalo = TimeSpan.Parse(csv.GetField<string>(4))
                    };
                    lstLineas.Add(newlinea);
                }
        }

        public static void saveLineasToCsv()
        {
            using (var writer = new StreamWriter(RutaArchivoLineas))
            using (var csv = new CsvWriter(writer, CsvConfig))
            {
                foreach (var linea in lstLineas)
                {
                    int numLinea = linea.NumLinea;
                    int codMunicipioOrigen = linea.CodMunicipioOrigen;
                    int codMunicipioDestino = linea.CodMunicipioDestino;
                    String horaSalidaStr = linea.HoraSalida.ToString();
                    String intervaloStr = linea.Intervalo.ToString();

                    csv.WriteField(numLinea);
                    csv.WriteField(codMunicipioOrigen);
                    csv.WriteField(codMunicipioDestino);
                    csv.WriteField(horaSalidaStr);
                    csv.WriteField(intervaloStr);
                    csv.NextRecord();
                }
            }
        }

        #endregion
    }
}
