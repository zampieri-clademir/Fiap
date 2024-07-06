using Microsoft.EntityFrameworkCore;

using System;

using TechChallenge_1.Domain.Entidades.Contato;
using TechChallenge_1.Domain.Repositorio;
using TechChallenge_1.Infra.Data.Contexts;

namespace TechChallenge_1.Infra.Data.Feature
{
    public class ContatoRepository : IRepositorioContato
    {
        ContatoDbContext _context;

        public ContatoRepository(ContatoDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> SalvarContatoAsync(ContatosVO contato)
        {
            var newEntity = _context.Set<ContatosVO>().Add(contato).Entity;

            await _context.SaveChangesAsync();

            return newEntity.ContatoId;
        }

        public async Task<List<ContatosVO>> BuscarPorRegiaoAsync(short regiao)
        {
            return await _context.Set<ContatosVO>().Where(x => x.Ddd == regiao).AsNoTracking().AsQueryable().ToListAsync();
        }

        public async Task<bool> RemoverContatoAsync(Guid id)
        {
            _context.Set<ContatosVO>().RemoveRange(_context.Set<ContatosVO>().Where(x=> x.ContatoId == id));

            await _context.SaveChangesAsync();

            return true;
        }
    }
}