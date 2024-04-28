using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly LearnQuestDBContext _dbContext;

        public PerguntaRepository(LearnQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pergunta> CriarPergunta(Pergunta pergunta)
        {
            await _dbContext.Perguntas.AddAsync(pergunta);
            _dbContext.SaveChanges();

            return pergunta;// async resolve os probelmas de return
        }

        public async Task<bool> ApagarPergunta(int id)
        {
            Pergunta perguntaPorId = await BuscarPorId(id);

            if (perguntaPorId == null)
            {
                throw new Exception("Pergunta com o Id " + id + " não encontrado!");
            }

            _dbContext.Perguntas.Remove(perguntaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Pergunta> AtualizarPergunta(Pergunta usuario, int id)
        {
            Pergunta perguntaPorId = await BuscarPorId(id);

            if (perguntaPorId == null)
            {
                throw new Exception("Usuario com o Id " + id + " não encontrado!");
            }

            perguntaPorId.Titulo = usuario.Titulo;
            perguntaPorId.Respostas = usuario.Respostas;

            _dbContext.Update(perguntaPorId);
            await _dbContext.SaveChangesAsync();

            return perguntaPorId;
        }

        public async Task<Pergunta> BuscarPorId(int id)
        {
            return await _dbContext.Perguntas.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Pergunta>> ListarTodasPerguntas()
        {
            return await _dbContext.Perguntas.ToListAsync();
        }
    }
}
