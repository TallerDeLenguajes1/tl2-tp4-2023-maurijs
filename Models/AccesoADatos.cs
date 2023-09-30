using System.Text.Json;
namespace webapi
{
    //todos los accesos son JSON
    public class AccesoADatosCadeteria 
    { 
        public  Cadeteria Obtener()
        {
            List<Cadeteria> cadeterias = null;
            string DataPath = "cadeteria.json";
            try
            {
                // Lee el contenido del archivo JSON
                string jsonText = File.ReadAllText(DataPath);

                // Deserializa el JSON en una lista de objetos Cadete
                cadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonText);
                Console.WriteLine("Cadetes cargados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetes desde el archivo JSON: {ex.Message}");
            }

            return cadeterias[0];
        }
    }
    public class AccesoADatosCadetes
    { 
        public  List<Cadete> Obtener()
        {
            List<Cadete> cadetes = null;
            string DataPath = "cadete.json";
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
    }
    public class AccesoADatosPedidos
    { 
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
                Console.WriteLine("Cadetes cargados correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetes desde el archivo JSON: {ex.Message}");
            }
            return pedidos;
        }
    }
}
