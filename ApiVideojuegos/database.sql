CREATE DATABASE ApiVideojuegosDb;
GO

USE ApiVideojuegosDb;
GO

CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Activo BIT NOT NULL
);
GO

CREATE TABLE Videojuegos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    CategoriaId INT NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT FK_Videojuegos_Categorias
        FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

INSERT INTO Categorias (Nombre, Activo) VALUES
('Acción', 1),
('Aventura', 1),
('RPG', 1);
GO

INSERT INTO Videojuegos (Nombre, Descripcion, CategoriaId, Activo) VALUES
('DOOM Eternal', 'Shooter frenético de acción.', 1, 1),
('The Legend of Zelda', 'Aventura clásica con exploración.', 2, 1),
('Final Fantasy X', 'Juego de rol por turnos.', 3, 1);
GO