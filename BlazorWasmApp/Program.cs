using ApiClient;
using BlazorWasmApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IMyApiClient, MyApiClient>(provider => new MyApiClient("https://localhost:7270", provider.GetService<IHttpContextAccessor>()!, new HttpClient()));

await builder.Build().RunAsync();
