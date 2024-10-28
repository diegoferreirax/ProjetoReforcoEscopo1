using CSharpFunctionalExtensions;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao;

public class IncluirPropostaHandler
{
    public async Task<Result<Proposta>> Handle(IncluirPropostaCommand command, CancellationToken cancellationToken)
    {
        /*
        TODO: configurar unitOfWork pro repositorio
        TODO: ajustar dominios anemicos
         */



        //var cliente = new Cliente
        //{
        //    Cpf = "",
        //    Telefone = "",
        //    Email = "",
        //    DataNascimento = DateTime.Now,

        //    Endereco = "",

        //    Rendimento1Nome = "",
        //    Rendimento1Valor = "",

        //    Rendimento2Nome = "",
        //    Rendimento2Valor = ""
        //};



        // ------VALIDACOES:
        // var validacao = validarDadosObrigatoriosCliente()
        // var validacao = propostaRepositorio.verificarPropostasExistentes(cpf)
        // var validacao = listaNegraRepositorio.validarCpfBloquadoCliente(cpf)

        // var conveniada = conveniadaRepositorio.BuscarConveniada(Conveniada.INSS)
        // var validacao = conveniada.Agente.validarAgenteAtivo()

        // var validacao = strategy.validarOperacaoRefinanciamento(TipoOperacao.Refinanciamento)

        // var estadoCliente = buscarEstadoCliente(cliente.Telefone)
        // var estado = conveniada.Estados.Select(estadoCliente)
        // var validacao = strategy.validarRestricaoValor(estado)

        // var validacao = strategy.verificarUltimaParcelaIdadeProponente(DateTime.Now, cliente.DataNascimento, numParcelas)



        // ------REGRAS DE NEGOCIO:
        // var tipoAssinatura = assinaturaFactory.buscarTipoAssinatura(cliente.Telefone, cliente.UfNascimento, estados);
        // var paramento = new Pagamento(valor, numParcelas);



        // ------EXECUCAO:
        // var parceiro = "Loja Consig Mais";
        // var proposta = new Proposta(parceiro, tipoOperacao, tipoAssinatura, cliente, pagamento, conveniada);
        // propostaFactory.incluirProposta(proposta)





        return Result.Success(new Proposta());
    }
}
