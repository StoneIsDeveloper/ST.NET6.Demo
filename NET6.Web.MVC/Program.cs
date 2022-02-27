

using NLog.Extensions.Logging;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region 使用Session
builder.Services.AddSession();
#endregion

#region log4net
//Nuget引入：
//1.Log4Net
//2.Microsoft.Extensions.Logging.Log4Net.AspNetCore
builder.Logging.AddLog4Net(@"./CfgFile/log4net.config");
#endregion

#region NLog
{
    //Nuget引入：NLog.Web.AspNetCore
    //builder.Logging.AddNLog("CfgFile/NLog.config");
}
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

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

#region 使用Session
app.UseSession();
#endregion

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
