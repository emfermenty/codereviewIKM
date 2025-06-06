using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Repository;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service;
using WebApplication2.Service.Interfaces;

/// <summary>
/// точка входа и конфигурация сервисов
/// </summary>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(option =>
{
    /// <summary>
    /// подключение к postgresql
    /// </summary>
    option.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

/// <summary>
/// регистрация репозиториев и сервисов в DI
/// </summary>
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ISongService, SongService>();

/// <summary>
/// поддержка API
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// генерация эндпоинтов для API
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// обработка запросов через сваггер
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

/// <summary>
/// мапинг в контроллерах
/// </summary>
app.MapControllers();
app.Run();