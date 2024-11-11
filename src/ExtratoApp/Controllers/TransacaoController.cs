using Conta.Application.Services.Interfaces;
using ExtratoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExtratoApp.Controllers;

public class TransacaoController : Controller
{
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> NovaTransacao(TransacaoViewModel model)
    {
        await _transacaoService.Add(model.Transacao);
        return RedirectToAction("Index", "Extrato");
    }
}
