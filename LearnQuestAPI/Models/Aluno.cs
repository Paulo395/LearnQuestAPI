using LearnQuestAPI.Models.Enum;

namespace LearnQuestAPI.Models
{
    public class Aluno : Usuario
    {
        public float Notas { get; set; }
        public Turma Turma { get; set; }
    }
}
