

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

DELIMITER //

-- Lista todos los socios (JOIN persona+socio)
CREATE PROCEDURE listar_socios()
BEGIN
    SELECT 
        s.codSocio        AS CodigoSocio,
        p.codPersona      AS CodigoPersona,
        p.nombre          AS Nombre,
        p.apellido        AS Apellido,
        p.tipoDocumento   AS TipoDocumento,
        p.documento       AS Documento,
        CASE WHEN p.fichaMedica = 1 THEN 'Sí' ELSE 'No' END AS AptoFisico
    FROM socio s
    INNER JOIN persona p ON p.codPersona = s.codPersona
    ORDER BY s.codSocio ASC;
END //

DELIMITER //