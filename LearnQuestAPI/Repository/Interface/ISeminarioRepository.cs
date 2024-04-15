using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface ISeminarioRepository
    {
        Task<List<Seminario>> ListarTodosSeminario();
        Task<Seminario> BuscarPorId(int id);
        Task<Seminario> CriarSeminario(Seminario seminario);
        Task AtualizarSeminario(int id, Seminario seminario);
        Task ApagarSeminario(int id);
    }
}
