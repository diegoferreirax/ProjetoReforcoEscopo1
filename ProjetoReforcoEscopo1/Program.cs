using ProjetoReforcoEscopo1.Dominio.Proposta.Aplicacao;
using ProjetoReforcoEscopo1.Dominio.Proposta.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ClienteRepositorio>();
builder.Services.AddScoped<PropostaRepositorio>();
builder.Services.AddScoped<ConveniadaRepositorio>();

builder.Services.AddScoped<IncluirPropostaHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
