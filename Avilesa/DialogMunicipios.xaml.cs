using Avilesa.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avilesa
{
    /// <summary>
    /// Lógica de interacción para DialogMunicipios.xaml
    /// </summary>
    public partial class DialogMunicipios : Window
    {
        public DialogMunicipios()
        {
            InitializeComponent();
            LogicaNegocio.readMunicipios();
            this.DataContext = this;
        }
        public ObservableCollection<Municipio> lstMunicipios { get; set; } = LogicaNegocio.lstMunicipios;
    }
}
