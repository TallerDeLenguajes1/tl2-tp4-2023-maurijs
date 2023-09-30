namespace webapi
{
    public class Cliente
    {
        private string nombre;
        private string telefono;
        private string direccion;
        private string referenciaDireccion;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string ReferenciaDireccion { get => referenciaDireccion; set => referenciaDireccion = value; }
    
        public Cliente(){}
        public Cliente(string nombre, string telefono, string direccion, string referenciaDireccion)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.referenciaDireccion = referenciaDireccion;
        }
    }
}