using BlazorSignalRChatDotNet8.Client.Pages;
using BlazorSignalRChatDotNet8.Components;
using BlazorSignalRChatDotNet8.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR(); // SignalR servisi ekleniyor..

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHub<ChatHub>("/chathub"); // SignalR hub�n�n hangi url yolu ile e�lece�ini belirtiyor.. �stemcilerin bu URL'ye ba�lanarak ChatHub ile ileti�im kurmalar�n� sa�lar.

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorSignalRChatDotNet8.Client._Imports).Assembly);

app.Run();
