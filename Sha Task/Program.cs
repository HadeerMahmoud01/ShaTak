using Microsoft.EntityFrameworkCore;
using Sha_Task.Models;
using Sha_Task.Services.CashierServices;
using Sha_Task.Services.Invoice;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShaTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr")));
builder.Services.AddScoped<IInvoiceservices, InvoiceServices>();
builder.Services.AddScoped<ICashierServices, CashierServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Invoice}/{action=Index}/{id?}");

app.Run();
