namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    // cliente seria um ValueObject ou criariamos uma entidade ?
    // proposta é uma entidade por nesse caso ser nosso dominio, o restante pode ser ValueObject
    public record Cliente
    (
        string Cpf,
        string Ddd,
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
