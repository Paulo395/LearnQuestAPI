using LearnQuestAPI.Data.Map;
using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Data
{
    public class LearnQuestDBContext : DbContext
    {
        public LearnQuestDBContext(DbContextOptions<LearnQuestDBContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Seminario> Seminarios { get; set; }
        public DbSet<Pergunta> Perguntas {  get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MensagemMap());
            modelBuilder.ApplyConfiguration(new SeminarioMap());
            modelBuilder.ApplyConfiguration(new PerguntaMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new NotaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
