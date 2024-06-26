using FPSGERewrite.Application;
using FPSGERewrite.DataService.Data;
using FPSGERewrite.Infrastructure.DataAccess.Repositories;
using FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy("myAllowSpecificOrigins", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(_ => true);
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(DI).Assembly)); // for MediatR ???
//builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("myAllowSpecificOrigins");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "FPSGERewrite Api");
        options.RoutePrefix = string.Empty;
        //options.DocumentTitle = "Demo Web API";
        //options.DocExpansion(DocExpansion.List);
    });
    app.UseCors("myAllowSpecificOrigins");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
