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

        public async Task<Pergunta> AtualizarPergunta(Pergunta pergunta, int id)
        {
            Pergunta perguntaPorId = await BuscarPorId(id);

            if (perguntaPorId == null)
            {
                throw new Exception("Pergunta com o Id " + id + " não encontrado!");
            }

            perguntaPorId.Texto = pergunta.Texto;

            // Atualizar respostas existentes e lidar com novas respostas/remoções
            foreach (var resposta in pergunta.Respostas)
            {
                var respostaExistente = perguntaPorId.Respostas.FirstOrDefault(r => r.Id == resposta.Id);

                if (respostaExistente != null)
                {
                    // Atualização da resposta existente
                    respostaExistente.Texto = resposta.Texto;
                }
                else
                {
                    // Adição de nova resposta
                    perguntaPorId.Respostas.Add(resposta);
                }
            }

            // Remover respostas que não estão mais presentes
            perguntaPorId.Respostas.RemoveAll(r => !pergunta.Respostas.Any(nr => nr.Id == r.Id));

            _dbContext.Perguntas.Update(perguntaPorId);
            await _dbContext.SaveChangesAsync();

            return perguntaPorId;
        }

        public async Task<Pergunta> BuscarPorId(int id)
        {
            return await _dbContext.Perguntas.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Pergunta> CriarPergunta(Pergunta pergunta)
        {
            await _dbContext.Perguntas.AddAsync(pergunta);
            _dbContext.SaveChanges();

            return pergunta;
        }

        public async Task<IEnumerable<Pergunta>> ListarTodasPerguntas()
        {
            return await _dbContext.Perguntas.ToListAsync();
        }
    }
}
