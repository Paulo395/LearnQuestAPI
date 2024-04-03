using System.ComponentModel;

namespace LearnQuestAPI.Models.Enum
{
    public enum TipoUsuario
    {
        [Description("Aluno")]
        Aluno = 0,
        [Description("Administrador")]
        Admin = 1
    }
}
