using ProjetoReforcoEscopo1.Shared;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao
{
    public record IncluirPropostaCommand
    {
        public string Cpf { get; }
        public decimal Valor { get; }
        public int NumeroParcelas { get; }
        public string TipoOperacao { get; }

        private IncluirPropostaCommand(string cpf, decimal valor, int numeroParcelas, string tipoOperacao)  
        {
            Cpf = cpf;
            Valor = valor;
            NumeroParcelas = numeroParcelas;
            TipoOperacao = tipoOperacao;
        }

        // tinha pensado em passar um model nos parametros ao inves das props
        public static ResultAggregate<IncluirPropostaCommand> Criar(string cpf, decimal valor, int numeroParcelas, string tipoOperacao)
        {
            var result = ResultAggregate.Combine(
                ResultAggregate.FailureIf(string.IsNullOrEmpty(cpf), ResultAggregate.PropriedadeDeErro, "CPF é obrigatório"),
                ResultAggregate.FailureIf(valor <= 0, ResultAggregate.PropriedadeDeErro, "Valor inválido"),
                ResultAggregate.FailureIf(numeroParcelas <= 0, ResultAggregate.PropriedadeDeErro, "Parcelas inválidas"),
                ResultAggregate.FailureIf(string.IsNullOrEmpty(tipoOperacao), ResultAggregate.PropriedadeDeErro, "Tipo operação é obrigatório")
                );

            if (result.IsFailure)
                return result.ConvertFailure<IncluirPropostaCommand>();

            return new IncluirPropostaCommand (cpf, valor, numeroParcelas, tipoOperacao);
        }
    }
}
