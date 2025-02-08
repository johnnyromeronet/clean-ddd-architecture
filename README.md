# Clean.DDD.Architecture

Bienvenido a **Clean.DDD.Architecture**, un proyecto donde exploramos **Domain-Driven Design (DDD)** y **Clean Architecture** aplicados a .NET Core. Este repositorio evolucionará con el tiempo a medida que lo desarrollamos en el canal de YouTube.

## 🎯 Objetivo
El objetivo de este proyecto es proporcionar una guía práctica para implementar una arquitectura limpia basada en DDD en aplicaciones .NET Core. A través del canal de YouTube, iremos explicando cada decisión arquitectónica y cómo mejorar el diseño del software en el tiempo.

## 📌 Características Clave
- Aplicación basada en **Clean Architecture**
- Implementación de **Domain-Driven Design (DDD)**
- Separación clara entre **Core, Infrastructure y Presentation**
- Uso de **.NET Core 8**
- Enfoque en **pruebas automatizadas** y buenas prácticas de diseño
- Ejemplos prácticos que evolucionan con el tiempo

## 📺 Sigue el Proyecto en YouTube
Este proyecto se desarrollará en nuestro canal de YouTube, donde explicaremos cada concepto con detalle. Suscríbete para no perderte ninguna actualización:

🔗 [Canal de YouTube](https://www.youtube.com/@johnnyromeronet)

## 🚀 Instalación y Ejecución
1. Clona este repositorio:
   ```sh
   git clone https://github.com/johnnyromeronet/clean-ddd-architecture.git
   ```
2. Accede al directorio del proyecto:
   ```sh
   cd Clean.DDD.Architecture
   ```
3. Restaura los paquetes de dependencias:
   ```sh
   dotnet restore
   ```
4. Ejecuta la aplicación:
   ```sh
   dotnet run
   ```

## 📂 Estructura del Proyecto
```
Clean.DDD.Architecture/
│-- Core/
│   │-- Clean.DDD.Architecture.Application/  # Casos de uso y servicios de aplicación
│   │-- Clean.DDD.Architecture.Business/     # Lógica de negocio
│   │-- Clean.DDD.Architecture.Domain/       # Entidades, Value Objects, Agregados y Repositorios
│-- Infrastructure/
│   │-- Clean.DDD.Architecture.Infrastructure/ # Persistencia, proveedores externos, implementaciones técnicas
│-- Presentation/
│   │-- Clean.DDD.Architecture.WebAPI/        # API y presentación
│-- Tests/                                    # Pruebas unitarias e integración
│-- README.md
│-- .gitignore
│-- Clean.DDD.Architecture.sln
```

## 🛠️ Tecnologías Utilizadas
- **.NET Core 8**
- **Entity Framework Core** (para la capa de persistencia)
- **MediatR** (para manejar patrones CQRS)
- **FluentValidation** (para validaciones de dominio)
- **xUnit / NUnit** (para pruebas)

## 🤝 Contribuciones
Este es un proyecto en evolución. Si quieres aportar mejoras, puedes indicarmelo en los **comentarios de YouTube**.

## 📜 Licencia
Este proyecto está licenciado bajo la **MIT License** - consulta el archivo [LICENSE](https://github.com/johnnyromeronet/clean-ddd-architecture/blob/master/LICENSE.txt) para más detalles.

---

✨ ¡No olvides suscribirte y seguir el desarrollo en el canal de YouTube! 🚀

