using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Repository;
using WebApplication2.Repository.interfaces;
using WebApplication2.Service;
using WebApplication2.Service.Interfaces;

/// <summary>
/// ����� ����� � ������������ ��������
/// </summary>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(option =>
{
    /// <summary>
    /// ����������� � postgresql
    /// </summary>
    option.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

/// <summary>
/// ����������� ������������ � �������� � DI
/// </summary>
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ISongService, SongService>();

/// <summary>
/// ��������� API
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// ��������� ���������� ��� API
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// ��������� �������� ����� �������
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
/// ������ � ������������
/// </summary>
app.MapControllers();
app.Run();