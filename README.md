# Portal de Solicitudes de Servicio Técnico — TecnoGas Hogar

Aplicación web ASP.NET Core MVC (.NET 10) para gestionar solicitudes de servicio técnico de artefactos a gas del hogar.

## Tecnologías
- ASP.NET Core MVC (.NET 10)
- Entity Framework Core + SQLite
- Bootstrap 5
- Docker (para despliegue en Render)

## Funcionalidades
- **Registrar solicitud**: formulario con Cliente, Teléfono, Distrito, Tipo de Servicio y Descripción
- **Listar solicitudes**: tabla con todas las solicitudes ordenadas por fecha descendente

## Ejecutar localmente

```bash
# Restaurar dependencias
dotnet restore

# Aplicar migraciones (crea tecnogas.db)
dotnet ef database update

# Ejecutar
dotnet run
```

La aplicación estará disponible en `http://localhost:5000`.

## Despliegue en Render con Docker

El proyecto incluye un `Dockerfile` multi-stage. Para desplegar en Render:

1. Crea un nuevo **Web Service** en [render.com](https://render.com)
2. Conecta el repositorio GitHub: `https://github.com/KushiedaZ5/examen1`
3. Selecciona **Docker** como entorno de ejecución
4. Render detectará el `Dockerfile` automáticamente
5. Puerto expuesto: `8080`
6. Variable de entorno: `ASPNETCORE_URLS=http://+:8080`

> La base de datos SQLite (`tecnogas.db`) se crea automáticamente al arrancar el contenedor gracias a `db.Database.Migrate()` en `Program.cs`.

## URL de la aplicación en Render

> ⏳ URL disponible tras el despliegue en Render

## Estructura de ramas (Git)

```
main
 └── develop
       ├── feature/modelo-sqlite       → Pregunta 1: Modelo + EF Core + SQLite
       ├── feature/registro-solicitud  → Pregunta 2: Registro de solicitudes (Insert)
       └── feature/listado-solicitudes → Pregunta 3: Listado de solicitudes (Select)
```

## Repositorio GitHub
- URL: [https://github.com/KushiedaZ5/examen1](https://github.com/KushiedaZ5/examen1)
