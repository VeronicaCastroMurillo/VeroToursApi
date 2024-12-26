

-- Usar la base de datos
USE VeroTours;
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
	Contraseña VARCHAR NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    Telefono NVARCHAR(15),
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Tabla de Aeropuertos
CREATE TABLE Aeropuertos (
    AeropuertoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Codigo NVARCHAR(10) NOT NULL UNIQUE,
    Ciudad NVARCHAR(100) NOT NULL,
    Pais NVARCHAR(100) NOT NULL
);

-- Tabla de Aerolíneas
CREATE TABLE Aerolineas (
    AerolineaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Codigo NVARCHAR(10) NOT NULL UNIQUE
);

-- Tabla de Vuelos
CREATE TABLE Vuelos (
    VueloID INT IDENTITY(1,1) PRIMARY KEY,
    AerolineaID INT NOT NULL,
    OrigenID INT NOT NULL,
    DestinoID INT NOT NULL,
    FechaHoraSalida DATETIME NOT NULL,
    FechaHoraLlegada DATETIME NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Vuelos_Aerolineas FOREIGN KEY (AerolineaID) REFERENCES Aerolineas(AerolineaID),
    CONSTRAINT FK_Vuelos_Origen FOREIGN KEY (OrigenID) REFERENCES Aeropuertos(AeropuertoID),
    CONSTRAINT FK_Vuelos_Destino FOREIGN KEY (DestinoID) REFERENCES Aeropuertos(AeropuertoID)
);

-- Tabla de Reservas
CREATE TABLE Reservas (
    ReservaID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL,
    VueloID INT NOT NULL,
    FechaReserva DATETIME DEFAULT GETDATE(),
    CantidadPasajeros INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Reservas_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    CONSTRAINT FK_Reservas_Vuelos FOREIGN KEY (VueloID) REFERENCES Vuelos(VueloID)
);
