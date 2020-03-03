use dbventasProyectTer
Go
-------------tabla Persona/Trabajador
create view Vistas_Persona_Trabjador
as
select P.cod_persona,P.cedula_ruc,P.nombre,P.apellido_sucursal,P.fechanac_fechaconstitucion,P.telefono,P.correo,P.direccion,
T.cod_trabajador,T.persona,T.genero,T.inss,T.estadocivil,T.razon_contratacion,T.estado
from cat_persona as P inner join cat_trabajador as T on P.cod_persona = T.cod_trabajador
--------------verificacion de las tabla
select * from Vistas_Persona_Trabjador-----> ejecutalo para ver el contenido de la vista hecha.

-------------tabla Persona/cliente 
create view Vistas_Persona_Cliente
as
select P.cod_persona,P.cedula_ruc,P.nombre,P.apellido_sucursal,P.fechanac_fechaconstitucion,P.telefono,P.correo,P.direccion,
C.cod_cliente,C.persona,C.tipo_Cliente,C.genero,C.estado
from cat_persona as P inner join cat_cliente as C on P.cod_persona = C.cod_cliente
--------------verificacion de las tabla
select * from Vistas_Persona_Cliente-----> ejecutalo para ver el contenido de la vista hecha.

---------------tabla vista Persona/Proveedor
create view Vistas_Persona_Proveedor
as
select P.cod_persona,P.cedula_ruc,P.nombre,P.apellido_sucursal,P.fechanac_fechaconstitucion,P.telefono,P.correo,P.direccion,
Pr.cod_proveedor,Pr.persona,Pr.politica_venta,Pr.observacion,Pr.fecharegistro,Pr.estado
from cat_persona as P inner join cat_proveedor as Pr on P.cod_persona = pr.cod_proveedor

select * from Vistas_Persona_Proveedor-----> ejecutalo para ver el contenido de la vista hecha.

-------------tabla vista Cargo/Trabajador
create view Vistas_Cargo_Trabajador
as
select C.id_cargo,C.nombre_cargo,C.descripcion_cargo,C.observacion,C.fecharegistro,
T.cod_trabajador,T.persona,T.genero,T.inss,T.estadocivil,T.razon_contratacion,T.estado
from tbl_cargo as C inner join cat_trabajador as T  on C.id_cargo = T.cod_trabajador

select * from Vistas_Cargo_Trabajador-----> ejecutalo para ver el contenido de la vista hecha.



select * from tbl_categoria
select * from tbl_presentacion
----------------tabla vista Categoria/Presentacion

create view Vistas_Categoria_Presentacion
as
select C.id_categoria,C.nombrecat,C.observacion,p.id_presentacion,p.nombre,p.descripcion,p.fecharegistro
from tbl_categoria as C inner join tbl_presentacion as P  on C.id_categoria = p.id_presentacion

select * from Vistas_Categoria_Presentacion-----> ejecutalo para ver el contenido de la vista hecha.
------------tabla vista categoria/Articulo
create view Vistas_Categoria_Articulo
as
select C.id_categoria,C.nombrecat,C.observacion,C.fecharegistro,
A.cod_articulo,A.categoria_articulo,A.nombre,A.descripcion,A.imagen,A.cod_presentacion
from tbl_categoria as C inner join cat_articulo as A  on C.id_categoria = A.cod_articulo

select * from Vistas_Categoria_Articulo-----> ejecutalo para ver el contenido de la vista hecha.
-----------------Tabla Presentacion/Articulo
create view Vistas_Presentacion_Articulo
as
select p.id_presentacion,p.nombre,p.descripcion,p.fecharegistro,
A.cod_articulo,A.categoria_articulo,A.imagen,A.cod_presentacion
from tbl_presentacion as p inner join cat_articulo as A  on p.id_presentacion = A.cod_articulo

select * from Vistas_Presentacion_Articulo-----> ejecutalo para ver el contenido de la vista hecha.
