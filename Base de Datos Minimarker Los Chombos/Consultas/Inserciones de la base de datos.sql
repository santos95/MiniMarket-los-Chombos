use dbventasProyectTer
GO

------inserciones de persona

insert into cat_persona values('1','0010512970016w','Omar Vidal','Aragon Pineda','19971205','83783451','omarpineda4568@gamil.com','Altagracia')
insert into cat_persona values('2','001','Jorge Enrrique','Perez Rios','1997','888888','4568@gamil.com','Tenderi')
insert into cat_persona values('3','002','Kevin Alexander','Lopez Tellez','1997','88888','4568@gamil.com','Ticuantepe')
insert into cat_persona values('4','003','Jose','Sandobal Ramos','1997','8888888','4568@gamil.com','Reparto')
insert into cat_persona values('5','004','Cristian','No me acuerdo','1997','888888','4568@gamil.com','quien sabe')
insert into cat_persona values('6','005','Jorge','Arebalo','1997','888888','4568@gamil.com','Reparto altos del dimitro')

---------inserciones de cargo
select * from tbl_cargo

insert into tbl_cargo values ('cajero','area de ventas','tiene gafetes',GETDATE(),'A')
insert into tbl_cargo values ('gerente','area administrativa','tiene gafetes',GETDATE(),'A')
insert into tbl_cargo values ('Contador','area administrativa','tiene gafetes',GETDATE(),'A')
insert into tbl_cargo values ('Bodegero','area de bodegas','tiene gafetes',GETDATE(),'A')
insert into tbl_cargo values ('gerente','area administrativa','tiene gafetes',GETDATE(),'A')


------------inserciones de trabajador

select * from cat_trabajador

insert into cat_trabajador values(1,1,'M','1','S','Tiempo Indefinido','A')
insert into cat_trabajador values(2,2,'M','2','S','Tiempo Indefinido','A')
insert into cat_trabajador values(3,3,'M','3','S','Tiempo Indefinido','A')  
insert into cat_trabajador values(4,4,'M','4','S','Tiempo Indefinido','A')  
insert into cat_trabajador values(5,5,'M','5','S','Tiempo Indefinido','A') 
insert into cat_trabajador values(6,6,'M','6','S','Tiempo Indefinido','A')  
 
 -----------insersiones de detalle de cargo
 select * from tbl_detallecargoasignado

insert into tbl_detallecargoasignado values(1,'1','Jorge','Kevin',GETDATE()) 
insert into tbl_detallecargoasignado values(2,'2','Jorge','Omar',GETDATE())
insert into tbl_detallecargoasignado values(3,'3','Jorge','Arebalo',GETDATE()) 
insert into tbl_detallecargoasignado values(4,'4','Jorge','Cristian',GETDATE())
insert into tbl_detallecargoasignado values(5,'5','Jorge','Jose',GETDATE())
insert into tbl_detallecargoasignado values(6,'6','Jorge','Jorge',GETDATE())


---------insersiones de rol de acceso 
select * from tbl_rolacceso

insert into tbl_rolacceso values('Administrador',GETDATE(),'A')
insert into tbl_rolacceso values('Vendedor',GETDATE(),'A')
insert into tbl_rolacceso values('Bodegero',GETDATE(),'A')
insert into tbl_rolacceso values('Contador',GETDATE(),'A')
insert into tbl_rolacceso values('Gerente',GETDATE(),'A')


----------insersiones de usuario
select * from cat_usuario
insert into cat_usuario values(1,1,1,'Administrador',1234,'Jorge',GETDATE(),'A')
insert into cat_usuario values(2,2,5,'Vendedor',12345,'Jorge',GETDATE(),'A')
insert into cat_usuario values(3,3,3,'Bodegero',123456,'Jorge',GETDATE(),'A')
insert into cat_usuario values(4,4,4,'Contador',1234567,'Jorge',GETDATE(),'A')
insert into cat_usuario values(5,5,5,'Gerente',12345678,'Jorge',GETDATE(),'A')


----------insersiones de control de acceso 

insert into tbl_control_acceso values(1,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(2,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(3,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(4,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(5,'c',getdate(), getdate(),getdate(),getdate())
insert into tbl_control_acceso values(6,'c',getdate(), getdate(),getdate(),getdate())