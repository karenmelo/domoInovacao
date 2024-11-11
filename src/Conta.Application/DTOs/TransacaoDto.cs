using Conta.Domain.ValueObject;

namespace Conta.Application.DTOs;

public class TransacaoDto
{   
    public string Local { get; set; }
    public TipoTransacao TipoTransacao { get; set; }
    public double Valor { get; set; }
}