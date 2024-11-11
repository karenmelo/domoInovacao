using Conta.Application.DTOs;
using Conta.Application.Services.Interfaces;
using ExtratoApp.Models;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoApp.Controllers;

public class ExtratoController : Controller
{
    private readonly IExtratoService _extratoService;

    public ExtratoController(IExtratoService extratoService)
    {
        _extratoService = extratoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Filtrar(int qtdDias)
    {

        if (qtdDias == 0)
        {
            ViewBag.Mensagem = "Selecione um período em dias!";
            return View("Index");
        }

        var model = new ExtratoViewModel();
        model.Extrato = await _extratoService.GetExtratoByQtdDiasAsync(qtdDias);
        model.QtdDias = qtdDias;
        return View("Index", model);
    }

    public async Task<IActionResult> ExportarExtrato(int dias)
    {
        var extrato = await _extratoService.GetExtratoByQtdDiasAsync(dias);
        return GerarExtratoPDF(extrato.ToList());
    }

    private FileResult GerarExtratoPDF(List<ExtratoDto> transacoes)
    {
        var doc = new iTextSharp.text.Document();
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
