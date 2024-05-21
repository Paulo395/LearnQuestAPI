using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class MensagemRepository : IMensagemRepository
    {
        private readonly LearnQuestDBContext _dbContext;

        public MensagemRepository(LearnQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Mensagem>> ListarTodasMensagens()
        {
            return await _dbContext.Mensagens.ToListAsync();
        }

        public async Task<Mensagem> BuscarMensagemPorId(int id)
        {
            return await _dbContext.Mensagens.FindAsync(id);
        }

        public async Task<Mensagem> CriarMensagem(Mensagem mensagem)
        {
            _dbContext.Mensagens.Add(mensagem);
            _dbContext.SaveChanges();

            return mensagem;
        }

        public async Task AtualizarMensagem(int id, Mensagem mensagem)
        {
            var mensagemExistente = await _dbContext.Mensagens.FindAsync(id);
            if (mensagemExistente != null)
            {
                mensagemExistente.Conteudo = mensagem.Conteudo;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task ApagarMensagem(int id)
        {
            var mensagemExistente = await _dbContext.Mensagens.FindAsync(id);
            if (mensagemExistente != null)
            {
                _dbContext.Mensagens.Remove(mensagemExistente);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Mensagem>> BuscarMensagensPorTurmaId(int turmaId)
        {
            return await _dbContext.Mensagens.Where(m => m.TurmaId == turmaId).ToListAsync();
        }
    }
}
