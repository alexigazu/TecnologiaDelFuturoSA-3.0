CREATE TABLE [dbo].[Trabajadores]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NCHAR(60) NOT NULL, 
    [Puesto] NCHAR(30) NOT NULL, 
    [Edad] INT NOT NULL, 
    [Sexo] NCHAR(1) NOT NULL, 
    [Fecha de ingreso] DATE NOT NULL, 
    [Salario básico] MONEY NOT NULL
)
