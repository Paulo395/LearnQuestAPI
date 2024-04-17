using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        private readonly IPerguntaRepository _perguntaRepository;
        public RespostaController(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }
    }
}
