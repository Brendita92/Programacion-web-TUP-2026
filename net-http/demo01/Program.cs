var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string HTML_INDEX_CONTENT = @"<html >
     <body>
            <h1 >Programacion 2026</h1>
            <p>Bienvenido a mi pagina de demostracion</p> 
     </body>
</html>";

app.UseHttpsRedirection();

//static files middleware
app.MapStaticAssets();

app.MapGet("/", () => "Hello World! GET");
//app.MapGet("/index.html", () => HTML_CONTENT);
app.MapGet("/index.html", () => Results.Content(HTML_INDEX_CONTENT, "text/html"));

app.MapPost("/", () => "Hello World! POST");

app.MapDelete("/", () => "Hello World! DELETE");

app.Run();
