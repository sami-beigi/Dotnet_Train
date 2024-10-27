using System.Data;
using System.Data.SqlTypes;
using DotnetAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContextEF>();

builder.Services.AddCors((options) =>
{
    options.AddPolicy("DevCors", (corBuilder) =>
    {
        corBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:2000")
         .AllowCredentials()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
    options.AddPolicy("ProdCors", (corBuilder) =>
    {
        corBuilder.WithOrigins("http://mysite.com")
         .AllowCredentials()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("DevCors");
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("ProdCors");
app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();

