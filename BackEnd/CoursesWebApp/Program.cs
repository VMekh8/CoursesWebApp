using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Caching.Abstract;
using CoursesWebApp.Infrastructure.Caching.Decorators;
using CoursesWebApp.Infrastructure.Persistence.Context;
using CoursesWebApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ILoggerFactory Logger = LoggerFactory.Create(log =>
{
    log.AddConsole();
    log.AddDebug();
});

builder.Services.AddDbContext<DBCoursesContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseLoggerFactory(Logger);
    opt.EnableSensitiveDataLogging();
});

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

builder.Services.AddScoped(typeof(IRedisService<>), typeof(IRedisService<>));

builder.Services.AddScoped<IRepository<NewsEntity>, NewsService>();
builder.Services.AddScoped<IReadOnlyRepository<NewsEntity>, NewsService>();

builder.Services.Decorate<IRepository<NewsEntity>, NewsDecorator>();
builder.Services.Decorate<IReadOnlyRepository<NewsEntity>, NewsDecorator>();


builder.Services.AddScoped<IRepository<StudentEntity>, StudentService>();
builder.Services.AddScoped<IReadOnlyRepository<StudentEntity>, StudentService>();

builder.Services.Decorate<IRepository<StudentEntity>, StudentDecorator>(); 
builder.Services.Decorate<IReadOnlyRepository<StudentEntity>, StudentDecorator>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
