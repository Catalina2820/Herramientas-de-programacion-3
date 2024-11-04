Create database BD_NAUTICA
USE BD_NAUTICA
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
    destino NVARCHAR(100) NOT NULL, 
    nroMatricula NVARCHAR(10), 
    idPatron NVARCHAR(10), 
    CONSTRAINT FK_Salidas_Barcos FOREIGN KEY (nroMatricula) REFERENCES Barcos(nroMatricula),
    CONSTRAINT FK_Salidas_Patrones FOREIGN KEY (idPatron) REFERENCES Patrones(idPatron)
);
Create table tbl_usuario(
 idusuario int identity primary key,
 email varchar(60) not null,
 contrasena varchar(255) not null)

go
--Procedimientos Almacenados de Socios
Create Procedure SP_Socios_Index
as
begin
  Select * from Socios
end
go

--Procedimiento para insertar socios
Create Procedure SP_Socios_Create
(@IdSocio nvarchar(10), @NombreS nvarchar(50), @FechaN date,
@celular nvarchar(15), @email nvarchar(50) )
as
begin
	insert into socios values (@IdSocio, @NombreS, @FechaN, @celular,
	@email)
end
---Retorna el identificador de la tabla
Select Scope_identity()
go

Create Procedure SP_Socios_Update
(@IdSocio nvarchar(10), @NombreS nvarchar(50), @FechaN date,
@celular nvarchar(15), @email nvarchar(50) )
as
begin
	Update socios set  Nombre=@NombreS, FechaNac= @FechaN, 
	celular=@celular,email=@email where IdSocio=@IdSocio
end
---Retorna el identificador de la tabla
Select Scope_identity()
go

Create Procedure SP_Socios_Delete
(@IdSocio nvarchar(10) )
as
begin
	Delete from Socios where IdSocio=@IdSocio
end
---Retorna el identificador de la tabla
Select Scope_identity()
go
Create Procedure SP_Socios_Read
(@IdSocio nvarchar(10) )
as
begin
	Select * from Socios where IdSocio=@IdSocio
end
---Retorna el identificador de la tabla
Select Scope_identity()
go

Create Procedure SP_ValidarUsuario
@email varchar(60),
@contra varchar(255)
as 
begin
	Select email, contrasena from tbl_usuario where
	email=@email and contrasena=@contra
end

insert into tbl_usuario values('gabo78@gmail.com', '12345')

-----------------------------------------------------
--Procedimientos Almacenados de Patrones
-----------------------------------------------------

Create Procedure SP_Patrones_Index
as
begin
  Select * from Patrones
end

go

--Procedimiento para insertar Patrones
Create Procedure SP_Patrones_Create
(@idPatron nvarchar(10), @nombrePatron nvarchar(50), @fechaNacPatron date,
@celPatron nvarchar(15))
as
begin
insert into Patrones values (@idPatron, @nombrePatron, @fechaNacPatron, @celPatron)
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento update Patrones
Create Procedure SP_Patrones_Update
(@idPatron nvarchar(10), @nombrePatron nvarchar(50), @fechaNacPatron date,
@celPatron nvarchar(15))
as
begin
Update Patrones set  nombrePatron=@nombrePatron, fechaNacPatron= @fechaNacPatron,
celPatron=@celPatron where idPatron=@idPatron
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Delete socios
Create Procedure SP_Patrones_Delete
(@idPatron nvarchar(10) )
as
begin
Delete from Patrones where idPatron=@idPatron
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Select por id
Create Procedure SP_Patrones_Read
(@idPatron nvarchar(10) )
as
begin
Select * from Patrones where idPatron=@idPatron
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimientos Almacenados de Barcos
--INDEX
Create Procedure SP_Barcos_Index
as
begin
  Select * from Barcos
end
---CREATE

Create Procedure SP_Barcos_Create
(@NroMatricula nvarchar(10), @NombreBarco nvarchar(50), @NroAmarre nvarchar(20),
@VlrCuota decimal(10,2), @IdSocio nvarchar(10) )
as
begin
    insert into Barcos values (@NroMatricula, @NombreBarco, @NroAmarre, @VlrCuota,
    @IdSocio)
end
---Retorna el identificador de la tabla
Select Scope_identity()

---READ

Create Procedure SP_Barcos_Read
(@NroMatricula nvarchar(10) )
as
begin
    Select * from Barcos where nroMatricula=@NroMatricula
end
---Retorna el identificador de la tabla
Select Scope_identity()

---UPDATE
Create Procedure SP_Barcos_Update
(@NroMatricula nvarchar(10), @NombreBarco nvarchar(50), @NroAmarre nvarchar(20),
@VlrCuota decimal(10,2), @IdSocio nvarchar(10) )
as
begin
    update Barcos set nombreBarco=@NombreBarco, nroAmarre=@NroAmarre, vlrCuota=@VlrCuota,
    IdSocio=@IdSocio where    nroMatricula=@NroMatricula
end
---Retorna el identificador de la tabla
Select Scope_identity()

---DELETE
Create Procedure SP_Barcos_Delete
(@NroMatricula nvarchar(10) )
as
begin
    Delete from Barcos where nroMatricula=@NroMatricula
end
Select Scope_identity()

-----------------------------------------------------
--Procedimientos Almacenados de salidas
-----------------------------------------------------

Create Procedure SP_Salida_Index
as
begin
  Select * from Salidas
end
go

--Procedimiento para insertar salidas

Create Procedure SP_Salidas_Create
(@fechaSalida date,
@destino nvarchar(100), @nromatricula nvarchar(10), @idpatron nvarchar(10))
as
begin
insert into Salidas values (@fechaSalida,@destino, @nromatricula, @idpatron)
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento update salidas
Create Procedure SP_Salida_Update
(@idSalida int, @fechaSalida date,
@destino nvarchar(100), @nromatricula nvarchar(10), @idpatron nvarchar(10))
as
begin
Update Salidas set fechaSalida = @fechaSalida,destino = @destino,
nroMatricula = @nromatricula, idPatron = @idpatron where idSalida = @idSalida
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Delete salidas
Create Procedure SP_Salida_Delete
(@idSalida int )
as
begin
Delete from Salidas where idSalida = @idSalida
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Select por id
Create Procedure SP_Salida_Read
(@idSalida int )
as
begin
Select * from Salidas where idSalida = @idSalida
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

-----------------------------------------------------
--Procedimientos Almacenados de Usuarios
-----------------------------------------------------

Create Procedure SP_Usuarios_Index
as
begin
  Select * from tbl_usuario
end

go


--Procedimiento para insertar Usuario
Create Procedure SP_Usuarios_Create
( @CedulaP varchar(20), @NombreP varchar(100))
as
begin
insert into tbl_usuario values ( @CedulaP , @NombreP)
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento update Usuario
Create Procedure SP_Usuarios_Update
( @email varchar(20), @Password varchar(100))
as
begin
Update tbl_usuario set contrasena= @Password
 where email = @email
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Delete Usuario
Create Procedure SP_Usuarios_Delete
(@email varchar(20))
as
begin
Delete from tbl_usuario where email = @email
end
---Retorna el identificador de la tabla
Select Scope_identity()

go

--Procedimiento Select por id
Create Procedure SP_Usuarios_Read
(@email varchar(20))
as
begin
Select * from tbl_usuario where email = @email
end
---Retorna el identificador de la tabla
Select Scope_identity()

go




Create procedure Sp_ValidarUsuario
(@email varchar(20) , @contra varchar(20))
as
begin
Select count(*) from tbl_usuario where email = @email and contrasena = @contra
end
