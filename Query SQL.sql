-- Crear base de datos
CREATE DATABASE VeroTours
GO

-- Usar la base de datos
USE VeroTours
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1),
	Contraseña VARCHAR NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Telefono NVARCHAR(15),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioID)
);

INSERT INTO Usuarios VALUES ('hola', 'Vero', 'Castro', 'vero@correo.com', '12345678', SYSDATETIME());

-- Tabla de Aeropuertos
CREATE TABLE Aeropuertos (
    AeropuertoID INT IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Codigo NVARCHAR(10) NOT NULL UNIQUE,
    Ciudad NVARCHAR(100) NOT NULL,
    Pais NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Aeropuertos PRIMARY KEY (AeropuertoID)
);

INSERT INTO Aeropuertos VALUES ('Juan Santamaria', 'SJO', 'San José', 'Costa Rica');
INSERT INTO Aeropuertos VALUES ('Miami', 'MIA', 'Miami', 'Estados Unidos');

-- Tabla de Aerolineas
CREATE TABLE Aerolineas (
    AerolineaID INT IDENTITY(1,1),
    Nombre NVARCHAR(150) NOT NULL,
    Codigo NVARCHAR(10) NOT NULL UNIQUE,
    CONSTRAINT PK_Aerolineas PRIMARY KEY (AerolineaID)
);

INSERT INTO Aerolineas VALUES ('Avianca', 'AV');
INSERT INTO Aerolineas VALUES ('Continental Airlines', 'CA');

-- Tabla de Vuelos
CREATE TABLE Vuelos (
    VueloID INT IDENTITY(1,1),
    AerolineaID INT NOT NULL,
    OrigenID INT NOT NULL,
    DestinoID INT NOT NULL,
    FechaHoraSalida DATETIME NOT NULL,
    FechaHoraLlegada DATETIME NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PK_Vuelos PRIMARY KEY (VueloID),
    CONSTRAINT FK_Vuelos_Aerolineas FOREIGN KEY (AerolineaID) REFERENCES Aerolineas(AerolineaID) ON DELETE CASCADE,
    CONSTRAINT FK_Vuelos_Origen FOREIGN KEY (OrigenID) REFERENCES Aeropuertos(AeropuertoID),
    CONSTRAINT FK_Vuelos_Destino FOREIGN KEY (DestinoID) REFERENCES Aeropuertos(AeropuertoID)
);

-- Tabla de Reservas
CREATE TABLE Reservas (
    ReservaID INT IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    VueloID INT NOT NULL,
    FechaReserva DATETIME DEFAULT GETDATE(),
    CantidadPasajeros INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PK_Reservas PRIMARY KEY (ReservaID),
    CONSTRAINT FK_Reservas_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID) ON DELETE CASCADE,
    CONSTRAINT FK_Reservas_Vuelos FOREIGN KEY (VueloID) REFERENCES Vuelos(VueloID) ON DELETE CASCADE
);
GO

-- Se crea un trigger para eliminar los vuelos asocioados a aeropuertos
CREATE TRIGGER TriggerEliminarAeropuerto
ON Aeropuertos
INSTEAD OF DELETE
AS
BEGIN
    -- Se eliminan los vuelos con el aeropuerto a eliminar
    DELETE FROM Vuelos 
    WHERE OrigenID IN (SELECT AeropuertoID FROM DELETED)
    OR DestinoID IN (SELECT AeropuertoID FROM DELETED);

    -- Se elimina el aeropuerto
    DELETE FROM Aeropuertos 
    WHERE AeropuertoID IN (SELECT AeropuertoID FROM DELETED);
END;

