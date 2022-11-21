using CommonLibrary.ClientServices.Logging.Implementations;
using CommonLibrary.ClientServices.Logging.Interfaces;
using CommonLibrary.ClientServices.Policies;
using CommonLibrary.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebClient;
using WebClient.Implementations;

//TODO URGENT: ADD SERILOG

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IRepository<IIObject>, ObjectRepository>();
builder.Services.AddHttpClient("HttpClient").AddPolicyHandler(
            request => new HttpClientPolicy().LinearHttpRetryPolicy);
builder.Services.AddSingleton<IClientLogger, DefaultLogger>();
await builder.Build().RunAsync();