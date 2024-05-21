using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IMensagemRepository
    {
        Task<IEnumerable<Mensagem>> ListarTodasMensagens();
        Task<Mensagem> BuscarMensagemPorId(int id);
        Task<Mensagem> CriarMensagem(Mensagem mensagem);
        Task AtualizarMensagem(int id, Mensagem mensagem);
        Task ApagarMensagem(int id);
        Task<IEnumerable<Mensagem>> BuscarMensagensPorTurmaId(int turmaId);
    }
}
