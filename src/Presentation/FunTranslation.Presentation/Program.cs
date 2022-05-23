using FunTranslation.Application;
using FunTranslation.Application.SystemModels;
using FunTranslation.Infrastructure;
using FunTranslation.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddAuthentication();

builder.Services.Configure<FunTranslationSystemModel>(builder.Configuration.GetSection("FunTranslationSystemModel"));

builder.Services.AddApplicationRegistration();
builder.Services.AddPersistanceServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddInfrastructureServices();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.DatabaseInitialize();

app.Run();
