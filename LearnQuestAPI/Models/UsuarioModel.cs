using LearnQuestAPI.Models.Enum;

namespace LearnQuestAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario Tipo {  get; set; }

        private string DetermineTipoUsuario(Usuario usuario)
        {
            switch (usuario.Tipo)
            {
                case TipoUsuario.Admin:
                    return "Admin";
                case TipoUsuario.Aluno:
                    return "Aluno";
                default:
                    return "Desconhecido";
            }
        }
    }

}
