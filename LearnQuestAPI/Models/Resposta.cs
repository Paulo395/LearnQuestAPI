using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearnQuestAPI.Models
{
    public class Resposta
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Alternativa { get; set; }
        public bool Correta { get; set; }
        [JsonIgnore]
        public int PerguntaId { get; set; }
    }
}