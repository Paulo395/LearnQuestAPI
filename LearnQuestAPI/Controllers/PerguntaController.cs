using LearnQuestAPI.Models;
using LearnQuestAPI.Repository;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : ControllerBase
    {
        private readonly IPerguntaRepository _perguntaRepository;
        public PerguntaController(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pergunta>>> ListarTodasPerguntas()
        {
            List<Pergunta> pergunta = await _perguntaRepository.ListarTodasPerguntas();
            return Ok(pergunta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pergunta>> BuscarPorId(int id)
        {
            Pergunta pergunta = await _perguntaRepository.BuscarPorId(id);
            return Ok(pergunta);
        }

        [HttpPost]
        public async Task<ActionResult<Pergunta>> CriarPergunta([FromBody] Pergunta pergunta)
        {
            Pergunta perguntaCad = await _perguntaRepository.CriarPergunta(pergunta);
            return Ok(perguntaCad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pergunta>> AtualizarPergunta([FromBody] Pergunta pergunta, int id)
        {
            pergunta.Id = id;
            Pergunta perguntaAt = await _perguntaRepository.AtualizarPergunta(pergunta, id);
            return Ok(perguntaAt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pergunta>> ApagarPergunta(int id)
        {
            bool apagar = await _perguntaRepository.ApagarPergunta(id);
            return Ok(apagar);
        }
    }
}
