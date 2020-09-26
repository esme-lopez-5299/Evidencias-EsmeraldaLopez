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
    public partial class EditarParticipante : ContentPage
    {
        public event EventHandler ParticipanteModificado;
        public EditarParticipante()
        {
            InitializeComponent();
        }

        private void ToolbEditar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            ParticipanteModificado.Invoke(this, new EventArgs());
            
        }
       
    }
}