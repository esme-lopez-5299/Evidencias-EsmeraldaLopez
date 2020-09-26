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
    /// Lógica de interacción para Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
         
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
   MainWindow m = new MainWindow();
            m.ShowDialog();
            this.Close();
        }
    }
}
