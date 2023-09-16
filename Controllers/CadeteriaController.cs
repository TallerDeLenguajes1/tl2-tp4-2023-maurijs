using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    // el objeto quedara guardado para seguir trabajandolo
    private static Cadeteria cadeteriaSingleTon;
    // private Cadeteria cadeteria;

    public static Cadeteria GetCadeteria()
    {
        if (cadeteriaSingleTon == null) return null;
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
        return Ok("cadeteria de prueba");
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
    /*public ActionResult<IEnumerable<Pedido>> AddPedido(Pedido P)
    {
        cadeteriaSingleTon.CrearPedido(P);
    }*/
    /*public Get()
    {
       
    }*/

    /*[HttpPost] //Agrega datos
    public ActionResult<Pedido> UpdatePedido(Pedido pedido)
    {
        var updPed = cadeteria.UpdatePedido(pedido)
    }*/
}
