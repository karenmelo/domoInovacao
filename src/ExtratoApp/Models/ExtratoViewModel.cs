using Conta.Application.DTOs;

namespace ExtratoApp.Models;

public class ExtratoViewModel
{
    public IEnumerable<ExtratoDto> Extrato { get; set; }
    public int QtdDias { get; set; }
}
