using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddMediator(options => { options.ServiceLifetime = ServiceLifetime.Scoped; })
	.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
