using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    public class MensagemController : ControllerBase
    {
        private readonly IMensagemRepository _mensagemService;

        public MensagemController(IMensagemRepository mensagemService)
        {
            _mensagemService = mensagemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagens()
        {
            var mensagens = await _mensagemService.GetAllMensagens();
            return Ok(mensagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagem(int id)
        {
            var mensagem = await _mensagemService.GetMensagemById(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            return Ok(mensagem);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMensagem(Mensagem mensagem)
        {
            var mensagemId = await _mensagemService.CreateMensagem(mensagem);
            return Ok(mensagemId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMensagem(int id, Mensagem mensagem)
        {
            await _mensagemService.UpdateMensagem(id, mensagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            await _mensagemService.DeleteMensagem(id);
            return NoContent();
        }

    }
}
