using LearnQuestAPI.Data;
using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LearnQuestAPI.Repository
{
    public class NotaRepository : INotaRepository
    {
        private readonly LearnQuestDBContext _context;

        public NotaRepository(LearnQuestDBContext context)
        {
            _context = context;
        }

        public async Task<Nota> CriarNota(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<IEnumerable<Nota>> ObterNotasPorAlunoId(int alunoId)
        {
            return await _context.Notas.Where(n => n.AlunoId == alunoId).ToListAsync();
        }
    }
}
