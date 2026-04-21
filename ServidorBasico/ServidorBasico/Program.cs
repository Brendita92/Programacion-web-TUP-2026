var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Habilitar archivos estáticos (sirve contenido de wwwroot)
app.UseStaticFiles();

// Redirigir la ruta principal "/" a index.html
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();

