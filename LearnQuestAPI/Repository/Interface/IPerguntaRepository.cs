using LearnQuestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Repository.Interface
{
    public interface IPerguntaRepository
    {
        Task<List<Pergunta>> ListarTodasPerguntas();
        Task<Pergunta> BuscarPorId(int id);
        Task<Pergunta> CriarPergunta(Pergunta pergunta);
        Task<Pergunta> AtualizarPergunta(Pergunta pergunta, int id);
        Task<bool> ApagarPergunta(int id);
    }
}
