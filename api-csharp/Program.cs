using projeto_dbm.Models;
using projeto_dbm.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar o SQL Server
builder.Services.AddDbContext<ContextoBD>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Adicionando os serviços de controller
builder.Services.AddControllers();

var app = builder.Build();

// Configuração para usar o roteamento e mapear os controllers
app.MapControllers();

// Migrando o banco de dados (garante que as migrações sejam aplicadas automaticamente)
using (var escopo = app.Services.CreateScope())
{
    var contexto = escopo.ServiceProvider.GetRequiredService<ContextoBD>();
    contexto.Database.Migrate();
}

// Iniciando a aplicação
app.Run();
builder.Logging.AddConsole();
