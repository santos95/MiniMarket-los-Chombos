USE dbventasProyectTer
GO
---Procedimientos de Logeo y control de acceso 

create procedure accesologin
(
@usuario varchar(100),
@password varchar(100)
)
as
BEGIN
SELECT rolacceso,usuario,pass,cod_usuario  FROm cat_usuario where usuario = @usuario and pass = @password
END
GO

create procedure estadoconexion
(
@cod_usuario int
)
as
SELECT * FROM tbl_control_acceso where usuario = @cod_usuario
GO

-----------------------------------procedimiento de cargo----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Chávez         -----------------------------------
-------------------       Date: 28/03/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------
--Procedimiento para listar todos los cargos
CREATE PROC spMostrarCargo
AS
BEGIN
	SELECT id_cargo AS Código, nombre_cargo as Cargo, descripcion_cargo AS Descripción, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo
END
GO

CREATE PROC spMostrarCargoA
AS
BEGIN
	SELECT id_cargo AS Código, nombre_cargo as Cargo, descripcion_cargo AS Descripción, strRegistrado AS RegistradoPor, strAutorizado AS AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE estado = 'A' ORDER BY nombre_cargo;
END
GO

CREATE PROC spMostrarCargoI
AS
BEGIN
	SELECT id_cargo AS Código, nombre_cargo as Cargo, descripcion_cargo AS Descripción, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE estado = 'I';
END
GO


CREATE PROC spBuscarCargoNombre
@textobuscar varchar(50)
AS
BEGIN
	SELECT id_cargo AS Código, nombre_cargo as Cargo, descripcion_cargo AS Descripción, strRegistrado as RegistradoPor, strAutorizado as AutorizadoPor , fecharegistro AS Registrado, estado AS Estado  FROM cat_cargo WHERE nombre_cargo LIKE @textobuscar + '%';
END


CREATE PROC spRegistrarCargo
@nombre			varchar(50),
@descripcion	varchar(200),
@registrado		varchar(100),
@autorizado		varchar(100),
@estado			char(1),
@Mensaje		Varchar(80) Out
As 
BEGIN
	If(Exists(SELECT * FROM cat_cargo WHERE nombre_cargo=@nombre))
		SET @Mensaje='El cargo ya se encuentra registrado.';
	ELSE 
		BEGIN
			DECLARE @codCargo INT;
			SELECT @codCargo = ISNULL(MAX(id_cargo), 0) + 1  FROM cat_cargo;

			IF @estado = 'I'
			BEGIN
				
				INSERT INTO cat_cargo
				VALUES (@codCargo,@nombre, @descripcion, @registrado, @autorizado, GETDATE(), @estado);
			
				SET @Mensaje='Se ha registrado el cargo correctamente. El cargo debse ser autorizado.';
		
			END
			ELSE IF @estado = 'A'
			BEGIN

				INSERT INTO cat_cargo
				VALUES(@codCargo, @nombre, @descripcion, @registrado, @autorizado, GETDATE(), @estado)

				SET @Mensaje = 'Se ha registrado el cargo correctamente. Se ha autorizado el cargo.'

			END
			
		END
END
GO


CREATE PROC spAutorizarCargo
@idCargo	int,
@autorizar	varchar(100),
@mensaje	varchar(50) out
AS
BEGIN

	IF(NOT EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo))
		SET @mensaje = 'El cargo no se encuentra registrado';
	IF(EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo and estado = 'I'))
	BEGIN	
		UPDATE cat_cargo SET strAutorizado = @autorizar, estado = 'A' WHERE id_cargo = @idCargo;
		SET @mensaje = 'Se ha autorizado el cargo.';
	END
	ELSE
		SET @mensaje = 'No se ha podido autorizar el cargo';
END
GO

CREATE PROC spDesautorizarCargo
@idCargo	int,
@autorizar	varchar(100),
@mensaje	varchar(50) out
AS
BEGIN

	IF(NOT EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo))
		SET @mensaje = 'El cargo no se encuentra registrado';
	IF(EXISTS(SELECT * FROM cat_cargo WHERE id_cargo = @idCargo and estado = 'A'))
	BEGIN	
		UPDATE cat_cargo SET strAutorizado = @autorizar, estado = 'I' WHERE id_cargo = @idCargo;
		SET @mensaje = 'Se ha Desautorizado el cargo.';
	END
	ELSE
		SET @mensaje = 'No se ha podido desautorizar el cargo';
END
GO

CREATE PROC spActualizarcargo
@idCargo			int,
@nombre				varchar(50),
@descripcion		varchar(200),
@registrado			nvarchar(100),
@autorizado			nvarchar(100),
@estado				char(1),
@mensaje			Varchar(80)  Out
AS
BEGIN
	
	If(NOT EXISTS(SELECT * FROM cat_cargo WHERE @idCargo = id_cargo))
		SET @Mensaje = 'El cargo no se encuentra registrado.';
	ELSE
	BEGIN

		IF @estado = 'A'
		BEGIN
			
			UPDATE cat_cargo SET nombre_cargo=@nombre, descripcion_cargo=@descripcion, strRegistrado = @registrado, strAutorizado = @autorizado,  estado = @estado  WHERE id_cargo = @idCargo;
			SET @Mensaje='Se ha Actualizado los Datos Correctamente. Se ha autorizado el cargo.';
		
		END
		ELSE IF @estado = 'I'
		BEGIN
			
			UPDATE cat_cargo SET nombre_cargo=@nombre, descripcion_cargo=@descripcion, strRegistrado = @registrado, strAutorizado = @autorizado, estado = @estado  WHERE id_cargo = @idCargo;
			SET @Mensaje='Se ha Actualizado los Datos Correctamente. Se ha anulado el cargo.';
		END
	END
END
GO


-----------------------------------procedimiento de EmplEado----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Chávez         -----------------------------------
-------------------       Date: 1/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

CREATE PROC spMostrarEmpleado
AS
BEGIN
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona;
END
GO


CREATE PROC spBuscarEmpleadoNombre
@textobuscar varchar(50)
AS
BEGIN
	
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE strNombre LIKE @textoBuscar + '%';

END
GO


CREATE PROC spBuscarEmpleadoApellido
@textobuscar varchar(50)
AS
BEGIN
	
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE strApellidoRazon LIKE @textoBuscar + '%';

END
GO

CREATE PROC spBuscarEmpleadoCodigo
@numDocumento int
AS
BEGIN
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE cod_Empleado = @numDocumento;
END
GO


--Filtros
--Empleados Activos
CREATE PROC spMostrarEmpleadoA
AS
BEGIN
	
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE estado = 'A';

END
GO

--Empleados Inactivos
CREATE PROC spMostrarEmpleadoI
AS
BEGIN
	
	SELECT cod_empleado as Código, chrTipoIdent as TipoIdentificación, numIdentificacion as Identificación, numInss as INSS, tipoContrato as Tipo_Contrato, strNombre as Nombre, strApellidoRazon as Apellidos, dtFechaNacConst as Fecha_Nacimiento, chrGenero as Genero, chrEstadoCivilNat as Estado_Civil, strDireccion as Dirección, celular as Celular, telefono as Telefono, correo as Correo, fechaReg as Registrado, estado as Estado, strObservacion as Observación FROM cat_empleado JOIN cat_persona on codPersona = cod_persona WHERE estado = 'i';

END
GO


 CREATE PROCEDURE spGuardarEmpleado
 @tipoIdent		char(3),
 @ident			varchar(20),
 @nombre		varchar(60),
 @apellido		varchar(60),
 @fechaNac		date,
 @genero		char(1),
 @estadoCiv		char(1),
 @direccion		varchar(300),
 @inss			varchar(50),
 @tipoCon		char(2),
 @telefono		nvarchar(12),
 @celular		nvarchar(12),
 @correo		varchar(80),
 @estado		char(1),
 @observacion	varchar(300), 
 @mensaje		varchar(50) output
 AS
		IF(EXISTS(SELECT * FROM cat_persona WHERE numIdentificacion = @ident))
			SET @Mensaje='El Empleado ya se encuentra registrado.';
		ELSE
		BEGIN
		 BEGIN TRANSACTION
			DECLARE @NError int
			DECLARE @codEmpleado INT
			DECLARE @codPersona INT
									
			SELECT @codPersona = ISNULL(MAX(cod_persona), 0) + 1  FROM cat_persona
			
			INSERT INTO cat_persona 
			VALUES(@codPersona, 'N', @tipoIdent, @ident, @nombre, @apellido, @fechaNac, @genero, @estadoCiv, @direccion)

			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SELECT @codEmpleado = ISNULL(MAX(cod_empleado), 0) + 1 FROM cat_empleado

			INSERT INTO cat_empleado (cod_empleado, codPersona, numInss, tipoContrato, telefono, celular, correo, estado, strObservacion)
			VALUES(@codEmpleado, @codPersona, @inss, @tipoCon, @telefono, @celular, @correo,  @estado, @observacion)

			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SET @mensaje = 'Se ha insertado el empleado'
			COMMIT TRAN

			Error:
			IF @NError <> 0
			BEGIN
				SET @mensaje = 'Error al momento de insertar el empleado'
				ROLLBACK TRAN
			END
		END
GO


CREATE PROC spActualizarEmpleado
 @codEmpleado	int,
 @tipoIdent		char(3),
 @ident			varchar(20),
 @nombre		varchar(60),
 @apellido		varchar(60),
 @fechaNac		date,
 @genero		char(1),
 @estadoCiv		char(1),
 @direccion		varchar(300),
 @inss			varchar(50),
 @tipoCon		char(2),
 @telefono		nvarchar(12),
 @celular		nvarchar(12),
 @correo		varchar(80),
 @estado		char(1),
 @observacion	varchar(300),
 @mensaje		varchar(50) out
 AS 
	IF (NOT EXISTS (SELECT * FROM cat_empleado WHERE cod_empleado = @codEmpleado))
		SET @mensaje = 'El empleado no se encuentra registrado.';
	ELSE
	BEGIN
		BEGIN TRANSACTION
			DECLARE @NError int
			DECLARE @codPersona int

			SELECT @codPersona =  cod_persona FROM cat_empleado e LEFT JOIN cat_persona p ON e.codPersona = p.cod_persona WHERE cod_empleado = @codEmpleado; 
			
			--Actualizar datos de persona del empleado
			UPDATE cat_persona SET chrTipoIdent = @tipoIdent, numIdentificacion = @ident, strNombre = @nombre, strApellidoRazon = @apellido, dtFechaNacConst = @fechaNac, chrGenero = @genero, chrEstadoCivilNat = @estadoCiv, strDireccion = @direccion WHERE cod_persona = @codPersona;
			
			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			UPDATE cat_empleado SET numINSS = @inss, tipoContrato = @tipoCon, telefono = @telefono, celular = @celular, correo = @correo, estado = @estado, strObservacion = @observacion WHERE cod_empleado = @codEmpleado;
			
			set @NError = @@ERROR
			IF (@NError <> 0) GOTO Error

			SET @mensaje = 'Se ha Actualizado al empleado'
			COMMIT TRAN

			Error:
			IF @NError <> 0
			BEGIN
				SET @mensaje = 'Error al momento de actualizar los datos del empleado'
				ROLLBACK TRAN
			END
	END
GO

-----------------------------------procedimiento de Historial----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Chávez         -----------------------------------
-------------------       Date: 8/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

--Listar los todos empleados con cargos asignados
CREATE PROC spMostrarHistorialEmpleadoA
AS 
BEGIN	
	
	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A';
		
END
GO


CREATE PROC spMostrarHistorialEmpleadoI
AS 
BEGIN	
	
	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por',  ISNULL(autorizado, 'Sin Autorizar.') as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I';
		
END
GO

--Listar todos los empleados con y sin cargo asignado
CREATE PROC spMostrarEmpleadosTodos
AS
BEGIN

	SELECT  ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial',  E.cod_empleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', ISNULL(codCargo, 0) as 'Código de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observación.') as 'Observación', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona

END
GO


--Listar todos los empleados sin cargos asignados
CREATE PROC spMostrarEmpleadosNuevos
AS
BEGIN

	SELECT E.cod_empleado as 'Código de Empleado', numIdentificacion as 'Identificación' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observación') as Observación, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A';  

END
GO

--Búsquedas 
--Búsqueda por documento - filtro -> índice del filtro utilizado 0 - todos, 1 - activos, 2 - inactivos, 3 - empleados
CREATE PROC spBuscarCódigoEmpleaado
@codigo int,
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', ISNULL(codCargo, 0) as 'Código de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observación.') as 'Observación', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE cod_empleado = @codigo;
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND E.cod_empleado = @codigo;
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND E.cod_empleado = @codigo;
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'Código de Empleado', numIdentificacion as 'Identificación' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observación') as Observación, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND E.cod_empleado = @codigo;  

END
GO

CREATE PROC spBuscarNombre
@nombre varchar(60),
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación' , ISNULL(codCargo, 0) as 'Código de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observación.') as 'Observación', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'Código de Empleado', numIdentificacion as 'Identificación' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observación') as Observación, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND P.strNombre LIKE @nombre + '%';  

END
GO


CREATE PROC spBuscarApellido
@apellido varchar(60),
@filtro int
AS
BEGIN

	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación' ,ISNULL(codCargo, 0) as 'Código de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observación.') as 'Observación', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, codCargo as 'Código de Cargo', numIdentificacion as 'Identificación', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND P.strApellidoRazon LIKE @apellido + '%';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado as 'Código de Empleado', numIdentificacion as 'Identificación' ,strNombre as Nombre, strApellidoRazon as Apellido, dtFechaNacConst as Fecha_Nacimiento, tipoContrato as Tipo_Contrato, ISNULL (E.strObservacion, 'Sin observación') as Observación, fechaReg as Registrado, E.estado as Estado FROM  tbl_detalleCargoEmpleado CE RIGHT JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON P.cod_persona = E.codPersona WHERE CE.id_detalleCargoEmpleado IS NULL AND E.estado = 'A' AND P.strApellidoRazon LIKE @apellido + '%';  

END
GO

CREATE PROC spBuscarCargo
@cargo varchar(50),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT ISNULL(CE.id_detalleCargoEmpleado, 0) as 'NumHistorial', E.cod_empleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación' ,ISNULL(codCargo, 0) as 'Código de Cargo', ISNULL(nombre_cargo, 'No asignado') as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', ISNULL(registrado, 'Sin registrar') as 'Registrado Por', ISNULL(autorizado, 'Sin autorizar') as 'Autorizado Por', ISNULL(dtFechaRegis, '1-1-1990') as Registrado, ISNULL(CE.strObservacion, 'Sin observación.') as 'Observación', ISNULL(CE.estado, 'N') as Estado FROM cat_empleado E LEFT JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado  LEFT JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE C.nombre_cargo LIKE @cargo + '%';
	ELSE IF @filtro = 1
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', autorizado as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'A' AND C.nombre_cargo LIKE @cargo + '%';
	ELSE IF @filtro = 2
		SELECT CE.id_detalleCargoEmpleado as NumHistorial,  codEmpleado as 'Código de Empleado', strNombre as Nombre, strApellidoRazon as Apellido, numIdentificacion as 'Identificación', codCargo as 'Código de Cargo', nombre_cargo as 'Nombre del Cargo' , tipoContrato as 'Tipo de Contrato', registrado as 'Registrado Por', ISNULL(autorizado, 'Sin Autorizar.')  as 'Autorizado Por', dtFechaRegis as Registrado, ISNULL(CE.strObservacion, 'Sin Observación.') as 'Observación', CE.estado as Estado FROM tbl_detalleCargoEmpleado CE JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN  cat_cargo C ON CE.codCargo = C.id_cargo JOIN cat_persona P ON E.codPersona = P.cod_persona WHERE CE.estado = 'I' AND C.nombre_cargo LIKE @cargo + '%';

END
GO

--Guardar historial Sin autorizar

CREATE PROC spGuardarHistorial
@codEmpleado int,
@codCargo int,
@registrado varchar(80),
@observacion varchar(300),
@mensaje varchar(50) out
AS
BEGIN

	DECLARE @numHistorial INT

	SELECT @numHistorial = ISNULL(MAX(id_detalleCargoEmpleado), 0) + 1 FROM tbl_detalleCargoEmpleado
	
	INSERT INTO tbl_detalleCargoEmpleado (id_detalleCargoEmpleado, codEmpleado, codCargo, registrado, strObservacion, estado) 
	VALUES (@numHistorial, @codEmpleado, @codCargo, @registrado, @observacion, 'I')

	SET @mensaje = 'Se ha guardado el historial.';

END
GO

--Guardar Hisgorial Autorizar
CREATE PROC spGuardarAutorizarHistorial
@codEmpleado int,
@codCargo int,
@registrado varchar(80),
@autorizado varchar(80),
@observacion varchar(300),
@mensaje varchar(50) out
AS
BEGIN
	
	If(Exists(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE codEmpleado = @codEmpleado AND estado = 'A'))
		Set @Mensaje='El empleado posee un cargo asignado activo.'
	ELSE
	BEGIN
		DECLARE @numHistorial INT

		SELECT @numHistorial = ISNULL(MAX(id_detalleCargoEmpleado), 0) + 1 FROM tbl_detalleCargoEmpleado

		INSERT INTO tbl_detalleCargoEmpleado (id_detalleCargoEmpleado, codEmpleado, codCargo, registrado, autorizado, strObservacion, estado) 
		VALUES(@numHistorial, @codEmpleado, @codCargo, @registrado, @autorizado, @observacion, 'A');

		SET @mensaje = 'Se ha guardado el historial.';
	END
END
GO


CREATE PROC spActualizarHistorial
@idDetalle int,
@observacion varchar(300),
@autorizado  varchar(80),
@estado char(1),
@mensaje varchar(80) out
AS
BEGIN
	
	--Estado Actual del registro
	DECLARE @estado1 CHAR(1)

	IF(NOT EXISTS(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'El historial no se encuentra registrado.';
	ELSE 
		SELECT @estado1 = estado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle;

		 IF @estado1 = 'I' AND @estado = 'A'
		 BEGIN

			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion, autorizado = @autorizado, estado = @estado WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial. Se ha autorizado la asignación.';
		 
		 END
		 ELSE IF @estado1 = 'A' AND @estado = 'I'
		 BEGIN
			
			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion, estado = @estado WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial. Se ha anulado la asignación.';

		 END	
		 ELSE IF @estado = @estado1
		 BEGIN
			
			UPDATE tbl_detalleCargoEmpleado SET strObservacion = @observacion WHERE id_detalleCargoEmpleado = @idDetalle;
			SET @mensaje = 'Se ha actualizado el historial.';
		 
		 END
END
GO

CREATE PROC spAutorizarHistorial
@idDetalle	int,
@autorizar	varchar(80),
@mensaje	varchar(50) out
AS
BEGIN
	


	IF(NOT EXISTS(SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'No fue posible realizar la operación. El Historial no se encuentra registrado';
	IF(EXISTS(SELECT * FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle and estado = 'I'))
	BEGIN	
			
		UPDATE tbl_detalleCargoEmpleado SET autorizado = @autorizar, estado = 'A' WHERE id_detalleCargoEmpleado = @idDetalle;
		SET @mensaje = 'Se ha autorizado la asignación de cargo.';
		
	END
	ELSE
		SET @mensaje = 'No se ha podido autorizar la asignación de cargo. Ya se encuentra activo.';
END
GO

CREATE PROC spAnularHistorial
@idDetalle int,
@mensaje varchar(50) out
AS
BEGIN
	DECLARE @estado CHAR(1)

	IF(NOT EXISTS (SELECT id_detalleCargoEmpleado  FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle))
		SET @mensaje = 'No fue posible realizar la operación. El Historial no se encuentra registrado'
	ELSE IF (EXISTS (SELECT id_detalleCargoEmpleado FROM tbl_detalleCargoEmpleado WHERE id_detalleCargoEmpleado = @idDetalle AND estado = 'A'))
	BEGIN

		UPDATE tbl_detalleCargoEmpleado SET estado = 'I' WHERE id_detalleCargoEmpleado = @idDetalle;
		SET @mensaje = 'Se ha anulado el cargo';
	
	END
	ELSE
		SET @mensaje = 'No se ha podido anular el cargo. Ya se encuentra Inactivo.';

END
GO


-----------------------------------procedimiento de Usuarios----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Chávez         -----------------------------------
-------------------       Date: 14/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------

--Usuarios
CREATE PROC spListarUsuarios
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo;                                                                                                                                                                                                                                   
GO


CREATE PROC spListarUsuariosA
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.estado = 'A';
GO

CREATE PROC spListarUsuariosI
AS
	SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.estado = 'I';
GO

--Listar empleados activos con historial activo que no tienen usuario asignado
CREATE PROC spListarEmpleados
AS
	SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A'
GO


CREATE PROC spNuevoUsuario
@codEmpleado	int,
@rol			int,
@usuario		varchar(100),
@contraseña		varchar(100),
@registrado		varchar(80),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	
		IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE empleado = @codEmpleado))
			SET @mensaje='El empleado ya tiene asignado un usuario.';
		ELSE IF(EXISTS(SELECT cod_usuario FROM cat_usuario WHERE contraseña = @contraseña))
			SET @mensaje='Contraseña no válida. Intente con una nueva';
		ELSE
		BEGIN
		
			DECLARE @codUsuario INT;

			SELECT @codUsuario = ISNULL(MAX(cod_usuario), 0) + 1 FROM cat_usuario;

			

			IF @estado = 'A'
			BEGIN
				
				INSERT INTO dbo.cat_usuario  (cod_usuario, empleado, rolacceso, usuario, contraseña, pass, registrado, autorizado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contraseña), @contraseña, @registrado, @autorizado, @observacion, @estado);
				
				SET @mensaje = 'Se ha registrado nuevo usuario. Se ha Autorizado el usuario.';

				
				IF(NOT EXISTS(SELECT id_control_acceso FROM tbl_control_acceso WHERE usuario = @codUsuario))
				BEGIN
					INSERT INTO tbl_control_acceso (usuario, estadoacceso) VALUES (@codUsuario, 'c')
				END
				
			END
			ELSE IF @estado = 'I'
			BEGIN
				
				INSERT INTO cat_usuario (cod_usuario, empleado, rolacceso, usuario, contraseña, pass, registrado, strObservacion, estado)
				VALUES (@codUsuario, @codEmpleado, @rol, @usuario, ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contraseña), @contraseña, @registrado, @observacion, @estado);	
				
				SET @mensaje = 'Se ha registrado nuevo usuario. Debe ser autorizado por un usuario autorizado.';
			
			END
			

		END
END
GO

CREATE PROC spActualizarUsuario
@codUsuario		int,
@rol			int,
@usuario		varchar(100),
@contraseña		varchar(100),
@autorizado		varchar(80),
@observacion	varchar(300),
@estado			char(1),
@mensaje		varchar(80) out
AS
BEGIN
	IF(NOT EXISTS(SELECT cod_usuario FROM cat_usuario WHERE cod_usuario = @codUsuario))
		SET @mensaje = 'El usuario no se encuentra registrado.';
	ELSE
	BEGIN
		
		DECLARE @contraseñaA VARCHAR(100)
		SELECT @contraseñaA = pass FROM cat_usuario WHERE cod_usuario = @codUsuario;

		IF @estado = 'A'
		BEGIN
			
			IF @contraseñaA = @contraseña
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha autorizado el usuario.'
			END
			ELSE
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, contraseña = ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contraseña), pass = @contraseña  WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha autorizado. Se ha actualizado la contraseña.'
			END

			IF(NOT EXISTS(SELECT id_control_acceso FROM tbl_control_acceso WHERE usuario = @codUsuario))
			BEGIN
				INSERT INTO tbl_control_acceso (usuario, estadoacceso) VALUES (@codUsuario, 'c')
			END

		END
		ELSE IF @estado = 'I'
		BEGIN
			IF @contraseñaA = @contraseña
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha anulado el usuario.'
			END
			ELSE
			BEGIN
				UPDATE cat_usuario SET rolacceso = @rol, usuario = @usuario, autorizado = @autorizado, strObservacion = @observacion, estado = @estado, contraseña = ENCRYPTBYPASSPHRASE('SuperSeguridad' ,@contraseña), pass = @contraseña  WHERE cod_usuario = @codUsuario;
				SET @mensaje = 'Se ha actualizado el usuario. Se ha actualizado la contraseña. Se ha anulado el usuario.'
			END

		END
	END
END
GO

CREATE PROC spBuscarCodUsuario
@usuario INT,
@filtro INT
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE U.cod_usuario = @usuario;
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario = @usuario AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario = @usuario AND U.estado = 'I';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A' AND E.cod_empleado = @usuario;

END
GO

CREATE PROC spBuscarNombreUsuario
@usuario varchar(100),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.usuario LIKE @usuario + '%';
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario LIKE @usuario + '%' AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE u.cod_usuario LIKE @usuario + '%' AND U.estado = 'I';
END
GO

CREATE PROC spBuscarUsuarioNombre
@nombre varchar(60),
@filtro int
AS
BEGIN
	
	IF @filtro = 0
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%';
	ELSE IF @filtro = 1
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%' AND U.estado = 'A';
	ELSE IF @filtro = 2
		SELECT U.cod_usuario AS 'CodUsuario',  U.rolacceso as 'CodRol', R.rol as Rol, U.usuario as 'Nombre de Usuario', U.empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon as Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CONVERT(VARCHAR(100), U.contraseña) AS Contraseña, U.registrado AS 'Registrado Por', U.fechaing AS Registrado, U.autorizado AS 'Autorizado Por', ISNULL(U.strObservacion, 'Sin Observación.') AS Observación, U.estado AS Estado FROM cat_usuario U JOIN tbl_rolacceso R ON U.rolacceso = R.id_rolacceso JOIN cat_empleado E ON U.empleado = E.cod_empleado JOIN cat_persona P ON E.cod_empleado = P.cod_persona JOIN tbl_detalleCargoEmpleado CE ON E.cod_empleado = CE.codEmpleado JOIN cat_cargo C ON CE.codCargo = C.id_cargo WHERE P.strNombre LIKE @nombre + '%' AND U.estado = 'I';
	ELSE IF @filtro = 3
		SELECT E.cod_empleado AS 'CodEmpleado', P.strNombre AS Nombre, P.strApellidoRazon AS Apellido, P.numIdentificacion AS Identificación, C.id_cargo AS CodCargo, C.nombre_cargo AS Cargo, CE.estado AS Estado FROM cat_usuario U RIGHT JOIN tbl_detalleCargoEmpleado CE ON U.empleado = CE.codEmpleado JOIN cat_empleado E ON CE.codEmpleado = E.cod_empleado JOIN cat_persona P ON E.codPersona = P.cod_persona JOIN cat_cargo C ON CE.codCargo = C.id_cargo  WHERE U.estado IS NULL and CE.estado = 'A' AND P.strNombre LIKE @nombre + '%'

END
GO


-----------------------------------procedimiento de Roles----------------------------------------------------
-------------------       Created by: Santos Alberto Ortiz Chávez         -----------------------------------
-------------------       Date: 14/04/2020                                ----------------------------------- 
-------------------------------------------------------------------------------------------------------------


--Roles
CREATE PROC spMostrarRoles
AS
BEGIN
	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso
END
GO

CREATE PROC spMostrarRolesA
AS 
BEGIN

	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE estado = 'A' ORDER BY rol ASC;

END
GO

CREATE PROC spMostrarRolesI
AS
BEGIN

	SELECT id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE estado = 'I';

END
GO

CREATE PROC spInsertarRol
@rol varchar(50),
@descrip varchar(120),
@registrado varchar(40),
@estado char(1),
@mensaje varchar(50) out
AS
BEGIN
	IF(EXISTS(SELECT * FROM tbl_rolacceso WHERE rol = @rol))
		BEGIN
			SET @mensaje = 'El rol ya se encuentra registrado.';
		END
	ELSE
		BEGIN
			
			DECLARE @codRol int

			SELECT @codRol = ISNULL(MAX(id_rolacceso), 0) + 1 FROM tbl_rolacceso

			INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
			VALUES (@codRol, @rol, @descrip, @registrado, @estado);
			SET @mensaje = 'El rol ha sido registrado correctamente.';
		END
END
GO

CREATE PROC spActualizarRol
@id INT,
@rol VARCHAR(50),
@descrip VARCHAR(120),
@estado CHAR(1),
@mensaje VARCHAR(50) OUT
AS
BEGIN
	IF(NOT EXISTS(SELECT * From tbl_rolacceso Where id_rolacceso = @id))
		SET @mensaje='El rol no se encuentra registrado.'
	ELSE
		BEGIN
			UPDATE tbl_rolacceso SET rol = @rol, descripcion = @descrip, estado = @estado  Where id_rolacceso = @id
			SET @mensaje='Se ha Actualizado los Datos Correctamente.'
		END
		
END
GO

SELECT  id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso	WHERE estado = 'A';

SELECT  id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso	WHERE estado = 'I';

CREATE PROC spBuscarRolNombre
@textobuscar varchar(50)
AS
BEGIN

	SELECT  id_rolacceso AS ID, rol AS Rol, descripcion AS Descripción, registrado as Registrador_Por ,fechaing AS FechaRegistro, estado AS Estado FROM tbl_rolacceso WHERE rol LIKE @textobuscar + '%';

END
GO



