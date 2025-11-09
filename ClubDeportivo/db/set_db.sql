drop database if exists clubdeportivoAACMP;
create database clubdeportivoAACMP; 
use clubDeportivoAACMP;

CREATE TABLE IF NOT EXISTS persona (
    codPersona INT AUTO_INCREMENT,
    nombre VARCHAR(20),
    apellido VARCHAR(20),
    documento VARCHAR(20),
    email VARCHAR(20),
    tel VARCHAR(20),
    tipoDocumento VARCHAR(20),
    fichaMedica BOOLEAN,
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
    INSERT INTO cuota (codSocio, fechaVencimiento, monto, fechaPago)
    VALUES (pIdSocio, pFechaVencimiento, pMonto, pFechaPago);

     IF pFechaPago IS NOT NULL THEN
        UPDATE socio 
        SET estado = 1
        WHERE codSocio = pIdSocio;
    END IF;
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE pagar_cuota(
    IN pIdSocio INT,
    IN pFechaPago DATE
)
BEGIN
    DECLARE vFechaVencimiento DATE;
    DECLARE vDiasAtraso INT;
    DECLARE vMonto DECIMAL(10,2);

    -- Obtener la última cuota del socio
    SELECT fechaVencimiento
    INTO vFechaVencimiento
    FROM cuota
    WHERE codSocio = pIdSocio
    ORDER BY fechaVencimiento DESC
    LIMIT 1;

    -- Calcular los días de atraso (si los hay)
    SET vDiasAtraso = DATEDIFF(pFechaPago, vFechaVencimiento);

    -- Si el socio pagó después del vencimiento
    IF vDiasAtraso > 0 THEN
        -- Registrar el pago con fecha de pago
        UPDATE cuota
        SET fechaPago = pFechaPago,
            estado = 'Pagada'
        WHERE codSocio = pIdSocio
          AND estado = 'Pendiente';

        -- Crear nueva cuota con vencimiento desde el día siguiente
        SELECT monto INTO vMonto FROM cuota WHERE codSocio = pIdSocio ORDER BY codCuota DESC LIMIT 1;
        INSERT INTO cuota (codSocio, fechaVencimiento, monto, estado)
        VALUES (
            pIdSocio,
            DATE_ADD(vFechaVencimiento, INTERVAL 1 MONTH), -- nuevo periodo
            vMonto,
            'Pendiente'
        );

        -- Activar nuevamente al socio
        UPDATE socio
        SET estado = 1
        WHERE codSocio = pIdSocio;

    ELSE
        -- Si paga dentro del vencimiento, solo se marca como pagada
        UPDATE cuota
        SET fechaPago = pFechaPago,
            estado = 'Pagada'
        WHERE codSocio = pIdSocio
          AND estado = 'Pendiente';

        UPDATE socio
        SET estado = 1
        WHERE codSocio = pIdSocio;
    END IF;
END //
DELIMITER ;
-- fin procedure cuota



-- Lista todos las personas por tipo
DELIMITER // 
CREATE PROCEDURE listar_personas_por_tipo(
    IN pTipo VARCHAR(20)
)
BEGIN
    IF pTipo = 'Socio' THEN
        SELECT 
            s.codSocio,
            p.codPersona,
            p.nombre,
            p.apellido,
            p.email,
            p.tel,
            p.tipoDocumento,
            p.documento,
            CASE WHEN p.fichaMedica = 1 THEN 'Sí' ELSE 'No' END AS AptoFisico,
            s.estado AS EstadoSocio,
            c.fechaVencimiento,
            c.estado AS EstadoCuota
        FROM socio s
        INNER JOIN persona p ON p.codPersona = s.codPersona
        LEFT JOIN (
            SELECT codSocio, fechaVencimiento, estado
            FROM cuota
            WHERE (codSocio, fechaVencimiento) IN (
                SELECT codSocio, MAX(fechaVencimiento)
                FROM cuota
                GROUP BY codSocio
            )
        ) c ON c.codSocio = s.codSocio
        ORDER BY s.codSocio ASC;

    ELSEIF pTipo = 'NoSocio' THEN
        SELECT 
            n.codNoSocio,
            p.codPersona,
            p.nombre,
            p.apellido,
            p.email,
            p.tel,
            p.tipoDocumento,
            p.documento,
            CASE WHEN p.fichaMedica = 1 THEN 'Sí' ELSE 'No' END AS AptoFisico
        FROM no_socio n
        INNER JOIN persona p ON p.codPersona = n.codPersona
        ORDER BY n.codNoSocio ASC;

    ELSE
        SELECT 'Tipo no válido. Usar "Socio" o "NoSocio".' AS Mensaje;
    END IF;
END //
DELIMITER ; 

-- === ACTUALIZAR ===
DELIMITER $$
CREATE PROCEDURE actualizar_persona(
    IN  pId            INT,
    IN  pNombre        VARCHAR(20),
    IN  pApellido      VARCHAR(20),
    IN  pTipoDocumento VARCHAR(20),
    IN  pDocumento     VARCHAR(20),
    IN  pEmail         VARCHAR(100),
    IN  pTel           VARCHAR(20),
    IN  pFichaMedica   BIT,
    IN  pTipo          VARCHAR(20),   -- "Socio" / "NoSocio" (por si querés usarlo luego)
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
END$$
DELIMITER ;

-- === ELIMINAR ===
DELIMITER $$
CREATE PROCEDURE eliminar_persona(
    IN  pId  INT,
    OUT rta  INT
)
BEGIN
  -- atrapamos el error específico
    DECLARE CONTINUE HANDLER FOR 1451
    BEGIN
        SET rta = -1451;   
    END;

    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        SET rta = -1;
    END;

    DELETE FROM persona WHERE codPersona = pId;
    SET rta = ROW_COUNT();
END$$
DELIMITER ;

-- =========== LISTAR VENCIMIENTOS DE HOY ============== --
-- lista cuotas que vencen en un la fecha pasada por parámetro, junto a información de contacto del socio.
-- si hay que modificar la lógica se hace y ya.
DELIMITER //
CREATE PROCEDURE listar_vencimientos(IN fecha DATE)
BEGIN 
SELECT c.codCuota, monto, c.codSocio, nombre, apellido, documento, email, tel 
FROM persona p 
INNER JOIN socio s ON p.codPersona = s.codPersona
INNER JOIN cuota c ON s.codSocio = c.codSocio
WHERE fechaVencimiento = fecha 
AND 
c.estado = 'Pendiente'
ORDER BY apellido;
END
//
DELIMITER ;


-- PROBLEMAS: 
-- no genera cuotas si paga en tiempo y forma
-- si no enetendí mal el código, y por como parece comportarse al probarlo, si paga atrasado, genera las cuotas para que venzan en en mes siguiente del vencimiento de la cuota morosa mas vieja
-- o sea, si su última cuota es de mayo, por ejemplo, y el socio paga la deuda en noviembre, la proxima cuota se genera para vencer en junio.

-- en la consigna no aclaraba que tiene que resetearse la fecha de vencimiento si paga moroso? (o sea, 30 dias luego del dia de regularización?)
-- adnuve repasando el codigo con una ia, me tiró también que el ORDER BY idCuota en el INSERT de pagar_cuota, y al probar el procedure, tiera error... (ARREGLADO)
-- también mencionó que el subquery en ese mismo inseret es supuestamente innecesario. y me tira error de que no se puede usar la misma tabla cuota en el subquery y en el update, 
-- capaz si se guarda el valor de monto en una variable antes del update sirva (ARREGLADO)
DROP PROCEDURE pagar_cuota;


CREATE TABLE IF NOT EXISTS actividad (
    codActividad INT AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(100),
    CONSTRAINT pk_actividad PRIMARY KEY (codActividad)
);

-- Carga inicial de actividades típicas de un club deportivo
INSERT INTO actividad (nombre, descripcion) VALUES
('Fútbol', 'Entrenamientos y torneos de fútbol para todas las edades'),
('Tenis', 'Clases y torneos en canchas de polvo de ladrillo o cemento'),
('Natación', 'Escuela de natación y entrenamiento libre en piscina'),
('Básquet', 'Entrenamientos y torneos recreativos y competitivos'),
('Vóley', 'Entrenamientos mixtos y participación en ligas locales'),
('Hockey', 'Hockey sobre césped y pista para distintas categorías'),
('Gimnasia', 'Clases de gimnasia general y localizada'),
('Yoga', 'Clases grupales de yoga y estiramiento'),
('Pilates', 'Clases de pilates suelo y con implementos'),
('Atletismo', 'Entrenamientos de carrera, salto y lanzamiento'),
('Patín artístico', 'Escuela de patín artístico y entrenamiento libre'),
('Artes marciales', 'Karate, Taekwondo y otras disciplinas'),
('Spinning', 'Clases de ciclismo indoor'),
('Zumba', 'Clases de baile fitness y ritmo latino'),
('Ajedrez', 'Talleres y torneos de ajedrez recreativo'),
('Boxeo', 'Entrenamientos y acondicionamiento físico'),
('Funcional', 'Entrenamientos funcionales y de alta intensidad'),
('Escuelita deportiva', 'Actividades recreativas para niños'),
('Rugby', 'Entrenamientos y torneos de rugby amateur'),
('Handball', 'Clases y torneos internos de handball');