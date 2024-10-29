namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Conveniada
    (
        string Nome,
        Agente Agente,
        List<Estado> Estados,
        bool ExecutaRefinanciamento
    );
}
