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
    public partial class Contrincantes : ContentPage
    {
        public Contrincantes()
        {
            InitializeComponent();
            part.Cargar();
            lstParticipantes.ItemsSource = part.ListaParticipante;
            nuevoFormulario.ParticipanteAgregado += NuevoFormulario_ParticipanteAgregado;
            vndEditar.ParticipanteModificado += VndEditar_ParticipanteModificado;
            if(part.ListaParticipante==null)
                grdTitulo.IsVisible = false;
            else grdTitulo.IsVisible = true;
        }

        private void VndEditar_ParticipanteModificado(object sender, EventArgs e)
        {
            part.Editar((Participante)vndEditar.BindingContext);
            lstParticipantes.ItemsSource = null;
            lstParticipantes.ItemsSource = part.ListaParticipante;
            grdTitulo.IsVisible = true;
        }

        private void NuevoFormulario_ParticipanteAgregado(object sender, EventArgs e)
        {
            try
            {
                part.Agregar((Participante)nuevoFormulario.BindingContext);
                lstParticipantes.ItemsSource = null;
                lstParticipantes.ItemsSource = part.ListaParticipante;
                if (part.ListaParticipante == null)
                    grdTitulo.IsVisible = false;
                else grdTitulo.IsVisible = true;
            }
            catch (Exception mm)
            {
                DisplayAlert("Mensaje", mm.Message, "Aceptar");
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Participante participante = new Participante();
            nuevoFormulario.BindingContext = participante;
            Navigation.PushAsync(nuevoFormulario);
        }


        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem i = (MenuItem)sender;
            Participante p = i.BindingContext as Participante;
            if (await DisplayAlert("Eliminar participante", $"¿Deseas eliminar el participante {p.Nombre}?", "Aceptar", "Cancelar"))
            {
                part.Eliminar(p);
                lstParticipantes.ItemsSource = null;
                lstParticipantes.ItemsSource = part.ListaParticipante;
            }
        }

        Participantes part = new Participantes();
        Formulario nuevoFormulario = new Formulario();
        EditarParticipante vndEditar = new EditarParticipante();
        private void BtnEditar_Clicked(object sender, EventArgs e)
        {
            MenuItem i = (MenuItem)sender;
            Participante p = i.BindingContext as Participante;
            vndEditar.BindingContext = p;
            Navigation.PushAsync(vndEditar);
        }

        vndVer ver = new vndVer();
        private void BtnVer_Clicked(object sender, EventArgs e)
        {
            MenuItem i = (MenuItem)sender;
            Participante p = i.BindingContext as Participante;
            ver.BindingContext = p;
            Navigation.PushAsync(ver);
        }
    }
}