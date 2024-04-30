using System.Text.Json.Serialization;

namespace LearnQuestAPI.Models
{
    public class Pergunta
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public List<Resposta> Respostas { get; set; } = new List<Resposta>();
        [JsonIgnore]
        public int DisciplinaId { get; set; }

    }
}
