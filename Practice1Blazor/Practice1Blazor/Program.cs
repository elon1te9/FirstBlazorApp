using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Practice1Blazor;
using Practice1Blazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5164/") });

builder.Services.AddScoped<ApiRequestService>();
builder.Services.AddSingleton<UserStateService>();

await builder.Build().RunAsync();
