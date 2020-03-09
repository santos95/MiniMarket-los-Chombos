USE MASTER
GO

USE dbventasProyectTer
GO



INSERT INTO cat_persona 
VALUES(1, '001-230495-0010N', 'Santos Alberto', 'Ortiz Chávez', '4-23-2020', 22222222, 'santos95ortiz@gmail.com', 'Mcfly street')
INSERT INTO cat_persona 
VALUES(2, '001-221094-0010N', 'Martin', 'McFly', '10-22-1994', 22222224, 'martyMcFly94@gmail.com', 'Avenida siempre viva 123.')
INSERT INTO cat_persona 
VALUES(3, '001-100590-0010N', 'Edward', 'Snowden', '5-10-1990', 22222225, 'ed04snowden@gmail.com', 'Assange street 123')
INSERT INTO cat_persona 
VALUES(4, '001-100595-0010N', 'Peter', 'Parker', '5-10-1995', 22222223, 'spiderman95@gmail.com', 'Newy York street')


SELECT * FROM cat_persona

INSERT INTO tbl_cargo 
VALUES('TI Administrador', 'Administrador área de TI', 'El administrador del área de TI gestíono todo lo relacionado a tecnologías de información dentro de la Minimarket los Chombos', GETDATE(), 'A')
INSERT INTO tbl_cargo 
VALUES('TI Desarrollador', 'Analista y programador ', 'Mantenimiento del SIFIC', GETDATE(), 'A')
INSERT INTO tbl_cargo 
VALUES('Supervisor de venta', 'Supervisor del área de venta.', 'Supervisión y gestión de tareas en el área de venta', GETDATE(), 'A')
INSERT INTO tbl_cargo 
VALUES('Vendedor', 'Facturación de artículos', 'Facturación de artículos y recibo de pagos de venta de los artículos.', GETDATE(), 'A')

SELECT * FROM tbl_cargo

INSERT INTO cat_trabajador 
VALUES(1, 1, 'M', '99423424323' ,'S', 'Tiempo definitivo', 'A')

INSERT INTO cat_trabajador 
VALUES(2, 2, 'M', '93848493849', 'C', 'Temporal', 'A')

INSERT INTO cat_trabajador 
VALUES(3, 3, 'M', '92342455322', 'S', 'Tiempo indefinido', 'A')

INSERT INTO cat_trabajador 
VALUES(4, 4, 'M', '93848493849', 'C', 'Tiempo indefinido', 'A')


INSERT INTO tbl_detallecargoasignado 
VALUES( 1, 1, 'Carlos Lopez', 'Omar Vidal', getdate())
INSERT INTO tbl_detallecargoasignado 
VALUES(3, 2, 'Carlos Lopez', 'Omar Vidal', getdate())
INSERT INTO tbl_detallecargoasignado 
VALUES(2, 3, 'Carlos Lopez', 'Omar Vidal', getdate())
INSERT INTO tbl_detallecargoasignado 
VALUES(4, 4, 'Carlos Lopez', 'Omar Vidal', getdate())

SELECT cod_persona as ID, cedula_ruc as Identificación, nombre as Nombre, apellido_sucursal as Apellido,  cod_trabajador as Código, cargo as CodCargo, nombre_cargo as Cargo , cat_trabajador.estado as Estado   FROM tbl_detallecargoasignado join cat_trabajador on tbl_detallecargoasignado.trabajador = cat_trabajador.cod_trabajador join cat_persona on cat_trabajador.persona = cat_persona.cod_persona join tbl_cargo on tbl_cargo.id_cargo = tbl_detallecargoasignado.cargo


INSERT INTO tbl_rolacceso
VALUES('Administrador', getdate(), 'A')
INSERT INTO tbl_rolacceso
VALUES('Vendedor', getdate(),'A')

SELECT * FROM tbl_rolacceso

INSERT INTO cat_usuario
VALUES (1, 1, 1, 'Admin-1', 'Administrador1234', 'Carlos Lopez', getdate(), 'A' )

INSERT INTO cat_usuario
VALUES (2, 4, 2, 'Venderdor-1', 'Vendedor1234', 'Carlos Lopez', getdate(), 'A' )

SELECT * FROM cat_usuario

insert into tbl_control_acceso values(1,'c',getdate(), getdate(),getdate(),getdate())





