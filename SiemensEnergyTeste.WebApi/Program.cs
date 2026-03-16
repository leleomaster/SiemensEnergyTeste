using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using SiemensEnergyTeste.Application.Services;
using SiemensEnergyTeste.Domain.Interfaces.Repositories;
using SiemensEnergyTeste.Domain.Interfaces.Services;
using SiemensEnergyTeste.Persistence;
using SiemensEnergyTeste.Persistence.Repositories;
using SiemensEnergyTeste.WebApi.Configurations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("SiemensEnergyTesteConnection") ??
                       throw new InvalidOperationException("Connection string 'SiemensEnergyTesteConnection' not found.");

builder.Services.AddDbContext<SiemensEnergyTesteContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api para livro, genero e autor",
        Description = "CRUD de livro, genero e autor",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "SiemensEnergyTeste@gmail.com",
            Url = new Uri("https://siemens-energy-teste.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "License SiemensEnergyTeste",
            Url = new Uri("https://siemens-energy-teste.com/license")
        }
    });
});

// 1. Get the global TypeAdapterConfig settings
var config = TypeAdapterConfig.GlobalSettings;

// 2. Scan the assembly for classes that implement IRegister (optional, for custom mappings)
config.Scan(Assembly.GetExecutingAssembly());

// 3. Register TypeAdapterConfig as a Singleton
builder.Services.AddSingleton(config);

#region Injeção de dependências

builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IGeneroService, GeneroService>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

builder.Services.AddScoped<IMapper, ServiceMapper>();

#endregion

builder.Services.RegistrarMapeamento();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
else
{
    // Captura exceções e retorna 500
    app.UseExceptionHandler();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
