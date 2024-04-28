namespace LearnQuestAPI.Models
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Resposta> Respostas { get; set; } = new List<Resposta>();

    }
}
