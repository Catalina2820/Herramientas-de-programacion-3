-- Creaci�n de la base de datos
CREATE DATABASE Bistro;
USE Bistro;

-- Tabla Cliente
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Telefono NVARCHAR(15),
    Correo NVARCHAR(50) UNIQUE,
    Direccion NVARCHAR(200) NULL
);
GO

-- Tabla Empleado
CREATE TABLE Empleado (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Puesto NVARCHAR(50),
    Telefono NVARCHAR(15),
    Correo NVARCHAR(50) UNIQUE
);
GO

-- Tabla Mesa
CREATE TABLE Mesa (
    IdMesa INT PRIMARY KEY IDENTITY(1,1),
    Numero INT UNIQUE,
    Capacidad INT
);
GO

-- Tabla Menu
CREATE TABLE Menu (
    IdPlato INT PRIMARY KEY IDENTITY(1,1),    
    NombrePlato NVARCHAR(100),
    Descripcion NVARCHAR(300),
    Precio DECIMAL(10, 2),
    Disponibilidad BIT 
);
GO

-- Tabla Pedido
CREATE TABLE Pedido (
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT NULL FOREIGN KEY REFERENCES Cliente(IdCliente),
    IdEmpleado INT NULL FOREIGN KEY REFERENCES Empleado(IdEmpleado),
    IdMesa INT NULL FOREIGN KEY REFERENCES Mesa(IdMesa),
    FechaPedido DATETIME DEFAULT GETDATE(),
    ModoPedido NVARCHAR(50) -- 'En Restaurante', 'Domicilio'
);
GO

-- Tabla Resumen
CREATE TABLE Resumen (
    IdResumen INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) ON DELETE CASCADE,
    IdPlato INT FOREIGN KEY REFERENCES Menu(IdPlato),
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Estado NVARCHAR(50) -- 'Pendiente', 'En Proceso', 'Terminado'
);
GO

-- Tabla Factura
CREATE TABLE Factura (
    IdFactura INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) ON DELETE CASCADE,
    FechaFactura DATETIME DEFAULT GETDATE(),
    TotalFactura DECIMAL(10,2)
);
GO

-- Tabla Reservacion
CREATE TABLE Reservacion (
    IdReservacion INT PRIMARY KEY IDENTITY(1,1),
    IdCliente INT NULL FOREIGN KEY REFERENCES Cliente(IdCliente),
    IdEmpleado INT NULL FOREIGN KEY REFERENCES Empleado(IdEmpleado),
    IdMesa INT FOREIGN KEY REFERENCES Mesa(IdMesa),
    FechaReservacion DATETIME,
    ClienteAnonimo BIT DEFAULT 0
);
GO

-- Procedimientos para la tabla Cliente
CREATE PROCEDURE SP_Cliente_Index
AS
BEGIN
    SELECT * FROM Cliente;
END;
GO

CREATE PROCEDURE SP_Cliente_Create
(
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(50),
    @Direccion NVARCHAR(200) = NULL
)
AS
BEGIN
    INSERT INTO Cliente (Nombre, Apellido, Telefono, Correo, Direccion)
    VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Direccion);

    SELECT SCOPE_IDENTITY() AS IdCliente;
END;
GO


CREATE PROCEDURE SP_Cliente_Update
(
    @IdCliente INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(50),
    @Direccion NVARCHAR(200) = NULL
)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion
    WHERE IdCliente = @IdCliente;
END;
GO

CREATE PROCEDURE SP_Cliente_Delete
(
    @IdCliente INT
)
AS
BEGIN
    DELETE FROM Cliente
    WHERE IdCliente = @IdCliente;
END;
GO

-- Procedimientos para la tabla Empleado
CREATE PROCEDURE SP_Empleado_Index
AS
BEGIN
    SELECT * FROM Empleado;
END;
GO

CREATE PROCEDURE SP_Empleado_Create
(
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Puesto NVARCHAR(50),
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO Empleado (Nombre, Apellido, Puesto, Telefono, Correo)
    VALUES (@Nombre, @Apellido, @Puesto, @Telefono, @Correo);

    SELECT SCOPE_IDENTITY() AS IdEmpleado;
END;
GO

CREATE PROCEDURE SP_Empleado_Update
(
    @IdEmpleado INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Puesto NVARCHAR(50),
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(50)
)
AS
BEGIN
    UPDATE Empleado
    SET Nombre = @Nombre, Apellido = @Apellido, Puesto = @Puesto, Telefono = @Telefono, Correo = @Correo
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

CREATE PROCEDURE SP_Empleado_Delete
(
    @IdEmpleado INT
)
AS
BEGIN
    DELETE FROM Empleado
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Procedimientos para la tabla Mesa
CREATE PROCEDURE SP_Mesa_Index
AS
BEGIN
    SELECT * FROM Mesa;
END;
GO

CREATE PROCEDURE SP_Mesa_Create
(
    @Numero INT,
    @Capacidad INT
)
AS
BEGIN
    INSERT INTO Mesa (Numero, Capacidad)
    VALUES (@Numero, @Capacidad);

    SELECT SCOPE_IDENTITY() AS IdMesa;
END;
GO

CREATE PROCEDURE SP_Mesa_Update
(
    @IdMesa INT,
    @Numero INT,
    @Capacidad INT
)
AS
BEGIN
    UPDATE Mesa
    SET Numero = @Numero, Capacidad = @Capacidad
    WHERE IdMesa = @IdMesa;
END;
GO

CREATE PROCEDURE SP_Mesa_Delete
(
    @IdMesa INT
)
AS
BEGIN
    DELETE FROM Mesa
    WHERE IdMesa = @IdMesa;
END;
GO

-- Procedimientos para la tabla Menu
CREATE PROCEDURE SP_Menu_Index
AS
BEGIN
    SELECT * FROM Menu;
END;
GO

CREATE PROCEDURE SP_Menu_Create
(
    @NombrePlato NVARCHAR(100),
    @Descripcion NVARCHAR(300),
    @Precio DECIMAL(10, 2),
    @Disponibilidad BIT
)
AS
BEGIN
    INSERT INTO Menu (NombrePlato, Descripcion, Precio, Disponibilidad)
    VALUES (@NombrePlato, @Descripcion, @Precio, @Disponibilidad);

    SELECT SCOPE_IDENTITY() AS IdPlato;
END;
GO

CREATE PROCEDURE SP_Menu_Update
(
    @IdPlato INT,
    @NombrePlato NVARCHAR(100),
    @Descripcion NVARCHAR(300),
    @Precio DECIMAL(10, 2),
    @Disponibilidad BIT
)
AS
BEGIN
    UPDATE Menu
    SET NombrePlato = @NombrePlato, Descripcion = @Descripcion, Precio = @Precio, Disponibilidad = @Disponibilidad
    WHERE IdPlato = @IdPlato;
END;
GO

CREATE PROCEDURE SP_Menu_Delete
(
    @IdPlato INT
)
AS
BEGIN
    DELETE FROM Menu
    WHERE IdPlato = @IdPlato;
END;
GO

-- Procedimientos para la tabla Pedido
CREATE PROCEDURE SP_Pedido_Index
AS
BEGIN
    SELECT * FROM Pedido;
END;
GO

CREATE PROCEDURE SP_Pedido_Create
(
    @IdCliente INT = NULL,
    @IdEmpleado INT = NULL,
    @IdMesa INT = NULL,
    @ModoPedido NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO Pedido (IdCliente, IdEmpleado, IdMesa, ModoPedido)
    VALUES (@IdCliente, @IdEmpleado, @IdMesa, @ModoPedido);

    SELECT SCOPE_IDENTITY() AS IdPedido;
END;
GO

CREATE PROCEDURE SP_Pedido_Update
(
    @IdPedido INT,
    @IdCliente INT = NULL,
    @IdEmpleado INT = NULL,
    @IdMesa INT = NULL,
    @ModoPedido NVARCHAR(50)
)
AS
BEGIN
    UPDATE Pedido
    SET IdCliente = @IdCliente, IdEmpleado = @IdEmpleado, IdMesa = @IdMesa, ModoPedido = @ModoPedido
    WHERE IdPedido = @IdPedido;
END;
GO

CREATE PROCEDURE SP_Pedido_Delete
(
    @IdPedido INT
)
AS
BEGIN
    DELETE FROM Pedido
    WHERE IdPedido = @IdPedido;
END;
GO

-- Procedimientos para la tabla Resumen
CREATE PROCEDURE SP_Resumen_Index
AS
BEGIN
    SELECT * FROM Resumen;
END;
GO

CREATE PROCEDURE SP_Resumen_Create
(
    @IdPedido INT,
    @IdPlato INT,
    @Cantidad INT
)
AS
BEGIN
    DECLARE @PrecioUnitario DECIMAL(10, 2);

    -- Obtener el precio del plato
    SELECT @PrecioUnitario = Precio FROM Menu WHERE IdPlato = @IdPlato;

    -- Insertar en el resumen
    INSERT INTO Resumen (IdPedido, IdPlato, Cantidad, PrecioUnitario)
    VALUES (@IdPedido, @IdPlato, @Cantidad, @PrecioUnitario);

    SELECT SCOPE_IDENTITY() AS IdResumen;
END;
GO

CREATE PROCEDURE SP_Resumen_Update
(
    @IdResumen INT,
    @IdPedido INT,
    @IdPlato INT,
    @Cantidad INT
)
AS
BEGIN
    DECLARE @PrecioUnitario DECIMAL(10, 2);

    -- Obtener el precio actualizado
    SELECT @PrecioUnitario = Precio FROM Menu WHERE IdPlato = @IdPlato;

    UPDATE Resumen
    SET IdPedido = @IdPedido, IdPlato = @IdPlato, Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario
    WHERE IdResumen = @IdResumen;
END;
GO

CREATE PROCEDURE SP_Resumen_Delete
(
    @IdResumen INT
)
AS
BEGIN
    DELETE FROM Resumen
    WHERE IdResumen = @IdResumen;
END;
GO

-- Procedimientos para la tabla Factura
CREATE PROCEDURE SP_Factura_Index
AS
BEGIN
    SELECT * FROM Factura;
END;
GO

CREATE PROCEDURE SP_Factura_Create
(
    @IdPedido INT
)
AS
BEGIN
    DECLARE @TotalFactura DECIMAL(10, 2);

    -- Calcular el total de la factura
    SELECT @TotalFactura = SUM(Cantidad * PrecioUnitario)
    FROM Resumen
    WHERE IdPedido = @IdPedido;

    -- Insertar la factura
    INSERT INTO Factura (IdPedido, TotalFactura)
    VALUES (@IdPedido, @TotalFactura);

    SELECT SCOPE_IDENTITY() AS IdFactura;
END;
GO

CREATE PROCEDURE SP_Factura_Update
(
    @IdFactura INT,
    @IdPedido INT
)
AS
BEGIN
    DECLARE @TotalFactura DECIMAL(10, 2);

    -- Calcular el total actualizado de la factura
    SELECT @TotalFactura = SUM(Cantidad * PrecioUnitario)
    FROM Resumen
    WHERE IdPedido = @IdPedido;

    UPDATE Factura
    SET IdPedido = @IdPedido, TotalFactura = @TotalFactura
    WHERE IdFactura = @IdFactura;
END;
GO

CREATE PROCEDURE SP_Factura_Delete
(
    @IdFactura INT
)
AS
BEGIN
    DELETE FROM Factura
    WHERE IdFactura = @IdFactura;
END;
GO

-- Procedimientos para la tabla Reservacion
CREATE PROCEDURE SP_Reservacion_Index
AS
BEGIN
    SELECT * FROM Reservacion;
END;
GO

CREATE PROCEDURE SP_Reservacion_Create
(
    @IdCliente INT = NULL,
    @IdEmpleado INT = NULL,
    @IdMesa INT,
    @FechaReservacion DATETIME,
    @ClienteAnonimo BIT = 0
)
AS
BEGIN
    INSERT INTO Reservacion (IdCliente, IdEmpleado, IdMesa, FechaReservacion, ClienteAnonimo)
    VALUES (@IdCliente, @IdEmpleado, @IdMesa, @FechaReservacion, @ClienteAnonimo);

    SELECT SCOPE_IDENTITY() AS IdReservacion;
END;
GO

CREATE PROCEDURE SP_Reservacion_Update
(
    @IdReservacion INT,
    @IdCliente INT = NULL,
    @IdEmpleado INT = NULL,
    @IdMesa INT,
    @FechaReservacion DATETIME,
    @ClienteAnonimo BIT = 0
)
AS
BEGIN
    UPDATE Reservacion
    SET IdCliente = @IdCliente, IdEmpleado = @IdEmpleado, IdMesa = @IdMesa, FechaReservacion = @FechaReservacion, ClienteAnonimo = @ClienteAnonimo
    WHERE IdReservacion = @IdReservacion;
END;
GO

CREATE PROCEDURE SP_Reservacion_Delete
(
    @IdReservacion INT
)
AS
BEGIN
    DELETE FROM Reservacion
    WHERE IdReservacion = @IdReservacion;
END;
GO

