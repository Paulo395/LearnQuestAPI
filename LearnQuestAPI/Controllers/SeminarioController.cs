using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarioController : ControllerBase
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public SeminarioController(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }

        [HttpGet]
        [Route("listar-todos")] //Solução erro API, dois http Get
        public async Task<ActionResult<IEnumerable<Seminario>>> ListarTodosSeminario()
        {
            var seminarios = await _seminarioRepository.ListarTodosSeminario();
            return Ok(seminarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seminario>> BuscarPorId(int id)
        {
            var seminario = await _seminarioRepository.BuscarPorId(id);
            if (seminario == null)
            {
                return NotFound();
            }
            return Ok(seminario);
        }

        [HttpPost]
        public async Task<ActionResult<Seminario>> CriarSeminario(Seminario seminario)
        {
            try
            {
                var novoSeminario = await _seminarioRepository.CriarSeminario(seminario);
                return CreatedAtAction(nameof(BuscarPorId), new { id = novoSeminario.Id }, novoSeminario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar seminário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Seminario>> AtualizarSeminario([FromBody] Seminario seminario, int id)
        {
            seminario.Id = id;
            Seminario seminarioAtualizado = await _seminarioRepository.AtualizarSeminario(seminario, id);
            return Ok(seminarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarSeminario(int id)
        {
            try
            {
                await _seminarioRepository.ApagarSeminario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao apagar seminário: {ex.Message}");
            }
        }
        //O que era aqui mesmo?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminario>>> ObterSeminariosPorTurmaId([FromQuery] int turmaId)
        {
            var seminarios = await _seminarioRepository.ObterSeminariosPorTurmaId(turmaId);
            return Ok(seminarios);
        }
    }
}
