USE MASTER
GO

USE dbventasProyectTer
GO

//ejecturar estos-------------------------------------------------------------------------------------------------
INSERT INTO cat_persona 
VALUES(1, 'N', 'CED', '001-230495-0010N', 'Santos Alberto', 'Ortiz Chávez', '4-23-2020', 'M', 'S' ,'Mcfly street número 33.')
INSERT INTO cat_cargo 
VALUES(1,'TI Administrador', 'Administrador área de TI', 'Admin-1', 'John Chombo', GETDATE(), 'A')
INSERT INTO cat_empleado
VALUES(1, 1,'99423424323', 'TI', '22345678', '84341859', 'santos95ortiz@gmail.com', 'Administrador del sistema', getdate(), 'A')
INSERT INTO tbl_detalleCargoEmpleado 
VALUES( 1, 1, 1, 'Admin-1', 'John Chombo', getdate(), 'Administrador del sistema. Carga Inicial', 'A')
INSERT INTO tbl_rolacceso (id_rolacceso, rol, descripcion, registrado, estado)
VALUES(1,'Administrador', 'Rol para el mantenimiento, respaldo y seguridad.', 'Admin-1' , 'A')
INSERT INTO cat_usuario
VALUES (1, 1, 1, 'Admin-1', 'Administrador1234', ENCRYPTBYPASSPHRASE('SuperSeguridad' ,'Administrador1234'), 'Admin-1', 'John Chombo', getdate(), 'Administrador del sistema, carga inicial.','A' )
INSERT INTO tbl_control_acceso 
VALUES (1, 'c',getdate(), getdate())

---------------------------------------------------------------------------------------------------------------------

INSERT INTO cat_persona 
VALUES(2, 'CED', '001-221094-0010N', 'Martin', 'McFly', '10-22-1994', 22222224, 'martyMcFly94@gmail.com', 'Avenida siempre viva 123.')
INSERT INTO cat_persona 
VALUES(3, 'CED', '001-100590-0010N', 'Edward', 'Snowden', '5-10-1990', 22222225, 'ed04snowden@gmail.com', 'Assange street 123')
INSERT INTO cat_persona 
VALUES(4, 'CED', '001-100595-0010N', 'Peter', 'Parker', '5-10-1995', 22222223, 'spiderman95@gmail.com', 'Newy York street')
INSERT INTO cat_persona 
VALUES(5,'RUC', '001-100595-0010N', 'Tesla', 'Tesla Motors S.A', '5-10-1995', 22222223, 'teslamotors@gmail.com', 'California street')
INSERT INTO cat_persona (cod_persona, tipoIdent, cedula_ruc, nombre, apellido_sucursal)
VALUES(6,'CED','000000000000', 'X', 'X')


SELECT * FROM cat_persona


INSERT INTO tbl_cargo 
VALUES('TI Desarrollador', 'Analista y programador ', 'Mantenimiento del SIFIC', GETDATE(), 'A')
INSERT INTO tbl_cargo 
VALUES('Supervisor de venta', 'Supervisor del área de venta.', 'Supervisión y gestión de tareas en el área de venta', GETDATE(), 'A')
INSERT INTO tbl_cargo 
VALUES('Vendedor', 'Facturación de artículos', 'Facturación de artículos y recibo de pagos de venta de los artículos.', GETDATE(), 'A')

SELECT * FROM tbl_cargo


INSERT INTO cat_trabajador 
VALUES(2, 2, 'M', '93848493849', 'C', 'TD', 'A')

INSERT INTO cat_trabajador 
VALUES(3, 3, 'M', '92342455322', 'S', 'TI', 'A')

INSERT INTO cat_trabajador 
VALUES(4, 4, 'M', '93848493849', 'C', 'TI', 'A')

SELECT * FROM cat_trabajador;


INSERT INTO tbl_detallecargoasignado 
VALUES(3, 2, 'Carlos Lopez', 'Omar Vidal', getdate())
INSERT INTO tbl_detallecargoasignado 
VALUES(2, 3, 'Carlos Lopez', 'Omar Vidal', getdate())
INSERT INTO tbl_detallecargoasignado 
VALUES(4, 4, 'Carlos Lopez', 'Omar Vidal', getdate())

SELECT cod_persona as ID, cedula_ruc as Identificación, nombre as Nombre, apellido_sucursal as Apellido,  cod_trabajador as Código, cargo as CodCargo, nombre_cargo as Cargo , cat_trabajador.estado as Estado   FROM tbl_detallecargoasignado join cat_trabajador on tbl_detallecargoasignado.trabajador = cat_trabajador.cod_trabajador join cat_persona on cat_trabajador.persona = cat_persona.cod_persona join tbl_cargo on tbl_cargo.id_cargo = tbl_detallecargoasignado.cargo




SELECT * FROM tbl_rolacceso


INSERT INTO cat_usuario
VALUES (2, 4, 2, 'Venderdor-1', 'Vendedor1234', 'Carlos Lopez', getdate(), 'A' )

SELECT * FROM cat_usuario



select * from tbl_control_acceso	
INSERT INTO cat_cliente
VALUES(2, 5, 'JU', 'N', 'A')
INSERT INTO cat_cliente
VALUES(1, 6, 'NA', 'N', 'A')

SELECT nombre, apellido_sucursal, tipo_cliente, estado FROM cat_persona join cat_cliente on cat_persona.cod_persona = cat_cliente.persona





