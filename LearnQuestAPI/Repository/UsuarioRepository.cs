using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LearnQuestDBContext _dbContext;
        public UsuarioRepository(LearnQuestDBContext minhaApiDBContex)
        {
            _dbContext = minhaApiDBContex;
        }
        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();

            return usuario;// async resolve os probelmas de return
        }

        public async Task<bool> ApagarUsuario(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario com o Id " + id + " não encontrado!");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario com o Id " + id + " não encontrado!");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.TurmaId = usuario.TurmaId;

            _dbContext.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> ListarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarCredenciais(string email, string senha)
        {
            // Busca o usuário com base no email e senha fornecidos
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            // Retorna o usuário encontrado ou null se não for encontrado
            return usuario;
        }

    }
}