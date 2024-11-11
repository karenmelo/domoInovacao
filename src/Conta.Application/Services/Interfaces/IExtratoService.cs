using Conta.Application.DTOs;

namespace Conta.Application.Services.Interfaces;

public interface IExtratoService
{
    Task<IEnumerable<ExtratoDto>> GetExtratoByQtdDiasAsync(int? qtdDias);
}