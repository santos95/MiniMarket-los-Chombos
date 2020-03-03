use dbventasProyectTer
GO
-------------Procedimiento de proveedor 
create procedure Proveedor
(
@cod_proveedor int,
@persona int,
@politica_venta varchar(200),
@observacion int,
@fechaRegistro date,
@estado char(1)
)
as
	begin
		begin try 
			begin tran
	Insert into cat_proveedor values (@cod_proveedor, @Persona,@politica_venta,@observacion,@fechaRegistro,@estado)
			commit tran 
			end try
		begin catch
	rollback tran
	select @@ERROR
end catch
end
----------------------------Procedimiento de compra
create procedure Compra
(
@cod_compra int,
@cod_trabajador int,
@cod_proveedor int,
@tipo_compra char(4),
@subtotal float,
@IVA float,
@total float,
@fecharegistro date,
@estado char(1)
)
as
begin
begin try 
begin tran
insert into cat_compra values (@cod_compra,@cod_trabajador,@cod_proveedor,@tipo_compra,@subtotal,@IVA,@total,@fecharegistro,@estado)
commit tran
end try
begin catch
rollback tran
select @@ERROR
end catch
end

-----------------procedimiento de articulos
Create Procedure articulo
(
@cod_articulo int,
@categoria_articulo int,
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@cod_presentacion int
)
as
begin
begin try 
begin tran
INSERT INTO cat_articulo values (@cod_articulo,@categoria_articulo,@nombre,@descripcion,@imagen,@cod_presentacion)
commit tran
end try
begin catch
rollback tran
select @@ERROR
end catch
end
Go



--------------------------------Ventas
Create Procedure Ventas
(
@cod_venta int,
@cod_trabajador int,
@forma_pago varchar(20),
@cliente int,
@subtotal float,
@IVA float,
@total float,
@fecharegistro date,
@estado char(1)
)
as
begin
begin try 
begin tran
INSERT INTO cat_venta values (@cod_venta,@cod_trabajador,@forma_pago,@cliente,@subtotal,@IVA,@total,@fecharegistro,@estado)
commit tran
end try
begin catch
rollback tran
select @@ERROR
end catch
end
Go
