# Portal de Solicitudes de Servicio Técnico — TecnoGas Hogar

Aplicación web ASP.NET Core MVC (.NET 10) para gestionar solicitudes de servicio técnico de artefactos a gas del hogar.

## Tecnologías
- ASP.NET Core MVC (.NET 10)
- Entity Framework Core + SQLite
- Bootstrap 5 (incluido por defecto en el template)
- Docker (para despliegue en Render)

## Funcionalidades
- **Registrar solicitud**: formulario con Cliente, Teléfono, Distrito, Tipo de Servicio y Descripción
- **Listar solicitudes**: tabla con todas las solicitudes ordenadas por fecha

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
2. Conecta tu repositorio GitHub (`evaluacion20262`)
3. Selecciona **Docker** como entorno
4. Render detectará el `Dockerfile` automáticamente
5. Puerto: `8080`

> La base de datos SQLite (`tecnogas.db`) se crea automáticamente al iniciar el contenedor gracias a `database update` en el entrypoint.

## Estructura de ramas (Git)

```
main
 └── develop
       ├── feature/modelo-sqlite       → Pregunta 1
       ├── feature/registro-solicitud  → Pregunta 2
       └── feature/listado-solicitudes → Pregunta 3
```

## Repositorio GitHub
- Nombre: `evaluacion20262`
