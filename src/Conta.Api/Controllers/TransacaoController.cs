using Conta.Application.DTOs;
using Conta.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Conta.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController: ControllerBase
{
    private readonly ILogger<ExtratoController> _logger;
    private readonly ITransacaoService _transacaoService;
    
    public TransacaoController(ILogger<ExtratoController> logger, ITransacaoService transacaoService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post([FromBody] TransacaoDto transacaoDto)
    {
        try
        {
            await _transacaoService.Add(transacaoDto);
            return Created();

        }
        catch (Exception ex)
        {
             _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro no servidor.");            
        } 
    }
    
}