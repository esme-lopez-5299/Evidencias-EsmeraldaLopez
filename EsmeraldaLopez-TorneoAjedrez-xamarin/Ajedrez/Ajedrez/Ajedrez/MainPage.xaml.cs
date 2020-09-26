using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ajedrez
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(5), Entrar);
        }
        bool Entrar()

        {
            App.Current.MainPage = new NavigationPage(new Menu())
            {
                BarBackgroundColor = Color.Turquoise,
                BarTextColor = Color.White
            };
            return false;
        }
    }
}
