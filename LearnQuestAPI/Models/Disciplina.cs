namespace LearnQuestAPI.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Pergunta> Quiz { get; set; }
        public double Nota { get; set; }
    }
}
