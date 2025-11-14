drop database if exists clubDeportivoAACMP;
create database clubDeportivoAACMP; 
use clubDeportivoAACMP;

CREATE TABLE IF NOT EXISTS persona (
    codPersona INT AUTO_INCREMENT,
    nombre VARCHAR(20),
    apellido VARCHAR(20),
    documento VARCHAR(20),
    tipoDocumento VARCHAR(20),
    fichaMedica BOOLEAN,
    CONSTRAINT pk_persona PRIMARY KEY (codPersona)
);


CREATE TABLE IF NOT EXISTS socio (
    codSocio INT AUTO_INCREMENT,
    codPersona INT,
    CONSTRAINT pk_socio PRIMARY KEY (codSocio),
    CONSTRAINT fk_persona_socio FOREIGN KEY (codPersona) REFERENCES persona(codPersona)
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

delimiter //  
create procedure IngresoLogin(in Usu varchar(20),in Pass varchar(15))

begin
   select CodUsu
	from usuario
		where NombreUsu = Usu and PassUsu = Pass 
			and Activo = 1; 
end 
//

delimiter ;

DELIMITER //

CREATE PROCEDURE crear_socio(
    IN pNombre VARCHAR(50),
    IN pApellido VARCHAR(50),
    IN pDocumento VARCHAR(20),
    IN pTipoDocumento VARCHAR(20),
    IN pFichaMedica BOOLEAN,
    OUT rta INT
)
BEGIN
    DECLARE vCodPersona INT;
    DECLARE vCodSocio INT;

    -- Inicializar variable
    SET vCodSocio = NULL;

    -- Verificar si ya existe el socio
    SELECT s.codSocio INTO vCodSocio
    FROM socio s
    JOIN persona p ON p.codPersona = s.codPersona
    WHERE p.tipoDocumento = pTipoDocumento AND p.documento = pDocumento
    LIMIT 1;

    IF vCodSocio IS NULL THEN
        -- Insertar persona
        INSERT INTO persona(nombre, apellido, documento, tipoDocumento, fichaMedica)
        VALUES (pNombre, pApellido, pDocumento, pTipoDocumento, pFichaMedica);

        SET vCodPersona = LAST_INSERT_ID();

        -- Insertar socio
        INSERT INTO socio(codPersona)
        VALUES (vCodPersona);

        SET rta = LAST_INSERT_ID(); -- ID del nuevo socio
    ELSE
        SET rta = 0; -- Indica que el socio ya existe
    END IF;

END //



DELIMITER ;