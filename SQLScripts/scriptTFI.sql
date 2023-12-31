USE [Proyecto TFI]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Admi_Codigo] [int] NOT NULL,
	[Admi_User_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[Admi_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Alum_Codigo] [int] NOT NULL,
	[Alum_User_Codigo] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[Alum_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Bita_Codigo] [int] NOT NULL,
	[Bita_Fecha] [datetime] NOT NULL,
	[Bita_Nivel_Importancia] [int] NOT NULL,
	[Bita_Descripcion] [varchar](80) NOT NULL,
	[Bita_User_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Bita_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clase]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[Clas_Codigo] [int] NOT NULL,
	[Clas_Descripcion] [varchar](500) NULL,
	[Clas_Activo] [bit] NULL,
	[Clas_Curs_Codigo] [int] NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[Clas_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursada_de_Alumno]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursada_de_Alumno](
	[CurAlu_Codigo] [int] NOT NULL,
	[CurAlu_Alum_Codigo] [int] NULL,
	[CurAlu_Curs_Codigo] [int] NULL,
 CONSTRAINT [PK_Cursada_de_Alumno] PRIMARY KEY CLUSTERED 
(
	[CurAlu_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Curs_Codigo] [int] NOT NULL,
	[Curs_Nombre] [varchar](30) NULL,
	[Curs_Descripcion] [varchar](80) NULL,
	[Curs_Activo] [bit] NULL,
	[Curs_Admi_Codigo] [int] NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[Curs_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[Doce_Codigo] [int] NOT NULL,
	[Doce_User_Codigo] [int] NULL,
 CONSTRAINT [PK_Docente] PRIMARY KEY CLUSTERED 
(
	[Doce_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente_Curso]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente_Curso](
	[DocCur_Codigo] [int] NOT NULL,
	[DocCur_Activo] [bit] NULL,
	[DocCur_Curs_Codigo] [int] NULL,
	[DocCur_Doce_Codigo] [int] NULL,
 CONSTRAINT [PK_Docente_Curso] PRIMARY KEY CLUSTERED 
(
	[DocCur_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[Dona_Codigo] [int] NOT NULL,
	[Dona_Empresa_Nombre] [varchar](50) NOT NULL,
	[Dona_Email] [varchar](100) NOT NULL,
	[Dona_Prefijo_Telefono] [int] NOT NULL,
	[Dona_Num_Telefono] [int] NOT NULL,
	[Dona_Monto] [decimal](18, 0) NOT NULL,
	[Dona_Tarje_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Donacion] PRIMARY KEY CLUSTERED 
(
	[Dona_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Rol_Codigo] [int] NULL,
	[Rol_Nombre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Respuesta]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Respuesta](
	[SoliR_Codigo] [int] NOT NULL,
	[SoliR_Descripcion] [varchar](450) NOT NULL,
	[SoliR_Fecha] [date] NOT NULL,
	[SoliR_Soli_Codigo] [int] NOT NULL,
	[SoliR_Admi_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud_Respuesta] PRIMARY KEY CLUSTERED 
(
	[SoliR_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Soporte]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Soporte](
	[Soli_Codigo] [int] NOT NULL,
	[Soli_Asunto] [varchar](50) NOT NULL,
	[Soli_Tipo_Consulta] [varchar](50) NOT NULL,
	[Soli_Descripcion] [varchar](450) NOT NULL,
	[Soli_Fecha] [date] NOT NULL,
	[Soli_Activo] [bit] NOT NULL,
	[Soli_Alum_Codigo] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud_Soporte] PRIMARY KEY CLUSTERED 
(
	[Soli_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[Tarje_Codigo] [int] NULL,
	[Tarje_Tipo] [bit] NULL,
	[Tarje_Numero] [varchar](50) NULL,
	[Tarje_Mes_Caducidad] [int] NULL,
	[Tarje_Ano_Caducidad] [int] NULL,
	[Tarje_Codigo_Seguridad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/08/2023 18:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[User_Codigo] [int] NOT NULL,
	[User_Nombre] [varchar](50) NOT NULL,
	[User_Contrasena] [varchar](50) NOT NULL,
	[User_Nombre_Real] [varchar](40) NOT NULL,
	[User_Apellido] [varchar](40) NOT NULL,
	[User_DNI] [varchar](8) NOT NULL,
	[User_Fecha_Nacimiento] [date] NULL,
	[User_Email] [varchar](100) NULL,
	[User_Activo] [bit] NULL,
	[User_Rol_Codigo] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[User_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (1, N'Web Master')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (2, N'Administrador')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (3, N'Docente')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (4, N'Alumno')
GO
INSERT [dbo].[Usuario] ([User_Codigo], [User_Nombre], [User_Contrasena], [User_Nombre_Real], [User_Apellido], [User_DNI], [User_Fecha_Nacimiento], [User_Email], [User_Activo], [User_Rol_Codigo]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'12345678', CAST(N'2000-01-01' AS Date), N'a@a.com', 1, 1)
GO
