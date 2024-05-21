using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Processor;
using DeskBooker.DataAccess;
using DeskBooker.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configuration setup
var configuration = builder.Configuration;

// Services registration
builder.Services.AddRazorPages();

var connectionString = "DataSource=:memory:";
var connection = new SqliteConnection(connectionString);
connection.Open();

builder.Services.AddDbContext<DeskBookerContext>(options =>
	options.UseSqlite(connection)
);

EnsureDatabaseExists(connection);

builder.Services.AddTransient<IDeskRepository, DeskRepository>();
builder.Services.AddTransient<IDeskBookingRepository, DeskBookingRepository>();
builder.Services.AddTransient<IDeskBookingRequestProcessor, DeskBookingRequestProcessor>();

static void EnsureDatabaseExists(SqliteConnection connection)
{
	var builder = new DbContextOptionsBuilder<DeskBookerContext>();
	builder.UseSqlite(connection);

	using var context = new DeskBookerContext(builder.Options);
	context.Database.EnsureCreated();
}

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

