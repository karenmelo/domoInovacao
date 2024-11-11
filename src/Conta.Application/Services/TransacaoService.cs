using AutoMapper;
using Conta.Application.DTOs;
using Conta.Application.Services.Interfaces;
using Conta.Domain.Entities;
using Conta.Domain.Repositories;

namespace Conta.Application.Services;

public class TransacaoService : ITransacaoService
{
    public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
    {
        _transacaoRepository = transacaoRepository;
        _mapper = mapper;
    }

    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IMapper _mapper;

    public async Task Add(TransacaoDto transacaoDto)
    {
        var transacaoEntity = _mapper.Map<Transacao>(transacaoDto);
        await _transacaoRepository.Create(transacaoEntity);
    }
}