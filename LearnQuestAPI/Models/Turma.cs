namespace LearnQuestAPI.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}
