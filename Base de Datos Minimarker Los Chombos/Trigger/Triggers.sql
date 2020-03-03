Use dbventasProyectTer
Go

------------trigger para generar el id del cargo "X"

Create Trigger  Generarid_cargo  on tbl_cargo for insert
As  
Declare @id_Cargo  varchar(10)
Select @id_Cargo ='C-' + right('00000000' + LTRIM(RIGHT(ISNULL(max(id_cargo),'00000000'),8)+ 1 ),8) from tbl_cargo
Update tbl_cargo set @id_Cargo =@id_Cargo where id_cargo =''
Go

---------------trigger para generar id de inventario

Create Trigger  Generarid_inventario  on tbl_inventario for insert
As  
Declare @id_inventario  varchar(11)
Select @id_inventario ='I-' + right('000000000' + LTRIM(RIGHT(ISNULL(max(@id_inventario),'000000000'),9)+ 1 ),9) from tbl_inventario
Update tbl_inventario set @id_Inventario =@id_inventario where id_inventario =''
Go

--------------trigger para generar la fecha de evencimineto de un producto "X"

Create Trigger  Generarcod_fecha_vencimiento  on fecha_vencimiento for insert
As  
Declare @fecha  varchar(11)
Select @fecha ='U-' + right('000000000' + LTRIM(RIGHT(ISNULL(max(fecha),'000000000'),9)+ 1 ),9) from fecha_vencimiento
Update fecha_vencimiento set fecha=@fecha where fecha =''
Go