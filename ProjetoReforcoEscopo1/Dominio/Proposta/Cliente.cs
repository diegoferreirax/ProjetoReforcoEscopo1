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
        string Rendimento1Valor,

        string Rendimento2Nome,
        string Rendimento2Valor
    );
}
