# Documentacion del proyecto ASP.NET Core MVC

Este archivo resume, de principio a fin, lo que se hizo para crear el proyecto MVC con .NET 10 y cumplir la consigna.

## 1. Creacion del proyecto

Se creo un proyecto ASP.NET Core MVC usando .NET 10 dentro de la carpeta `mvc`.

Comando usado:

```powershell
dotnet new mvc --framework net10.0 --use-program-main false
```

Esto genero la estructura base del proyecto MVC:

- `Controllers/`
- `Models/`
- `Views/`
- `wwwroot/`
- `Program.cs`
- `mvc.csproj`

El archivo `mvc.csproj` quedo configurado con:

```xml
<TargetFramework>net10.0</TargetFramework>
```

## 2. Revision del ejemplo del profesor

Se reviso el ejemplo del profesor en GitHub:

https://github.com/TUP-UTN-FRRe/programacion3-web-tup-2026/tree/main/013-aspnet-mvc/WebAppMvc

En ese ejemplo el profesor tenia un controlador llamado `JediController` con una accion `Index()` y una vista `Views/Jedi/Index.cshtml`.

La idea principal tomada del ejemplo fue:

- Crear un controlador propio.
- Crear una accion dentro del controlador.
- Crear una vista dentro de `Views/NombreDelControlador/`.
- Usar Razor para mostrar informacion en la vista.

## 3. Creacion del modelo

Se creo el archivo:

```text
Models/Producto.cs
```

Ese archivo define la clase `Producto`, que representa el objeto que se envia desde el controlador hacia la vista.

La clase tiene estas propiedades:

- `Id`
- `Nombre`
- `Descripcion`
- `Precio`
- `Stock`

Codigo creado:

```csharp
namespace mvc.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}
```

## 4. Creacion del controlador

Se creo el archivo:

```text
Controllers/ProductosController.cs
```

Este controlador se encarga de manejar las rutas relacionadas con productos.

Tiene dos acciones principales:

### Accion Detalle

```csharp
[HttpGet]
public IActionResult Detalle(int id)
```

Esta accion cumple con la parte principal de la consigna:

- Recibe un parametro `id` desde la URL.
- Crea una lista de productos.
- Busca el producto cuyo `Id` coincida con el parametro recibido.
- Si no encuentra el producto, devuelve `NotFound()`.
- Si lo encuentra, envia el objeto a la vista con `return View(producto);`.

Ejemplo de URL:

```text
/Productos/Detalle/1
```

### Accion Listado

```csharp
[HttpGet]
public IActionResult Listado()
```

Esta accion corresponde al bonus:

- Crea una lista de productos.
- Envia esa lista completa a otra vista.

Ejemplo de URL:

```text
/Productos/Listado
```

## 5. Creacion de la vista Detalle

Se creo el archivo:

```text
Views/Productos/Detalle.cshtml
```

Esta vista recibe un solo objeto de tipo `Producto`.

Al inicio de la vista se indico el modelo recibido:

```csharp
@model Producto
```

La vista muestra los datos del producto usando `@Model`:

- Nombre
- Descripcion
- Id
- Precio
- Stock

Ejemplo:

```csharp
@Model.Nombre
@Model.Descripcion
@Model.Precio
```

Esta vista cumple con:

- Recibir el objeto enviado por el controlador.
- Mostrar los datos del objeto en pantalla.

## 6. Creacion de la vista Listado

Se creo el archivo:

```text
Views/Productos/Listado.cshtml
```

Esta vista recibe una lista de productos:

```csharp
@model List<Producto>
```

Luego recorre la lista usando `foreach`:

```csharp
@foreach (var producto in Model)
```

Por cada producto muestra:

- Id
- Nombre
- Precio
- Stock
- Un boton para ver el detalle

El boton usa Tag Helpers de ASP.NET Core MVC:

```html
<a asp-controller="Productos"
   asp-action="Detalle"
   asp-route-id="@producto.Id">
    Ver detalle
</a>
```

Eso genera un enlace hacia:

```text
/Productos/Detalle/{id}
```

Por ejemplo:

```text
/Productos/Detalle/1
```

## 7. Modificacion del menu

Se modifico el archivo:

```text
Views/Shared/_Layout.cshtml
```

Se agrego un link en el menu de navegacion para entrar al listado de productos:

```html
<a class="nav-link text-dark" asp-area="" asp-controller="Productos" asp-action="Listado">Productos</a>
```

Gracias a eso, desde la barra superior de la aplicacion se puede acceder directamente a la vista de productos.

## 8. Verificacion del proyecto

Se ejecuto la compilacion del proyecto con:

```powershell
dotnet build
```

La compilacion termino correctamente:

```text
Compilacion correcta.
0 Advertencia(s)
0 Errores
```

En un momento la compilacion fallo porque la aplicacion estaba ejecutandose y bloqueaba el archivo `mvc.exe`. Se detuvo ese proceso y luego se volvio a compilar correctamente.

## 9. Como ejecutar el proyecto

Para iniciar la aplicacion:

```powershell
dotnet run --launch-profile http
```

Segun `launchSettings.json`, la aplicacion usa esta URL:

```text
http://localhost:5002
```

## 10. Rutas para probar

Vista del bonus, con listado de objetos:

```text
http://localhost:5002/Productos/Listado
```

Vista principal de la consigna, con parametro `id`:

```text
http://localhost:5002/Productos/Detalle/1
```

Tambien se pueden probar otros ids existentes:

```text
http://localhost:5002/Productos/Detalle/2
http://localhost:5002/Productos/Detalle/3
```

Si se ingresa un id que no existe, el controlador devuelve `NotFound()`.

## 11. Resumen de archivos creados o modificados

Archivos creados:

```text
Models/Producto.cs
Controllers/ProductosController.cs
Views/Productos/Detalle.cshtml
Views/Productos/Listado.cshtml
```

Archivo modificado:

```text
Views/Shared/_Layout.cshtml
```

## 12. Relacion con la consigna

La consigna pedia:

- Crear un proyecto MVC Web: cumplido.
- Generar un controlador: cumplido con `ProductosController`.
- Generar una vista llamada `Detalle`: cumplido con `Views/Productos/Detalle.cshtml`.
- Recibir un parametro `id`: cumplido en `Detalle(int id)`.
- Crear un objeto en el controlador: cumplido mediante la lista de productos creada en `CrearProductos()`.
- Enviar el objeto a la vista: cumplido con `return View(producto);`.
- Mostrar los datos del objeto en la vista: cumplido usando `@Model`.
- Bonus, enviar un listado de objetos a otra vista: cumplido con `Listado()` y `Views/Productos/Listado.cshtml`.
