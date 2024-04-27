using Avilesa.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Avilesa
{
    /// <summary>
    /// Lógica de interacción para DialogLineas.xaml
    /// </summary>
    public partial class DialogLineas : Window
    {
        public DialogLineas()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<Linea> lstLineas { get; set; } = LogicaNegocio.lstLineas;
        public static Linea editedLinea = null;
        private void btnAnyadir_Click(object sender, RoutedEventArgs e)
        {
            DialogNewLinea dlgNewLinea = new DialogNewLinea(new Linea());
            dlgNewLinea.ShowDialog();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Linea removedLinea = dgLineas.SelectedItem as Linea;

            if(removedLinea != null)
            {
                LogicaNegocio.removeLinea(removedLinea);
                LogicaNegocio.saveLineasToCsv();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna línea para eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            editedLinea = dgLineas.SelectedItem as Linea;

            if(editedLinea!= null)
            {
                DialogNewLinea dlgNewLinea = new DialogNewLinea(editedLinea);
                dlgNewLinea.txtNumLinea.Text = editedLinea.NumLinea.ToString();
                dlgNewLinea.txtHoraSalida.Text = editedLinea.HoraSalida.ToString();
                dlgNewLinea.txtIntervalo.Text = editedLinea.Intervalo.ToString();
                dlgNewLinea.cbCodMunicipioOrigen.SelectedItem = LogicaNegocio.findMunicipioByCod(editedLinea.CodMunicipioOrigen);
                dlgNewLinea.cbCodMunicipioDestino.SelectedItem = LogicaNegocio.findMunicipioByCod(editedLinea.CodMunicipioDestino);
                dlgNewLinea.ShowDialog();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna línea para editar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
