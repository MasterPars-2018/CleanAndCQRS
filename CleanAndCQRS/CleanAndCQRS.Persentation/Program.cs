using CleanAndCQRS.Application;
using CleanAndCQRS.Infrastructure;
using CleanAndCQRS.Persentation.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

 

builder.Services.AddControllers();

builder.Services.RegisterInfrastructure(builder.Configuration)
    .RegisterApplicationService();


 

 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(option => { });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
