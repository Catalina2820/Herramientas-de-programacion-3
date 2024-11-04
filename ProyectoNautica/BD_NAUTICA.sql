
CREATE DATABASE BD_Nautica;
use BD_Nautica;

-- tabla Socios
CREATE TABLE Socios (
    IdSocio NVARCHAR(10) PRIMARY KEY, 
    Nombre NVARCHAR(50) NOT NULL, 
    FechaNac DATE NOT NULL, 
    Celular NVARCHAR(15), 
    Email NVARCHAR(50) UNIQUE 
);

-- tabla Barcos
CREATE TABLE Barcos (
    nroMatricula NVARCHAR(10) PRIMARY KEY, 
    nombreBarco NVARCHAR(50) NOT NULL, 
    nroAmarre NVARCHAR(20) NOT NULL, 
    vlrCuota DECIMAL(10, 2) NOT NULL, 
    IdSocio NVARCHAR(10), 
    CONSTRAINT FK_Barcos_Socios FOREIGN KEY (IdSocio) REFERENCES Socios(IdSocio)
);

--  tabla Patrones
CREATE TABLE Patrones (
    idPatron NVARCHAR(10) PRIMARY KEY, 
    nombrePatron NVARCHAR(50) NOT NULL, 
    fechaNacPatron DATE NOT NULL,
    celPatron NVARCHAR(15) 
);

--  tabla Salidas
CREATE TABLE Salidas (
    idSalida INT PRIMARY KEY IDENTITY(1,1), 
    fechaSalida DATE NOT NULL, 
    hora TIME NOT NULL, 
    destino NVARCHAR(100) NOT NULL, 
    nroMatricula NVARCHAR(10), 
    idPatron NVARCHAR(10), 
    CONSTRAINT FK_Salidas_Barcos FOREIGN KEY (nroMatricula) REFERENCES Barcos(nroMatricula),
    CONSTRAINT FK_Salidas_Patrones FOREIGN KEY (idPatron) REFERENCES Patrones(idPatron)
);

--Procedimientos Almacenados de Socios
CREATE PROCEDURE SP_Socios_Index
AS
BEGIN
SELECT * FROM Socios
END
GO
--Así se ivoca un sp
--EXECUTE SP_Socios_Index

--Procedimientos prara insertar Socios
CREATE PROCEDURE SP_Socios_Create
(	@IdSocio NVARCHAR(10), 
	@NombreS NVARCHAR(50), 
	@FechaN DATE, 
    @Celular NVARCHAR(15), 
    @email NVARCHAR(50))
--Los nombres de los parametros pueden ser diferentes solo debe coincidir el tipo de dato
as
begin
	insert into Socios values(	@IdSocio, 
								@NombreS,
								@FechaN,
								@Celular,
								@email)
end
---Retorna el identificador de la tabla
Select SCOPE_IDENTITY()
go


--Procedimientos prara modificar Socios
CREATE PROCEDURE SP_Socios_Update
(	@IdSocio NVARCHAR(10), 
	@NombreS NVARCHAR(50), 
	@FechaN DATE, 
    @Celular NVARCHAR(15), 
    @email NVARCHAR(50))
--Los nombres de los parametros pueden ser diferentes solo debe coincidir el tipo de dato
as
begin
	Update Socios set Nombre = @NombreS,
					  FechaNac	= @FechaN,
					  Celular  = @Celular,
					  Email	 = @email 
	where IdSocio = @IdSocio
end
---Retorna el identificador de la tabla
Select SCOPE_IDENTITY()
go


--Procedimientos para eliminar Socios
CREATE PROCEDURE SP_Socios_Delete
(@IdSocio NVARCHAR(10))
--Los nombres de los parametros pueden ser diferentes solo debe coincidir el tipo de dato
as
begin
	Delete from Socios  where IdSocio = @IdSocio
end
---Retorna el identificador de la tabla
Select SCOPE_IDENTITY()
go

--Procedimiento para consultar de la tabla
CREATE PROCEDURE SP_Socios_Read
(@IdSocio NVARCHAR(10))
--Los nombres de los parametros pueden ser diferentes solo debe coincidir el tipo de dato
as
begin
	Delete from Socios  where IdSocio = @IdSocio
end
---Retorna el identificador de la tabla
Select SCOPE_IDENTITY()
go

create table tbl_usuario(
idusuario int identity primary key,
email varchar(60) not null,
contrasena varchar(255) not null
)
go

create procedure SP_ValidarUsuario
@email varchar (60),
@contra varchar(255)
as 
begin
	select email, contrasena from tbl_usuario where
	email = @email and contrasena = @contra
end

insert into tbl_usuario values('gabo78@gmail.com', '12345')