# tl2-tp4-2023-maurijs
creo o busco el directorio/carpeta donde estara la webapi
Ejecuto el comando dotnet new webapi (crea un esqueleto de una web api funcional a modo de ejemplo, que es del clima)
Compilo el programa y copio el link, ej:
Compilando...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5201 <---- link q necesito
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\mauri\OneDrive\Documentos\Facultad\3ero\TDL2\TPs\tp4\tl2-tp4-2023-maurijs
Pongo en el navegador el link y le agrego /Swagger
 http://localhost:5201/Swagger

Ahi estare probando si anda la api

Creo una carpeta Models, en ella iran las clases

Para parar el consumo de la api debo tocar Ctrl + c en la terminal, y la pagina dejara de andar

Incorporaciones para el tp5:
private AccesoADatos AccesoADatosCadeteria;
private AccesoADatos AccesoADatosCadetes;
private AccesoADatos AccesoADatosPedidos;

public static Cadeteria GetInstance()
      {
      if (instance == null)
      {
            var AccesoADatosCadeteria = new AccesoADatosCadeteria();
            instance = AccesoADatosCadeteria.Obtener();
            instance.AccesoADatosCadetes = new AccesoADatosCadetes();
            instance.AccesoADatosPedidos = new ACcesoADatosPedidos();
            instance.CargarCadetes();
            instance.CargarPedidos();
      }
      return instance;
}
