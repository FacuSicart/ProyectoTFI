USE [Proyecto TFI]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[ID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[ID] [int] NOT NULL,
	[UsuarioID] [int] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Clase]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[ID] [int] NOT NULL,
	[Descripcion] [varchar](500) NULL,
	[Activo] [bit] NULL,
	[CursoID] [int] NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursada_de_Alumno]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursada_de_Alumno](
	[ID] [int] NOT NULL,
	[AlumnoID] [int] NULL,
	[CursoID] [int] NULL,
 CONSTRAINT [PK_Cursada_de_Alumno] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Docente]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente](
	[ID] [int] NOT NULL,
	[UsuarioID] [int] NULL,
 CONSTRAINT [PK_Docente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docente_Curso]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docente_Curso](
	[ID] [int] NOT NULL,
	[Activo] [bit] NULL,
	[CursoID] [int] NULL,
	[DocenteID] [int] NULL,
 CONSTRAINT [PK_Docente_Curso] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donacion]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donacion](
	[ID] [int] NOT NULL,
	[NombreEmpresa] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PrefijoTelefono] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[TarjetaID] [int] NOT NULL,
 CONSTRAINT [PK_Donacion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 25/08/2023 16:52:02 ******/
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
/****** Object:  Table [dbo].[Solicitud_Respuesta]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Respuesta](
	[ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Solicitud_Soporte]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Soporte](
	[ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/08/2023 16:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] NOT NULL,
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
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (1, N'Web Master')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (2, N'Administrador')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (3, N'Docente')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (4, N'Alumno')
GO
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'12345678', CAST(N'2000-01-01' AS Date), N'a@a.com', 1, 1)
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
