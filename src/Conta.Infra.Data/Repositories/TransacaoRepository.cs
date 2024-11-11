using Conta.Domain.Entities;
using Conta.Domain.Repositories;
using Conta.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Conta.Infra.Data.Repositories;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly ApplicationDbContext _context;

    public TransacaoRepository(ApplicationDbContext context) => _context = context;
       
    public async Task<IEnumerable<Transacao>> GetExtratoByQtdDiasAsync(int? qtdDias)
    {
        var query = _context.Transacoes.AsQueryable();

        if (qtdDias.HasValue)
        {
            var data = DateTime.Now.AddDays(-qtdDias.Value);
            query = query.Where(t => t.DataTransacao >= data);
        }

        var transacoes = await query.AsNoTracking()
                                    .ToListAsync();
         
        return transacoes;
    }
    


    public async Task Create(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();      
    }

   
}