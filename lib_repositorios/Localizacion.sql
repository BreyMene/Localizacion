CREATE DATABASE db_Localizacion --Se crea la base de datos db_Localizacion
GO

USE db_Localizacion
GO

--Crear tabla de 'Coordenadas'
CREATE TABLE [Coordenadas] (
	[Id] INT NOT NULL IDENTITY (1,1), --Id de la coordenada (Llave Primaria), Autogenerada
	[Latitud] NVARCHAR(50) NOT NULL, --Latitud de la coordenada (de norte a sur), tipo NVARCHAR de 50 digitos, no nulos
	[Longitud] NVARCHAR(50) NOT NULL, --Longitud horizontal (De este a oeste), tipo NVARCHAR de 50 digitos, no nulos
	CONSTRAINT PK_Coordenadas PRIMARY KEY CLUSTERED ([Id]) --Constraint de Primary Key
);
GO

--Crear tabla de 'Personas'
CREATE TABLE [Personas] (
	[Id] INT NOT NULL IDENTITY (1,1), --Id de la Persona (Llave Primaria), tipo int, Autogenerada
	[Cedula] NVARCHAR(50) NOT NULL, --Cedula, tipo NVARCHAR de 50 digitos, no nulos
	[Nombre] NVARCHAR(50) NOT NULL,--Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Contrasena] NVARCHAR(50) NOT NULL, --Contraseña, tipo NVARCHAR de 50 digitos, no nulos
	CONSTRAINT PK_Personas PRIMARY KEY CLUSTERED ([Id]) --Constraint de Primary Key
);
GO

--Crear tabla de 'Paises'
CREATE TABLE [Paises] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	[Nombre] NVARCHAR(50) NOT NULL,-- Nombre, tipo NVARCHAR de 50 digitos, no nulos
	CONSTRAINT PK_Paises PRIMARY KEY CLUSTERED ([Id]) --Constraint de Primary Key
);
GO

--Crear tabla de 'Departamentos'
CREATE TABLE [Departamentos] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	[Nombre] NVARCHAR(50) NOT NULL,--Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Pais] INT NOT NULL,--Id del pais al que pertenece, no admite nulos (todo departamento pertenece a un país)
	CONSTRAINT PK_Departamentos PRIMARY KEY CLUSTERED ([Id]),--Constraint de Primary Key
	CONSTRAINT FK_Departamentos_Paises FOREIGN KEY ([Pais]) REFERENCES [Paises] ([Id]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre departamentos y paises, evitando borrado en cascada
);
GO

--Crear tabla de 'Ciudades'
CREATE TABLE [Ciudades] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	[Nombre] NVARCHAR(50) NOT NULL, --Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Departamento] INT NOT NULL, --Id del departamento al que pertenece, no admite nulos (toda ciudad pertenece a un Departamento)
	CONSTRAINT PK_Ciudades PRIMARY KEY CLUSTERED ([Id]),--Constraint de Primary Key
	CONSTRAINT FK_Ciudades_Departamentos FOREIGN KEY ([Departamento]) REFERENCES [Departamentos] ([Id]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre ciudades y departamentos, evitando borrado en cascada
);
GO

--Crear tabla de 'Barrios'
CREATE TABLE [Barrios] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	Nombre NVARCHAR(50) NOT NULL,--Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Ciudad] INT NOT NULL,--Id de al ciudad a la que pertenece, no admite nulos (todo Barrio pertenece a una Ciudad)
	CONSTRAINT PK_Barrios PRIMARY KEY CLUSTERED ([Id]),--Constraint de Primary Key
	CONSTRAINT FK_Barrios_Ciudades FOREIGN KEY ([Ciudad]) REFERENCES [Ciudades] ([Id]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre Barrios y ciudades, evitando borrado en cascada
);
GO

--Crear tabla de 'Ubicaciones'
CREATE TABLE [Ubicaciones] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	[Descripcion] NVARCHAR(150) NOT NULL,--Descripcion, tipo NVARCHAR de 150 digitos, no nulos
	[Imagen] NVARCHAR(100) NOT NULL,--Imagen, tipo NVARCHAR de 100 digitos, no nulos (El tipo de imagen no se ha definido)
	[Nombre] NVARCHAR(50) NOT NULL,--Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Barrio] INT NOT NULL,--Id del Barrio al que pertenece, no admite nulos (toda Ubicacion pertenece a un Barrio)
	[Coordenada] INT NOT NULL,--Id de la Coordenada a la que pertenece, no admite nulos (toda Ubicacion tiene una Coordenada)
	CONSTRAINT PK_Ubicaciones PRIMARY KEY CLUSTERED ([Id]),--Constraint de Primary Key
	CONSTRAINT FK_Barrios_Ubicaciones FOREIGN KEY ([Barrio]) REFERENCES [Barrios] ([Id]) ON DELETE No Action ON UPDATE No Action, --constraint de Foreign key entre Ubicaciones y Barrios, evitando borrado en cascada
	CONSTRAINT FK_Barrios_Coordenada FOREIGN KEY ([Coordenada]) REFERENCES [Coordenadas] ([Id]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre Ubicaciones y Coordenadas, evitando borrado en cascada
);
GO

--Crear tabla en 'Detalles'
CREATE TABLE [Detalles] (
	[ID] INT NOT NULL IDENTITY (1,1),--Id de la  (Llave Primaria), Autogenerada
	[Fecha] SMALLDATETIME NOT NULL DEFAULT GETDATE(), --Fecha del Detalle, no nula, por defecto se toma la fecha actual
	[Ubicacion] INT NOT NULL, --Id de la Ubicacion a la que pertenece, no admite nulos (todo Detalle tiene una Ubicacion)
	[Persona] INT NOT NULL, --Id de la Persona a la que pertenece, no admite nulos (todo Detalle tiene una Persona)
	CONSTRAINT PK_Detalles PRIMARY KEY CLUSTERED ([ID]),--Constraint de Primary Key
	CONSTRAINT FK_Detalles_Ubicaciones FOREIGN KEY ([Ubicacion]) REFERENCES [Ubicaciones] ([Id]) ON DELETE No Action ON UPDATE No Action,--constraint de Foreign key entre Detalles y Ubicaciones, evitando borrado en cascada
	CONSTRAINT FK_Detalles_Personas FOREIGN KEY ([Persona]) REFERENCES [Personas] ([ID]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre Detalles y Personas, evitando borrado en cascada
);
GO

-- Insertar datos en 'Paises'
INSERT INTO Paises (Nombre) VALUES ('Colombia');
INSERT INTO Paises (Nombre) VALUES ('Mexico');
INSERT INTO Paises (Nombre) VALUES ('Argentina');
INSERT INTO Paises (Nombre) VALUES ('Brasil');
GO

-- Insertar datos en 'Departamentos'
INSERT INTO Departamentos ([Pais], Nombre) VALUES (1, 'Antioquia');
INSERT INTO Departamentos ([Pais], Nombre) VALUES (1, 'Cundinamarca');
INSERT INTO Departamentos ([Pais], Nombre) VALUES (4, 'Estado de Sao Paulo');
INSERT INTO Departamentos ([Pais], Nombre) VALUES (3, 'Provincia de Buenos Aires');
GO

-- Insertar datos en 'Ciudades'
INSERT INTO Ciudades ([Departamento], Nombre) VALUES (1, 'Medellin');
INSERT INTO Ciudades ([Departamento], Nombre) VALUES (2, 'Bogotá');
INSERT INTO Ciudades ([Departamento], Nombre) VALUES (4, 'Buenos Aires');
INSERT INTO Ciudades ([Departamento], Nombre) VALUES (3, 'Sao Paulo');
GO

-- Insertar datos en 'Barrios'
INSERT INTO Barrios ([Ciudad], Nombre) VALUES (1, 'Poblado');
INSERT INTO Barrios ([Ciudad], Nombre) VALUES (1, 'Laureles');
INSERT INTO Barrios ([Ciudad], Nombre) VALUES (3, 'Palermo');
INSERT INTO Barrios ([Ciudad], Nombre) VALUES (4, 'Bela Vista');
GO

-- Insertar datos en 'Coordenadas'
INSERT INTO Coordenadas (Latitud, Longitud) VALUES ('6.235925', '-75.575138');
INSERT INTO Coordenadas (Latitud, Longitud) VALUES ('6.244203', '-75.581212');
INSERT INTO Coordenadas (Latitud, Longitud) VALUES ('-34.603722', '-58.381592');
INSERT INTO Coordenadas (Latitud, Longitud) VALUES ('-23.55052', '-46.633308');
GO

-- Insertar datos en 'Ubicaciones'
INSERT INTO Ubicaciones (Coordenada, Barrio, Descripcion, Imagen, Nombre) 
VALUES (1, 1, 'Cerca de...', 'img1', 'Parque poblado');
INSERT INTO Ubicaciones (Coordenada, Barrio, Descripcion, Imagen, Nombre) 
VALUES (2, 1, 'Al lado de...', 'img2', 'Centro comercial');
INSERT INTO Ubicaciones (Coordenada, Barrio, Descripcion, Imagen, Nombre) 
VALUES (3, 3, 'Cerca del centro', 'img3', 'Palermo Central');
INSERT INTO Ubicaciones (Coordenada, Barrio, Descripcion, Imagen, Nombre) 
VALUES (4, 4, 'Vistas excelentes', 'img4', 'Torres de Bela Vista');
GO

-- Insertar datos en 'Personas'
INSERT INTO Personas (Cedula, Nombre, Contrasena) VALUES ('1234567890', 'Juan Pérez', 'pass123');
INSERT INTO Personas (Cedula, Nombre, Contrasena) VALUES ('9876543210', 'María López', 'pass456');
INSERT INTO Personas (Cedula, Nombre, Contrasena) VALUES ('1111222233', 'Carlos Garcia', 'pass789');
INSERT INTO Personas (Cedula, Nombre, Contrasena) VALUES ('4444555566', 'Ana Silva', 'pass123');
GO

-- Insertar datos en 'Detalles'
INSERT INTO Detalles ([Ubicacion], Persona, Fecha) VALUES (1, 1, '2023-09-01');
INSERT INTO Detalles ([Ubicacion], Persona, Fecha) VALUES (2, 3, '2023-09-05');
INSERT INTO Detalles ([Ubicacion], Persona, Fecha) VALUES (3, 4, '2023-09-10');
INSERT INTO Detalles ([Ubicacion], Persona, Fecha) VALUES (4, 2, '2023-09-15');
GO