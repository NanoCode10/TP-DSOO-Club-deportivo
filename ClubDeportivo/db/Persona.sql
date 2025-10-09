
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



