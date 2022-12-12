using Microsoft.AspNetCore.Mvc;
using RetoNetcore2.HttpApi.Models;

namespace RetoNetcore2.HttpApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController:ControllerBase
{
    private static readonly List<Usuario> usuarios = new List<Usuario>(){
        new Usuario(){Cedula="1724956402",Nombre="Maria Reed"},
        new Usuario(){Cedula="1724949449",Nombre="Lizzie Sandoval"},
        new Usuario(){Cedula="1724918957",Nombre="Derek Moore"},
        new Usuario(){Cedula="1724957748",Nombre="Delia Newman"},
        new Usuario(){Cedula="1724945814",Nombre="Jimmy Paul"},
        new Usuario(){Cedula="1724979193",Nombre="Mina Beck"},
        new Usuario(){Cedula="1724912053",Nombre="Georgia Collins"},
        new Usuario(){Cedula="1724984520",Nombre="Sean Beck"},
        new Usuario(){Cedula="1724984716",Nombre="Lloyd Robertson"},
        };

    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger=logger;
    }

    [HttpGet]
    public string GetUsuario([FromHeader] string cedula)
    {
        if(usuarios.Any(x=>x.Cedula.Equals(cedula)))
        {
            var base64EncodedBytes = System.Text.Encoding.UTF8.GetBytes(cedula);
            var resultadoEncoding = System.Convert.ToBase64String(base64EncodedBytes);
            _logger.LogWarning($"||METODO GET||cedula: {resultadoEncoding}||CODIGO: 200");
            return $"||METODO GET||cedula:{resultadoEncoding}||CODIGO: 200";
        }
        else
        {
            throw new ArgumentException($"No existe un usuario con cedula {cedula}");
        }
        
        
        
    }
}
