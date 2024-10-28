namespace ProjetoReforcoEscopo1.Dominio.Proposta
{
    public record Proposta
    {
        public string Parceiro { get; set; }
        public string TipoOperacao { get; set; }
        public string TipoAssinatura { get; set; }
        public Cliente Cliente { get; set; }
        public Pagamento Pagamento { get; set; }
        public Conveniada Conveniada { get; set; }

        // TODO: botar num simple factory - AssinaturaFactory
        public bool buscarTipoAssinatura(/*telefone, ufNascimento, estados*/)
        {
            // Operações de contratos novos, devem definir o tipo de assinatura, conforme

            // return assinatura eletrônica
            // return assinatura Híbrida
            // return assinatura Figital

            return true;
        }

        // TODO: factory method - PropostaFactory
        public bool incluirProposta(/*proposta*/)
        {
            return true;
        }
    }
}
