![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)![net](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)	![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

# Demo Video funcionando:
Se ha subido un corto video a youtube para demostrar el funcionamiento.

[![Video Demo de la prueba](https://img.youtube.com/vi/OHDbhWNWf4I/mqdefault.jpg)](https://youtu.be/OHDbhWNWf4I)

# API Documentación

## Overview

El proyecto ha sido creado respetando los principios solid e inyeccion de dependencias asi como separacion de capas por responsabilidad ademas la arquitectura reduce el acoplamiento de codigo mediante el uso de interfaces facilitando las pruebas a futuro, se han utilizado diversos patrones comunmente usados en la industria y se ha elegido una arquitectura clean, ademas se ha utilizado el micro ORM dapper para la base de datos y SqlServer para el motor de BD. 

## Contenido
1. [¿Como Utilizar?](#como-utilizar)
6. [Arquitectura](#arquitectura)
7. [Contacto](#contacto)

## ¿Como Utilizar?

El proyecto esta listo para compilar al ejecutar solo hay que configurar la base de datos y la cadena de conexión

### Muy Importante
Es necesario configurar correctamente la cadena de conexion del motor de SQLServer y tener la instancia de SQLServer Funcionando en local aqui el ejemplo:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "SQLServerConn": "Server=DESKTOP-0LIL35T\\SQLEXPRESS;Database=soyCalidad_db;User Id=sa;Password=root;TrustServerCertificate=true;"
  }
}
```

 ## Arquitectura

 ![arquitectura](https://miro.medium.com/v2/resize:fit:678/1*dyEEkN3GHQeg7sA6v22EHw.png)
