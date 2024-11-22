using claseCliente;
namespace AltaPresupuesto
{
    public class AltaPresupuestoViewModel
    {
        int idPresupuesto;
        int idCliente;
        List<Cliente> listaclientes;
        public AltaPresupuestoViewModel()
        {
            IdPresupuesto = 0;
            Listaclientes = new List<Cliente>();
        }
        public AltaPresupuestoViewModel(int idPresu,List<Cliente> cli)
        {
            IdPresupuesto = idPresu;
            Listaclientes = cli;

        }

        public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value;}
        public List<Cliente> Listaclientes { get => listaclientes; set => listaclientes = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
    }
}