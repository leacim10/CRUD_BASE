create database DB_PRUEBA_CRUD
go
use DB_PRUEBA_CRUD
go
create table PERSONAS
(
	idPersona_IN int identity primary key,
	nombre_VC varchar(50),
	apellidos_VC varchar(50),
	edad_IN int
)

go
create procedure PERSONAS_insert
@nombre_VC varchar(50)
,@apellidos_VC varchar(50)
,@edad_IN int
as
begin
	insert into dbo.PERSONAS
		(
			nombre_VC
			,apellidos_VC
			,edad_IN
		)
	VALUES
		(
			@nombre_VC
			,@apellidos_VC
			,@edad_IN
		)
end
go
create procedure PERSONAS_getId
	@idPersona_IN int
as
begin
	select
		idPersona_IN
		,nombre_VC
		,apellidos_VC
		,edad_IN
	from dbo.PERSONAS
	where
		idPersona_IN = @idPersona_IN
end

go
create procedure PERSONAS_getList	
as
begin
	select
		idPersona_IN
		,nombre_VC
		,apellidos_VC
		,edad_IN
	from dbo.PERSONAS
end






select * from dbo.PERSONAS