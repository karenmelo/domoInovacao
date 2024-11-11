using AutoMapper;
using Conta.Application.DTOs;
using Conta.Application.Services.Interfaces;
using Conta.Domain.Repositories;

namespace Conta.Application.Services;

public class ExtratoService : IExtratoService
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IMapper _mapper;
    public IEnumerable<ExtratoDto> Model { get; }

    public ExtratoService(ITransacaoRepository transacaoRepository, IMapper mapper, IEnumerable<ExtratoDto> model)
    {
        _transacaoRepository = transacaoRepository ?? throw new ArgumentNullException(nameof(transacaoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        Model = model;
    }

    public async Task<IEnumerable<ExtratoDto>> GetExtratoByQtdDiasAsync(int? qtdDias)
    {
        var transacoes = await _transacaoRepository.GetExtratoByQtdDiasAsync(qtdDias);
        return _mapper.Map<IEnumerable<ExtratoDto>>(transacoes);
    }
}