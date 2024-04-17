using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IPerguntaRepository
    {
        Task<Pergunta> BuscarPorId(int id);
        Task<IEnumerable<Pergunta>> ListarTodasPerguntas();
        Task<Pergunta> CriarPergunta(Pergunta pergunta);
        Task<Pergunta> AtualizarPergunta(Pergunta pergunta, int id);
        Task<bool> ApagarPergunta(int id);
    }
}
