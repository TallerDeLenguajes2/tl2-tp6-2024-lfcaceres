
//using System.Data.SQLite;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
public class PresupuestoRepository : IPresupuestoRepostory
{
    private string cadenaConexion = "Data Source=db/Tienda.db";
    public void CrearNuevo(Presupuesto pres)
    {
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Descripcion", pres.Nombre));
            command.Parameters.Add(new SqliteParameter("@Precio", pres.Detalle));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    
    public Presupuesto ObtenerDetallePorID(int id)
    {
        Presupuesto presu = new Presupuesto();
        using ( SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            var query = "Select p.idPresupuesto,p.NombreDestinatario,Pr.idProducto as idProducto, cantidad, Descripcion, Precio FROM Presupuestos p INNER JOIN PresupuestosDetalle ON p.idPresupuesto = PresupuestosDetalle.idPresupuesto INNER JOIN Productos Pr ON PresupuestosDetalle.idProducto = Pr.idProducto WHERE p.idPresupuesto = @IdPresupuesto";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@IdPresupuesto", id));

            using (SqliteDataReader reader = command.ExecuteReader())
                {   
                    
                    while (reader.Read())
                    {
                        //PresupuestoDetalle presdet = new PresupuestoDetalle();
                        Producto prod=new Producto();
                        presu.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                        presu.Nombre = reader["NombreDestinatario"].ToString();
                        prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                        prod.Descripcion=reader["Descripcion"].ToString();
                        prod.Precio=Convert.ToInt32(reader["Precio"]);
                        int Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        //presdet.CargaProducto(prod);
                        presu.AgregaProducto(prod,Cantidad);
                         
                    }
                }
            connection.Close();
        }
        return presu;
    }

    public bool AgregarProducto(int id, Producto prod, int cant){
        
        return true;
    }

    public List<Presupuesto> ListarPresupuestos()
        {
            List<Presupuesto> listaProd = new List<Presupuesto>();
            using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Presupuesto;";
                SqliteCommand command = new SqliteCommand(query, connection);
                connection.Open();
                using(SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var presu = new Presupuesto();
                        presu.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                        presu.Nombre = reader["NombreDestinatario"].ToString();
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
                string query = @"DELETE FROM Productos WHERE id = @id;";
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.Add(new SqliteParameter("@id", id));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
}