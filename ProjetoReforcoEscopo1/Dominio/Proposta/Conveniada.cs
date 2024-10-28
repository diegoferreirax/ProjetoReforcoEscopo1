namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Conveniada
    {
        public string Nome { get; set; }
        public List<Agente> Agentes { get; set; }
        public List<Estado> Estados { get; set; }

        // TODO: botar num strategy
        public bool validarOperacaoRefinanciamento(/*TipoOperacao.Refinanciamento*/)
        {
            // Algumas conveniadas não aceitam operação de refinanciamento
            return true;
        }
    }
}
