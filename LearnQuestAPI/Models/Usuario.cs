using LearnQuestAPI.Models.Enum;
using System.Text.Json.Serialization;

namespace LearnQuestAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime DataRegistro { get; set; }
        public int? TurmaId { get; set; }
        public bool Ativo { get; set; }
    }

}
