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
        TODO: fazer motor de regras no banco
         */

        // TODO: verificar importancia/ordem dos IF's
        // TODO: melhorar quantidade de IF's
        var cliente = await _clienteRepositorio.BuscarDadosCliente(command.Cpf);
        if (cliente.HasNoValue)
            return Result.Failure<Proposta>("Cliente não encontrado");

        var propostasExistentes = await _propostaRepositorio.VerificarPropostasExistentes(cliente.Value.Cpf);
        if (propostasExistentes)
            return Result.Failure<Proposta>("Cliente já possui propostas em aberto");

        // TODO: talvez botar essa validação do cliente em um lugar só
        // TODO: criar classes de validação estilo da aula 
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
            return Result.Failure<Proposta>("Conveniada não encontrada nesse estado");


        // TODO: botar num strategy e adicionar os erros em uma lista de erros
        #region validacao restrição valor
        if (estadoCliente.Sigla.Equals("RS"))
        {
            if (command.NumeroParcelas >= 60)
            {
                return Result.Failure<Proposta>("Parcelas maior que 60x");
            }

            if (command.Valor >= 500000)
            {
                return Result.Failure<Proposta>("Valor maior que 500mil");
            }
        }

        if (estadoCliente.Sigla.Equals("SC"))
        {
            if (command.NumeroParcelas >= 80)
            {
                return Result.Failure<Proposta>("Parcelas maior que 80x");
            }

            if (command.Valor >= 700000)
            {
                return Result.Failure<Proposta>("Valor maior que 700mil");
            }
        }

        if (estadoCliente.Sigla.Equals("PR"))
        {
            if (command.NumeroParcelas >= 100)
            {
                return Result.Failure<Proposta>("Parcelas maior que 100x");
            }

            if (command.Valor >= 200000)
            {
                return Result.Failure<Proposta>("Valor maior que 200mil");
            }
        }
        #endregion


        // TODO: botar num strategy e melhorar logica com meses
        #region validação quantidade de parcelas com idade máxima
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - cliente.Value.DataNascimento.Year;

        var anosFaltandoPara80 = 80 - idade;

        if (command.NumeroParcelas > anosFaltandoPara80)
        {
            return Result.Failure<Proposta>("Quantidade de parcelas inválida por idade máxima");
        }
        #endregion


        // TODO: botar num simple factory - AssinaturaFactory
        #region validação tipo assinatura

        var tipoAssinatura = "assinatura eletrônica";
        var dddUfNascimento = ObterDDD(cliente.Value.UfNascimento);
        if (dddUfNascimento.Equals(cliente.Value.Ddd))
        {
            tipoAssinatura = "assinatura eletrônica";
        }
        else if (estadoCliente.AssinaturaHibrida)
        {
            tipoAssinatura = "assinatura eletrônica";
        }
        else if (!dddUfNascimento.Equals(cliente.Value.Ddd))
        {
            tipoAssinatura = "assinatura eletrônica";
        }

        #endregion


        #region incluir proposta
        var parceiro = "Loja Consig Mais";

        // TODO: talvez um factory method para realizar outras formas de pagamento
        var pagamento = new Pagamento(command.Valor, command.NumeroParcelas);

        // TODO: factory method - PropostaFactory
        var proposta = new Proposta(parceiro, command.TipoOperacao, tipoAssinatura, cliente.Value, pagamento, conveniada.Value);
        await _propostaRepositorio.IncluirProposta(proposta);
        #endregion

        // TODO: retornar um dto de response
        return Result.Success(proposta);
    }

    // TODO: ver um lugar melhor pra esse metodo
    // pode colocar em uma tabela ou em uma lista estatica, sem mt misterio pra resolver
    private static string ObterDDD(string uf)
    {
        switch (uf.ToUpper())
        {
            case "AC":
                return "68";
            case "AL":
                return "82";
            case "AM":
                return "92";
            case "AP":
                return "96";
            case "BA":
                return "71";
            case "CE":
                return "85";
            case "DF":
                return "61";
            case "ES":
                return "27";
            case "GO":
                return "62";
            case "MA":
                return "98";
            case "MG":
                return "31";
            case "MS":
                return "67";
            case "MT":
                return "65";
            case "PA":
                return "91";
            case "PB":
                return "83";
            case "PE":
                return "81";
            case "PI":
                return "86";
            case "PR":
                return "41";
            case "RJ":
                return "21";
            case "RN":
                return "84";
            case "RO":
                return "69";
            case "RR":
                return "95";
            case "RS":
                return "51";
            case "SC":
                return "47";
            case "SE":
                return "79";
            case "SP":
                return "11";
            case "TO":
                return "63";
            default:
                return "UF inválida";
        }
    }
}
