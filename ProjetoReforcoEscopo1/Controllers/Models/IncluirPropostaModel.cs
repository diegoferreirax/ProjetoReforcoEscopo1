using System.ComponentModel.DataAnnotations;

namespace ProjetoReforcoEscopo1.Controllers.Models;

public record IncluirPropostaModel
{
    // TODO: aplicar mais validações
    [Required]
    public string Cpf { get; set; }

    [Required]
    public decimal Valor { get; set; }

    [Required]
    public int NumeroParcelas { get; set; }

    [Required]
    public string TipoOperacao { get; set; }

    [Required]
    public string Conveniada { get; set; }
}
