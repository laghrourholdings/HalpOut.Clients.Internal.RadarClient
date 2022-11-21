using CommonLibrary.ClientServices.Logging.Implementations;
using CommonLibrary.ClientServices.Logging.Interfaces;
using CommonLibrary.ClientServices.Policies;
using CommonLibrary.Core;
using CommonLibrary.Logging;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RadarClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IRepository<LogHandle>, LogHandleRepository>();
builder.Services.AddHttpClient("HttpClient").AddPolicyHandler(
    request => new HttpClientPolicy().LinearHttpRetryPolicy);
builder.Services.AddSingleton<IClientLogger, DefaultLogger>();
await builder.Build().RunAsync();