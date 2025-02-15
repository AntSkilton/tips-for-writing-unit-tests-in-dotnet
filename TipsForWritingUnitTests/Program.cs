using TipsForWritingUnitTests.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICurrencyService, CurrencyService>();

var app = builder.Build();

app.Run();