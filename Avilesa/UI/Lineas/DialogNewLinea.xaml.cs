using Avilesa.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Avilesa
{
    /// <summary>
    /// Lógica de interacción para DialogNewLinea.xaml
    /// </summary>
    public partial class DialogNewLinea : Window
    {
        public Linea linea { get; set; }
        private int errores = 0;
        public DialogNewLinea(Linea l)
        {
            InitializeComponent();
            this.linea = l;
            this.DataContext = this;

        }

        public ObservableCollection<Municipio> lstMunicipios { get; set; } = LogicaNegocio.lstMunicipios;

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (cbCodMunicipioOrigen.SelectedItem!=null && cbCodMunicipioDestino.SelectedItem!=null)
            {
                int numLinea = int.Parse(txtNumLinea.Text);
                int codMunicipioOrigen = ((Municipio)cbCodMunicipioOrigen.SelectedItem).codigoMunicipio;
                int codMunicipioDestino = ((Municipio)cbCodMunicipioDestino.SelectedItem).codigoMunicipio;
                TimeSpan horaSalida = TimeSpan.Parse(txtHoraSalida.Text);
                TimeSpan intervalo = TimeSpan.Parse(txtIntervalo.Text);
                if (LogicaNegocio.lstLineas.Contains(linea))
                {
                    linea.NumLinea = numLinea;
                    linea.CodMunicipioOrigen = codMunicipioOrigen;
                    linea.CodMunicipioDestino = codMunicipioDestino;
                    linea.HoraSalida = horaSalida;
                    linea.Intervalo = intervalo;
                    LogicaNegocio.saveLineasToCsv();
                }
                else
                {
                    linea = new Linea(numLinea, codMunicipioOrigen, codMunicipioDestino, horaSalida, intervalo);
                    LogicaNegocio.lstLineas.Add(linea);
                    LogicaNegocio.saveLineasToCsv();
                }

                this.Close();
            }
            else
            {
                if ((cbCodMunicipioOrigen.SelectedItem)==null)
                    MessageBox.Show("No ha seleccionado ningun municipio de origen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if ((cbCodMunicipioDestino.SelectedItem)==null)
                    MessageBox.Show("No ha seleccionado ningun municipio de destino", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errores++;
            }
            else
            {
                errores--;
            }
            if (errores == 0)
            {
                btnAceptar.IsEnabled = true;
            }
            else
            {
                btnAceptar.IsEnabled = false;
            }
        }
    }
}