using System;
using System.Collections.Generic;
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

namespace Unidad2ZapateriaIxchel
{
    /// <summary>
    /// Lógica de interacción para vndAgregar.xaml
    /// </summary>
    public partial class vndAgregar : Window
    {
        public vndAgregar()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
        AdministracionZapatos az = new AdministracionZapatos();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTalla.Clear();
            txtUnidades.Clear();
            txtAnchoPierna.Clear();
            cmbIdZapato.ItemsSource = az.ObtenerListaZapato();
        }
    }
}
