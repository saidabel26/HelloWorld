# Hello World - Razor Pages + MySQL (Docker Compose)

Pequeña práctica que muestra una aplicación Razor Pages (ASP.NET Core .NET 9) que se conecta a una base de datos MySQL ejecutada por Docker Compose.

## Descripción
- Página principal que muestra "Hello World!" y permite agregar nombres a una lista persistida en MySQL.
- Proyecto dividido en: proyecto web (Razor Pages) y biblioteca de lógica (Core).

## Estructura (carpetas físicas)
- `HelloWorld/` — Proyecto web (Razor Pages)
- `HelloWorld.Core.Application/` — Biblioteca con el repositorio de nombres
- `docker-compose.yml` — Orquesta `app` y `db`
- `HelloWorld/Dockerfile` — Dockerfile del proyecto web

## Requisitos
- Docker y Docker Compose instalados (Docker Desktop o similar).
- .NET 9 SDK (solo si compilas fuera de contenedor).

## Credenciales MySQL (desarrollo)
- Usuario: `hello`
- Contraseña: `hello`
- Root: `root` (password `root`)
- Base de datos: `hello_world`

> La aplicación usa la cadena de conexión con `server=db;...` porque el servicio MySQL en docker-compose se llama `db`.

## Ejecutar
Desde la carpeta raíz del repositorio (donde está `docker-compose.yml`):
docker compose up --build

Accede en: [http://localhost:5000](http://localhost:5000)

## ✅ Evidencias:

<img width="427" height="709" alt="image" src="https://github.com/user-attachments/assets/5f7b0f7d-ebc9-4fd3-a6a6-1b635e0424ca" />

<img width="1600" height="841" alt="image" src="https://github.com/user-attachments/assets/bcfaee69-d7ac-4815-acd7-4ec70641fc10" />

<img width="1600" height="786" alt="image" src="https://github.com/user-attachments/assets/1ba068f2-d896-4c58-9979-d7ac20a972fc" />
