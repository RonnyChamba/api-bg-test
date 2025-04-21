# api-bg-test

Este repositorio contiene un proyecto de API REST desarrollado en **C# con .NET 8** llamado `ApiPruebaIntegrity`.

## 📁 Estructura del repositorio

- **ApiPruebaIntegrity/**: Contiene el código fuente del proyecto principal de la API.
- **1_backup_api.sql**: Script SQL que incluye tanto la estructura de la base de datos como datos necesarios para su funcionamiento. **Debe ejecutarse antes de levantar la API**.
- **diagrama_er.pdf**: Contiene el modelo entidad relación.

## 🚀 Requisitos

Asegúrate de tener instalado lo siguiente en tu entorno local:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
- Un IDE como [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms) (opcional)

## 🛠️ Configuración inicial

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/RonnyChamba/api-bg-test.git
   cd api-bg-test

2. **Ejecuta el script de base de datos**
    Abre 1_backup_api.sql en tu gestor de base de datos y ejecútalo para crear la estructura y poblar los datos.

3. **Configura la cadena de conexión**
   Abre el archivo appsettings.json dentro de ApiPruebaIntegrity y edita la propiedad ConnectionStrings:DefaultConnection con los datos de tu servidor SQL.
   ```ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=NombreBD;User Id=usuario;Password=contraseña;"}

4. **Ejecuta la aplicación**
   dotnet run
