using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Ajedrez
{
    public class Participantes
    {
        private List<Participante> listap =new List<Participante>();
        public List<Participante> ListaParticipante
        {
            get { return listap; }
        }

        public void Agregar(Participante p)
        {
            if (string.IsNullOrEmpty(p.Nombre))
                throw new ArgumentException("Escriba el nombre del participante");
            if(string.IsNullOrEmpty(p.ApellidoP))
                throw new ArgumentException("Escriba el apellido paterno del participante");
            if (string.IsNullOrEmpty(p.ApellidoM))
                throw new ArgumentException("Escriba el apellido materno del participante");
            if (string.IsNullOrEmpty(p.Edad))
                throw new ArgumentException("Escriba una edad válida");
            //Asegurarme que la lista está creada
            if (listap == null)
                listap = new List<Participante>();
            //Asegurarme que no haya el mismo participante
            if (listap.Any(x => x.Nombre == p.Nombre && x.ApellidoP==p.ApellidoP&&x.ApellidoM==p.ApellidoM))
                throw new ArgumentException("Ya se ha realizado la inscripción del jugador");
            listap.Add(p);
            Guardar();
        }
        public void Editar(Participante p)
        {
            
            if(listap!=null)
            {
                var temp = listap.FirstOrDefault(x => x.Nombre == p.Nombre);
                temp.Edad = p.Edad;
                Guardar();
            }
        }
        public void Eliminar(Participante p)
        {
            if(listap!=null)
            {
                listap.Remove(p);
                Guardar();
            }
        }
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public void Guardar()
        {
            //Serializa
            FileStream archivo = new FileStream(ruta + "/ajedrez.txt", FileMode.Create);
            BinaryFormatter serializar = new BinaryFormatter();
            serializar.Serialize(archivo, listap);
            archivo.Close();
        }
        public void Cargar()
        {
            //Deserializa
            if(File.Exists(ruta + "/ajedrez.txt"))
            {
                BinaryFormatter deserializar = new BinaryFormatter();
                FileStream archivo=new FileStream(ruta + "/ajedrez.txt", FileMode.Open);
                if (listap == null)
                    listap = new List<Participante>();
                listap = (List<Participante>)deserializar.Deserialize(archivo);
                archivo.Close();
            }
        }

    }
}
