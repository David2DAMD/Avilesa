using Avilesa.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Avilesa
{
    /// <summary>
    /// Lógica de interacción para DialogParadas.xaml
    /// </summary>
    public partial class DialogParadas : Window
    {
        public DialogParadas()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public ObservableCollection<Parada> lstParadas { get; set; } = LogicaNegocio.lstParadas;

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Parada removedParada = dgParadas.SelectedItem as Parada;
            if(removedParada != null)
            {
                LogicaNegocio.removeParada(removedParada);
                LogicaNegocio.saveParadas();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna parada para eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnAnyadir_Click(object sender, RoutedEventArgs e)
        {
            DialogNewParada dlgNewParada = new DialogNewParada(new Parada());
            dlgNewParada.ShowDialog();
        }

        private void btnVEditar_Click(object sender, RoutedEventArgs e)
        {
            Parada editedParada = dgParadas.SelectedItem as Parada;
            if(editedParada != null)
            {
                DialogNewParada dlgNewParada = new DialogNewParada(editedParada);
                dlgNewParada.cbNumLinea.SelectedItem = LogicaNegocio.findLineaByNumLinea(editedParada.NumLinea);
                dlgNewParada.cbCodMunicipio.SelectedItem = LogicaNegocio.findMunicipioByCod(editedParada.CodMunicipio);
                dlgNewParada.txtIntervalo.Text = editedParada.Intervalo.ToString();
                dlgNewParada.ShowDialog();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna parada para editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}