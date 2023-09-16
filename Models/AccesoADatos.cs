using System.Text.Json;
namespace webapi
{
    public abstract class AccesoADatos
    {
        private string dataPath;
        public string DataPath { get => dataPath; set => dataPath = value; }
        public AccesoADatos(string DirArchivo)
        {
            DataPath = DirArchivo;
        }

        /*public virtual List<Cadete> cargarCadetes()
        {
            // Si uso virtual debo escribir una definicion generica para este metodo, es decir, debo escribir alguna instruccion aqui
            // si uso abstract no debo incluir nada aqui, pero la clase AccesoADatos se volvera abstracta
        }*/
        public abstract List<Cadete> cargarCadetes();
    }
    public class AccesoCSV : AccesoADatos
    {
        public AccesoCSV(string DirArchivo) : base(DirArchivo)
        {
        }     
        public override List<Cadete> cargarCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            var cadetesCargados = File.ReadAllLines(DataPath)
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
            cadetes.AddRange(cadetesCargados);
            Console.WriteLine("Cadetes cargados correctamente");
            return cadetes;
        }
    }
    public class AccesoJSON : AccesoADatos
    {
        public AccesoJSON(string DirArchivo) : base(DirArchivo)
        {
        }     
        public override List<Cadete> cargarCadetes()
        {

            List<Cadete> cadetes = new List<Cadete>();
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
}
