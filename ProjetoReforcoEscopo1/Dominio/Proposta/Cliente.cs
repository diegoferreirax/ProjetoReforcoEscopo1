namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Cliente
    (
        string Cpf,
        string Telefone,
        string Email,
        string UfNascimento,
        DateTime DataNascimento,

        // TODO: encapsular
        string Endereco,

        // TODO: encapsular
        string Rendimento1Nome,
        decimal Rendimento1Valor,

        string Rendimento2Nome,
        decimal Rendimento2Valor
    );
}
