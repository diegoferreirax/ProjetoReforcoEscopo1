using ProjetoReforcoEscopo1.Shared;

namespace ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao
{
    public record IncluirPropostaCommand
    {
        public string Cpf { get; }
        public decimal Valor { get; }
        public int NumeroParcelas { get; }
        public string TipoOperacao { get; }
        public string Conveniada { get; }

        private IncluirPropostaCommand(string cpf, decimal valor, int numeroParcelas, string tipoOperacao, string conveniada)  
        {
            Cpf = cpf;
            Valor = valor;
            NumeroParcelas = numeroParcelas;
            TipoOperacao = tipoOperacao;
            Conveniada = conveniada;
        }

        // tinha pensado em passar um model nos parametros ao inves das props
        public static ResultAggregate<IncluirPropostaCommand> Criar(string cpf, decimal valor, int numeroParcelas, string tipoOperacao, string conveniada)
        {
            var result = ResultAggregate.Combine(
                ResultAggregate.FailureIf(string.IsNullOrEmpty(cpf), "IncluirPropostaCommand", "CPF é obrigatório"),
                ResultAggregate.FailureIf(valor <= 0, "IncluirPropostaCommand", "Valor inválido"),
                ResultAggregate.FailureIf(numeroParcelas <= 0, "IncluirPropostaCommand", "Parcelas inválidas"),
                ResultAggregate.FailureIf(string.IsNullOrEmpty(tipoOperacao), "IncluirPropostaCommand", "Tipo operação é obrigatório"),
                ResultAggregate.FailureIf(string.IsNullOrEmpty(conveniada), "IncluirPropostaCommand", "Conveniada é obrigatória")
                );

            if (result.IsFailure)
                return result.ConvertFailure<IncluirPropostaCommand>();

            return new IncluirPropostaCommand (cpf, valor, numeroParcelas, tipoOperacao, conveniada);
        }
    }
}
