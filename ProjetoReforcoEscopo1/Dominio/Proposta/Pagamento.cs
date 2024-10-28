namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Pagamento
    {
        public decimal ValorTotal { get; set; }
        public int QuantidadeParcela { get; set; }

        // TODO: botar num strategy
        public bool verificarUltimaParcelaIdadeProponente(/*DateTime.Now, numParcelas*/)
        {
            // Última parcela de pagamento não pode exceder a idade de 80 anos do proponente
            return true;
        }
    }
}
