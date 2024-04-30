using LearnQuestAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TurmaDisciplina
{
    //Entidade Intermediaria para representar relacionamento entre Turma e Disciplina
    [Key]
    public int Id { get; set; }

    public int TurmaId { get; set; }
    public Turma Turma { get; set; }

    public int DisciplinaId { get; set; }
    public Disciplina Disciplina { get; set; }
}
