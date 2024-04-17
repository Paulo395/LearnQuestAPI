namespace LearnQuestAPI.Models
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public List<Resposta> Respostas { get; set; }

    }
}
