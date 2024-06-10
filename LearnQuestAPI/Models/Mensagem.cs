namespace LearnQuestAPI.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public int? TurmaId { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
