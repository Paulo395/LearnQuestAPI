using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface ITurmaRepository
    {
        Task<List<Turma>> ListarTodasTurmas();
        Task<Turma> BuscarPorId(int id);
        Task<Turma> AdicionarTurma(Turma turma);
        Task<Turma> AtualizarTurma(Turma turma, int id);
        Task<bool> ApagarTurma(int id);
    }
}
