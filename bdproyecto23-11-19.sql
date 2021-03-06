USE MASTER
GO

DROP DATABASE dbventasProyectTer
GO
USE dbventasProyectTer
GO

CREATE TABLE cat_persona
(
cod_persona int primary key,
cedula_ruc varchar(50) not null,
nombre varchar(50) not null,
apellido_sucursal varchar(50) not null,---en dado caso sea empresa se pide en donde esta ubicado.
fechanac_fechaconstitucion varchar(50) null,
telefono int null,
correo varchar(30) null,
direccion varchar(250) null
)
GO
select * from cat_persona

insert into cat_persona (cod_persona, cedula_ruc, nombre, apellido_sucursal, telefono, correo, direccion) values('1','001-230495-0010N','Santos Alberto','Ortiz Chávez',22554422,'santos95ortiz@gmail.com','La concha de la lora, 2c al norte, 2 al sur.');

CREATE TABLE tbl_cargo
(
id_cargo int identity(1,1) primary key,
nombre_cargo varchar(50) not null,
descripcion_cargo varchar(50) not null,
observacion varchar(500) null,
fecharegistro date default getdate(),
estado char(1)check (estado in ('A','I'))not null
)
GO

insert into tbl_cargo values ('IT','Cargo con amplios conocimientos en ITs','Cargo para la gestión y admiinstración de ITs',GETDATE(),'A');
insert into tbl_cargo values ('Vendedor','Rol de gestión de ventas.','Encargado de llevar a cabo el proceso de venta de los artículos',GETDATE(),'A');

CREATE TABLE cat_trabajador
(
cod_trabajador int PRIMARY KEY NOT NULL,
persona int not null,
genero char(1) check (genero in ('M','F'))not null,
inss varchar(50) null,
estadocivil char(1) check (estadocivil in ('S','C','D','J'))not null,
razon_contratacion  varchar(50) null,---temporal, tiempo indefinido, fijo.
estado char(1)check (estado in ('A','I'))not null---agregar al programa
CONSTRAINT FK_persona FOREIGN KEY (persona) REFERENCES cat_persona (cod_persona)
)
GO

select * from cat_trabajador JOIN cat_persona ON cat_trabajador.persona = cat_persona.cod_persona;

insert into cat_trabajador values(1,1,'M','1','S','Tiempo Indefinido','A')
insert into cat_trabajador values(2,'M','1','S','Tiempo Indefinido','A')  

CREATE TABLE tbl_detallecargoasignado
(
id_detallec int IDENTITY(1,1) PRIMARY KEY NOT NULL,
trabajador int not null,
cargo int not null,
autorizado varchar(50) not null,
ingresado varchar(50) not null,
fechaasign date default getdate(),
CONSTRAINT FK_trabajador FOREIGN KEY (trabajador) REFERENCES cat_trabajador (cod_trabajador),
CONSTRAINT FK_cargo FOREIGN KEY (cargo) REFERENCES tbl_cargo (id_cargo)
)
GO

insert into tbl_detallecargoasignado values(1,'1','Jorge','Kevin',GETDATE()) 
insert into tbl_detallecargoasignado values(2,'1','ella','nel perro',GETDATE()) 

select * from tbl_detallecargoasignado join cat_trabajador on trabajador = cod_trabajador join cat_persona on cod_persona = persona;

CREATE TABLE cat_sucursal
(
cod_ int PRIMARY KEY NOT NULL,
nombresucursal varchar(50) not null,
telefono int null,
direccion varchar(250) null,
observacion varchar(500) not null,
fecharegistro date default getdate(),
estado char(1)check (estado in ('A','I'))not null
)
GO

CREATE TABLE tbl_asignacionsucursal
(
id_asignacionsucursal int IDENTITY(1,1) NOT NULL,
trabajador int,
observacion varchar(200) not null,
fecharegistro date default getdate(),
CONSTRAINT FK_detalletrabajador FOREIGN KEY (trabajador) REFERENCES tbl_detallecargoasignado (id_detallec)
)
GO

CREATE TABLE tbl_categoria
(
id_categoria int IDENTITY(1,1)PRIMARY KEY NOT NULL,
nombrecat varchar(50) NOT NULL,
observacion varchar(256) NULL,
fecharegistro date default getdate()
)
GO

CREATE TABLE tbl_presentacion
(
id_presentacion int IDENTITY(1,1)PRIMARY KEY NOT NULL,
nombre varchar(50) NOT NULL,
descripcion varchar(256) NULL,
fecharegistro date default getdate()
)
GO

CREATE TABLE cat_proveedor
(
cod_proveedor int PRIMARY KEY NOT NULL,
persona int not null,
politica_venta varchar (3) check (politica_venta in ('Cred','Con'))not null,
observacion varchar(200) not null,
fecharegistro date default getdate(),
estado char(1)check (estado in ('A','I'))not null,
CONSTRAINT FK_persona1 FOREIGN KEY (persona) REFERENCES cat_persona (cod_persona)
)
GO

 ----Ac=activo o NA= no activo
----------------------------------------------------------------REVISAR ESTE CAMPO--------------------------------------------------------------------
CREATE TABLE cat_articulo
(
cod_articulo int PRIMARY KEY  NOT NULL,
categoria_articulo int NOT NULL,
nombre varchar(50) NOT NULL,
descripcion varchar(1024) NULL,
imagen image NULL,
cod_presentacion int NOT NULL,
CONSTRAINT FK_articulo_categoria2 FOREIGN KEY (categoria_articulo) REFERENCES tbl_categoria (id_categoria), 
CONSTRAINT FK_articulo_presentacion2 FOREIGN KEY (cod_presentacion) REFERENCES tbl_presentacion (id_presentacion) 
)
GO
-------punto 5
CREATE TABLE cat_cliente
(
cod_cliente int PRIMARY KEY NOT NULL,
persona int not null,
tipo_cliente char(1) check (tipo_cliente in ('J','N'))not null, --Juridico, Natural
genero char(1) check (genero in ('M','F','N'))not null, --Masculino , Femenino , Ninguno
estado char(1)check (estado in ('A','I'))not null,
CONSTRAINT FK_persona2 FOREIGN KEY (persona) REFERENCES cat_persona (cod_persona)
)
GO

-----------------punto 6
CREATE TABLE cat_compra
(
cod_compra int PRIMARY KEY NOT NULL,
cod_trabajador int NOT NULL,
cod_proveedor int NOT NULL,
tipo_compra char(4) check (tipo_compra in ('cred','cont','cons')) NOT NULL,-----credito, contado, consignacion.
subtotal float NOT NULL,
IVA float NOT NULL,
total float NOT NULL,
fecharegistro date default getdate(),
estado char(1)check (estado in ('A','I'))not null, --se controla si todo lo pedido fue recibido
CONSTRAINT FK_ingreso_proveedor FOREIGN KEY (cod_proveedor) REFERENCES cat_proveedor (cod_proveedor),
CONSTRAINT FK_ingreso_trabajador FOREIGN KEY (cod_trabajador) REFERENCES  cat_trabajador (cod_trabajador)
)
GO

CREATE TABLE tbl_detalle_compra
(
cod_detalle_compra int IDENTITY(1,1)PRIMARY KEY NOT NULL,
compra int NOT NULL,
articulo int NOT NULL,
cantidad int not null,
cantidad_rec int not null,
precio_compra int not null,
tasa_descuento varchar(20) not null,
descuento float not null,
monto float not null
CONSTRAINT FK_compra FOREIGN KEY (compra) REFERENCES cat_compra (cod_compra)
)
GO

CREATE TABLE tbl_estadocompra
(
id_estadocompra int identity(1,1) PRIMARY KEY,
detalle_compra int not null,
fecharegistro date default getdate(),
estado char(1) check (estado in ('P','R'))not null, --Pedido, Recibido
CONSTRAINT FK_detallecompra FOREIGN KEY (detalle_compra) REFERENCES tbl_detalle_compra (cod_detalle_compra)
)
GO

Create Table cat_cuentaxpagar
(
NumCuentaxPagar int PRIMARY KEY not null,
Compra int not null,
Monto float not null,
TipoPago nvarchar(50) not null, --Mensual, Quincenal
TasaInteres varchar(50) not null,
Prima float not null,
Cuotas_Pagar int  not null,
Total_Pagar float not null,
FechaInicio date default getdate()
CONSTRAINT FK_cuentacompra FOREIGN KEY (compra) REFERENCES cat_compra (cod_compra)
)
;

CREATE TABLE tbl_DetalleCuentaxPagar
(
id_detallecuentaxpagar int IDENTITY(1,1) primary key not null,
cuentaxpagar int not null,
ultimafechapago date not null,
proximafechapago date not null,
saldoinicial float not null,
montoproximo float not null,
cuotas_pagadas int not null,
cuotasrestantes int not null,
montopagototal float not null,
saldorestante float not null
CONSTRAINT FK_detallecuenta FOREIGN KEY (cuentaxpagar) REFERENCES cat_cuentaxpagar (NumCuentaxPagar)
)
;

CREATE TABLE tbl_estadocuenta
(
id_estadocuentaxpagar int IDENTITY(1,1) PRIMARY KEY not null,
detallecuenta int not null,
FechaInicio date default getdate() not null,
FechaCancelacion varchar(20) null,
EstadoCuenta varchar(10) not null  -- Pendiente, Pagada
CONSTRAINT FK_detallepagar FOREIGN KEY (detallecuenta) REFERENCES tbl_DetalleCuentaxPagar (id_detallecuentaxpagar)
)
;

Create table cat_venta
(
cod_venta int PRIMARY KEY NOT NULL,
cod_trabajador int NOT NULL,
forma_pago varchar(20) not null, -- pago x tarjeta o contado
cliente int NOT NULL,
subtotal float NOT NULL,
IVA float NOT NULL,
descuento float NOT NULL,
total float NOT NULL,
fecharegistro date default getdate(),
estado char(1)check (estado in ('A','I'))not null,
CONSTRAINT FK_venta_trabajador FOREIGN KEY (cod_trabajador) REFERENCES  cat_trabajador (cod_trabajador),
CONSTRAINT FK_venta_cliente FOREIGN KEY (cliente) REFERENCES cat_cliente (cod_cliente)
)
GO

CREATE TABLE tbl_detalle_venta
(
cod_detalle_venta int IDENTITY(1,1)PRIMARY KEY NOT NULL,
cod_venta int NOT NULL,
articulo int NOT NULL,
cantidad int NOT NULL,
precio_venta money NOT NULL,
descuento money NOT NULL,
CONSTRAINT FK_venta FOREIGN KEY (cod_venta) REFERENCES cat_venta (cod_venta),
CONSTRAINT FK_articulo FOREIGN KEY (articulo) REFERENCES cat_articulo (cod_articulo)
)
GO

CREATE TABLE tbl_inventario
(
id_inventario int IDENTITY(1,1) PRIMARY KEY,
articulo int not null,
existencia int not null,
disponibilidad int not null,
cantidadminima int not null,
cantidadmaxima int not null,
fecharegistro date default getdate(), 
estado char(1)check (estado in ('A','I'))not null,
CONSTRAINT FK_articuloinventario FOREIGN KEY (articulo) REFERENCES cat_articulo (cod_articulo)
)
GO

------------------------------------------Tablas de Seguridad------------------------------------------

CREATE TABLE tbl_rolacceso
(
id_rolacceso int identity(1,1) primary key,
tiporol varchar(50) not null,
fechaing date default getdate(),
estado char(1) check(Estado in ('A','I')) --Si el registro se mantiene A, I si no se mantiene
)
GO

select * from tbl_rolacceso

insert into tbl_rolacceso values('Administrador',GETDATE(),'A')
insert into tbl_rolacceso values('Vendedor',GETDATE(),'A')

-------------punto 10
CREATE TABLE cat_usuario
(
cod_usuario int primary key,
trabajadoremp int not null,
rolacceso int not null,
usuario varchar(100) unique not null,
pass  varchar(100) unique not null,
autorizado varchar(100) not null,
fechaing DATE DEFAULT GETDATE(),
estado char(1) check(Estado in ('A','I')), --Si el registro se mantiene A, I si no se mantiene
CONSTRAINT FK_empleado FOREIGN KEY (trabajadoremp) REFERENCES cat_trabajador (cod_trabajador),
CONSTRAINT FK_rolacceso FOREIGN KEY (rolacceso) REFERENCES tbl_rolacceso (id_rolacceso)
)
GO
select * from cat_usuario
select * from cat_trabajador
insert into cat_usuario values(1,1,1,'Administrador',1234,'Jorge',GETDATE(),'A')
insert into cat_usuario values(2,2,'Vendedor',12345,'papu',GETDATE(),'A')

----------------------punto 11
CREATE TABLE tbl_control_acceso
(
id_control_acceso int identity(1,1) primary key,
usuario int not null,
estadoacceso char(1) check (estadoacceso in ('c','d','b')) not null, --CONTROLA SI EL USUARIO ESTA CONECTADO, DESCONECTADO, BLOQUEADO
fecha_acceso date default getdate(),
hora_acceso time default getdate(),
FECHA_DESCONEXION DATETIME null,
hora_desconexion time null
)
GO

select * from tbl_control_acceso

insert into tbl_control_acceso values(1,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(2,'c',getdate(), getdate(),getdate(),getdate())
----------------------------------------------Control de funcionalidad al sistema-------------------------------------------------------------------
--------------------punto 12
CREATE TABLE cat_bitacora_acceso
(   
cod_bitacora int identity primary key,
usuario int not null,
fecha_conexion date default getdate(),
hora_conexion time default getdate(),
hora_desconexion time null, --este campo se llena con un procedimiento almacenado de actualizacion
ip_maquina varchar(50) not null,
actividad varchar(50) not null,
estado char(1) check(Estado in ('A','I')), --Controla si se lleva o no seguimiento a los registros de un usuario
CONSTRAINT FK_usuario FOREIGN KEY (usuario) REFERENCES cat_usuario (cod_usuario)
)
GO

create table fecha_vencimiento
(
cod_vencimiento int primary key not null,
fecha date,
cod_producto foreign key references tbl_producto(cod_producto)
)

CREATE TABLE tbl_detallebitacora
(   
id_detallebitacora int IDENTITY(1,1) primary key,
cod_bitacora int not null,
tablaafectada varchar(50) not null,
numcamposafectados int not null,
tipomovimiento varchar(50) null, --ingreso, actualizacion
horamovimiento time default getdate(),
registroanterior varchar(50) null,
registronuevo varchar(50) NOT NULL,
CONSTRAINT FK_bitacora1 FOREIGN KEY (cod_bitacora) REFERENCES cat_bitacora_acceso (cod_bitacora)
)
GO
create procedure accesologin
(
@usuario varchar(100),
@password varchar(100)
)
as
SELECT rolacceso,usuario,pass,cod_usuario  FROm cat_usuario where usuario = @usuario and pass = @password
GO

create procedure estadoconexion
(
@cod_usuario int
)
as
SELECT * FROM tbl_control_acceso where usuario = @cod_usuario
GO

 
