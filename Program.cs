using Microsoft.EntityFrameworkCore;
using OrdersManager.DB_Access;
using OrdersManager.DBcontext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add dbContext to di container
string con = "Data Source=DESKTOP-SKDKQ0E;Initial Catalog=OrdersManager;Integrated Security=True";
builder.Services.AddDbContext<OrdersManagerContext>(options => options.UseSqlServer(con));
builder.Services.AddScoped<IDB_Provider, DB_Provider>();

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
