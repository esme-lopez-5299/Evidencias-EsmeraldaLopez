using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ajedrez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnInscribete_Clicked(object sender, EventArgs e)
        {
            Formulario vndFrm =new Formulario();
            Navigation.PushAsync(vndFrm);
        }

        private void BtnParticipantes_Clicked(object sender, EventArgs e)
        {
            Contrincantes vndContrincantes = new Contrincantes();
            Navigation.PushAsync(vndContrincantes);
        }

        private void BtnConvocatoria_Clicked(object sender, EventArgs e)
        {
            Convocatoria vndConvocatoria = new Convocatoria();
            Navigation.PushAsync(vndConvocatoria);
        }
    }
}