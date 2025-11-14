drop database if exists clubdeportivoAACMP;
create database clubdeportivoAACMP; 
use clubDeportivoAACMP;

CREATE TABLE IF NOT EXISTS persona (
    codPersona     INT AUTO_INCREMENT,
    nombre         VARCHAR(50),
    apellido       VARCHAR(50),
    documento      VARCHAR(20),
    email          VARCHAR(40),
    tel            VARCHAR(20),
    tipoDocumento  VARCHAR(20),
    fichaMedica    BOOLEAN,
    activo         TINYINT(1) NOT NULL DEFAULT 1,  -- <== nueva columna
    CONSTRAINT pk_persona PRIMARY KEY (codPersona)
);

CREATE TABLE IF NOT EXISTS socio (
    codSocio INT AUTO_INCREMENT,
    codPersona INT,
    estado BOOLEAN,
    CONSTRAINT pk_socio PRIMARY KEY (codSocio),
    CONSTRAINT fk_persona_socio FOREIGN KEY (codPersona) REFERENCES persona(codPersona)
);

CREATE TABLE IF NOT EXISTS no_socio (
    codNoSocio INT AUTO_INCREMENT,
    codPersona INT,
    CONSTRAINT pk_noSocio PRIMARY KEY (codNoSocio),
    CONSTRAINT fk_persona_no_socio FOREIGN KEY (codPersona) REFERENCES persona(codPersona)
);


CREATE TABLE IF NOT EXISTS usuario(
CodUsu int auto_increment,
NombreUsu varchar (20),
PassUsu varchar (15),
Activo boolean default true,
constraint pk_usuario primary key (CodUsu)
);

insert into usuario(CodUsu,NombreUsu,PassUsu) values
(26,'admin','123456');

CREATE TABLE cuota (
    codCuota INT AUTO_INCREMENT PRIMARY KEY,
    codSocio INT NOT NULL,
    fechaVencimiento DATE NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fechaPago DATE NULL,
    estado ENUM('Pendiente', 'Pagada') DEFAULT 'Pendiente',

    CONSTRAINT fk_cuota_socio
        FOREIGN KEY (codSocio) REFERENCES socio(codSocio)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

#PROCEDIMIENTOS ALMACENADOS:


delimiter //  
create procedure IngresoLogin(in Usu varchar(20),in Pass varchar(15))

begin
   select CodUsu
	from usuario
		where NombreUsu = Usu and PassUsu = Pass 
			and Activo = 1; 
end 
//
DELIMITER ;

DELIMITER //
CREATE PROCEDURE crear_persona(
    IN pNombre VARCHAR(50),
    IN pApellido VARCHAR(50),
    IN pDocumento VARCHAR(20),
    IN pTipoDocumento VARCHAR(20),
    IN pEmail VARCHAR(50),
    IN pTel VARCHAR(20),
    IN pFichaMedica BOOLEAN,
    IN pTipo VARCHAR(20),
    OUT rta INT
)
BEGIN
    DECLARE vCodPersona INT DEFAULT NULL;
    DECLARE vCodSocio INT DEFAULT NULL;
    DECLARE vCodNoSocio INT DEFAULT NULL;

    -- Verificar si ya existe la persona
    SELECT codPersona INTO vCodPersona
    FROM persona
    WHERE tipoDocumento = pTipoDocumento
      AND documento = pDocumento
    LIMIT 1;

    IF vCodPersona IS NULL THEN
        -- Insertar persona
        INSERT INTO persona(nombre, apellido, documento, tipoDocumento, email, tel, fichaMedica)
        VALUES (pNombre, pApellido, pDocumento, pTipoDocumento, pEmail, pTel, pFichaMedica);

        SET vCodPersona = LAST_INSERT_ID();

        -- Insertar según tipo y devolver el ID del tipo correspondiente
        IF pTipo = 'Socio' THEN
            INSERT INTO socio(codPersona, estado) VALUES (vCodPersona, 0);
            SET vCodSocio = LAST_INSERT_ID();
            SET rta = vCodSocio;

        ELSEIF pTipo = 'NoSocio' THEN
            INSERT INTO no_socio(codPersona) VALUES (vCodPersona);
            SET vCodNoSocio = LAST_INSERT_ID();
            SET rta = vCodNoSocio;
        END IF;

    ELSE
        SET rta = 0; -- Ya existe
    END IF;
END //
DELIMITER ;

-- Registrar cuota
DELIMITER //
CREATE PROCEDURE registrar_cuota(
    IN pIdSocio INT,
    IN pFechaVencimiento DATE,
    IN pMonto DECIMAL(10,2),
    IN pFechaPago DATE
)
BEGIN
    INSERT INTO cuota (codSocio, fechaVencimiento, monto, estado, fechaPago)
    VALUES (pIdSocio, pFechaVencimiento, pMonto,
            IF(pFechaPago IS NULL,'Pendiente','Pagada'), pFechaPago);
    IF pFechaPago IS NOT NULL THEN
        UPDATE socio SET estado = 1 WHERE codSocio = pIdSocio;
    END IF;
END //
DELIMITER ;





DELIMITER //
CREATE PROCEDURE pagar_cuota(
    IN pIdSocio   INT,
    IN pFechaPago DATE
)
BEGIN
    DECLARE vMonto       DECIMAL(10,2);
    DECLARE vUltVenc     DATE;
    DECLARE vDiaAnchor   INT;
    DECLARE vPrimDiaMes  DATE;
    DECLARE vUltDiaMes   INT;
    DECLARE vVencActual  DATE;
    DECLARE vIdPend      INT;

    -- Último monto y último vencimiento para anclar el día
    SELECT c.monto, c.fechaVencimiento
      INTO vMonto, vUltVenc
      FROM cuota c
     WHERE c.codSocio = pIdSocio
     ORDER BY c.fechaVencimiento DESC
     LIMIT 1;

    IF vMonto   IS NULL THEN SET vMonto   := 25000.00; END IF;   -- default si no hay historial
    IF vUltVenc IS NULL THEN SET vUltVenc := pFechaPago; END IF; -- primera vez

    -- Anclamos el vencimiento al día que venía usando el socio (o al día del pago)
    SET vDiaAnchor  := DAY(vUltVenc);
    SET vPrimDiaMes := DATE_SUB(pFechaPago, INTERVAL (DAY(pFechaPago)-1) DAY);
    SET vUltDiaMes  := DAY(LAST_DAY(pFechaPago));
    SET vVencActual := DATE_ADD(vPrimDiaMes, INTERVAL LEAST(vDiaAnchor, vUltDiaMes)-1 DAY);

    -- Traer/crear pendiente del mes actual
    SELECT codCuota
      INTO vIdPend
      FROM cuota
     WHERE codSocio = pIdSocio AND estado = 'Pendiente'
     ORDER BY fechaVencimiento DESC
     LIMIT 1;

    IF vIdPend IS NULL THEN
        INSERT INTO cuota (codSocio, fechaVencimiento, monto, estado)
        VALUES (pIdSocio, vVencActual, vMonto, 'Pendiente');
        SET vIdPend := LAST_INSERT_ID();
    ELSE
        UPDATE cuota
           SET fechaVencimiento = vVencActual
         WHERE codCuota = vIdPend;
    END IF;

    -- Pagar la del mes actual
    UPDATE cuota
       SET fechaPago = pFechaPago,
           estado    = 'Pagada'
     WHERE codCuota  = vIdPend;

    -- Crear la próxima pendiente (+1 mes)
    IF NOT EXISTS (
        SELECT 1
          FROM cuota
         WHERE codSocio = pIdSocio
           AND estado = 'Pendiente'
           AND fechaVencimiento = DATE_ADD(vVencActual, INTERVAL 1 MONTH)
    ) THEN
        INSERT INTO cuota (codSocio, fechaVencimiento, monto, estado)
        VALUES (pIdSocio, DATE_ADD(vVencActual, INTERVAL 1 MONTH), vMonto, 'Pendiente');
    END IF;

    -- Reactivar socio
    UPDATE socio SET estado = 1 WHERE codSocio = pIdSocio;
END //
DELIMITER ;
-- fin procedure cuota


-- Incio procedure Listar persona por tipo
DELIMITER //
CREATE PROCEDURE listar_personas_por_tipo(IN pTipo VARCHAR(20))
BEGIN
  SET pTipo = LOWER(REPLACE(pTipo,' ',''));

  IF pTipo='socio' THEN
    /*SELECT
      s.codSocio, p.codPersona, p.nombre, p.apellido, p.email, p.tel,
      p.tipoDocumento, p.documento,
      CASE WHEN p.fichaMedica=1 THEN 'Sí' ELSE 'No' END AS AptoFisico,
      s.estado AS EstadoSocio,
      v.fechaVencProx AS fechaVencimiento,
      CASE WHEN v.tienePagoVigente=1 THEN 'Pagada' ELSE 'Pendiente' END AS EstadoCuota
    FROM socio s
    JOIN persona p ON p.codPersona=s.codPersona AND p.activo=1
    LEFT JOIN (
      SELECT c.codSocio,
             MAX(c.fechaVencimiento) AS fechaVencProx,
             MAX(CASE WHEN c.estado='Pagada' AND c.fechaVencimiento>=CURDATE() THEN 1 ELSE 0 END) AS tienePagoVigente
      FROM cuota c GROUP BY c.codSocio
    ) v ON v.codSocio=s.codSocio
    ORDER BY p.apellido, p.nombre;*/
  
    SELECT
      s.codSocio, p.codPersona, p.nombre, p.apellido, p.email, p.tel,
      p.tipoDocumento, p.documento,
      CASE WHEN p.fichaMedica=1 THEN 'Sí' ELSE 'No' END AS AptoFisico,
      s.estado AS EstadoSocio,
      ultima.fechaVencimiento AS fechaVencimiento,
      CASE 
        WHEN ultima.fechaVencimiento <= CURDATE() THEN 'Pendiente' 
        ELSE 'Pagada'
      END AS EstadoCuota
    FROM socio s
    JOIN persona p ON p.codPersona=s.codPersona AND p.activo=1
    LEFT JOIN (
      SELECT 
        codSocio,
        fechaVencimiento,
        estado
      FROM cuota 
      WHERE (codSocio, fechaVencimiento) IN (
        SELECT codSocio, MAX(fechaVencimiento)
        FROM cuota 
        GROUP BY codSocio
      )
    ) ultima ON ultima.codSocio = s.codSocio
    ORDER BY p.apellido, p.nombre;

  ELSEIF pTipo='nosocio' THEN
    SELECT
      n.codNoSocio, p.codPersona, p.nombre, p.apellido, p.email, p.tel,
      p.tipoDocumento, p.documento,
      CASE WHEN p.fichaMedica=1 THEN 'Sí' ELSE 'No' END AS AptoFisico
    FROM no_socio n
    JOIN persona p ON p.codPersona=n.codPersona AND p.activo=1
    ORDER BY p.apellido, p.nombre;

  ELSE
    SELECT 'Tipo no válido. Usar "Socio" o "NoSocio".' AS Mensaje;
  END IF;
END //
DELIMITER ;
-- Fin procedure Listar persona por tipo

-- === ACTUALIZAR ===
DELIMITER //
CREATE PROCEDURE actualizar_persona(
    IN  pId            INT,
    IN  pNombre        VARCHAR(20),
    IN  pApellido      VARCHAR(20),
    IN  pTipoDocumento VARCHAR(20),
    IN  pDocumento     VARCHAR(20),
    IN  pEmail         VARCHAR(100),
    IN  pTel           VARCHAR(20),
    IN  pFichaMedica   BIT,
    IN  pTipo          VARCHAR(20),   -- "Socio" / "NoSocio" 
    OUT rta            INT
)
BEGIN
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        SET rta = -1;
    END;

    UPDATE persona
       SET nombre        = pNombre,
           apellido      = pApellido,
           tipoDocumento = pTipoDocumento,
           documento     = pDocumento,
           email         = pEmail,
           tel           = pTel,
           fichaMedica   = pFichaMedica
     WHERE codPersona    = pId;

    SET rta = ROW_COUNT();  -- 0=no cambió, 1=ok
END//
DELIMITER ;

-- === Descativar Persona ===
-- '0' = inactivo '1' = Activo

DELIMITER //
CREATE PROCEDURE desactivar_persona(
  IN  pId INT,
  OUT rta INT
)
BEGIN
  DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET rta=-1;

  UPDATE persona SET activo=0 WHERE codPersona=pId;
  SET rta = ROW_COUNT();

  -- si era socio, lo marcamos inactivo en tabla socio
  UPDATE socio SET estado=0 WHERE codPersona=pId;
END //
DELIMITER ;

-- === Obtener Persona ===
DELIMITER //
CREATE PROCEDURE obtener_persona(IN pId INT)
BEGIN
  SELECT codPersona, nombre, apellido, tipoDocumento, documento,
         email, tel, fichaMedica
  FROM persona
  WHERE codPersona=pId;
END //
DELIMITER ;

-- =========== LISTAR VENCIMIENTOS DE HOY ============== --
-- lista cuotas con vencimiento anterior o igual a la fecha pasada por parámetro, junto a información de contacto del socio.

DELIMITER //
CREATE PROCEDURE listar_vencimientos(IN fecha DATE)
BEGIN 
SELECT c.codCuota, c.fechaVencimiento, monto, c.codSocio, nombre, apellido, documento, email, tel 
FROM persona p 
INNER JOIN socio s ON p.codPersona = s.codPersona
INNER JOIN cuota c ON s.codSocio = c.codSocio
WHERE fechaVencimiento <= fecha 
AND 
c.estado = 'Pendiente'
ORDER BY c.fechaVencimiento;
END
//
DELIMITER ;

-- DROP PROCEDURE  listar_vencimientos;




CREATE TABLE IF NOT EXISTS actividad (
    codActividad INT AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(100),
    costo DECIMAL(10,2) NOT NULL,
    CONSTRAINT pk_actividad PRIMARY KEY (codActividad)
);

CREATE TABLE IF NOT EXISTS pago_eventual (
    id_pago_eventual INT AUTO_INCREMENT,
    id_no_socio INT NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    CONSTRAINT pk_pago_eventual PRIMARY KEY (id_pago_eventual),
    CONSTRAINT fk_pago_eventual_no_socio FOREIGN KEY (id_no_socio) REFERENCES no_socio(codNoSocio)
);



-- Carga inicial de actividades típicas de un club deportivo
INSERT INTO actividad (nombre, descripcion, costo) VALUES
('Fútbol', 'Entrenamientos y torneos de fútbol para todas las edades', 7500.00),
('Tenis', 'Clases y torneos en canchas de polvo de ladrillo o cemento', 8200.00),
('Natación', 'Escuela de natación y entrenamiento libre en piscina', 9800.00),
('Básquet', 'Entrenamientos y torneos recreativos y competitivos', 7100.00),
('Vóley', 'Entrenamientos mixtos y participación en ligas locales', 6900.00),
('Hockey', 'Hockey sobre césped y pista para distintas categorías', 8600.00),
('Gimnasia', 'Clases de gimnasia general y localizada', 6300.00),
('Yoga', 'Clases grupales de yoga y estiramiento', 5900.00),
('Pilates', 'Clases de pilates suelo y con implementos', 6200.00),
('Atletismo', 'Entrenamientos de carrera, salto y lanzamiento', 6500.00),
('Patín artístico', 'Escuela de patín artístico y entrenamiento libre', 7400.00),
('Artes marciales', 'Karate, Taekwondo y otras disciplinas', 8100.00),
('Spinning', 'Clases de ciclismo indoor', 7700.00),
('Zumba', 'Clases de baile fitness y ritmo latino', 6100.00),
('Ajedrez', 'Talleres y torneos de ajedrez recreativo', 5500.00),
('Boxeo', 'Entrenamientos y acondicionamiento físico', 8300.00),
('Funcional', 'Entrenamientos funcionales y de alta intensidad', 7200.00),
('Escuelita deportiva', 'Actividades recreativas para niños', 5800.00),
('Rugby', 'Entrenamientos y torneos de rugby amateur', 8700.00),
('Handball', 'Clases y torneos internos de handball', 7000.00);

-- Carga inicial de socios y no socios de prueba CORREGIDA
INSERT INTO persona (nombre, apellido, documento, email, tel, tipoDocumento, fichaMedica) VALUES 
('Juan', 'Pérez', '30123456', 'juan.perez@email.com', '1156789012', 'DNI', TRUE),
('María', 'Gómez', '28987654', 'maria.gomez@email.com', '1154321098', 'DNI', TRUE),
('Carlos', 'López', '35234567', 'carlos.lopez@email.com', '1167890123', 'DNI', TRUE),
('Ana', 'Martínez', '27456789', 'ana.martinez@email.com', '1145678901', 'DNI', TRUE),
('Roberto', 'Díaz', '33456789', 'roberto.diaz@email.com', '1178901234', 'DNI', TRUE);

-- Insertar socios (asumiendo que las personas se insertaron con IDs 1-5)
INSERT INTO socio (codPersona, estado) VALUES 
(1, 1),
(2, 1), 
(3, 1),
(4, 1),
(5, 1);

-- Carga inicial de cuotas para socios con las fechas modificadas
INSERT INTO cuota (codSocio, fechaVencimiento, monto, fechaPago, estado) VALUES 
(1, '2025-11-13', 25000.00, '2025-11-13', 'Pagada'),
(1, '2025-12-13', 25000.00, NULL, 'Pendiente'),
(2, '2025-11-13', 25000.00, NULL, 'Pendiente'),
(3, '2025-11-13', 25000.00, NULL, 'Pendiente'),
(4, '2025-11-13', 25000.00, '2025-11-13', 'Pagada'),
(4, '2025-12-13', 25000.00, NULL, 'Pendiente'),
(5, '2025-11-14', 25000.00, NULL, 'Pendiente');





INSERT INTO persona (nombre, apellido, documento, email, tel, tipoDocumento, fichaMedica) VALUES 
('Laura', 'Fernández', '28765432', 'laura.fernandez@email.com', '1156789432', 'DNI', FALSE),
('Diego', 'Rodríguez', '36543210', 'diego.rodriguez@email.com', '1165432189', 'DNI', TRUE),
('Sofía', 'Hernández', '29876543', 'sofia.hernandez@email.com', '1143218765', 'DNI', FALSE);

-- Insertar no socios (asumiendo que las personas se insertaron con IDs 6-8)
INSERT INTO no_socio (codPersona) VALUES 
(6),
(7),
(8);

-- Datos de carga inicial para pago_eventual
INSERT INTO pago_eventual (id_no_socio, monto, fecha) VALUES 
(1, 7500.00, '2024-12-01'),
(2, 8200.00, '2024-12-02'),
(3, 9800.00, '2024-12-03');