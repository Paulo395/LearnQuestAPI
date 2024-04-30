using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IDisciplinaRepository
    {
        Task<List<Disciplina>> ListarTodasDisciplinas();
        Task<Disciplina> BuscarPorId(int id);
        Task<Disciplina> AdicionarDisciplina(Disciplina disciplina);
        Task<Disciplina> AtualizarDisciplina(Disciplina disciplina, int id);
        Task<bool> ApagarDisciplina(int id);
    }
}
