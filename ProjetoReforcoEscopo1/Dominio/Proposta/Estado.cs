namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Estado
    {
        public string Sigla { get; set; } = string.Empty;

        // TODO: botar num strategy
        public bool validarRestricaoValor(/*estado*/)
        {
            // RS, SC, PR da conveniada INSS DATAPREV, limite máximo 100k de empréstimo
            return true;
        }
    }
}
