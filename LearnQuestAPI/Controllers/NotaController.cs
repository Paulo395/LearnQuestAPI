using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository _notaRepository;

        public NotaController(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Nota>> CriarNota(Nota nota)
        {
            try
            {
                var novaNota = await _notaRepository.CriarNota(nota);
                return CreatedAtAction(nameof(CriarNota), new { id = novaNota.Id }, novaNota);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar nota: {ex.Message}");
            }
        }

        [HttpGet("{alunoId}")]
        public async Task<ActionResult<IEnumerable<Nota>>> ObterNotasPorAlunoId(int alunoId)
        {
            var notas = await _notaRepository.ObterNotasPorAlunoId(alunoId);
            return Ok(notas);
        }
    }
}
