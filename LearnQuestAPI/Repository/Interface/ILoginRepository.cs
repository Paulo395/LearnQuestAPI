using LearnQuestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Repository.Interface
{
    public interface ILoginRepository
    {
       Task<Usuario> BuscarCredenciais(string email, string senha);
    }
}
