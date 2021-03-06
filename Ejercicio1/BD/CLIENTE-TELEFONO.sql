USE [master]
GO
/****** Object:  Database [Ejercicio1]    Script Date: 27/10/2015 15:53:01 ******/
CREATE DATABASE [Ejercicio1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ejercicio1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Ejercicio1.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ejercicio1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Ejercicio1_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ejercicio1] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ejercicio1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ejercicio1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ejercicio1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ejercicio1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ejercicio1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ejercicio1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ejercicio1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ejercicio1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Ejercicio1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ejercicio1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ejercicio1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ejercicio1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ejercicio1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ejercicio1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ejercicio1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ejercicio1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ejercicio1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ejercicio1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ejercicio1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ejercicio1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ejercicio1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ejercicio1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ejercicio1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ejercicio1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ejercicio1] SET RECOVERY FULL 
GO
ALTER DATABASE [Ejercicio1] SET  MULTI_USER 
GO
ALTER DATABASE [Ejercicio1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ejercicio1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ejercicio1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ejercicio1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ejercicio1', N'ON'
GO
USE [Ejercicio1]
GO
/****** Object:  StoredProcedure [dbo].[s_AltaAlumno]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_AltaAlumno]
	@Nombre varchar(50),
	@Apellido varchar(50),
	@FechaNac date,
	@Numero varchar(50),
	@Zona varchar(50),
	@Detalle varchar(50),
	@Facultad_Id int
AS
BEGIN

	INSERT INTO Telefonos (Numero,Zona,Detalle)
	VALUES (@Numero,@Zona,@Detalle);

	DECLARE @Telefono_Id int
	SET @Telefono_Id = (SELECT MAX(Id) FROM [dbo].[Telefonos])
	
	INSERT INTO Alumnos(Nombre,Apellido,FechaNac,Telefono_Id,Facultad_Id) 
	VALUES (@Nombre,@Apellido,@FechaNac,@Telefono_Id,@Facultad_Id);

END

GO
/****** Object:  StoredProcedure [dbo].[s_ConsultarPorIdAlumno]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ConsultarPorIdAlumno]
	@Id int
AS
BEGIN

	SELECT A.Id,A.Nombre,A.Apellido,A.FechaNac,T.Numero,T.Zona,T.Detalle,F.Nombre as FacNombre,F.Id as FacId
	FROM Alumnos A, Telefonos T, Facultades F
	WHERE A.Id = @Id AND A.Telefono_Id = T.Id AND Facultad_Id = F.Id

END

GO
/****** Object:  StoredProcedure [dbo].[s_EditarAlumno]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_EditarAlumno]
	@Id int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@FechaNac date,
	@Numero varchar(50),
	@Zona varchar(50),
	@Detalle varchar(50),
	@Facultad_Id int
AS
BEGIN

	UPDATE Alumnos SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, Facultad_Id = @Facultad_Id WHERE ID = @Id

	UPDATE Telefonos SET Numero = @Numero, Zona = @Zona, Detalle = @Detalle WHERE Id = (SELECT Telefono_Id FROM Alumnos WHERE Id = @Id)

END

GO
/****** Object:  StoredProcedure [dbo].[s_EliminarAlumno]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_EliminarAlumno]
	@Id int
AS
BEGIN
	DECLARE @TelefonoId int
	SET @TelefonoId = (SELECT Telefono_Id FROM Alumnos WHERE Id = @Id)
	DELETE FROM Alumnos WHERE Id = @Id
	DELETE FROM Telefonos WHERE Id = @TelefonoId
	

END

GO
/****** Object:  StoredProcedure [dbo].[s_ListarAlumno]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ListarAlumno]
AS
BEGIN

	SELECT A.Id,A.Nombre,Apellido,FechaNac,Numero,Zona,Detalle,F.Nombre as FacNombre 
	FROM Alumnos A, Telefonos T, Facultades F
	WHERE Telefono_Id = T.Id AND Facultad_Id = F.Id

END

GO
/****** Object:  StoredProcedure [dbo].[s_ListarFacultad]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_ListarFacultad]
AS
BEGIN

	SELECT Id,Nombre 
	FROM Facultades

END

GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNac] [date] NOT NULL,
	[Telefono_Id] [int] NULL,
	[Facultad_Id] [int] NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facultades]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facultades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Facultades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Telefonos]    Script Date: 27/10/2015 15:53:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Telefonos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Zona] [varchar](50) NOT NULL,
	[Detalle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Telefonos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Facultades] FOREIGN KEY([Facultad_Id])
REFERENCES [dbo].[Facultades] ([Id])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Facultades]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Telefonos] FOREIGN KEY([Telefono_Id])
REFERENCES [dbo].[Telefonos] ([Id])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Telefonos]
GO
USE [master]
GO
ALTER DATABASE [Ejercicio1] SET  READ_WRITE 
GO
