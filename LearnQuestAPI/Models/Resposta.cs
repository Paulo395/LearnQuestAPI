namespace LearnQuestAPI.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Correta { get; set; }
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}