namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Agente
    {
        public bool Ativo { get; set; }

        public bool validarAgenteAtivo()
        {
            // Agente que está incluindo a proposta deve estar ativo
            return true;
        }
    }
}
