using System.Text.Json.Serialization;

namespace LearnQuestAPI.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Pergunta> Perguntas { get; set; }
        [JsonIgnore]
        public int TurmaId { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}
