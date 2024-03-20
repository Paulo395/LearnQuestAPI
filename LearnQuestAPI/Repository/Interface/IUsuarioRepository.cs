using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario, int id);
        Task<bool> ApagarUsuario(int id);
        Task<Usuario> BuscarPorEmailSenha(string email, string senha);
    }
}
