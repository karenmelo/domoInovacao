using Conta.Domain.Entities;

namespace Conta.Domain.Repositories;

public interface ITransacaoRepository
{
    Task<IEnumerable<Transacao>> GetExtratoByQtdDiasAsync(int? qtdDias);
    Task Create(Transacao transacao);
  
}