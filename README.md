# POC 🚀

Este proyecto es una **Prueba de Concepto (POC)** diseñada para resolver las inconsistencias y deficiencias de los sistemas legacy en el procesamiento de novedades de nómina. El sistema automatiza la recepción, validación y limpieza de registros de horas extras provenientes de archivos CSV.

---

## 📋 Resumen de la Solución

El sistema garantiza que solo la información de alta calidad llegue al proceso de nómina, eliminando errores comunes como horas negativas, formatos de fecha inválidos o tipos de recargo inexistentes.

### Características Principales:
*   **Validación Rigurosa:** Aplicación de reglas de negocio fila por fila.
*   **Seguridad de Datos:** Control de duplicados mediante hashing de archivos (SHA256).
*   **Trazabilidad:** Separación y almacenamiento de registros válidos y erróneos para auditoría.
*   **Arquitectura Limpia:** Estructura desacoplada y preparada para el crecimiento.

---

## 🏗️ Arquitectura del Sistema

Se implementó una **Arquitectura en Capas** para asegurar la separación de responsabilidades y facilitar el mantenimiento:

*   **API Layer:** Exposición de endpoints REST, manejo de peticiones HTTP y validaciones de esquema.
*   **Core Layer (Application & Domain):** Contiene la lógica de negocio, servicios de validación y el orquestador del procesamiento.
*   **Infrastructure Layer:** Gestión de la persistencia en base de datos (PostgreSQL) y acceso a datos.

---

## 🛠️ Tecnologías Utilizadas

*   **.NET 8 / C#**
*   **Entity Framework Core**
*   **PostgreSQL** (Base de datos principal)
*   **Hashing (SHA256)** para la validación de integridad y duplicidad de archivos.

---

## 📉 Flujo del Proceso

1.  **Carga:** El usuario envía el archivo CSV vía API.
2.  **Verificación de Integridad:** Se calcula el Hash del archivo para evitar reprocesar documentos idénticos.
3.  **Parsing & Validación:** Se lee el contenido y se aplican las reglas:
    *   `EmployeeDocument`: Obligatorio.
    *   `Hours`: Numérico y mayor a 0.
    *   `ReportDate`: Formato de fecha válido.
    *   `OvertimeType`: Debe ser uno de los tipos permitidos (HE_DIURNA, HE_NOCTURNA, HE_DOMINICAL, HE_FESTIVA).
4.  **Persistencia Atómica:** 
    *   Registros exitosos $\rightarrow$ Tabla `OvertimeRecords`.
    *   Registros fallidos $\rightarrow$ Tabla `OvertimeErrors` (con descripción del error).
    *   Log de control $\rightarrow$ Tabla `ProcessedFiles`.

---

## 🚀 Escalabilidad y Visión Futura

Este POC fue diseñado con una mentalidad **Cloud-Ready** y **Enterprise-Level**:

*   **Procesamiento Asíncrono:** Implementación de colas de mensajes (Azure Service Bus / RabbitMQ) para procesar archivos masivos en background.
*   **Batch Insert:** Optimización de inserts en base de datos para manejar cientos de miles de registros.
*   **Multi-tenancy:** Capacidad técnica para aislar datos por cliente o empresa.
*   **Cloud Persistence:** Adaptabilidad para usar Azure Blob Storage o AWS S3 para el almacenamiento físico de archivos.

---

> **Nota:** La solución actual representa una arquitectura inicial robusta que permite evolucionar hacia un entorno de alta disponibilidad y procesamiento masivo.
