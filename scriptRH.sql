USE [master]
GO
/****** Object:  Database [RecursosHumanos]    Script Date: 03/06/2020 7:06:56 ******/
CREATE DATABASE [RecursosHumanos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecursosHumanos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RecursosHumanos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RecursosHumanos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RecursosHumanos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RecursosHumanos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecursosHumanos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecursosHumanos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecursosHumanos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecursosHumanos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecursosHumanos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecursosHumanos] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecursosHumanos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RecursosHumanos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecursosHumanos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecursosHumanos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecursosHumanos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecursosHumanos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecursosHumanos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecursosHumanos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecursosHumanos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecursosHumanos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RecursosHumanos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecursosHumanos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecursosHumanos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecursosHumanos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecursosHumanos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecursosHumanos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RecursosHumanos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecursosHumanos] SET RECOVERY FULL 
GO
ALTER DATABASE [RecursosHumanos] SET  MULTI_USER 
GO
ALTER DATABASE [RecursosHumanos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecursosHumanos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecursosHumanos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecursosHumanos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RecursosHumanos] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RecursosHumanos', N'ON'
GO
ALTER DATABASE [RecursosHumanos] SET QUERY_STORE = OFF
GO
USE [RecursosHumanos]
GO
/****** Object:  Table [dbo].[Aguinaldo]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aguinaldo](
	[IdAguinaldo] [int] IDENTITY(1,1) NOT NULL,
	[FechaActual] [date] NULL,
	[Total] [decimal](12, 2) NULL,
	[IdContrato] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAguinaldo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contratos]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contratos](
	[IdContrato] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NULL,
	[Salario] [decimal](13, 2) NOT NULL,
	[JornadaLAboral] [nvarchar](100) NOT NULL,
	[DiasdeDescanso] [nvarchar](100) NOT NULL,
	[Fecha_de_contrato] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[IdDepartamentos] [int] IDENTITY(1,1) NOT NULL,
	[NombreDepartamento] [nvarchar](50) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDepartamentos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Sexo] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](100) NOT NULL,
	[Dui] [nvarchar](100) NOT NULL,
	[Nit] [nvarchar](100) NOT NULL,
	[Estado] [nvarchar](100) NOT NULL,
	[Tipo] [nvarchar](100) NOT NULL,
	[IdPuesto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorasExtras]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorasExtras](
	[IdHorasExtras] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[TablaHora] [int] NOT NULL,
	[PrecioHora] [decimal](12, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHorasExtras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[IdPuesto] [int] IDENTITY(1,1) NOT NULL,
	[NombrePuesto] [nvarchar](50) NOT NULL,
	[IdDepartamentos] [int] NOT NULL,
	[Descripcion] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rendimiento]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rendimiento](
	[IdRendimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[Observaciones] [nvarchar](300) NULL,
	[Rendimiento] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRendimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usaurios]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usaurios](
	[Idusuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Sexo] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](100) NOT NULL,
	[Estado] [nvarchar](100) NOT NULL,
	[usuario] [nvarchar](100) NOT NULL,
	[pass] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacaciones]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacaciones](
	[IdVacaciones] [int] IDENTITY(1,1) NOT NULL,
	[desde] [date] NOT NULL,
	[hasta] [date] NOT NULL,
	[IdContrato] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVacaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacantes]    Script Date: 03/06/2020 7:06:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacantes](
	[IdVacantes] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdPuesto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVacantes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aguinaldo]  WITH CHECK ADD  CONSTRAINT [FK_Aguinaldo_Contratos] FOREIGN KEY([IdContrato])
REFERENCES [dbo].[Contratos] ([IdContrato])
GO
ALTER TABLE [dbo].[Aguinaldo] CHECK CONSTRAINT [FK_Aguinaldo_Contratos]
GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [FK_Contratos_Empleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [FK_Contratos_Empleado]
GO
ALTER TABLE [dbo].[Departamentos]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([IdEmpresa])
GO
ALTER TABLE [dbo].[Departamentos] CHECK CONSTRAINT [FK_Departamento_Empresa]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Puestos] FOREIGN KEY([IdPuesto])
REFERENCES [dbo].[Puestos] ([IdPuesto])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Puestos]
GO
ALTER TABLE [dbo].[HorasExtras]  WITH CHECK ADD  CONSTRAINT [FK_HorasExtras_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[HorasExtras] CHECK CONSTRAINT [FK_HorasExtras_Empleados]
GO
ALTER TABLE [dbo].[Puestos]  WITH CHECK ADD  CONSTRAINT [FK_Puesto_Departamento] FOREIGN KEY([IdDepartamentos])
REFERENCES [dbo].[Departamentos] ([IdDepartamentos])
GO
ALTER TABLE [dbo].[Puestos] CHECK CONSTRAINT [FK_Puesto_Departamento]
GO
ALTER TABLE [dbo].[Rendimiento]  WITH CHECK ADD  CONSTRAINT [FK_Rendimiento_Empleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Rendimiento] CHECK CONSTRAINT [FK_Rendimiento_Empleados]
GO
ALTER TABLE [dbo].[Vacaciones]  WITH CHECK ADD  CONSTRAINT [FK_Vacaciones_Contratos] FOREIGN KEY([IdContrato])
REFERENCES [dbo].[Contratos] ([IdContrato])
GO
ALTER TABLE [dbo].[Vacaciones] CHECK CONSTRAINT [FK_Vacaciones_Contratos]
GO
ALTER TABLE [dbo].[Vacantes]  WITH CHECK ADD  CONSTRAINT [FK_Vacantes_Puesto] FOREIGN KEY([IdPuesto])
REFERENCES [dbo].[Puestos] ([IdPuesto])
GO
ALTER TABLE [dbo].[Vacantes] CHECK CONSTRAINT [FK_Vacantes_Puesto]
GO
USE [master]
GO
ALTER DATABASE [RecursosHumanos] SET  READ_WRITE 
GO
