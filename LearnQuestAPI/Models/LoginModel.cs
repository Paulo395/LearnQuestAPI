using LearnQuestAPI.Models.Enum;

namespace LearnQuestAPI.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }
    }
}
