using ScadaBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciono os serviços básicos para a API funcionar
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registo o meu simulador como Singleton (uma única instância partilhada por toda a aplicação para não perder os dados)
builder.Services.AddSingleton<MachineSimulator>();

// Registo o motor que acabámos de criar para correr em segundo plano
builder.Services.AddHostedService<MachineBackgroundService>();

// Configuro o CORS para permitir que o nosso futuro frontend consiga aceder a esta API sem bloqueios de segurança
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuro a interface do Swagger para podermos testar a API facilmente
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();