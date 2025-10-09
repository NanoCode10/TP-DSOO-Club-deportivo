

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
