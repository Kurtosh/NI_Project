using Microsoft.EntityFrameworkCore;
using NI_Project.Api;
using NI_Project.Api.Interfaces;
using NI_Project.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BookDataContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
        options.UseLazyLoadingProxies();
    });

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IReaderService, ReaderService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
