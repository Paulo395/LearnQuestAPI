using LearnQuestAPI.Models;
using LearnQuestAPI.Repository;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Turma>>> ListarTodasTurmas()
        {
            List<Turma> turmas = await _turmaRepository.ListarTodasTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> BuscarPorId(int id)
        {
            Turma turmas = await _turmaRepository.BuscarPorId(id);
            return Ok(turmas);
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> AdicionarTurma([FromBody] Turma turma)
        {
            Turma turmaCad = await _turmaRepository.AdicionarTurma(turma);
            return Ok(turmaCad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Turma>> AtualizarTurma([FromBody] Turma turma, int id)
        {
            turma.Id = id;
            Turma turmaAt = await _turmaRepository.AtualizarTurma(turma, id);
            return Ok(turmaAt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> ApagarTurma(int id)
        {
            bool apagar = await _turmaRepository.ApagarTurma(id);
            return Ok(apagar);
        }
    }
}
