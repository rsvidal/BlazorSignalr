using BlazorSignalr.Server;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// RSV. Añadir SignalR
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(o => 
{ 
    o.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" }); 
});
// RSV. Fin

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// RSV. User ResponseCompression
app.UseResponseCompression();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// RSV. Endpoints
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapHub<TestHub>("/testhub"); // RSV. Se añade un nuevo EndPoint, de tal forma que al invocar a /testhub, se está invocando a la clase TestHub

app.Run();
