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
    public partial class Formulario : ContentPage
    {
        public event EventHandler ParticipanteAgregado;
        public Formulario()
        {
            InitializeComponent();
        }

        //private void BtnInscribirse_Clicked(object sender, EventArgs e)
        //{
            
        //}

        //private void BtnCancelar(object sender, EventArgs e)
        //{
        //    Navigation.PopAsync();
        //}

        private void ToolbAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            ParticipanteAgregado.Invoke(this, new EventArgs());
        }
    }
}