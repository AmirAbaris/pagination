using api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddRepositoryServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(); // this line is added

app.UseAuthentication(); // this line has to be between Cors and Authorization!

app.UseAuthorization();

app.MapControllers();

app.Run();