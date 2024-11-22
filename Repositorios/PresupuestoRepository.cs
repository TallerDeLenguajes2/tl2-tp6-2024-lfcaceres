
//using System.Data.SQLite;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using claseCliente;
public class PresupuestoRepository : IPresupuestoRepostory
{
    private string cadenaConexion = "Data Source=db/Tienda.db";
    public void CrearNuevo(Presupuesto pres)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Presupuestos (ClienteId,FechaCreacion) VALUES (@ClienteId,@Fecha)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@ClienteId", pres.Clientes.ClienteId));
            DateTime fechaActual = DateTime.Now;
            command.Parameters.Add(new SqliteParameter("@Fecha", fechaActual.ToString() ));
            //command.Parameters.Add(new SqliteParameter("@Precio", pres.Detalle));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }


    public bool AgregarProductoPresupuesto(int id, Producto prod, int cant)
    {
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES (@idPresupuesto, @idProducto, @Cantidad)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@idPresupuesto", id));
            command.Parameters.Add(new SqliteParameter("@idProducto", prod.IdProducto));
            command.Parameters.Add(new SqliteParameter("@Cantidad", cant));
            command.ExecuteNonQuery();
            connection.Close();
        }
        return true;
    }

    public List<Presupuesto> ListarPresupuestos()
    {
        List<Presupuesto> listaProd = new List<Presupuesto>();
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            string query = "SELECT p.idPresupuesto, p.ClienteId, Nombre, Email, Telefono, r.idProducto, Descripcion, Precio, Cantidad FROM Presupuestos as p INNER JOIN Clientes as c ON p.ClienteId=c.ClienteId INNER JOIN PresupuestosDetalle as d ON p.idPresupuesto = d.idPresupuesto INNER JOIN Productos as r ON d.idProducto = r.idProducto ORDER BY p.idPresupuesto;";
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var presu = new Presupuesto();
                    presu.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);

                    var cl = new Cliente();
                    cl.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    cl.Nombre = reader["Nombre"].ToString();
                    cl.Email = reader["Email"].ToString();
                    cl.Telefono = reader["Telefono"].ToString();

                    presu.Clientes = cl;

                    var prod = new Producto();
                    prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    prod.Descripcion = reader["Descripcion"].ToString();
                    prod.Precio = Convert.ToInt32(reader["Precio"]);

                    presu.AgregaProducto(prod, Convert.ToInt32(reader["Cantidad"]));
                    // var det = new PresupuestoDetalle();
                    // det.Producto.Add(prod);
                    // det.Cantidad = ;

                    // presu.Detalle.Add(det);

                    listaProd.Add(presu);
                }
            }
            connection.Close();

        }
        return listaProd;
    }

    public void EliminarPresupuesto(int id)
    {
        try
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
        catch
        {
            Console.Write("No se puede eliminar el producto");
        }

    }




}