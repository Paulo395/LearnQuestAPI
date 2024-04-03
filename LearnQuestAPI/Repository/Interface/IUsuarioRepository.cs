using LearnQuestAPI.Models;
using LearnQuestAPI.Models.Enum;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario, int id);
        Task<bool> ApagarUsuario(int id);
        Task<Usuario> BuscarCredenciais(string email, string senha);
    }
}
