using Microsoft.AspNetCore.Mvc;
using ProjetoReforcoEscopo1.Controllers.Models;
using ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao;

namespace ProjetoReforcoEscopo1.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/{controller}")]
public class PropostaController : ControllerBase
{
    [HttpPost(Name = "IncluirProposta")]
    public async Task<IActionResult> Post(
        [FromBody] IncluirPropostaModel input,
        [FromServices] IncluirPropostaHandler handler,
        CancellationToken cancellationToken)
    {
        var command = IncluirPropostaCommand.Criar(
            input.Cpf,
            input.Valor,
            input.NumeroParcelas,
            input.TipoOperacao
        );

        var result = await handler.Handle(command.Value, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}
