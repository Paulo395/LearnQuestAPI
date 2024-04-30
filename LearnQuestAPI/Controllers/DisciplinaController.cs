using LearnQuestAPI.Models;
using LearnQuestAPI.Repository;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Disciplina>>> ListarTodasDisciplinas()
        {
            List<Disciplina> disciplinas = await _disciplinaRepository.ListarTodasDisciplinas();
            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> BuscarPorId(int id)
        {
            Disciplina disciplinas = await _disciplinaRepository.BuscarPorId(id);
            return Ok(disciplinas);
        }

        [HttpPost]
        public async Task<ActionResult<Disciplina>> AdicionarDisciplina([FromBody] Disciplina disciplina)
        {
            Disciplina disciplinasCad = await _disciplinaRepository.AdicionarDisciplina(disciplina);
            return Ok(disciplinasCad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Disciplina>> AtualizarDisciplina([FromBody] Disciplina disciplina, int id)
        {
            disciplina.Id = id;
            Disciplina disciplinasCadAt = await _disciplinaRepository.AtualizarDisciplina(disciplina, id);
            return Ok(disciplinasCadAt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Disciplina>> ApagarDisciplina(int id)
        {
            bool apagar = await _disciplinaRepository.ApagarDisciplina(id);
            return Ok(apagar);
        }
    }
}
