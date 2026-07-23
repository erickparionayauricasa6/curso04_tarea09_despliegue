-- Script para crear la base de datos y las tablas de la API (Libros y Usuarios)
-- Puede ejecutarse en SQL Server Management Studio (Gestor de Base de Datos)

CREATE DATABASE CursoNetCore_DB;
GO

USE CursoNetCore_DB;
GO

-- Crear tabla Libros
CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(150) NOT NULL,
    Autor NVARCHAR(150) NOT NULL,
    Isbn NVARCHAR(50) NOT NULL,
    FechaPublicacion DATETIME2 NOT NULL,
    Precio DECIMAL(18,2) NOT NULL
);
GO

-- Crear tabla Usuarios (Para autenticación JWT)
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);
GO

-- Insertar datos de prueba
INSERT INTO Usuarios (NombreUsuario, Email, Password) 
VALUES ('admin', 'admin@admin.com', '123456');
GO

INSERT INTO Libros (Titulo, Autor, Isbn, FechaPublicacion, Precio) 
VALUES ('Clean Code: A Handbook of Agile Software Craftsmanship', 'Robert C. Martin', '978-0132350884', '2008-08-01', 45.50);

INSERT INTO Libros (Titulo, Autor, Isbn, FechaPublicacion, Precio) 
VALUES ('Pro ASP.NET Core 9', 'Adam Freeman', '978-1484212345', '2025-01-01', 55.00);
GO
