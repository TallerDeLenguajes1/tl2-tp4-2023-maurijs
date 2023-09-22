using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    // el objeto quedara guardado para seguir trabajandolo
    private static Cadeteria cadeteriaSingleTon;
    private Cadeteria cadeteria;

    public static Cadeteria GetCadeteria()
    {
        return cadeteriaSingleTon;
    }
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        //Inicializo a traves del controlador
        cadeteriaSingleTon = cadeteriaSingleTon.GetCadeteria();
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
        var pedidos = cadeteriaSingleTon.ListadoPedidos;
        if (pedidos != null)
        {
            return Ok(pedidos); // Devuelve una respuesta HTTP 200 OK con los pedidos
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

    [Get] GetPedidos() => Retorna una lista de Pedidos
    [Get] GetCadetes() => Retorna una lista de Cadetes
    [Get] GetInforme() => Retorna un objeto Informe
    [Post] AgregarPedido(Pedido pedido)
    [Put] AsignarPedido(int idPedido, int idCadete)
    [Put] CambiarEstadoPedido(int idPedido,int NuevoEstado)
    [Put] CambiarCadetePedido(int idPedido,int idNuevoCadete)


}
