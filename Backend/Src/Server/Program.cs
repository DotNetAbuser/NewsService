using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelSection = configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
}).UseKestrel();

builder.Services.AddEndpointsApiExplorer();
#if DEBUG
builder.Services.AddSwagger();
#endif
builder.Services.AddHttpContextAccessor();

builder.Services.AddDatabase(configuration);
builder.Services.AddJwtAuthentication(configuration);

builder.Services.AddHelpers();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

#if DEBUG
app.AddSwagger();
#else
app.UseForwardedHeaders();
#endif

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Files")),
    RequestPath = "/Files"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
