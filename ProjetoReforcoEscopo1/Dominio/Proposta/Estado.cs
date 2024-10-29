namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Estado
    {
        public string Sigla { get; set; } = string.Empty;
        public decimal ValorMaximo { get; set; }
    }
}
