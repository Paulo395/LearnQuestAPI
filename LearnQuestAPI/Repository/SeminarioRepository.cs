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

        public async Task<Seminario> AtualizarSeminario(Seminario seminario, int id)
        {
            Seminario seminarioPorId = await BuscarPorId(id);

            if (seminarioPorId == null)
            {
                throw new Exception("Seminario com o Id " + id + " não encontrado!");
            }

            seminarioPorId.Titulo = seminario.Titulo;
            seminarioPorId.Descricao = seminario.Descricao;
            seminarioPorId.LinkVideo = seminario.LinkVideo;

            _dbContext.Update(seminarioPorId);
            await _dbContext.SaveChangesAsync();

            return seminarioPorId;
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
