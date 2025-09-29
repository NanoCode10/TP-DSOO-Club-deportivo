# Club Deportivo

Implementa:
1) Registro de Socios y No Socios  
2) Entrega de Carnet y cobro de Cuota (mensual/diaria)  
3) Listado diario de socios con vencimiento hoy

UML/Alcance: ver PDFs en /docs (Clase UML - Corrección, Bocetos, DCU).  
Stack: .NET 7, WinForms, EF Core + Pomelo, MySQL.

---

## Arquitectura (¿por qué 3 proyectos?)

- **Core (Dominio) — `ClubDeportivo.Core`**
  - Qué contiene: Entidades 1:1 con el UML, enums y contratos de servicios.
  - Qué **no** contiene: EF, UI, ni dependencias de infraestructura.
  - Beneficio: dominio limpio, testeable y estable; UI/DB pueden cambiar sin romper reglas de negocio.

- **Data (Infraestructura) — `ClubDeportivo.Data`**
  - Qué contiene: EF Core (Pomelo MySQL), `DbContext`, mapeos y migraciones; repos/queries simples.
  - Depende de: Core (pero Core no depende de Data).
  - Beneficio: cambiar MySQL/estrategia de persistencia sin tocar el dominio ni la UI.

- **WinForms (UI) — `ClubDeportivo.WinForms`**
  - Qué contiene: Formularios según **Bocetos**, Host/DI/Logging, `appsettings.json`.
  - Qué **no** contiene: lógica de negocio; solo orquesta servicios.
  - Beneficio: eventos de UI delgados, acoplamiento bajo y mantenible.

> En resumen: **Core = qué**, **Data = dónde**, **WinForms = cómo lo usa la persona**.

---

## Estado actual (setup inicial listo)

- Solución creada con **tres proyectos** y **referencias** entre ellos.
- Paquetes agregados:
  - Data: `Microsoft.EntityFrameworkCore`, `Pomelo.EntityFrameworkCore.MySql`, `Microsoft.EntityFrameworkCore.Design`.
  - WinForms: `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.Configuration.Json`, `Microsoft.Extensions.Logging.Console`.
- Infra lista:
  - `Program.cs` con **Host + DI + Logging** y `ConnectionString`.
  - `ClubContext` y `DesignTimeContextFactory` listos para migraciones.
- Dominio:
  - Entidades base (placeholders) para `Persona`, `Socio`, `NoSocio`, `Cuota`, `Carnet` (nombrado 1:1; tipos ajustables).
- Raíz del repo: `.gitignore`, `.editorconfig`, `README.md`.
- **Sin credenciales** en el repo (usar `appsettings.Development.json` o `CLUB_CONN` por entorno).

---

## Qué falta (alcance mínimo verificable)

1. **Modelado 1:1 final** del UML (claves, relaciones, tipos exactos) en Core/Data.
2. **Enums** (p. ej. `TipoCuota: Mensual/Diaria`) donde aplique.
3. **Migración `Initial`** y `database update` sobre MySQL limpio.
4. **Servicios de aplicación** mínimos:
   - `SocioService`: alta/baja/edición de Socio y NoSocio.
   - `CuotaService`: cobro **mensual/diaria** (marca pago, fecha, monto).
   - `CarnetService`: emisión de carnet.
5. **Formularios (según Bocetos)** con checklist de controles:
   - `FrmSocioABM`, `FrmNoSocioABM`, `FrmCobroCuota`, `FrmEntregaCarnet`, `FrmVencimientosHoy`.
6. **Listado “vencen hoy”** (consulta + grilla, validado con datos de prueba).
7. **README final de arranque** (migraciones + primera corrida end-to-end).
8. (Opcional) **Tests** para reglas de dominio y casos borde.

---

> Objetivo: entregar lo **mínimo valioso** funcionando, fiel al UML y a los Bocetos, listo para iterar.
