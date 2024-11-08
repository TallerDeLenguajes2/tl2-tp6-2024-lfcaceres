
//using System.Data.SQLite;
using Microsoft.Data.Sqlite;
public class ProductoRepository : IProductoRepostory
{
    private string cadenaConexion = "Data Source=db/Tienda.db";
    public void CrearNuevo(Producto prod)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", prod.Descripcion));
            command.Parameters.Add(new SqliteParameter("@Precio", prod.Precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void ModificarProducto(int id, Producto prod)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "UPDATE Productos SET Descripcion = @NuevaDescripcion, Precio = @NuevoPrecio WHERE idProducto = @IdProducto";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@NuevaDescripcion", prod.Descripcion));
            command.Parameters.Add(new SqliteParameter("@NuevoPrecio", prod.Precio));
            command.Parameters.Add(new SqliteParameter("@IdProducto", id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public Producto ObtenerProductoPorID(int id)
    {
        Producto prod = new Producto();
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "Select * FROM Productos WHERE idProducto = @IdProducto";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@IdProducto", id));

            using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion = reader["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader["Precio"]);
                    }
                }
            connection.Close();
        }
        return prod;
    }

    public List<Producto> ListarProducto()
        {
            List<Producto> listaProd = new List<Producto>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Productos;";
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var prod = new Producto();
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion = reader["Descripcion"].ToString();
                        prod.Precio = Convert.ToInt32(reader["Precio"]);
                        listaProd.Add(prod);
                    }
                }
                connection.Close();

            }
            return listaProd;
        }

        public void EliminarProducto(int id)
        {
             using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = @"DELETE FROM Productos WHERE idProducto = @id;";
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
}