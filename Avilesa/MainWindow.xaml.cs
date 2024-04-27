using Avilesa.UI.Itinerarios;
using System.Windows;

namespace Avilesa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LogicaNegocio.readMunicipios();
            LogicaNegocio.readLineas();
            LogicaNegocio.readParadas();
        }

        private void btnMunicipios_Click(object sender, RoutedEventArgs e)
        {
            DialogMunicipios dlgMunicipios = new DialogMunicipios();
            dlgMunicipios.ShowDialog();
        }

        private void btnParadas_Click(object sender, RoutedEventArgs e)
        {
            DialogParadas dlgParadas = new DialogParadas();
            dlgParadas.ShowDialog();

        }

        private void btnLineas_Click(object sender, RoutedEventArgs e)
        {
            DialogLineas dlgLineas = new DialogLineas();
            dlgLineas.ShowDialog();
        }

        private void btnItinerarios_Click(object sender, RoutedEventArgs e)
        {
            DialogItinerarios dlgItinerarios = new DialogItinerarios();
            dlgItinerarios.ShowDialog();
        }
    }
}