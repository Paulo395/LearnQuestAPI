using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class SeminarioRepository : ISeminarioRepository
    {
        private readonly LearnQuestDBContext _dbContext;
        public SeminarioRepository(LearnQuestDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Seminario>> ListarTodosSeminario()
        {
            return await _dbContext.Seminarios.ToListAsync();
        }

        public async Task<Seminario> BuscarPorId(int id)
        {
            return await _dbContext.Seminarios.FindAsync(id);
        }

        public async Task<Seminario> CriarSeminario(Seminario seminario)
        {
            _dbContext.Seminarios.Add(seminario);
            await _dbContext.SaveChangesAsync();
            return seminario;
        }

        public async Task AtualizarSeminario(int id, Seminario seminario)
        {
            _dbContext.Entry(seminario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ApagarSeminario(int id)
        {
            var seminario = await _dbContext.Seminarios.FindAsync(id);
            if (seminario != null)
            {
                _dbContext.Seminarios.Remove(seminario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
