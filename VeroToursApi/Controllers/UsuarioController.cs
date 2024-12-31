using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeroToursApi.Context;
using VeroToursApi.DTOS;
using VeroToursApi.Interfaces;
using VeroToursApi.Models;

namespace VeroToursApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var response = await _usuarioService.ListarUsuarios();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("crearUsuario")]
        public async Task<ActionResult> CrearUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var response = await _usuarioService.CrearUsuario(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editarUsuario")]

        public async Task<ActionResult> EditarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var response = await _usuarioService.EditarUsuario(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("borrarUsuario/{id:int}")]
        public async Task<ActionResult> BorrarUsuario(int id)
        {
            try
            {
                var response = await _usuarioService.BorrarUsuario(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
