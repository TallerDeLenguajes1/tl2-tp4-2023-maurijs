namespace webapi
{
    public enum Estado
    {
        Aceptado,
        Cancelado,
        Recibido
    }
    
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Estado estado;
        private Cliente cliente;
        private Cadete cadete;
        private float monto;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }
        public float Monto { get => monto; set => monto = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public Pedido() 
        { }
        public Pedido(int numero, float monto, string observacion, Estado estado, Cliente cliente)
        {
            this.numero = numero;
            this.observacion = observacion; 
            this.estado = estado;
            this.cliente = cliente;
            this.monto = monto;
        }

        public int GetCadeteID()
        {
            return cadete.Id;
        }
        public bool HasThisNumber(int numeroPedido)
        {   
            if (numero == numeroPedido){ return true; };
            return false;
        }
        public string VerDireccionCliente()
        {
            return cliente.Direccion + " - " + cliente.ReferenciaDireccion;
        }
        public string VerDatosCliente()
        {
            return cliente.Nombre + " - " + cliente.Telefono;
        }
    }
}
