using Conta.Application.DTOs;

namespace Conta.Application.Services.Interfaces;

public interface ITransacaoService
{
    Task Add(TransacaoDto transacaoDto);
}