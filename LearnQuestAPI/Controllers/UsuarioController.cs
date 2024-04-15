using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using LearnQuestAPI.Models.Enum;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _config;
        public UsuarioController(IUsuarioRepository usuarioRepository, IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _config = config;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var usuario = await _usuarioRepository.BuscarCredenciais(login.Email, login.Senha);
            if (usuario == null)
                return Unauthorized();

            // Determine o tipo de usuário com base nas suas regras de negócio
            var tipoUsuario = DetermineTipoUsuario(usuario);

            // Retorne o tipo de usuário junto com a resposta
            return Ok(new { tipoUsuario = tipoUsuario });
        }

        private string DetermineTipoUsuario(Usuario usuario)
        {
            switch (usuario.Tipo)
            {
                case TipoUsuario.Admin:
                    return "Admin";
                case TipoUsuario.Aluno:
                    return "Aluno";
                default:
                    return "Desconhecido";
            }
        }


    }
}
