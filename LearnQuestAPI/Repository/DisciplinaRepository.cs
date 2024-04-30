using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly LearnQuestDBContext _dbContext;

        public DisciplinaRepository(LearnQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Disciplina> AdicionarDisciplina(Disciplina disciplina)
        {
            await _dbContext.Disciplinas.AddAsync(disciplina);
            _dbContext.SaveChanges();

            return disciplina;
        }

        public async Task<bool> ApagarDisciplina(int id)
        {
            Disciplina disciplinaPorId = await BuscarPorId(id);

            if (disciplinaPorId == null)
            {
                throw new Exception("Disciplina com o Id " + id + " não encontrada!");
            }

            _dbContext.Disciplinas.Remove(disciplinaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Disciplina> AtualizarDisciplina(Disciplina disciplina, int id)
        {
            Disciplina disciplinaPorId = await BuscarPorId(id);

            if (disciplinaPorId == null)
            {
                throw new Exception("Disciplina com o Id " + id + " não encontrada!");
            }

            disciplinaPorId.Nome = disciplina.Nome;

            _dbContext.Update(disciplinaPorId);
            await _dbContext.SaveChangesAsync();

            return disciplinaPorId;
        }

        public async Task<Disciplina> BuscarPorId(int id)
        {
            return await _dbContext.Disciplinas.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Disciplina>> ListarTodasDisciplinas()
        {
            return await _dbContext.Disciplinas.ToListAsync();
        }
    }
}
