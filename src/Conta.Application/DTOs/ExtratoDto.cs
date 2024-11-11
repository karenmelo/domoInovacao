using Conta.Domain.ValueObject;

namespace Conta.Application.DTOs;

public class ExtratoDto
{
    public string DataTransacao { get; set; }
    public TipoTransacao TipoTransacao { get; set; }
    public double Valor { get; set; }
}