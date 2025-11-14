CREATE TABLE IF NOT EXISTS usuario(
CodUsu int auto_increment,
NombreUsu varchar (20),
PassUsu varchar (15),
Activo boolean default true,
constraint pk_usuario primary key (CodUsu)
);

insert into usuario(CodUsu,NombreUsu,PassUsu) values
(26,'admin','123456');