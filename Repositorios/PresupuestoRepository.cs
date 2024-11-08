
//using System.Data.SQLite;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
public class PresupuestoRepository : IPresupuestoRepostory
{
    private string cadenaConexion = "Data Source=db/Tienda.db";
    public void CrearNuevo(Presupuesto pres)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Presupuestos (ClienteId) VALUES (@ClienteId)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@ClienteId", pres.Clientes.ClienteId));
            //command.Parameters.Add(new SqliteParameter("@Precio", pres.Detalle));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }


    public bool AgregarProducto(int id, Producto prod, int cant)
    {

        return true;
    }

    public List<Presupuesto> ListarPresupuestos()
    {
        List<Presupuesto> listaProd = new List<Presupuesto>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = "SELECT idPresupuesto,ClienteId,Nombre,Email,Telefono, idProducto, Descripcion, Precio FROM Presupuestos as p INNER JOIN Clientes as c ON p.ClienteId=c.ClienteId INNER JOIN PresupuestosDetalle as d ON p.idPresupuesto = d.idPresupuesto INNER JOIN Productos as r ON d.idProducto = r.idProducto;";
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var presu = new Presupuesto();
                    presu.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presu.Clientes.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    presu.Clientes.Nombre= reader["Nombre"].ToString();
                    presu.Clientes.Email = reader["Email"].ToString();
                    presu.Clientes.Telefono = reader["Telefono"].ToString();
                    listaProd.Add(presu);
                }
            }
            connection.Close();

        }
        return listaProd;
    }

    public void EliminarPresupuesto(int id)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = @"DELETE FROM Presupuestos WHERE idPresupuesto = @id;";
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id", id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}