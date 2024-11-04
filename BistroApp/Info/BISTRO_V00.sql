
CREATE DATABASE BD_Bistro;
use BD_Bistro;

-- Tabla Clientes (pueden ser clientes registrados o anónimos)
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
	Apellido NVARCHAR(50),
    Telefono NVARCHAR(15),
	Correo NVARCHAR(50) UNIQUE,
    Direccion NVARCHAR(200) NULL
);
GO

-- Tabla Empleados
CREATE TABLE Empleado (
    IdEmpleado INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
	Apellido NVARCHAR(50),
    Puesto NVARCHAR(50),
	Telefono NVARCHAR(15),
	Correo NVARCHAR(50) UNIQUE

);
GO

-- Tabla Mesas (solo para pedidos en restaurante)
CREATE TABLE Mesa (
    MesaID INT PRIMARY KEY IDENTITY(1,1),
    NumeroMesa INT UNIQUE,
    Capacidad INT
);
GO

-- Tabla Menu (Platos disponibles en el restaurante)
CREATE TABLE Menu (
    PlatoID INT PRIMARY KEY IDENTITY(1,1),
    NombrePlato NVARCHAR(100),
    Precio DECIMAL(10, 2)
);
GO

-- Tabla Pedidos (almacena la información general del pedido)
CREATE TABLE Pedido (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NULL FOREIGN KEY REFERENCES Clientes(ClienteID), -- Puede ser NULL para clientes anónimos
    EmpleadoID INT NULL FOREIGN KEY REFERENCES Empleados(EmpleadoID), -- NULL si es un pedido de domicilio
    MesaID INT NULL FOREIGN KEY REFERENCES Mesas(MesaID), -- Solo aplica si es un pedido en restaurante
    FechaPedido DATETIME DEFAULT GETDATE(),
    ModoPedido NVARCHAR(50), -- 'En Restaurante', 'Domicilio'
    ClienteAnonimo BIT DEFAULT 0 -- 0: Cliente registrado, 1: Cliente anónimo (sin registro)
);
GO

-- Tabla Resumen (detalles de cada plato pedido, incluyendo el estado)
CREATE TABLE Resumen (
    ResumenID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT FOREIGN KEY REFERENCES Pedidos(PedidoID) ON DELETE CASCADE, -- Relaciona con Pedidos
    PlatoID INT FOREIGN KEY REFERENCES Menu(PlatoID), -- Relaciona con los platos del menú
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Estado NVARCHAR(50) DEFAULT 'Pendiente' -- 'Pendiente', 'En Proceso', 'Terminado'
);
GO

-- Tabla Reservaciones (gestiona las reservaciones en el restaurante)
CREATE TABLE Reservacion (
    ReservacionID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NULL FOREIGN KEY REFERENCES Clientes(ClienteID), -- Puede ser NULL para clientes anónimos
    EmpleadoID INT NULL FOREIGN KEY REFERENCES Empleados(EmpleadoID),
    MesaID INT FOREIGN KEY REFERENCES Mesas(MesaID),
    FechaReservacion DATETIME,
    ClienteAnonimo BIT DEFAULT 0 -- 0: Cliente registrado, 1: Cliente anónimo
);
GO

---Procedimiento para clientes

CREATE PROCEDURE SP_Clientes_Index
AS
BEGIN
    SELECT * FROM Cliente
END
GO

CREATE PROCEDURE SP_Cliente_Create
(
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Direccion NVARCHAR(200)
)
AS
BEGIN
    INSERT INTO Cliente (Nombre, Telefono, Direccion)
    VALUES (@Nombre, @Telefono, @Direccion)
    
    SELECT SCOPE_IDENTITY() AS ClienteID
END
GO

CREATE PROCEDURE SP_Cliente_Update
(
    @ClienteID INT,
    @Nombre NVARCHAR(50),
    @Telefono NVARCHAR(20),
    @Direccion NVARCHAR(200)
)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Telefono = @Telefono,
        Direccion = @Direccion
    WHERE ClienteID = @ClienteID
END
GO

CREATE PROCEDURE SP_Cliente_Delete
(
    @ClienteID INT
)
AS
BEGIN
    DELETE FROM Clientes
    WHERE ClienteID = @ClienteID
END
GO

CREATE PROCEDURE SP_Clientes_Read
(
    @ClienteID INT
)
AS
BEGIN
    SELECT * FROM Clientes
    WHERE ClienteID = @ClienteID
END
GO

---Procedimientos para empleados
CREATE PROCEDURE SP_Empleados_Index
AS
BEGIN
    SELECT * FROM Empleados
END
GO

CREATE PROCEDURE SP_Empleados_Create
(
    @Nombre NVARCHAR(50),
    @Puesto NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO Empleados (Nombre, Puesto)
    VALUES (@Nombre, @Puesto)
    
    SELECT SCOPE_IDENTITY() AS EmpleadoID
END
GO

CREATE PROCEDURE SP_Empleados_Update
(
    @EmpleadoID INT,
    @Nombre NVARCHAR(50),
    @Puesto NVARCHAR(50)
)
AS
BEGIN
    UPDATE Empleados
    SET Nombre = @Nombre,
        Puesto = @Puesto
    WHERE EmpleadoID = @EmpleadoID
END
GO

CREATE PROCEDURE SP_Empleados_Delete
(
    @EmpleadoID INT
)
AS
BEGIN
    DELETE FROM Empleados
    WHERE EmpleadoID = @EmpleadoID
END
GO

CREATE PROCEDURE SP_Empleados_Read
(
    @EmpleadoID INT
)
AS
BEGIN
    SELECT * FROM Empleados
    WHERE EmpleadoID = @EmpleadoID
END
GO


---Procedimientos para mesas
CREATE PROCEDURE SP_Mesas_Index
AS
BEGIN
    SELECT * FROM Mesas
END
GO

CREATE PROCEDURE SP_Mesas_Create
(
    @NumeroMesa INT,
    @Capacidad INT
)
AS
BEGIN
    INSERT INTO Mesas (NumeroMesa, Capacidad)
    VALUES (@NumeroMesa, @Capacidad)
    
    SELECT SCOPE_IDENTITY() AS MesaID
END
GO

CREATE PROCEDURE SP_Mesas_Update
(
    @MesaID INT,
    @NumeroMesa INT,
    @Capacidad INT
)
AS
BEGIN
    UPDATE Mesas
    SET NumeroMesa = @NumeroMesa,
        Capacidad = @Capacidad
    WHERE MesaID = @MesaID
END
GO

CREATE PROCEDURE SP_Mesas_Delete
(
    @MesaID INT
)
AS
BEGIN
    DELETE FROM Mesas
    WHERE MesaID = @MesaID
END
GO

CREATE PROCEDURE SP_Mesas_Read
(
    @MesaID INT
)
AS
BEGIN
    SELECT * FROM Mesas
    WHERE MesaID = @MesaID
END
GO

--Procedimientos para menu
CREATE PROCEDURE SP_Menu_Index
AS
BEGIN
    SELECT * FROM Menu
END
GO

CREATE PROCEDURE SP_Menu_Create
(
    @NombrePlato NVARCHAR(100),
    @Precio DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO Menu (NombrePlato, Precio)
    VALUES (@NombrePlato, @Precio)
    
    SELECT SCOPE_IDENTITY() AS PlatoID
END
GO

CREATE PROCEDURE SP_Menu_Update
(
    @PlatoID INT,
    @NombrePlato NVARCHAR(100),
    @Precio DECIMAL(10, 2)
)
AS
BEGIN
    UPDATE Menu
    SET NombrePlato = @NombrePlato,
        Precio = @Precio
    WHERE PlatoID = @PlatoID
END
GO

CREATE PROCEDURE SP_Menu_Delete
(
    @PlatoID INT
)
AS
BEGIN
    DELETE FROM Menu
    WHERE PlatoID = @PlatoID
END
GO

CREATE PROCEDURE SP_Menu_Read
(
    @PlatoID INT
)
AS
BEGIN
    SELECT * FROM Menu
    WHERE PlatoID = @PlatoID
END
GO

--Procedimientos para pedidos

CREATE PROCEDURE SP_Pedidos_Index
AS
BEGIN
    SELECT * FROM Pedidos
END
GO

CREATE PROCEDURE SP_Pedidos_Create
(
    @ClienteID INT,
    @EmpleadoID INT,
    @MesaID INT,
    @ModoPedido NVARCHAR(50),
    @ClienteAnonimo BIT
)
AS
BEGIN
    INSERT INTO Pedidos (ClienteID, EmpleadoID, MesaID, ModoPedido, ClienteAnonimo)
    VALUES (@ClienteID, @EmpleadoID, @MesaID, @ModoPedido, @ClienteAnonimo)
    
    SELECT SCOPE_IDENTITY() AS PedidoID
END
GO

CREATE PROCEDURE SP_Pedidos_Update
(
    @PedidoID INT,
    @ClienteID INT,
    @EmpleadoID INT,
    @MesaID INT,
    @ModoPedido NVARCHAR(50),
    @ClienteAnonimo BIT
)
AS
BEGIN
    UPDATE Pedidos
    SET ClienteID = @ClienteID,
        EmpleadoID = @EmpleadoID,
        MesaID = @MesaID,
        ModoPedido = @ModoPedido,
        ClienteAnonimo = @ClienteAnonimo
    WHERE PedidoID = @PedidoID
END
GO

CREATE PROCEDURE SP_Pedidos_Delete
(
    @PedidoID INT
)
AS
BEGIN
    DELETE FROM Pedidos
    WHERE PedidoID = @PedidoID
END
GO

CREATE PROCEDURE SP_Pedidos_Read
(
    @PedidoID INT
)
AS
BEGIN
    SELECT * FROM Pedidos
    WHERE PedidoID = @PedidoID
END
GO

--Procedimientos para Resumen
CREATE PROCEDURE SP_Resumen_Index
AS
BEGIN
	SELECT * FROM Resumen
END
GO

CREATE PROCEDURE SP_Resumen_Create
(
	@PedidoID INT,
	@PlatoID INT,
	@Cantidad INT,
    @PrecioUnitario DECIMAL(10, 2),
    @Estado NVARCHAR(50)
)
AS
BEGIN
	INSERT INTO Resumen (PedidoID, PlatoID, Cantidad, PrecioUnitario, Estado)
	VALUES (@PedidoID, @PlatoID, @Cantidad, @PrecioUnitario, @Estado)
	SELECT SCOPE_IDENTITY() AS ResumenID
END
GO

CREATE PROCEDURE SP_Resumen_Update
(
	@ResumenID INT,
	@PedidoID INT,
	@PlatoID INT,
	@Cantidad INT,
    @PrecioUnitario DECIMAL(10, 2),
    @Estado NVARCHAR(50)
)
AS
BEGIN
	UPDATE Resumen 
	SET PedidoID = @PedidoID, 
		PlatoID = @PlatoID,
		Cantidad = @Cantidad, 
		PrecioUnitario = @PrecioUnitario, 
		Estado = @Estado
	WHERE ResumenID = @ResumenID
END
GO

CREATE PROCEDURE SP_Resumen_Delete
(
	@ResumenID INT
)
AS
BEGIN
	DELETE FROM Resumen
	WHERE ResumenID = @ResumenID
END
GO

CREATE PROCEDURE SP_Resumen_Read
(
	@ResumenID INT
)
AS
BEGIN
	SELECT * FROM Resumen
	WHERE ResumenID = @ResumenID
END
GO

--Procedimientos para Reservaciones

CREATE PROCEDURE SP_Reservaciones_Index
AS
BEGIN
	SELECT * FROM Reservaciones
END
GO

CREATE PROCEDURE SP_Reservaciones_Create
(
	@ClienteID INT = NULL,
	@EmpleadoID INT = NULL,
	@MesaID INT,
	@FechaReservacion DATETIME,
	@ClienteAnonimo BIT
)
AS
BEGIN
    INSERT INTO Reservaciones (ClienteID, EmpleadoID, MesaID, FechaReservacion, ClienteAnonimo)
    VALUES (@ClienteID, @EmpleadoID, @MesaID, @FechaReservacion, @ClienteAnonimo)
    
    SELECT SCOPE_IDENTITY() AS ReservacionID
END
GO

CREATE PROCEDURE SP_Reservaciones_Update
(
    @ReservacionID INT,
    @ClienteID INT,
    @EmpleadoID INT,
    @MesaID INT,
    @FechaReservacion DATETIME,
    @ClienteAnonimo BIT
)
AS
BEGIN
    UPDATE Reservaciones
    SET ClienteID = @ClienteID,
        EmpleadoID = @EmpleadoID,
        MesaID = @MesaID,
        FechaReservacion = @FechaReservacion,
        ClienteAnonimo = @ClienteAnonimo
    WHERE ReservacionID = @ReservacionID
END
GO

CREATE PROCEDURE SP_Reservaciones_Delete
(
    @ReservacionID INT
)
AS
BEGIN
    DELETE FROM Reservaciones
    WHERE ReservacionID = @ReservacionID
END
GO

CREATE PROCEDURE SP_Reservaciones_Read
(
    @ReservacionID INT
)
AS
BEGIN
    SELECT * FROM Reservaciones
    WHERE ReservacionID = @ReservacionID
END
GO
