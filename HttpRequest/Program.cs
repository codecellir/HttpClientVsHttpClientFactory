using HttpRequest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("coinDeskApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CoinDeskApi:Url"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
