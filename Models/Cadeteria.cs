namespace webapi
{
    public class Cadeteria
    {
        private static Cadeteria instance;
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;
        private AccesoADatosCadetes accesoADatosCadetes;
        private AccesoADatosPedidos accesoADatosPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        //Constructores
        public Cadeteria(){}
        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }
        public Cadeteria(string nombre, string telefono, List<Cadete> listado)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = listado;
            listadoPedidos = new List<Pedido>();
        }

        //Metodos para obtener/guardar los datos
        public void CargarCadetes()
        {
            listadoCadetes = accesoADatosCadetes.Obtener();
        }
        public void CargarPedidos()
        {
            listadoPedidos = accesoADatosPedidos.Obtener();
        }
        public void GuardarPedidos()
        {
            accesoADatosPedidos.Guardar(ListadoPedidos);
        }       
 
        public static Cadeteria GetInstance()
        {
            if (instance == null)
            {
                var accesoADatosCadeteria = new AccesoADatosCadeteria();
                instance = accesoADatosCadeteria.ObtenerCadeteria();
                instance.accesoADatosCadetes = new AccesoADatosCadetes();
                instance.accesoADatosPedidos = new AccesoADatosPedidos();
                instance.CargarCadetes();
                instance.CargarPedidos();
            }
            return instance;
        }

        //Metodos para manipular/crear los datos
        public void CrearPedido(int numero, float monto, string observacion,string nombre, string telefono, string direccion, string referenciaDireccion)
        {
            var cliente = new Cliente(nombre, telefono, direccion, referenciaDireccion);
            var pedido = new Pedido(numero, monto, observacion, Estado.Aceptado, cliente);
            listadoPedidos.Add(pedido);
        }
        public Pedido CrearPedido(Pedido P)
        {
            
            ListadoPedidos.Add(P);
            P.Numero = ListadoPedidos.Count;
            GuardarPedidos();
            return P;
        }
         public Pedido ModificarPedido(Pedido pedido)
        {
            var pedidoAModificar = GetPedidoByID(pedido.Numero);
            pedidoAModificar.Observacion =  pedido.Observacion;
            GuardarPedidos();
            return pedidoAModificar;
        }


        public Pedido AsignarCadeteAPedido(int NumPedido, int  IDcadete)
        {
            var pedido = GetPedidoByID(NumPedido);
            var cadete = GetCadeteByID(IDcadete);
            pedido.Cadete = cadete;
            GuardarPedidos();
            return pedido;
        } 

        public Pedido ReasignarPedido(int NumPedido, int IdCadete)
        {
            Pedido pedido = null;
            Cadete cadete = null;
            if (ContieneCadete(IdCadete))
            {
                if (ContienePedido(NumPedido))
                {
                    pedido = GetPedidoByID(NumPedido);
                    cadete = GetCadeteByID(IdCadete);
                    pedido.Cadete = cadete;
                }
            }
            GuardarPedidos();
            return pedido;
        }

        public void DarAltaPedido(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Aceptado;
            GuardarPedidos();
        }
        public void CancelarPedido(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Cancelado;
            GuardarPedidos();
        }
        public void PedidoEntregado(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Recibido;
            GuardarPedidos();
        }
        public Pedido CambiarEstadoPedido(int idPedido, int NuevoEstado)
        {
            var pedido = GetPedidoByID(idPedido);
            // Si el pedido fue cancelado o ya fue entregado no se puede cambiar el estado
            if (pedido.Estado == Estado.Aceptado){
                switch (NuevoEstado)
                {
                    case 0:
                        PedidoEntregado(idPedido);
                        break;
                    case 1:
                        CancelarPedido(idPedido);
                        break;
                }
            }
            GuardarPedidos();
            return pedido;
        }

        public bool ContienePedido(int NumPedido)
        {
            foreach (var pedido in listadoPedidos)
                {
                    if (pedido.Numero == NumPedido)
                    {
                        return true;
                    }
                }
            return false;
        }
        public bool ContieneCadete(int id)
        {
            foreach (var cadete in listadoCadetes)
            {
                if (cadete.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Cadete GetCadeteByID(int id)
        {
            return ListadoCadetes.FirstOrDefault(Cadete => Cadete.Id == id);
            /*foreach (var cadete in listadoCadetes)
            {
                if (cadete.Id == id)
                {
                    return cadete;
                }
            }
            return null;*/
        }
        public Pedido GetPedidoByID(int id)
        {
            return ListadoPedidos.FirstOrDefault(Pedido => Pedido.Numero == id);
        }

        //Metodos para el cadete
        public float JornalACobrarCadete(int IdCadete)
        {
            float Ganancias = Calcular(IdCadete, 1);
            return Ganancias;
        }
        public float MontoTotalCadete(int IdCadete)
        {
            float Ganancias = Calcular(IdCadete, 2);
        
            return Ganancias;
        }
        public int EnviosRealizados(int IdCadete)
        {
            int contador = (int)Calcular(IdCadete, 3);
            return contador;
        }
        // Funcion que calcula: 1-ganancias individuales (jornalAcobrar), 2-Ganancias de todos los pedidos del cadete, 
        // 3- Cantidad de envios realizados
        private float Calcular(int IdCadete, int tipo)
        {
            float cantidad = 0;
            if (ContieneCadete(IdCadete))
            {
                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.GetCadeteID() == IdCadete)
                    {
                        if (pedido.Estado == Estado.Recibido)
                        {
                            switch (tipo)
                            {
                                case 1:
                                    cantidad += 500;
                                    break;
                                case 2:
                                    cantidad += pedido.Monto;
                                    break;
                                case 3:
                                    cantidad++;
                                    break;
                            }
                        }
                    }
                }
            } 
            return cantidad;
        }
     
    }
    
}
