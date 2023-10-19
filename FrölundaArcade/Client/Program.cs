using FrölundaArcade.Client;
using FrölundaArcade.Client.Helpers;
using FrölundaArcade.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddMudMarkdownServices();
builder.Services.AddScoped<AuthMessageHandler>();
builder.Services.AddSingleton<NavigateTo>();
builder.Services.AddSingleton<GuestCart>();

builder.Services.AddHttpClient("FrölundaArcade.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<AuthMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FrölundaArcade.ServerAPI"));
builder.Services.AddSingleton<LocalStorage>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();