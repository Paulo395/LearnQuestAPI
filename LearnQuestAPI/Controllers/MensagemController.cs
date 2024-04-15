using LearnQuestAPI.Models;
using LearnQuestAPI.Repository;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagemController(IMensagemRepository mensagemService)
        {
            _mensagemRepository = mensagemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            var mensagens = await _mensagemRepository.ListarTodasMensagens();
            return Ok(mensagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _mensagemRepository.BuscarMensagemPorId(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            return Ok(mensagem);
        }

        [HttpPost]
        public async Task<ActionResult<Mensagem>> CriarMensagem(Mensagem mensagem)
        {
            var mensagemAux = await _mensagemRepository.CriarMensagem(mensagem);
            return Ok(mensagemAux);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMensagem(int id, Mensagem mensagem)
        {
            await _mensagemRepository.AtualizarMensagem(id, mensagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            await _mensagemRepository.ApagarMensagem(id);
            return NoContent();
        }

    }
}
