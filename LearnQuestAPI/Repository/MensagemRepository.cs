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

        public async Task<IEnumerable<Mensagem>> GetAllMensagens()
        {
            return await _dbContext.Mensagems.ToListAsync();
        }

        public async Task<Mensagem> GetMensagemById(int id)
        {
            return await _dbContext.Mensagems.FindAsync(id);
        }

        public async Task<int> CreateMensagem(Mensagem mensagem)
        {
            _dbContext.Mensagems.Add(mensagem);
            await _dbContext.SaveChangesAsync();
            return mensagem.Id;
        }

        public async Task UpdateMensagem(int id, Mensagem mensagem)
        {
            var mensagemExistente = await _dbContext.Mensagems.FindAsync(id);
            if (mensagemExistente != null)
            {
                mensagemExistente.Conteudo = mensagem.Conteudo;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMensagem(int id)
        {
            var mensagemExistente = await _dbContext.Mensagems.FindAsync(id);
            if (mensagemExistente != null)
            {
                _dbContext.Mensagems.Remove(mensagemExistente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
