using CSharpFunctionalExtensions;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Infra
{
    public class ConveniadaRepositorio
    {
        public async Task<Maybe<Conveniada>> BuscarConveniada(string codigo)
        {
            // TODO: conectar no banco
            return await Task.FromResult(Maybe.From
            (
                new Conveniada
                (
                    "INSS",
                    new Agente { Ativo = true },
                    new List<Estado> ()
                    {
                        new Estado { Sigla = "RS", ValorMaximo = 100000 },
                    },
                    true
                )
            ));
        }
    }
}
