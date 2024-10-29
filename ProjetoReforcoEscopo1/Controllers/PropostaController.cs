using Microsoft.AspNetCore.Mvc;
using ProjetoReforcoEscopo1.Controllers.Models;
using ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao;

namespace ProjetoReforcoEscopo1.Controllers;

[ApiController]
[Route("api/v1/proposta")]
public class PropostaController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> IncluirProposta(
        [FromBody] IncluirPropostaModel input,
        [FromServices] IncluirPropostaHandler handler,
        CancellationToken cancellationToken)
    {
        var command = IncluirPropostaCommand.Criar(
            input.Cpf,
            input.Valor,
            input.NumeroParcelas,
            input.TipoOperacao,
            input.Conveniada
        );

        var result = await handler.Handle(command.Value, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}
