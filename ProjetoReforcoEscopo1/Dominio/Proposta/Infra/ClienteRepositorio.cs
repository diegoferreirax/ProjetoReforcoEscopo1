using CSharpFunctionalExtensions;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Infra
{
    public class ClienteRepositorio
    {
        public async Task<Maybe<Cliente>> BuscarDadosCliente(string cpf)
        {
            // TODO: conectar no banco
            return await Task.FromResult(Maybe.From(new Cliente
            (
                Cpf: cpf,
                Ddd: "51",
                Telefone: "986532127",
                Email: "exemplo@email.com",
                UfNascimento: "RS",
                DataNascimento: DateTime.Parse("1960-01-05T16:00:00.220Z"),

                Endereco: "Rua alameda, 122, brasilia",

                Rendimento1Nome: "Salario",
                Rendimento1Valor: 5000,

                Rendimento2Nome: "Poupança",
                Rendimento2Valor: 10000
            )));
        }

        public async Task<bool> VerificarCpfBloquadoCliente(string cpf)
        {
            // TODO: conectar no banco
            return await Task.FromResult(false);
        }
    }
}
