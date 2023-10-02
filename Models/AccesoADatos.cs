using System.Text.Json;
namespace webapi
{
    //todos los accesos son JSON
    public class AccesoADatosCadeteria
    {
        public AccesoADatosCadeteria(){}
        public  Cadeteria ObtenerCadeteria()
        {
            string DataPath = "cadeteria.json";
            try
            {
                // Lee el contenido del archivo JSON
                string jsonText = File.ReadAllText(DataPath);

                // Deserializa el JSON en una lista de objetos Cadete
                var cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonText);
                Console.WriteLine("Cadeteria cargada correctamente");
                Console.WriteLine(cadeteria.Nombre);
                Console.WriteLine(cadeteria.Telefono );
                return cadeteria;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar Cadeteria desde el archivo JSON: {ex.Message}");
            }
            return null;
        }
    }
    public class AccesoADatosCadetes
    { 
        public AccesoADatosCadetes(){}
        public  List<Cadete> Obtener()
        {
            List<Cadete> cadetes = null;
            string DataPath = "cadetes.json";
            try
            {
                // Lee el contenido del archivo JSON
                string jsonText = File.ReadAllText(DataPath);

                // Deserializa el JSON en una lista de objetos Cadete
                cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonText);
                Console.WriteLine("Cadetes cargados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetes desde el archivo JSON: {ex.Message}");
            }

            return cadetes;
        }
        public void Guardar(List<Cadete> cadetes)
        {  
            string DataPath = "cadetes.json";
            string jsonText = JsonSerializer.Serialize(cadetes);
            using (var archivo = new FileStream(DataPath, FileMode.OpenOrCreate))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", jsonText);
                    strWriter.Close();
                }
            }
        }
    }
    public class AccesoADatosPedidos
    { 
        public AccesoADatosPedidos(){}
        public  List<Pedido> Obtener()
        {
            List<Pedido> pedidos = null;
            string DataPath = "pedidos.json";
            try
            {
                // Lee el contenido del archivo JSON
                string jsonText = File.ReadAllText(DataPath);

                // Deserializa el JSON en una lista de objetos Cadete
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonText);
                Console.WriteLine("Pedidos cargados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar pedidos desde el archivo JSON: {ex.Message}");
            }
            return pedidos;
        }

        public void Guardar(List<Pedido> Pedidos)
        {  
            string DataPath = "pedidos.json";
            string jsonText = JsonSerializer.Serialize(Pedidos);
            using (var archivo = new FileStream(DataPath, FileMode.OpenOrCreate))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", jsonText);
                    strWriter.Close();
                }
            }
        }

    }
}

/*Por si trabajo con listado de
[
    {
        "nombre": "Cadeteria 1",
        "telefono": " 3858 111111",
        "listadoCadetes": [],
        "listadoPedidos": []
    },
    {
        "nombre": "Cadeteria 2",
        "telefono": " 3858 222222",
        "listadoCadetes": [],
        "listadoPedidos": []
    },
    {
        "nombre": "Cadeteria 3",
        "telefono": " 3858 3333333",
        "listadoCadetes": [],
        "listadoPedidos": []
    }
]*/