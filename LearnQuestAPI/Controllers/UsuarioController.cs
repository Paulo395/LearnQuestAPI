using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnQuestAPI.Models;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ListarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.ListarTodosUsuarios();
            return Ok(usuarios);
        }
    }
}
