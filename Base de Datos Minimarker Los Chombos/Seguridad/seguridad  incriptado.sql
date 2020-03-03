Use dbventasProyectTer
GO

Create Procedure Sp_Usuario
(
@cod_Usuario    varchar(11),
@trabajadoremp        int,
@rolacceso int,
@usuario varchar(100),
@Pass           varchar(35),
@autorizado    varchar(50),
@fechaing date,
@estado         char(1)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			Insert into cat_usuario values(@cod_Usuario, @trabajadoremp, @rolacceso,@usuario, ENCRYPTBYPASSPHRASE ('1234',@Pass), 
			                           @autorizado,@fechaing,@estado)
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		SELECT @@ERROR
	END CATCH
END
