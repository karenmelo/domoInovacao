using Conta.Domain.ValueObject;

namespace Conta.Domain.Entities;

public class Transacao
{
    public int Id { get; set; }
    public DateTime DataTransacao { get; set; } = DateTime.Now;
    public string Local { get; set; }
    public TipoTransacao TipoTransacao { get; set; }
    public double Valor { get; set; }
}