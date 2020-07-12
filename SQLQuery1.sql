
select * from Usuarios;

create table Perfiles_Tabla(
	id int not null identity(1,1),
	perfil varchar(40) not null primary key
)

create table Usuarios_Tabla(
	id int,
	cedula varchar(20) not null primary key,
	nombres varchar(40) not null,
	apellidos varchar(40) not null,
	perfil varchar(40) not null,
	correo varchar(60),
	celular varchar(20),
	creacion DATETIME,
	constraint fk_Usuarios_Tabla foreign key (perfil) references Perfiles_Tabla(perfil)
);

/* Leer - Read*/ 
select * from Perfiles_Tabla;

/* Escribir - Create*/ 
INSERT INTO Perfiles_Tabla (perfil)
VALUES ('Visitante');

/* Eliminar - Delete*/ 
delete Perfiles_Tabla where perfil = 'Visitante'

/* Actualizar - Update*/ 
update Perfiles_Tabla set perfil = 'Desa' where id = '3';

/* Leer - Read*/ 
select * from Usuarios_Tabla where cedula = '1090493157';

/* Escribir - Create*/ 
INSERT INTO Usuarios_Tabla (cedula, nombres, apellidos, perfil, correo, celular)
VALUES ('10904956451', 'Yorman', 'Mendoza', 'Consultor', 'yorman@hotmail.com', '32023132132');

Update Usuarios_Tabla set cedula = '999999999' where nombres = 'mente';

select * from Usuarios_Tabla;