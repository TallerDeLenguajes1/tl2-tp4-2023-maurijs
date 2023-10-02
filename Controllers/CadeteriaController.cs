using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

//Para c# estos serian los "atributos", y a los atributos de la clase se los conocen como campos
[ApiController] //atributo que se aplica sobre un controlador 
[Route("[controller]")] //es la ruta de acceso a este controlador, [controller] quiere decir que la ruta sera CadeteriaController
                        //Todos los verbos GET, PUT, etc estan dentro de esta clase
public class CadeteriaController : ControllerBase
{
    // el objeto quedara guardado para seguir trabajandolo
    private Cadeteria cadeteria;

    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        //Inicializo a traves del controlador
        cadeteria = Cadeteria.GetInstance(); // GetCadeteria es static asi que puedo usar el metodo sin crear una instancia de la clase
    }

    //metodo que se consume del controlador
    [HttpGet] // no posee parametros
    public ActionResult<string> GetNombreCadeteria()
    {
        return Ok(cadeteria.Nombre);
    }

    [HttpGet]
    [Route("Pedidos")] // debe tener este parametro, ya q no puedo tener dos get sin parametro
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = cadeteria.ListadoPedidos;
        if (pedidos != null)
        {
            return Ok(pedidos); // Devuelve una respuesta HTTP 200 OK con los pedidos
        } 
        else
        {
            return NotFound(); // Devuelve una respuesta HTTP 404 Not Found
        }
    }
    [HttpGet("pedido/{id}")]
    
    public ActionResult<Pedido> GetPedido(int id)
    {
        return Ok(cadeteria.GetPedidoByID(id));
    }
    [HttpGet("Cadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes()
    {
        var cadetes = cadeteria.ListadoCadetes;
        if (cadetes != null)
        {
            return Ok(cadetes); // Devuelve una respuesta HTTP 200 OK con los pedidos
        } 
        else
        {
            return NotFound(); // Devuelve una respuesta HTTP 404 Not Found
        }
    }

    [HttpGet("Cadete/{id}")] // no me apareceran los parametros en el postman, tengo q agregarlos en el url
    // escribir el parametro en la ruta hace que sea obligatorio mandar un parametro
    public ActionResult<Pedido> GetCadete(int id)
    {
        return Ok(cadeteria.GetCadeteByID(id));
    }

    [HttpPost("AddPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.CrearPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPost("AddCadete")]
    public ActionResult<Pedido> AgregarCadete(Cadete cadete)
    {
        cadete = cadeteria.CrearCadete(cadete);
        return Ok(cadete);
    }

    [HttpPut("UpdatePedido")]
    public ActionResult<Pedido> ModificarPedido(Pedido pedido)
    {
    
        var pedidoModificado = cadeteria.ModificarPedido(pedido);
        return Ok(pedidoModificado);
    }

    [HttpGet("Informe")]
    public ActionResult<Informe> GetInforme()
    {
        var informe = new Informe(cadeteria);
        return Ok(informe);
    }   

    [HttpPut("AsignarPedido")] //si no incluyo los parametros en la ruta si me apareceran en el postman ya que lo que haria seria
                               // cargarlos por formulario
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var pedido = cadeteria.AsignarCadeteAPedido(idPedido, idCadete);
        return Ok(pedido);
    }
    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, int NuevoEstado)
    {
        var pedidoCambiado = cadeteria.CambiarEstadoPedido(idPedido, NuevoEstado);
        return Ok(pedidoCambiado);
    }
    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido,int idNuevoCadete)
    {
        var pedido = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(pedido);
    }
}
