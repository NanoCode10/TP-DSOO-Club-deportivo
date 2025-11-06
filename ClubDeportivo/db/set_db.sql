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
END //



-- Lista todos las personas por tipo
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

