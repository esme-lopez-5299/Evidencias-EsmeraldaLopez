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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Unidad2ZapateriaIxchel
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Inventario i = new Inventario();
        AdministracionZapatos az = new AdministracionZapatos();
        public MainWindow()
        {
            InitializeComponent();
            dtgInventario.ItemsSource = null;
            dtgInventario.ItemsSource = az.ListaInventario;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                vndEditar Editar = new vndEditar();
                var a = ((FrameworkElement)sender).DataContext as Inventario;
                Editar.DataContext = a;
                bool? resultado = Editar.ShowDialog();
                if (resultado == true)
                {
                    az.Editar(a);
                }
                else
                    az.Normalidad();
                dtgInventario.ItemsSource = null;
                dtgInventario.ItemsSource = az.ListaInventario ;
            }
            catch (Exception ex)
            {
                az.Normalidad();
                dtgInventario.ItemsSource = null;
                dtgInventario.ItemsSource = az.ListaInventario;
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
 if(MessageBox.Show("¿Desea eliminar el contacto seleccionado?", "Eliminar inventario",
                MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                Inventario inv = ((FrameworkElement)sender).DataContext as Inventario;
                az.Eliminar(inv);
                MessageBox.Show("Registro de inventario eliminado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                dtgInventario.ItemsSource = null;
                dtgInventario.ItemsSource = az.ListaInventario;              
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtgInventario.ItemsSource = null;
            dtgInventario.ItemsSource = az.ListaInventario;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vndAgregar Agregar = new vndAgregar();
                Agregar.DataContext = i;
                bool? resultado = Agregar.ShowDialog();
                if (resultado == true)

                {
                    az.Agregar(i);
                    MessageBox.Show("Registro agregado");
                    az.Normalidad();
                    dtgInventario.ItemsSource = null;
                dtgInventario.ItemsSource = az.ListaInventario;
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BtnEditar_Click_1(object sender, RoutedEventArgs e)
        {

        }

        //private void BtnEditar_Click_2(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BtnEditar_Click_3(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
