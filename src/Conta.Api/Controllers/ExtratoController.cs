using Conta.Application.DTOs;
using Conta.Application.Services.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Conta.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtratoController : ControllerBase
{
    private readonly ILogger<ExtratoController> _logger;
    private readonly IExtratoService _extratoService;


    public ExtratoController(ILogger<ExtratoController> logger,
                             IExtratoService extratoService)
    {
        _logger = logger;
        _extratoService = extratoService;

    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int dias)
    {
        if(dias == 0)
        {
            return NotFound("Informe o periodo de 5, 10, 15 ou 20 dias");
        }

        var result = await _extratoService.GetExtratoByQtdDiasAsync(dias);
        return Ok(result);
    }


    [HttpGet("extrato/pdf")]
    public async Task<IActionResult> ExportarExtrato([FromQuery] int dias)
    {
        var extrato = await _extratoService.GetExtratoByQtdDiasAsync(dias);
        return GerarExtratoPDF(extrato.ToList());
    }

    private FileResult GerarExtratoPDF(List<ExtratoDto> transacoes)
    {
        var doc = new Document();
        var memoryStream = new MemoryStream();
        var writer = PdfWriter.GetInstance(doc, memoryStream);
        doc.Open();


        var table = new PdfPTable(3);
        table.AddCell("Data da Transação");
        table.AddCell("Tipo da Transação");
        table.AddCell("Valor");

        foreach (var transacao in transacoes)
        {
            table.AddCell(transacao.DataTransacao);
            table.AddCell(transacao.TipoTransacao.ToString());
            table.AddCell(transacao.Valor.ToString("C", new System.Globalization.CultureInfo("pt-BR")));
        }

       
        doc.Add(table);
        doc.Close();

        return File(memoryStream.ToArray(), "application/pdf", "extrato.pdf");
    }
}