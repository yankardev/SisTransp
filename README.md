# SisTransp

SisTransp es un sistema web desarrollado para la gestión operativa de una empresa de transporte pesado. El sistema permite controlar choferes, unidades, rutas, programación de viajes, combustible, caja y reportes generales.

## Tecnologías utilizadas

- ASP.NET MVC
- C#
- SQL Server
- ADO.NET
- Bootstrap
- JavaScript
- HTML
- CSS

## Arquitectura del proyecto

El sistema está desarrollado bajo una arquitectura por capas:

- SisTransp.Presentacion
- SisTransp.Aplicacion
- SisTransp.Dominio
- SisTransp.Infraestructura

## Módulos implementados

- Inicio de sesión por roles
- Dashboard
- Gestión de choferes
- Gestión de unidades
- Gestión de rutas
- Programación de viajes
- Registro e historial de combustible
- Registro de gastos de caja
- Reporte general de operaciones
- Impresión de reportes
- Buscadores en tablas

## Roles del sistema

- Administrador
- Operaciones
- Combustible
- Caja

## Base de datos

El sistema utiliza SQL Server como motor de base de datos.

## Autor

**Yancarlos Calderón Espinola**

- GitHub: https://github.com/yankardev

- ## Usuarios de demostración

El proyecto incluye los siguientes roles para pruebas:

- Administrador
- Operaciones
- Combustible
- Caja

> **Nota:** Las credenciales no se publican por motivos de seguridad. Para realizar pruebas, registre usuarios en la base de datos o ejecute el script SQL incluido en la carpeta `database`.

Nombre de la base de datos:

```sql
SISTRANSP

