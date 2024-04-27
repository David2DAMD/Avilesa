using Avilesa.Model;
using System.Collections.ObjectModel;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;

namespace Avilesa
{
    /// <summary>
    /// Lógica de interacción para DialogNewParada.xaml
    /// </summary>
    public partial class DialogNewParada : Window
    {
        public Parada parada {  get; set; }
        private int errores = 0;
        public DialogNewParada(Parada p)
        {
            InitializeComponent();
            this.parada = p;
            this.DataContext = this;
        }
        public ObservableCollection<Municipio> lstMunicipios { get; set; } = LogicaNegocio.lstMunicipios;
        public ObservableCollection<Linea> lstLineas { get; set; } = LogicaNegocio.lstLineas;

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if ((cbCodMunicipio.SelectedItem)!=null && (cbNumLinea.SelectedItem)!=null) { 
                int numLinea = ((Linea)cbNumLinea.SelectedItem).NumLinea;
                int codMunicipio = ((Municipio)cbCodMunicipio.SelectedItem).codigoMunicipio;
                TimeSpan intervalo = TimeSpan.Parse(txtIntervalo.Text);
            
                if (LogicaNegocio.lstParadas.Contains(parada))
                {
                    parada.NumLinea = numLinea;
                    parada.CodMunicipio= codMunicipio;
                    parada.Intervalo = intervalo;
                    LogicaNegocio.saveParadas();
                }
                else
                {
                    parada = new Parada(numLinea, codMunicipio, intervalo);
                    LogicaNegocio.lstParadas.Add(parada);
                    LogicaNegocio.saveParadas();
                }

                this.Close();
            }
            else
            {
                if((cbCodMunicipio.SelectedItem)==null)
                MessageBox.Show("No ha seleccionado ningun municipio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if((cbNumLinea.SelectedItem)==null)
                MessageBox.Show("No ha seleccionado ningun número de línea", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if(errores == 0)
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