using System.Reflection;
using CadastroCliente.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra os serviços da infraestrutura (EF Core + Repositórios)
builder.Services.AddInfrastructure(builder.Configuration);

// Registra o MediatR apontando para o assembly da Application
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("CadastroCliente.Application")));

// Registra os Controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigemLocalhost",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



var app = builder.Build();
app.UseCors("PermitirOrigemLocalhost");
// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // HTTPS não será usado no Docker por padrão

app.UseAuthorization();

// Mapeia controllers (como ClienteController)
app.MapControllers();

app.Run();
