using Employees.Application.Interfaces;
using Employees.Application.Mapping;
using Employees.Application.Services;
using Employees.Application.Validation;
using Employees.Infrastructure;
using Employees.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<EmployeeMappingProfile>());

builder.Services.AddControllers();

builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string AllowAll = "AllowAll";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(AllowAll, policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors(AllowAll);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DbInitializer.InitializeAsync(db);
}

app.Run();