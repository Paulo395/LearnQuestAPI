namespace LearnQuestAPI.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public double Pontuacao { get; set; }
        public DateTime Data { get; set; }
    }
}
