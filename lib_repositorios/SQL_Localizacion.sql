CREATE DATABASE db_Localizacion --Se crea la base de datos db_Localizacion
GO

USE db_Localizacion
GO

--Crear tabla de 'Roles'
CREATE TABLE [Roles] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id del rol (Llave Primaria), Autogenerada
	[Nombre] NVARCHAR(10) NOT NULL,-- Nombre, tipo NVARCHAR de 50 digitos, no nulos
	CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED ([Id]) --Constraint de Primary Key
);
GO

--Crear tabla de 'Coordenadas'
CREATE TABLE [Coordenadas] (
	[Id] INT NOT NULL IDENTITY (1,1), --Id de la coordenada (Llave Primaria), Autogenerada
	[Latitud] NVARCHAR(50) NOT NULL, --Latitud de la coordenada (de norte a sur), tipo NVARCHAR de 50 digitos, no nulos
	[Longitud] NVARCHAR(50) NOT NULL, --Longitud horizontal (De este a oeste), tipo NVARCHAR de 50 digitos, no nulos
	CONSTRAINT PK_Coordenadas PRIMARY KEY CLUSTERED ([Id]) --Constraint de Primary Key
);
GO

--Crear tabla de 'Usuarios'
CREATE TABLE [Usuarios] (
	[Id] INT NOT NULL IDENTITY (1,1), --Id del Usuario (Llave Primaria), tipo int, Autogenerada
	[Cedula] NVARCHAR(50) NOT NULL, --Cedula, tipo NVARCHAR de 50 digitos, no nulos
	[Nombre] NVARCHAR(50) NOT NULL,--Nombre, tipo NVARCHAR de 50 digitos, no nulos
	[Contrasena] NVARCHAR(50) NOT NULL, --Contraseña, tipo NVARCHAR de 50 digitos, no nulos
	[Rol] INT NOT NULL, -- Rol del usuario, tipo Entero, no nulo
	CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED ([Id]), --Constraint de Primary Key
	CONSTRAINT FK_Uuarios_Roles FOREIGN KEY ([Rol]) REFERENCES [Roles] ([Id]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre Usuarios y Roles, evitando borrado en cascada
);
GO

--Crear tabla de 'Paises'
CREATE TABLE [Paises] (
	[Id] INT NOT NULL IDENTITY (1,1),--Id del pais  (Llave Primaria), Autogenerada
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
	[Imagen] NVARCHAR(MAX) NOT NULL,--Imagen, tipo NVARCHAR(MAX), no nulos (El tipo de imagen Base64)
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
	[Usuario] INT NOT NULL, --Id del Usuario a la que pertenece, no admite nulos (todo Detalle tiene una Usuario)
	CONSTRAINT PK_Detalles PRIMARY KEY CLUSTERED ([ID]),--Constraint de Primary Key
	CONSTRAINT FK_Detalles_Ubicaciones FOREIGN KEY ([Ubicacion]) REFERENCES [Ubicaciones] ([Id]) ON DELETE No Action ON UPDATE No Action,--constraint de Foreign key entre Detalles y Ubicaciones, evitando borrado en cascada
	CONSTRAINT FK_Detalles_Usuarios FOREIGN KEY ([Usuario]) REFERENCES [Usuarios] ([ID]) ON DELETE No Action ON UPDATE No Action --constraint de Foreign key entre Detalles y Usuarios, evitando borrado en cascada
);
GO
