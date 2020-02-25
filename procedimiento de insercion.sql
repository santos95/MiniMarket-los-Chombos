Use dbventasProyectTer
Go

----------------------------------------------------------------------------------------------------------
Create procedure Insertar_cargo
(
@nombre_cargo varchar(50),
@descripcion_cargo varchar(50),
@observacion varchar(500),
@estado char(1)
)
As
Insert into tbl_cargo values (@nombre_cargo,@descripcion_cargo, @observacion, getdate(), @estado)
Go


------------------------------------------------------------------------------------------------------------
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

--PROCEDIMIENTO DE CATEGORIA 
--procedimiento mostrar
create proc spmostrar_categoria
as
select top 200 * from tbl_categoria
order by id_categoria desc 
go
--procedimiento buscar Nombre 
create proc spbuscar_categoria 
@textobuscar varchar(50)
as 
select * from tbl_categoria
where nombrecat like @textobuscar + '%'
go

--procedimiento insertar 
create proc spinsertar_categoria 
@id_categoria int output, 
@nombrecat varchar(50),
@observacion varchar (256),
@fecharegistro date
as 
insert into tbl_categoria(nombrecat,observacion,fecharegistro)
values(@nombrecat,@observacion,@fecharegistro)
go

--procedimiento editar
create proc speditar_categoria
@id_categoria int output, 
@nombrecat varchar(50),
@observacion varchar (256),
@fecharegistro date
as 
update tbl_categoria set nombrecat=@nombrecat,
observacion=@observacion,fecharegistro=@fecharegistro
where id_categoria=@id_categoria
go


--PROCEDIMIENTO DE PRESENTACIONES

--procedimiento mostrar
create proc spmostrar_presentacion
as 
select top 200 * from tbl_presentacion
order by id_presentacion desc 
go
--procedimineto buscar 
create proc spbuscar_presentacion_nombre
@textobuscar varchar(50)
as 
select * from tbl_presentacion
where nombre like @textobuscar + '%'
go
--procedimineto insertar 
create proc spinsertar_presentacion 
@id_presentacion int output,
@nombre varchar (50),
@descripcion varchar(256),
@fecharegistro date
as 
insert into tbl_presentacion(nombre,descripcion,fecharegistro)
values  (@nombre,@descripcion,@fecharegistro)
go
--procedimiento editar 
create proc speditar_presentacion
@id_presentacion int,
@nombre varchar (50),
@descripcion varchar(256),
@fecharegistro date 
as 
update tbl_presentacion set nombre = @nombre, descripcion = @descripcion,fecharegistro=@fecharegistro
where id_presentacion = @id_presentacion
go

--PROCEDIMINETO DE ARTICULO

--procedimineto mostrar 
create proc spmostrar_articulo
as
SELECT top 100 cat_articulo.cod_articulo, cat_articulo.nombre, cat_articulo.descripcion, cat_articulo.imagen,
 cat_articulo.categoria_articulo, 
tbl_categoria.nombrecat,cat_articulo.cod_presentacion, 
tbl_presentacion.nombre AS Presentacion
FROM cat_articulo INNER JOIN
tbl_categoria ON cat_articulo.categoria_articulo = tbl_categoria.id_categoria INNER JOIN
tbl_presentacion ON cat_articulo.cod_presentacion = tbl_presentacion.id_presentacion
order by cat_articulo.cod_articulo desc
go
--procedimineto buscar
create proc spbuscar_articulo_nombre
@textobuscar varchar(50)
as
SELECT cat_articulo.cod_articulo, cat_articulo.nombre, cat_articulo.descripcion, cat_articulo.imagen,
 cat_articulo.categoria_articulo, 
tbl_categoria.nombrecat,cat_articulo.cod_presentacion, 
tbl_presentacion.nombre AS Presentacion
FROM cat_articulo INNER JOIN
tbl_categoria ON cat_articulo.categoria_articulo = tbl_categoria.id_categoria INNER JOIN
tbl_presentacion ON cat_articulo.cod_presentacion = tbl_presentacion.id_presentacion
where cat_articulo.nombre like  @textobuscar + '%'
order by cat_articulo.cod_articulo desc
go

--procedimineto insertar
create proc spinsertar_articulo
@cod_articulo int output,
@nombre varchar (50),
@descripcion varchar(1024),
@imagen image,
@categoria_articulo int,
@cod_presentacion int
as
insert into cat_articulo (nombre,descripcion,imagen,categoria_articulo,cod_presentacion)
values (@nombre,@descripcion,@imagen,@categoria_articulo,@cod_presentacion)
go
--procedimineto editar 
create proc speditar_articulo
@cod_articulo int,
@nombre varchar (50),
@descripcion varchar(1024),
@imagen image,
@categoria_articulo int,
@cod_presentacion int
as update  cat_articulo set nombre=@nombre,descripcion=@descripcion,imagen=@imagen,
categoria_articulo=@categoria_articulo,cod_presentacion=@cod_presentacion
where cod_articulo=@cod_articulo
go
--procedimineto eliminar 
create proc speliminar_articulo
@cod_articulo int 
as 
delete from cat_articulo
where cod_articulo=@cod_articulo
go

--insertar proveedor
create procedure spinsertar_per
(
@cedula_ruc varchar(50),
@nombre varchar(50),
@apellido_sucursal varchar(50),
@fechanac_fechaconstitucion varchar(50),
@telefono int,
@correo varchar(30),
@direccion varchar(250)
)
as
insert into cat_persona values(@cedula_ruc,@nombre,@apellido_sucursal,@fechanac_fechaconstitucion,@telefono,@correo,@direccion)
go

--Insertar Proveedor

Create procedure insert_proveedor
(
@persona int,
@politica_venta varchar (3),
@observacion varchar(200),
@estado char(1)
)
as
insert into cat_proveedor values(@persona,@politica_venta,@observacion,getdate(),@estado)
go

--Consulta

Create procedure query_persona
as
select * from cat_persona
Go