using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

//Para c# estos serian los "atributos", y a los atributos de la clase se los conocen como campos
[ApiController]
[Route("[controller]")]
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
    [HttpGet]
    [Route("Cadetes")]
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
    [HttpPost("AddPedido")]
    public ActionResult<Pedido> PostPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.CrearPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPut("UpdatePedido")]
    public ActionResult<Pedido> PutPedido(Pedido pedido)
    {
    
        var pedidoModificado = cadeteria.ModificarPedido(pedido);
        return Ok(pedidoModificado);
    }

    [HttpGet("Informe")]
    public ActionResult<Informe> GetInforme()
    {
        var informe = new Informe(cadeteria);
        informe.MostrarInfCompleto();
        return Ok(informe);
    }   

    [HttpPut("AsignarPedido")]
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
