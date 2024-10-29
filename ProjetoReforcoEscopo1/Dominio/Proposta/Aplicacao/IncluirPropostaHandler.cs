using CSharpFunctionalExtensions;
using ProjetoReforcoEscopo1.Dominio.Proposta.Infra;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao;

public class IncluirPropostaHandler
{
    private readonly PropostaRepositorio _propostaRepositorio;
    private readonly ClienteRepositorio _clienteRepositorio;
    private readonly ConveniadaRepositorio _conveniadaRepositorio;

    public IncluirPropostaHandler(
        PropostaRepositorio propostaRepositorio, 
        ClienteRepositorio clienteRepositorio,
        ConveniadaRepositorio conveniadaRepositorio)
    {
        _propostaRepositorio = propostaRepositorio;
        _clienteRepositorio = clienteRepositorio;
        _conveniadaRepositorio = conveniadaRepositorio;
    }

    public async Task<Result<Proposta>> Handle(IncluirPropostaCommand command, CancellationToken cancellationToken)
    {
        /*
        TODO: configurar unitOfWork pro repositorio
        TODO: ajustar dominios anemicos
         */

        // Verificar importancia/ordem dos IF's
        var cliente = await _clienteRepositorio.BuscarDadosCliente(command.Cpf);
        if (cliente.HasNoValue)
            return Result.Failure<Proposta>("Cliente não encontrado");

        var propostasExistentes = await _propostaRepositorio.VerificarPropostasExistentes(cliente.Value.Cpf);
        if (propostasExistentes)
            return Result.Failure<Proposta>("Cliente já possui propostas em aberto");

        var cpfBloqueado = await _clienteRepositorio.VerificarCpfBloquadoCliente(cliente.Value.Cpf);
        if (cpfBloqueado)
            return Result.Failure<Proposta>("Cliente com CPF bloqueado");

        var conveniada = await _conveniadaRepositorio.BuscarConveniada(command.Conveniada);
        if (conveniada.HasNoValue)
            return Result.Failure<Proposta>("Conveniada não encontrada");

        if (!conveniada.Value.ExecutaRefinanciamento)
            return Result.Failure<Proposta>("Conveniada não realiza operação de refinanciamento");

        if (!conveniada.Value.Agente.Ativo)
            return Result.Failure<Proposta>("Agente inativo");

        var estadoCliente = conveniada.Value.Estados.FirstOrDefault(s => s.Sigla.Equals(cliente.Value.UfNascimento));
        if (estadoCliente is null)
            return Result.Failure<Proposta>("Estado não encontrado");



        // TODO: botar num strategy e adicionar os erros em uma lista de erros
        #region validacao restrição valor
        if (estadoCliente.Sigla.Equals("RS"))
        {
            if (command.NumeroParcelas >= 60)
            {
                Result.Failure<Proposta>("Parcelas maior que 60x");
            }

            if (command.Valor >= 500000)
            {
                Result.Failure<Proposta>("Valor maior que 500mil");
            }
        }

        if (estadoCliente.Sigla.Equals("SC"))
        {
            if (command.NumeroParcelas >= 80)
            {
                Result.Failure<Proposta>("Parcelas maior que 80x");
            }

            if (command.Valor >= 700000)
            {
                Result.Failure<Proposta>("Valor maior que 700mil");
            }
        }

        if (estadoCliente.Sigla.Equals("PR"))
        {
            if (command.NumeroParcelas >= 100)
            {
                Result.Failure<Proposta>("Parcelas maior que 100x");
            }

            if (command.Valor >= 200000)
            {
                Result.Failure<Proposta>("Valor maior que 200mil");
            }
        }
        #endregion



        #region validação quantidade de parcelas com idade máxima
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - cliente.Value.DataNascimento.Year;

        var anosFaltandoPara80 = 80 - idade;

        if (command.NumeroParcelas > anosFaltandoPara80)
        {
            return Result.Failure<Proposta>("Quantidade de parcelas inválida por idade máxima");
        }
        #endregion



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
