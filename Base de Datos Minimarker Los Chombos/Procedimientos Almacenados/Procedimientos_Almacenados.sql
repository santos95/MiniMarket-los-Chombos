use dbventasProyectTer
GO

---Procedimientos de Logeo y control de acceso 

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
--------Procedimiento de persona
Create Proc Listadopersona
As Begin
	Select cod_persona,cedula_ruc,nombre,apellido_sucursal,fechanac_fechaconstitucion,telefono,correo,direccion
	From cat_persona
End
go


Create proc Registrarpersona
@cod_persona int,
@cedula_ruc varchar(50),
@nombre varchar(50),
@apellido_sucursal varchar(50),
@fechanac_fechaconstitucion varchar(50),
@telefono int,
@correo varchar(30),
@direccion varchar(250),
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_persona Where cod_persona=@cod_persona))
		Set @Mensaje='la persona ya se encuentra Registrado(a).'
	Else Begin
		Insert cat_persona Values(@cod_persona,@cedula_ruc,@nombre,@apellido_sucursal,@fechanac_fechaconstitucion,@telefono,@correo,@direccion)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarpersona
@cod_persona int,
@cedula_ruc varchar(50),
@nombre varchar(50),
@apellido_sucursal varchar(50),
@fechanac_fechaconstitucion varchar(50),
@telefono int,
@correo varchar(30),
@direccion varchar(250),
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_persona Where cod_persona=@cod_persona))
		Set @Mensaje='la persona no se encuentra Registrado(a).'
	Else Begin
		Update cat_persona Set cod_persona=@cod_persona Where nombre=@nombre
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarpersona
@Datos Varchar(50)
As Begin
	Select * From cat_persona Where nombre=@Datos
End
Go
--------Procedimiento de trabajador

Create Proc ListadoTrabajador
As Begin
	Select cod_trabajador,persona,genero,inss,estadocivil,razon_contratacion,estado 
	From cat_trabajador
End
go


Create proc RegistrarTrabajador
@cod_trabajador int,
@persona int,
@genero char(1),
@inss varchar(50),
@estadocivil char(1),
@razon_contratacion  varchar(50),
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_trabajador Where cod_trabajador=@cod_trabajador))
		Set @Mensaje='el empleado ya se encuentra Registrado(a).'
	Else Begin
		Insert cat_trabajador Values(@cod_trabajador,@persona,@genero,@inss,@estadocivil,@razon_contratacion,@estado)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizartrabajador
@cod_trabajador int,
@persona int,
@genero char(1),
@inss varchar(50),
@estadocivil char(1),
@razon_contratacion  varchar(50),
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_trabajador Where cod_trabajador=@cod_trabajador))
		Set @Mensaje='el empleado no se encuentra Registrado(a).'
	Else Begin
		Update cat_trabajador Set cod_trabajador=@cod_trabajador Where persona=@persona
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscartrabajador
@Datos Varchar(50)
As Begin
	Select * From cat_trabajador Where cod_trabajador=@Datos
End
Go
-------procedimiento de cargo
Create Proc Listarcargo
As Begin
	Select * From tbl_cargo
End
Go


Create proc Registrarcargo
@nombre_cargo varchar(50),
@descripcion_cargo varchar(50),
@observacion varchar(500),
@fecharegistro date,
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From tbl_cargo Where nombre_cargo=@nombre_cargo))
		Set @Mensaje='la presentacion ya se encuentra Registrada.'
	Else Begin
		Insert tbl_cargo Values(@nombre_cargo,@descripcion_cargo,@observacion,@fecharegistro,@estado)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarcargo
@nombre_cargo varchar(50),
@descripcion_cargo varchar(50),
@observacion varchar(500),
@fecharegistro date,
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From tbl_cargo Where nombre_cargo=@nombre_cargo))
		Set @Mensaje='la presentacion no se encuentra Registrada.'
	Else Begin
		Update tbl_cargo Set nombre_cargo=@nombre_cargo Where descripcion_cargo=@descripcion_cargo
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarcargo
@Datos Varchar(50)
As Begin
	Select * From tbl_cargo Where nombre_cargo=@Datos
End
Go




--------Procedimientos de presentacion

Create Proc ListarPrecentacion
As Begin
	Select * From Tbl_presentacion
End
Go


Create proc RegistrarPrecentacion
@id_Precentacion int,
@nombre varchar(50),
@descripcion varchar(256),
@fecharegistro date,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From Tbl_presentacion Where nombre=@nombre))
		Set @Mensaje='la presentacion ya se encuentra Registrada.'
	Else Begin
		Insert Tbl_presentacion Values(@nombre,@descripcion,@fecharegistro)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc ActualizarPrecentacion
@Num_Precentacion int,
@nombre varchar(50),
@descripcion varchar(256),
@fecharegistro date,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From Tbl_presentacion Where nombre=@nombre))
		Set @Mensaje='la presentacion no se encuentra Registrada.'
	Else Begin
		Update Tbl_presentacion Set nombre=@nombre Where descripcion=@descripcion
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc BuscarPrecentacion
@Datos Varchar(50)
As Begin
	Select * From Tbl_presentacion Where Descripcion=@Datos
End
Go


----------Procedimientos de categoria

Create Proc Listarcategoria
As Begin
	Select * From tbl_categoria
End
Go


Create proc Registrarcategoria
@id_categoria int,
@nombrecat varchar(50),
@observacion varchar(256),
@fecharegistro date,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From tbl_categoria Where nombrecat=@nombrecat))
		Set @Mensaje='Categoria ya se encuentra Registrada.'
	Else Begin
		Insert tbl_categoria Values(@nombrecat,@observacion,@fecharegistro)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarcategoria
@id_categoria int,
@nombrecat varchar(50),
@observacion varchar(256),
@fecharegistro date,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From tbl_categoria Where nombrecat=@nombrecat))
		Set @Mensaje='Categoria no se encuentra Registrada.'
	Else Begin
		Update tbl_categoria Set nombrecat=@nombrecat Where observacion=@observacion
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarcategoria
@Datos Varchar(50)
As Begin
	Select * From tbl_categoria Where nombrecat=@Datos
End
Go

---------Prosedimiento de proveedor

Create Proc Listarproveedor
As Begin
	Select * From cat_proveedor
End
Go


Create proc Registrarproveedor
@cod_proveedor int,
@persona int,
@politica_venta varchar(100),
@observacion varchar(100),
@fecharegistro date,
@estado char,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_proveedor Where persona=@persona))
		Set @Mensaje='el proveedor ya se encuentra Registrada.'
	Else Begin
		Insert cat_proveedor Values(@cod_proveedor,@persona,@politica_venta,@observacion,@fecharegistro,@estado)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarproveedor
@cod_proveedor int,
@persona int,
@politica_venta varchar(100),
@observacion varchar(100),
@fecharegistro date,
@estado char,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_proveedor Where persona=@persona))
		Set @Mensaje='el proveedor no se encuentra Registrada.'
	Else Begin
		Update cat_proveedor Set persona=@persona Where politica_venta=@politica_venta
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarproveedor
@Datos Varchar(50)
As Begin
	Select * From cat_proveedor Where cod_proveedor=@Datos
End
Go

----------procedimientos de articulos

Create Proc Listararticulos
As Begin
	Select * From cat_articulo
End
Go


Create proc Registrararticulos
@cod_articulo int,
@categoria_articulo int,
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@cod_presentacion int,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_articulo Where nombre=@nombre))
		Set @Mensaje='el artuculo ya se encuentra Registrada.'
	Else Begin
		Insert cat_articulo Values(@cod_articulo,@categoria_articulo,@nombre,@descripcion,@imagen,@cod_presentacion)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizararticulos
@cod_articulo int,
@categoria_articulo int,
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@cod_presentacion int,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_articulo Where nombre=@nombre))
		Set @Mensaje='el el articulo no se encuentra Registrada.'
	Else Begin
		Update cat_articulo Set nombre=@nombre Where descripcion=@descripcion
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscararticulo
@Datos Varchar(50)
As Begin
	Select * From cat_articulo Where nombre=@Datos
End
Go

----------Procedimientos de clientes 

Create Proc Listarclientes 
As Begin
	Select * From cat_cliente
End
Go


Create proc Registrarcliente
@cod_cliente int,
@persona int,
@tipo_cliente char(2),
@genero char(1),
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_cliente Where estado=@estado))
		Set @Mensaje='el cliente ya se encuentra Registrada.'
	Else Begin
		Insert cat_cliente Values(@cod_cliente,@persona,@tipo_cliente,@genero,@estado)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarcliente
@cod_cliente int,
@persona int,
@tipo_cliente char(2),
@genero char(1),
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_cliente Where cod_cliente=@cod_cliente))
		Set @Mensaje='el el articulo no se encuentra Registrada.'
	Else Begin
		Update cat_cliente Set persona=@persona Where estado=@estado
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarcliente
@Datos Varchar(50)
As Begin
	Select * From cat_cliente Where tipo_cliente=@Datos
End
Go

--------------procedimiento de detalle de cargo asignado

Create Proc ListarCargo_asignado 
As Begin
	Select * From tbl_detallecargoasignado
End
Go


Create proc Registrarcargo_asignado
@trabajador int,
@cargo int,
@autorizado varchar(50),
@ingresado varchar(50),
@fechaasign date,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From tbl_detallecargoasignado Where fechaasign=@fechaasign))
		Set @Mensaje='el cargo asignado se encuentra Registrado.'
	Else Begin
		Insert tbl_detallecargoasignado Values(@trabajador,@cargo,@autorizado,@ingresado,@fechaasign)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarcargo_asignado
@trabajador int,
@cargo int,
@autorizado varchar(50),
@ingresado varchar(50),
@fechaasign date,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From tbl_detallecargoasignado Where fechaasign=@fechaasign))
		Set @Mensaje='la fecha de asignacion no se encuentra Registrada.'
	Else Begin
		Update tbl_detallecargoasignado Set trabajador=@trabajador Where cargo=@cargo
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarcargo_asignado
@Datos Varchar(50)
As Begin
	Select * From tbl_detallecargoasignado Where fechaasign=@Datos
End
Go

-----------Procedimiento de compra 

Create Proc Listarcompra
As Begin
	Select * From cat_compra
End
Go


Create proc Registrarcompra
@cod_compra int,
@cod_trabajador int,
@cod_proveedor int,
@tipo_compra char(4),
@subtotal float,
@IVA float,
@total float,
@fecharegistro date,
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From cat_compra Where cod_compra=@cod_compra))
		Set @Mensaje='la compra se encuentra Registrado.'
	Else Begin
		Insert cat_compra Values(@cod_compra,@cod_trabajador,@cod_proveedor,@tipo_compra,@subtotal,@IVA,@total,@fecharegistro,@estado)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizarcompra
@cod_compra int,
@cod_trabajador int,
@cod_proveedor int,
@tipo_compra char(4),
@subtotal float,
@IVA float,
@total float,
@fecharegistro date,
@estado char(1),
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From cat_compra Where cod_compra=@cod_compra))
		Set @Mensaje='la compra no se encuentra Registrada.'
	Else Begin
		Update cat_compra Set cod_compra=@cod_compra Where tipo_compra=@tipo_compra
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscarcompra
@Datos Varchar(50)
As Begin
	Select * From cat_compra Where cod_compra=@Datos
End
Go

-----------Procedimiento detalle de compra

Create Proc Listardetallecompra
As Begin
	Select * From tbl_detalle_compra
End
Go


Create proc Registrardetallecompra
@compra int,
@articulo int ,
@cantidad int ,
@cantidad_rec int,
@precio_compra int,
@tasa_descuento varchar(20),
@descuento float,
@monto float,
@Mensaje Varchar(50)  Out
As Begin
	If(Exists(Select * From tbl_detalle_compra Where cantidad=@cantidad))
		Set @Mensaje='el detalle compra se encuentra Registrado.'
	Else Begin
		Insert tbl_detalle_compra Values(@compra,@articulo,@cantidad,@cantidad_rec,@precio_compra,@tasa_descuento,@descuento,@monto)
		Set @Mensaje='Registrado Correctamente.'
	End
End
Go

Create proc Actualizardetallecompra
@compra int,
@articulo int ,
@cantidad int ,
@cantidad_rec int,
@precio_compra int,
@tasa_descuento varchar(20),
@descuento float,
@monto float,
@Mensaje Varchar(50)  Out
As Begin
	If(Not Exists(Select * From tbl_detalle_compra Where compra=@compra))
		Set @Mensaje='el detalle de compra no se encuentra Registrada.'
	Else Begin
		Update tbl_detalle_compra Set compra=@compra Where cantidad=@cantidad
		Set @Mensaje='Se ha Actualizado los Datos Correctamente.'
	End
End
Go

Create Proc Buscardetallecompra
@Datos Varchar(50)
As Begin
	Select * From tbl_detalle_compra Where cod_detalle_compra=@Datos
End
Go