using LearnQuestAPI.Models;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IMensagemRepository
    {
        Task<IEnumerable<Mensagem>> GetAllMensagens();
        Task<Mensagem> GetMensagemById(int id);
        Task<int> CreateMensagem(Mensagem mensagem);
        Task UpdateMensagem(int id, Mensagem mensagem);
        Task DeleteMensagem(int id);
    }
}
