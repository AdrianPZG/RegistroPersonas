DROP TABLE IF EXISTS Usuarios;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY (1,1),
    Usuario NVARCHAR(50) NOT NULL UNIQUE,
    Contrasena NVARCHAR(50) NOT NULL
);
INSERT INTO Usuarios (Usuario, Contrasena) VALUES ('admin', '1234');


CREATE TABLE Personas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50) NOT NULL,
    ApellidoPaterno NVARCHAR(50) NOT NULL,
    ApellidoMaterno NVARCHAR(50),
    Calle NVARCHAR(100) NOT NULL,
    Numero NVARCHAR(10),
    Colonia NVARCHAR(100) NOT NULL,
    CP NVARCHAR(10) NOT NULL,
    Municipio NVARCHAR(50),
    Estado NVARCHAR(50),
    Email NVARCHAR(100) NOT NULL
);

CREATE TABLE Persona (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    ApellidoPaterno NVARCHAR(50) NOT NULL,
    ApellidoMaterno NVARCHAR(50) NULL,
    Calle NVARCHAR(100) NOT NULL,
    Numero NVARCHAR(10) NULL,
    Colonia NVARCHAR(50) NOT NULL,
    CP NVARCHAR(10) NOT NULL,
    Municipio NVARCHAR(50) NULL,
    Estado NVARCHAR(50) NULL,
    Email NVARCHAR(100) NOT NULL
);

