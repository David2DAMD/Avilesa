using Avilesa.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Avilesa.UI.Itinerarios
{
    /// <summary>
    /// Lógica de interacción para DialogItinerarios.xaml
    /// </summary>
    public partial class DialogItinerarios : Window
    {
        public DialogItinerarios()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<Parada> lstParadasByLinea { get; set; } = LogicaNegocio.lstParadasByLinea;
        public ObservableCollection<Linea> lstLineas { get; set; } = LogicaNegocio.lstLineas;

        private void cbNumLinea_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Linea selectedLinea = cbNumLinea.SelectedItem as Linea;
            lblSalida.Content = selectedLinea.HoraSalida.ToString();
            lblIntervalo.Content = selectedLinea.Intervalo.ToString();
            lblMunicipioOrigen.Content = LogicaNegocio.findMunicipioByCod(selectedLinea.CodMunicipioOrigen).nombre;
            lblMunicipioDestino.Content = LogicaNegocio.findMunicipioByCod(selectedLinea.CodMunicipioDestino).nombre;
            LogicaNegocio.listParadaByLinea(selectedLinea.NumLinea);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
