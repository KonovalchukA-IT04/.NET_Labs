using BLL.Services.Interfaces;
using BLL.Services;
using DAL.Context;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TMContext>();


builder.Services.AddScoped<IRepository<Employee>, Employee_rep>();
builder.Services.AddScoped<IRepository<State>, State_rep>();
builder.Services.AddScoped<IRepository<TheTask>, TheTask_rep>();
builder.Services.AddScoped<IRepository<Team>, Team_rep>();
builder.Services.AddScoped<IRepository<Assigment>, Assigment_rep>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IEmployee_srv, Employee_srv>();
builder.Services.AddScoped<IState_srv, State_srv>();
builder.Services.AddScoped<ITeam_srv, Team_srv>();
builder.Services.AddScoped<ITheTask_srv, TheTask_srv>();
builder.Services.AddScoped<IAssigment_srv, Assigment_srv>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();