using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Unidad2ZapateriaIxchel
{
    public class AdministracionZapatos
    {
        public ObservableCollection<Zapato> listaZapatos;
        public ObservableCollection<Zapato> ListaZapato { get { return listaZapatos; } }
        public ObservableCollection<Inventario> listaInventario;
        public ObservableCollection<Inventario> ListaInventario
        {
            get { return listaInventario; }
        }

        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader lector;

        public MySqlConnection Conexion
        {
            get { return conexion; }
        }

        private void Conectar()
        {
            conexion = new MySqlConnection("server=localhost;user=root;password=root;database=zapateriaixchel");
            if (conexion.State != ConnectionState.Open)

            { conexion.Open(); }
        }

        ~AdministracionZapatos()
        {
            if (conexion.State != ConnectionState.Closed)
                conexion.Close();
        }

        public AdministracionZapatos()
        {
            Conectar();
            comando = new MySqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from inventario";
            listaInventario = new ObservableCollection<Inventario>();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Inventario inv = new Inventario()
                {
                    idInventario = Convert.ToInt32(lector["idInventario"]),
                    Talla = (string)lector["talla"],
                    Unidades = Convert.ToInt16(lector["unidades"]),
                    AnchoPierna = (Convert.IsDBNull(lector["anchoPierna"])) ? "Sin dato" : lector["anchoPierna"].ToString(),
                    idZapato = Convert.ToInt32(lector["idZapato"])
                };
                listaInventario.Add(inv);
            }
            lector.Close();            
        }

        public ObservableCollection<Zapato> ObtenerListaZapato()
        {

            Conectar();
            comando = new MySqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "Select*from zapato";
            listaZapatos = new ObservableCollection<Zapato>();
            lector = comando.ExecuteReader();
            while(lector.Read())
            {
                Zapato z = new Zapato()
                {
                    idZapato = Convert.ToInt32(lector["idZapato"]),
                    Color = (string)lector["color"],
                    Costo = (decimal)lector["costo"],
                    Precio = (decimal)lector["precio"],
                    Altura = Convert.ToInt32(lector["altura"]),
                    Material = (string)lector["material"],
                    Modelo = (string)lector["modelo"],
                    Descripcion = (string)lector["descripcion"],
                    Marca = (string)lector["marca"]
                };
                listaZapatos.Add(z);
            }
            lector.Close();
            return listaZapatos;
        }

        public void Agregar(Inventario i)
        {
            if (string.IsNullOrEmpty(i.Talla))
                throw new ArgumentException("La talla es un campo requerido");
            if (i.Unidades <= 0)
                throw new ArgumentException("El número de unidades no puede estar en cero.");
            if (i.idZapato <= 0)
                throw new ArgumentException("No puede ser nulo el id del zapato");
            //Verifico que no esté
            comando = new MySqlCommand(string.Format("select count(*) from inventario where idZapato='{0}' and talla='{1}';", i.idZapato, i.Talla), conexion);

            int resultado = Convert.ToInt32(comando.ExecuteScalar());

            if (resultado > 0)
                throw new ArgumentException("Inventario ya registrado");
            if (i.AnchoPierna == "")
                i.AnchoPierna = "Sin dato";
            comando.CommandText = string.Format("insert into inventario(talla, unidades, anchoPierna, idZapato) values('{0}','{1}','{2}','{3}')", i.Talla, i.Unidades, i.AnchoPierna, i.idZapato);
            comando.ExecuteNonQuery();
            Inventario invent = new Inventario()
            {
                Talla = i.Talla,
                Unidades = i.Unidades,
                AnchoPierna = i.AnchoPierna,
                idZapato = i.idZapato
            };
            listaInventario.Add(invent);
            Normalidad();
        }

        public void Editar(Inventario i)
        {
            if (string.IsNullOrEmpty(i.Talla))
                throw new ArgumentException("La talla es un campo requerido");
            if (i.Unidades <= 0)
                throw new ArgumentException("El número de unidades no puede estar en cero.");
            if (i.idZapato <= 0)
                throw new ArgumentException("No puede ser nulo el id del zapato");
            //Consulta para saber si el contacto está registrado
            comando = new MySqlCommand(string.Format("select count(*) from inventario where idInventario='{0}'", i.idInventario), conexion);
            int resultado = Convert.ToInt32(comando.ExecuteScalar());
            if (resultado == 0)
                throw new ArgumentException("El inventario que intenta editar no está en la lista");

            comando.CommandText = string.Format("update inventario set talla='{0}', unidades='{1}', anchoPierna='{2}' where idInventario={3}", i.Talla, i.Unidades, i.AnchoPierna, i.idInventario);
            comando.ExecuteNonQuery();            
        }

        public void Eliminar(Inventario i)
        {
            comando = new MySqlCommand(string.Format("select count(*) from inventario where idInventario='{0}'", i.idInventario), conexion);
            int resultado = Convert.ToInt32(comando.ExecuteScalar());
            if (resultado == 0)
                throw new ArgumentException("El contacto no se encuentra registrado en la base de datos");

            comando.CommandText = string.Format("delete from inventario where idInventario='{0}'", i.idInventario);
            comando.ExecuteNonQuery();
            listaInventario.Remove(i);
        }

        public void Normalidad()
        {
            Conectar();
            comando = new MySqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from inventario";
            listaInventario = new ObservableCollection<Inventario>();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Inventario inv = new Inventario()
                {
                    idInventario = Convert.ToInt32(lector["idInventario"]),
                    Talla = (string)lector["talla"],
                    Unidades = Convert.ToInt16(lector["unidades"]),
                    AnchoPierna = (Convert.IsDBNull(lector["anchoPierna"])) ? "Sin dato" : lector["anchoPierna"].ToString(),
                    idZapato = Convert.ToInt32(lector["idZapato"])
                };
                listaInventario.Add(inv);
            }
            lector.Close();
        }
    }
}
