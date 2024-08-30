using Dapper;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UIDesign.Model;

namespace UIDesign.Connector
{
    public class MainData
    {
        public static ObservableCollection<ContactoModel> ListarContactos()
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.dataBase))
            {
                string storedProcedure = "sp_Listar";
                var contactos = conn.Query<ContactoModel>(
                    storedProcedure,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return new ObservableCollection<ContactoModel>(contactos);
            }
        }

        public static void GuardarContacto(string nombre, string posicion, string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.dataBase))
            {
                string storedProcedure = "sp_GuardarContacto";

                var parameters = new
                {
                    Nombre = nombre,
                    Posicion = posicion,
                    Correo = correo,
                    Telefono = telefono
                };

                conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.dataBase))
            {
                string storedProcedure = "sp_EliminarContacto";

                var parameters = new
                {
                    IdContacto = id
                };

                conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public static void EditarContacto(int id, string nombre, string posicion, string correo, string telefono)
        {
            using (SqlConnection conn = new SqlConnection(ConexionBD.dataBase))
            {
                string storedProcedure = "sp_EditarContacto";

                var parameters = new
                {
                    IdContacto = id,
                    Nombre = nombre,
                    Posicion = posicion,
                    Correo = correo,
                    Telefono = telefono

                };

                conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
