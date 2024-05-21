namespace LearnQuestAPI.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
        public List<Usuario> Alunos { get; set; } = new List<Usuario>();
        public List<Mensagem> Mensagens { get; set; } = new List<Mensagem>();
        public List<Seminario> Seminarios { get; set; } = new List<Seminario>();
    }
}
