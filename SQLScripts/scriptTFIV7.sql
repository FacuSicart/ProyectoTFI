USE [master]
GO
/****** Object:  Database [Proyecto TFI]    Script Date: 25/09/2023 16:46:09 ******/
CREATE DATABASE [Proyecto TFI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto TFI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Proyecto TFI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto TFI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Proyecto TFI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Proyecto TFI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto TFI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto TFI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto TFI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto TFI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto TFI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto TFI] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto TFI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proyecto TFI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto TFI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto TFI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto TFI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto TFI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto TFI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto TFI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto TFI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto TFI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Proyecto TFI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto TFI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto TFI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto TFI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto TFI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto TFI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto TFI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto TFI] SET RECOVERY FULL 
GO
ALTER DATABASE [Proyecto TFI] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto TFI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto TFI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto TFI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto TFI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proyecto TFI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proyecto TFI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Proyecto TFI', N'ON'
GO
ALTER DATABASE [Proyecto TFI] SET QUERY_STORE = OFF
GO
USE [Proyecto TFI]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Importancia] [int] NOT NULL,
	[Descripcion] [varchar](80) NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NULL,
	[LinkVideo] [varchar](500) NULL,
	[Activo] [bit] NULL,
	[CursoID] [int] NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursada_de_Alumno]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursada_de_Alumno](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoID] [int] NULL,
	[CursoID] [int] NULL,
 CONSTRAINT [PK_Cursada_de_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NULL,
	[Descripcion] [varchar](80) NULL,
	[Activo] [bit] NULL,
	[AdministradorID] [int] NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NULL,
 CONSTRAINT [PK_Docente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente_Curso]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente_Curso](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Activo] [bit] NULL,
	[CursoID] [int] NULL,
	[DocenteID] [int] NULL,
 CONSTRAINT [PK_Docente_Curso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpresa] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PrefijoTelefono] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[Monto] [int] NOT NULL,
	[TarjetaID] [int] NOT NULL,
 CONSTRAINT [PK_Donacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[PorcAprobacion] [int] NULL,
	[Activo] [bit] NULL,
	[ClaseID] [int] NULL,
 CONSTRAINT [PK_Quiz] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz_Conclusion]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Conclusion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Clasificacion] [int] NULL,
	[Fecha] [datetime] NULL,
	[Aprobado] [bit] NULL,
	[QuizCursadaDeAlumno] [int] NULL,
 CONSTRAINT [PK_Quiz_Conclusion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz_Cursada_de_Alumno]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Cursada_de_Alumno](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CursadaDeAlumnoID] [int] NULL,
	[QuizID] [int] NULL,
 CONSTRAINT [PK_Quiz_Cursada_de_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz_Pregunta]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Pregunta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionPregunta] [varchar](50) NULL,
	[QuizID] [int] NULL,
 CONSTRAINT [PK_Quiz_Pregunta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz_Pregunta_Opcion]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Pregunta_Opcion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionOpcion] [varchar](50) NULL,
	[Correcta] [bit] NULL,
	[QuizPreguntaID] [int] NULL,
 CONSTRAINT [PK_Quiz_Pregunta_Opcion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quiz_Respuesta]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quiz_Respuesta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuizCursadaDeAlumnoID] [int] NULL,
	[QuizPreguntaOpcionID] [int] NULL,
 CONSTRAINT [PK_Quiz_Respuesta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Respuesta]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Respuesta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](450) NOT NULL,
	[Fecha] [date] NOT NULL,
	[SolicitudID] [int] NOT NULL,
	[AdministradorID] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud_Respuesta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Soporte]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Soporte](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Asunto] [varchar](50) NOT NULL,
	[TipoConsulta] [varchar](50) NOT NULL,
	[Descripcion] [varchar](450) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
	[AlumnoID] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud_Soporte] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [bit] NULL,
	[Numero] [varchar](50) NULL,
	[FechaCaducidad] [int] NULL,
	[CVV] [int] NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/09/2023 16:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Apellido] [varchar](40) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[Email] [varchar](100) NULL,
	[Activo] [bit] NULL,
	[RolID] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [FK_Administrador_Usuario]
GO
ALTER TABLE [dbo].[Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Alumno_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Alumno] CHECK CONSTRAINT [FK_Alumno_Usuario]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_Usuario]
GO
ALTER TABLE [dbo].[Clase]  WITH CHECK ADD  CONSTRAINT [FK_Clase_Curso] FOREIGN KEY([CursoID])
REFERENCES [dbo].[Curso] ([ID])
GO
ALTER TABLE [dbo].[Clase] CHECK CONSTRAINT [FK_Clase_Curso]
GO
ALTER TABLE [dbo].[Cursada_de_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Cursada_de_Alumno_Alumno] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumno] ([ID])
GO
ALTER TABLE [dbo].[Cursada_de_Alumno] CHECK CONSTRAINT [FK_Cursada_de_Alumno_Alumno]
GO
ALTER TABLE [dbo].[Cursada_de_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Cursada_de_Alumno_Curso] FOREIGN KEY([CursoID])
REFERENCES [dbo].[Curso] ([ID])
GO
ALTER TABLE [dbo].[Cursada_de_Alumno] CHECK CONSTRAINT [FK_Cursada_de_Alumno_Curso]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Administrador] FOREIGN KEY([AdministradorID])
REFERENCES [dbo].[Administrador] ([ID])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Administrador]
GO
ALTER TABLE [dbo].[Docente]  WITH CHECK ADD  CONSTRAINT [FK_Docente_Usuario] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Docente] CHECK CONSTRAINT [FK_Docente_Usuario]
GO
ALTER TABLE [dbo].[Docente_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Docente_Curso_Curso] FOREIGN KEY([CursoID])
REFERENCES [dbo].[Curso] ([ID])
GO
ALTER TABLE [dbo].[Docente_Curso] CHECK CONSTRAINT [FK_Docente_Curso_Curso]
GO
ALTER TABLE [dbo].[Docente_Curso]  WITH CHECK ADD  CONSTRAINT [FK_Docente_Curso_Docente] FOREIGN KEY([DocenteID])
REFERENCES [dbo].[Docente] ([ID])
GO
ALTER TABLE [dbo].[Docente_Curso] CHECK CONSTRAINT [FK_Docente_Curso_Docente]
GO
ALTER TABLE [dbo].[Donacion]  WITH CHECK ADD  CONSTRAINT [FK_Donacion_Tarjeta] FOREIGN KEY([TarjetaID])
REFERENCES [dbo].[Tarjeta] ([ID])
GO
ALTER TABLE [dbo].[Donacion] CHECK CONSTRAINT [FK_Donacion_Tarjeta]
GO
ALTER TABLE [dbo].[Quiz]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Clase] FOREIGN KEY([ClaseID])
REFERENCES [dbo].[Clase] ([ID])
GO
ALTER TABLE [dbo].[Quiz] CHECK CONSTRAINT [FK_Quiz_Clase]
GO
ALTER TABLE [dbo].[Quiz_Cursada_de_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Cursada_de_Alumno_Cursada_de_Alumno] FOREIGN KEY([CursadaDeAlumnoID])
REFERENCES [dbo].[Cursada_de_Alumno] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Cursada_de_Alumno] CHECK CONSTRAINT [FK_Quiz_Cursada_de_Alumno_Cursada_de_Alumno]
GO
ALTER TABLE [dbo].[Quiz_Cursada_de_Alumno]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Cursada_de_Alumno_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Cursada_de_Alumno] CHECK CONSTRAINT [FK_Quiz_Cursada_de_Alumno_Quiz]
GO
ALTER TABLE [dbo].[Quiz_Pregunta]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Pregunta_Quiz] FOREIGN KEY([QuizID])
REFERENCES [dbo].[Quiz] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Pregunta] CHECK CONSTRAINT [FK_Quiz_Pregunta_Quiz]
GO
ALTER TABLE [dbo].[Quiz_Pregunta_Opcion]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Pregunta_Opcion_Quiz_Pregunta] FOREIGN KEY([QuizPreguntaID])
REFERENCES [dbo].[Quiz_Pregunta] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Pregunta_Opcion] CHECK CONSTRAINT [FK_Quiz_Pregunta_Opcion_Quiz_Pregunta]
GO
ALTER TABLE [dbo].[Quiz_Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Respuesta_Quiz_Cursada_de_Alumno] FOREIGN KEY([QuizCursadaDeAlumnoID])
REFERENCES [dbo].[Quiz_Cursada_de_Alumno] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Respuesta] CHECK CONSTRAINT [FK_Quiz_Respuesta_Quiz_Cursada_de_Alumno]
GO
ALTER TABLE [dbo].[Quiz_Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Quiz_Respuesta_Quiz_Pregunta_Opcion] FOREIGN KEY([QuizPreguntaOpcionID])
REFERENCES [dbo].[Quiz_Pregunta_Opcion] ([ID])
GO
ALTER TABLE [dbo].[Quiz_Respuesta] CHECK CONSTRAINT [FK_Quiz_Respuesta_Quiz_Pregunta_Opcion]
GO
ALTER TABLE [dbo].[Solicitud_Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Respuesta_Administrador] FOREIGN KEY([AdministradorID])
REFERENCES [dbo].[Administrador] ([ID])
GO
ALTER TABLE [dbo].[Solicitud_Respuesta] CHECK CONSTRAINT [FK_Solicitud_Respuesta_Administrador]
GO
ALTER TABLE [dbo].[Solicitud_Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Respuesta_Solicitud_Soporte] FOREIGN KEY([SolicitudID])
REFERENCES [dbo].[Solicitud_Soporte] ([ID])
GO
ALTER TABLE [dbo].[Solicitud_Respuesta] CHECK CONSTRAINT [FK_Solicitud_Respuesta_Solicitud_Soporte]
GO
ALTER TABLE [dbo].[Solicitud_Soporte]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Soporte_Alumno] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumno] ([ID])
GO
ALTER TABLE [dbo].[Solicitud_Soporte] CHECK CONSTRAINT [FK_Solicitud_Soporte_Alumno]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([ID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [Proyecto TFI] SET  READ_WRITE 
GO
