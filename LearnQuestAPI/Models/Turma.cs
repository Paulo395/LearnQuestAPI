namespace LearnQuestAPI.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Administrador> Administradores { get; set; }
        public List<Disciplina> Disciplinas { get; set; }

        public Turma(string nome, List<Aluno> alunos, List<Administrador> administradores, List<Disciplina> disciplinas)
        {
            Nome = nome;
            Alunos = new List<Aluno>();
            Administradores = new List<Administrador>();
            Disciplinas = new List<Disciplina>();
        }
    }
}
