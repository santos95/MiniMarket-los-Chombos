Use dbventasProyectTer
GO


Create Procedure Persona
(
@cod_persona int,
@cedula_ruc varchar(50),
@nombre varchar(50),
@apellido_sucursal varchar(50),
@fechanac_fechaconstitucion varchar(50),
@telefono int,
@correo varchar(30),
@direccion varchar(250) 
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			Insert into cat_persona values(@cod_persona,@cedula_ruc,@nombre,@apellido_sucursal,@fechanac_fechaconstitucion,
			@telefono,@correo,@direccion)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT @@ERROR
	END CATCH
END
Create Procedure trabajador
(
@cod_trabajador int,
@persona int,
@genero char(1),
@inss varchar(50),
@estadocivil char(1),
@razon_contratacion  varchar(50),
@estado char(1)
)
	as
	begin
		begin try 
			begin tran
	Insert into cat_trabajador values (@cod_trabajador,@persona,@genero,@inss,@estadocivil,@razon_contratacion,@estadocivil)
			commit tran 
			end try
		begin catch
	rollback tran
	select @@ERROR
End catch
End
