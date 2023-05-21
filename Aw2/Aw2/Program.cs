using Aw2.Data.UnitOfWork;
using Aw2.Schema.Validation;
using Aw2.Service.RestExtensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<StaffRequestValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerExtension();
builder.Services.AddDbContextExtension(configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMapperExtension();
builder.Services.AddRepositoryExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelExpandDepth(-1);
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aw2 Company");
        c.DocumentTitle = "Aw2 Company";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
