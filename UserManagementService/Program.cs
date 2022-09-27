using UserManagementService;
using UserManagementService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContext();
builder.Services.ServicesCofiguration();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
PrepDb.PrepUser(app);
app.Run();