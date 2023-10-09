
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAutoFacContainer();

builder.Services.AddDbContext(builder.Configuration);

builder.Services.ConfigureApplicationServices();

builder.Services.AddControllers();

builder.Services.ConfigureFluentValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

// Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Registration API v1");    
});

app.MapControllers();

app.Run();
