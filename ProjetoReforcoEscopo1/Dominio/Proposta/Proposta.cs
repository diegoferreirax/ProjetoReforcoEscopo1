namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Proposta
    (
        string Parceiro,
        string TipoOperacao,
        string TipoAssinatura,
        Cliente Cliente,
        Pagamento Pagamento,
        Conveniada Conveniada
    );
}
