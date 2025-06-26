using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Interfaces;
using SalesWebMvc.Middlewares;
using SalesWebMvc.Repositories;
using SalesWebMvc.Services;  // <-- Ajuste para o namespace do seu contexto

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com SQL Server
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<SalesRecordService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISalesRecordRepository, SalesRecordRepository>();
// Adicionar serviços MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configurar o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
