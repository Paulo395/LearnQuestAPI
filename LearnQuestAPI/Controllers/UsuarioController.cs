using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ListarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.ListarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuarios = await _usuarioRepository.BuscarPorId(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AdicionarUsuario([FromBody] Usuario usuario)
        {
            Usuario usuarioCad = await _usuarioRepository.AdicionarUsuario(usuario);
            return Ok(usuarioCad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> AtualizarUsuario([FromBody] Usuario usuario, int id)
        {
            usuario.Id = id;
            Usuario usuarioAt = await _usuarioRepository.AtualizarUsuario(usuario, id);
            return Ok(usuarioAt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> ApagarUsuario(int id)
        {
            bool apagar = await _usuarioRepository.ApagarUsuario(id);
            return Ok(apagar);
        }
    }
}
