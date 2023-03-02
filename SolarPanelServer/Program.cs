using Microsoft.EntityFrameworkCore;
using SolarPanelServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList")
);


builder.Services.AddDbContext<UserContext>(opt =>
    //opt.UseInMemoryDatabase("User")
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SolarPanel"))
);

builder.Services.AddDbContext<ComponentContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SolarPanel"))
);

builder.Services.AddDbContext<MaterialContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SolarPanel"))
);


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
