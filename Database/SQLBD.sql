create database visortickets2025;
go
use visortickets2025;

create table Roles (
	ro_identificador int primary key identity(1,1),
	ro_descripcion varchar(125) not null, 

	ro_fecha_adicion datetime not null, 
	ro_adicionado_por varchar(125) not null, 
	ro_fecha_modificacion datetime, 
	ro_modificado_por varchar(125), 
);

insert into Roles values( 'Soporte', GETDATE(), 'admin', null,null);
insert into Roles values( 'Analista', GETDATE(), 'admin', null,null);

select * from Roles;

create table Usuarios (
    us_identificador int primary key identity(1,1),
	us_correo varchar(125) not null, 
	us_clave varchar(255) not null, 
	us_nombre_completo varchar(255) not null, 
	us_ro_identificador int foreign key (us_ro_identificador) references Roles (ro_identificador) not null,
	us_estado varchar(1) not null, 

	us_fecha_adicion datetime not null, 
	us_adicionado_por varchar(125) not null, 
	us_fecha_modificacion datetime, 
	us_modificado_por varchar(125), 
);
insert into Usuarios 
values ('kbrenesc@gmail.com', '123', 'Karla Brenes Campos', 1, 'A',  GETDATE(),'admin', null, null);

insert into Usuarios 
values ('jcarlos@gmail.com', '123', 'Juan Arroyo', 1, 'A',  GETDATE(),'admin', null, null);

insert into Usuarios 
values ('palvarado@gmail.com', '123', 'Paola Alvarado', 2, 'A',  GETDATE(),'admin', null, null);

select * from Usuarios;

SELECT
  r.ro_descripcion,
  u.*
FROM
  Usuarios u,
  Roles r
WHERE
  u.us_ro_identificador = r.ro_identificador;

create table Categorias (
	ca_identificador int primary key identity(1,1),
	ca_descripcion varchar(125) not null, 
	ca_estado varchar(1) not null check (ca_estado in ('A', 'I')), 
	ca_fecha_adicion datetime not null, 
	ca_adicionado_por varchar(125) not null, 
	ca_fecha_modificacion datetime, 
	ca_modificado_por varchar(125), 
);

insert into Categorias values('Software', 'A', GETDATE(),'admin', null, null);
insert into Categorias values('Hardare', 'A', GETDATE(),'admin', null, null);
insert into Categorias values('Red', 'A', GETDATE(),'admin', null, null);

select * from Categorias;

create table Urgencias (
	ur_identificador int primary key identity(1,1),
	ur_descripcion varchar(125) not null, 
	ur_estado varchar(1) not null check (ur_estado in ('A', 'I')), 
	ur_fecha_adicion datetime not null, 
	ur_adicionado_por varchar(125) not null, 
	ur_fecha_modificacion datetime, 
	ur_modificado_por varchar(125), 
);

insert into Urgencias values('Baja', 'A', GETDATE(),'admin', null, null);
insert into Urgencias values('Media', 'A', GETDATE(),'admin', null, null);
insert into Urgencias values('Alta', 'A', GETDATE(),'admin', null, null);

select * from Urgencias;
 
create table Importancias (
	im_identificador int primary key identity(1,1),
	im_descripcion varchar(125) not null, 
	im_estado varchar(1) not null check (im_estado in ('A', 'I')), 
	im_fecha_adicion datetime not null, 
	im_adicionado_por varchar(125) not null, 
	im_fecha_modificacion datetime, 
	im_modificado_por varchar(125), 
);

insert into Importancias values('Baja', 'A', GETDATE(),'admin', null, null);
insert into Importancias values('Media', 'A', GETDATE(),'admin', null, null);
insert into Importancias values('Alta', 'A', GETDATE(),'admin', null, null);

select * from Importancias;
 

create table Tiquetes (
    ti_identificador int primary key identity(1,1),
	ti_asunto varchar(125) not null, 
	ti_detalle_caso varchar(255) not null, 
	ti_ca_identificador int foreign key (ti_ca_identificador) references Categorias (ca_identificador) not null,
	ti_ur_identificador int foreign key (ti_ur_identificador) references Urgencias (ur_identificador) not null,
	ti_im_identificador int foreign key (ti_im_identificador) references Importancias (im_identificador) not null,
	ti_us_identificador int foreign key (ti_us_identificador) references Usuarios (us_identificador) not null,
	ti_solucion varchar(255), 
	ti_estado varchar(1) not null check (ti_estado in ('A', 'I')),	
    ti_fecha_adicion datetime not null, 
	ti_adicionado_por varchar(125) not null, 
	ti_fecha_modificacion datetime, 
	ti_modificado_por varchar(125), 
);

insert into Tiquetes values ('Fallo en red', 'Compa�ero reporta que no logra conectarse a la red', 4, 3, 1, 2,null, 'A', GETDATE(), 'admin',null, null);

select *from Tiquetes;

SELECT
  i.im_descripcion 'Importancia',
  u.ur_descripcion 'Urgencia',
  c.ca_descripcion 'Categoria',
  s.us_nombre_completo,
  t.ti_asunto 'Asunto'
FROM
  Tiquetes t,
  Categorias c,
  Urgencias u,
  Importancias i,
  Usuarios s
WHERE
      t.ti_ca_identificador = c.ca_identificador
  AND t.ti_im_identificador = i.im_identificador
  AND t.ti_ur_identificador = u.ur_identificador
  AND t.ti_us_identificador = s.us_identificador;