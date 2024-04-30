using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly LearnQuestDBContext _dbContext;

        public TurmaRepository(LearnQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Turma> AdicionarTurma(Turma turma)
        {
            await _dbContext.Turmas.AddAsync(turma);
            _dbContext.SaveChanges();

            return turma;
        }

        public async Task<bool> ApagarTurma(int id)
        {
            Turma turmaPorId = await BuscarPorId(id);

            if (turmaPorId == null)
            {
                throw new Exception("Turma com o Id " + id + " não encontrada!");
            }

            _dbContext.Turmas.Remove(turmaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Turma> AtualizarTurma(Turma turma, int id)
        {
            Turma turmaPorId = await BuscarPorId(id);

            if (turmaPorId == null)
            {
                throw new Exception("Turma com o Id " + id + " não encontrada!");
            }

            turmaPorId.Nome = turma.Nome;

            _dbContext.Update(turmaPorId);
            await _dbContext.SaveChangesAsync();

            return turmaPorId;
        }

        public async Task<Turma> BuscarPorId(int id)
        {
            return await _dbContext.Turmas.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Turma>> ListarTodasTurmas()
        {
            return await _dbContext.Turmas.ToListAsync();
        }
    }
}
