using Microsoft.AspNetCore.Authorization;
using ST.Razor.Web.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option =>
{
    option.Cookie.Name = "MyCookieAuth";
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.ExpireTimeSpan = TimeSpan.FromSeconds(30);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly",
       policy => policy.RequireClaim("Admin"));

    options.AddPolicy("MustBelongToHRDepartment",
        policy => policy.RequireClaim("Department", "HR"));

    options.AddPolicy("HRManagerOnly",
       policy => policy
       .RequireClaim("Department", "HR")
       .RequireClaim("Manager")
       .Requirements.Add(new HRManagerProbationRequirement(3))
       );

});

builder.Services.AddSingleton<IAuthorizationHandler, HRManagerProbationRequirementHander>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
