
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 

builder.Services.AddControllers();


// Connection With Database 
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") , b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName) ));



// Add Services
//builder.Services.AddTransient(typeof(IBaseRepository<>) , typeof(BaseRepository<>)); 
builder.Services.AddTransient<IUnitOfWork , UnitOfWork>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
