﻿namespace ProjetoReforcoEscopo1.Dominio.Proposta.Infra
{
    // TODO: ver possibilidades de usar o dapper
    public class PropostaRepositorio
    {
        public async Task IncluirProposta(Proposta proposta)
        {
            // TODO: conectar no banco
            await Task.FromResult(proposta);
        }

        public async Task<bool> VerificarPropostasExistentes(string cpf)
        {
            // TODO: conectar no banco
            return await Task.FromResult(false);
        }
    }
}
