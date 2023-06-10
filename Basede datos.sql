Create database Practica

use Practica
Create Table Usuario
(
IdUsuario INT IDENTITY(1,1) Primary key,
Nombre varchar(50),
ApellidoMaterno varchar(50),
ApellidoPaterno varchar(50),
FechaNacimiento varchar(50),
Edad int
)

Select IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Edad from Usuario
go

Create procedure AddUsuario
@opcion int,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento VARCHAR(50)
AS
if(@opcion =1)

iNSERT INTO Usuario (Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento)
				VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento)
----Where @FechaNacimiento ==(convert(datetime,@FechaNacimiento) )

if(@opcion = 2)

Select IdUsuario, Nombre, ApellidoPaterno,@ApellidoMaterno, FechaNacimiento, Edad from Usuario

exec AddUsuario 1,'Ulises','Esteban','Valdes','24/09/1998'

exec AddUsuario 2,'','','',''


--------modificaciones
exec AddUsuario 1,'Ulises','Esteban','Valdes','1998-09-18'

alter table usuario 
ALTER COLUMN FechaNacimiento DATE

truncate table Usuario

ALTER procedure [dbo].[AddUsuario]
@opcion int,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento DATE
AS
if(@opcion =1)

iNSERT INTO Usuario (Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Edad)
				VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,DATEDIFF(YEAR,@FechaNacimiento,GETDATE()))

if(@opcion = 2)

Select IdUsuario, Nombre, ApellidoPaterno,ApellidoMaterno, FechaNacimiento, Edad from Usuario