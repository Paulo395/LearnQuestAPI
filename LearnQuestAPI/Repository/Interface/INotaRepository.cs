using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface INotaRepository
    {
        Task<Nota> CriarNota(Nota nota);
        Task<IEnumerable<Nota>> ObterNotasPorAlunoId(int alunoId);
    }
}
