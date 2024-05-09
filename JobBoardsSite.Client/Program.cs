using Blazored.LocalStorage;
using JobBoardsSite.Client;
using JobBoardsSite.Client.Helpers;
using JobBoardsSite.Client.Interceptors;
using JobBoardsSite.Client.Services;
using JobBoardsSite.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IClientAuthService, ClientAuthService>();
builder.Services.AddScoped<IClientRecruiterService, ClientRecruiterService>();
builder.Services.AddScoped<IClientApplicantService, ClientApplicantService>();
builder.Services.AddScoped<IClientJobService, ClientJobService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IManageLocalStorage, ManageLocalStorage>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<TestInterceptor>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7090/") });

await builder.Build().RunAsync();
