USE [Proyecto TFI]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Alumno]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Clase]    Script Date: 17/10/2023 14:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](max) NULL,
	[LinkVideo] [varchar](500) NULL,
	[Activo] [bit] NOT NULL,
	[CursoID] [int] NOT NULL,
 CONSTRAINT [PK_Clase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursada_de_Alumno]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Curso]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Docente]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Docente_Curso]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Donacion]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz_Conclusion]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz_Cursada_de_Alumno]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz_Pregunta]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz_Pregunta_Opcion]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Quiz_Respuesta]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Solicitud_Mensaje]    Script Date: 17/10/2023 14:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Mensaje](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionAlumno] [varchar](450) NOT NULL,
	[RespuestaAdministrador] [varchar](450) NULL,
	[FechaEmision] [date] NOT NULL,
	[FechaRespuesta] [date] NULL,
	[SolicitudID] [int] NOT NULL,
	[AdministradorID] [int] NULL,
 CONSTRAINT [PK_Solicitud_Respuesta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Solicitud_Soporte]    Script Date: 17/10/2023 14:35:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud_Soporte](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Asunto] [varchar](50) NOT NULL,
	[TipoConsulta] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
	[AlumnoID] [int] NOT NULL,
 CONSTRAINT [PK_Solicitud_Soporte] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 17/10/2023 14:35:02 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/10/2023 14:35:02 ******/
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
SET IDENTITY_INSERT [dbo].[Administrador] ON 

INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (1, 8)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (2, 9)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (3, 10)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (4, 11)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (5, 12)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (6, 13)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (7, 14)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (8, 15)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (9, 16)
INSERT [dbo].[Administrador] ([ID], [UsuarioID]) VALUES (10, 20)
SET IDENTITY_INSERT [dbo].[Administrador] OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (1, 3)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (2, 2)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (3, 5)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (4, 4)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (5, 6)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (6, 7)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (7, 17)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (8, 21)
INSERT [dbo].[Alumno] ([ID], [UsuarioID]) VALUES (9, 22)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Clase] ON 

INSERT [dbo].[Clase] ([ID], [Titulo], [Descripcion], [LinkVideo], [Activo], [CursoID]) VALUES (1, N'miau', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,', NULL, 1, 1)
INSERT [dbo].[Clase] ([ID], [Titulo], [Descripcion], [LinkVideo], [Activo], [CursoID]) VALUES (2, N'a', N'f', NULL, 1, 1)
INSERT [dbo].[Clase] ([ID], [Titulo], [Descripcion], [LinkVideo], [Activo], [CursoID]) VALUES (3, N'WINDOWS STARTUPS', N'A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart. I am alone, and feel the charm of existence in this spot, which was created for the bliss of souls like mine. I am so happy, my dear friend, so absorbed in the exquisite sense of mere tranquil existence, that I neglect my talents. I should be incapable of drawing a single stroke at the present moment; and yet I feel that I never was a greater artist than now. When, while the lovely valley teems with vapour around me, and the meridian sun strikes the upper surface of the impenetrable foliage of my trees, and but a few stray gleams steal into the inner sanctuary, I throw myself down among the tall grass by the trickling stream; and, as I lie close to the earth, a thousand unknown plants are noticed by me: when I hear the buzz of the little world among the stalks, and grow familiar with the countless indescribable forms of the insects and flies, then I feel the presence of the Almighty, who formed us in his own image, and the breath', N'https://www.youtube.com/watch?v=ACEkZQyCc4Y', 1, 1)
INSERT [dbo].[Clase] ([ID], [Titulo], [Descripcion], [LinkVideo], [Activo], [CursoID]) VALUES (4, N'TEST 222', N'PRUEBA 2', N'', 1, 1)
SET IDENTITY_INSERT [dbo].[Clase] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursada_de_Alumno] ON 

INSERT [dbo].[Cursada_de_Alumno] ([ID], [AlumnoID], [CursoID]) VALUES (1, 1, 1)
INSERT [dbo].[Cursada_de_Alumno] ([ID], [AlumnoID], [CursoID]) VALUES (2, 1, 2)
INSERT [dbo].[Cursada_de_Alumno] ([ID], [AlumnoID], [CursoID]) VALUES (3, 7, 1)
INSERT [dbo].[Cursada_de_Alumno] ([ID], [AlumnoID], [CursoID]) VALUES (6, 7, 2)
SET IDENTITY_INSERT [dbo].[Cursada_de_Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([ID], [Nombre], [Descripcion], [Activo], [AdministradorID]) VALUES (1, N'Emprendimiento', N'Descripcion1', 1, 1)
INSERT [dbo].[Curso] ([ID], [Nombre], [Descripcion], [Activo], [AdministradorID]) VALUES (2, N'Programación en C', N'Descripcion2', 1, 1)
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Docente] ON 

INSERT [dbo].[Docente] ([ID], [UsuarioID]) VALUES (1, 18)
INSERT [dbo].[Docente] ([ID], [UsuarioID]) VALUES (2, 19)
INSERT [dbo].[Docente] ([ID], [UsuarioID]) VALUES (3, 23)
SET IDENTITY_INSERT [dbo].[Docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Docente_Curso] ON 

INSERT [dbo].[Docente_Curso] ([ID], [Activo], [CursoID], [DocenteID]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Docente_Curso] ([ID], [Activo], [CursoID], [DocenteID]) VALUES (2, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Docente_Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Donacion] ON 

INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (1, N'1', N'a@a.com', 1, 1, 3, 1)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (2, N'1', N'a@a.com', 3, 1, 3, 2)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (3, N'A', N'a@a.com', 2, 2, 11, 3)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (4, N'1', N'a@a.com', 2, 1, 2, 4)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (5, N'f', N'a@a.com', 3, 2, 4, 5)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (6, N'jhh', N'a@a.com', 1, 3, 2, 6)
INSERT [dbo].[Donacion] ([ID], [NombreEmpresa], [Email], [PrefijoTelefono], [Telefono], [Monto], [TarjetaID]) VALUES (7, N'f', N'a@a.com', 2, 3, 1, 7)
SET IDENTITY_INSERT [dbo].[Donacion] OFF
GO
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (1, N'Web Master')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (2, N'Administrador')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (3, N'Docente')
INSERT [dbo].[Rol] ([ID], [Nombre]) VALUES (4, N'Alumno')
GO
SET IDENTITY_INSERT [dbo].[Solicitud_Mensaje] ON 

INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (1, N'asd', NULL, CAST(N'2023-10-12' AS Date), NULL, 1, NULL)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (2, N'UUUUU', NULL, CAST(N'2023-10-12' AS Date), NULL, 2, NULL)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (3, N'hola', NULL, CAST(N'2023-10-13' AS Date), NULL, 3, NULL)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (4, N'HOAL YO SUGIERO', N'ESTOY MAULKLANDO MIAUFDDFS', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 4, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (11, N'hgfghgfhgf', N'finn el humano', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 4, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (12, N'na flaco yo soy fan del ice king', N'aaaaaaaaaaaaaa', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 4, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (13, N'ñaaaaaaa', NULL, CAST(N'2023-10-13' AS Date), NULL, 4, NULL)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (14, N'HOPLÑSD', N'jj', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 5, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (15, N'gff', N'ghfhgfhgf', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 5, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (16, N'como el tu sabes ', N'y7 nbueno flaco jodete', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 6, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (17, N'NOPERO COMO ME VAS A HACER USAR ALGO FEO FLACO LA RE CONCHA BIEN PUTA DE TU HERMANA AAA', N'Y BUENO ES GRATIS ES LO QUE TENES CHAU', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 6, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (18, N'QUIERO JUGAR DOKKAN', N'GGGGGGGGGGGGGGGG', CAST(N'2023-10-13' AS Date), CAST(N'2023-10-13' AS Date), 7, 10)
INSERT [dbo].[Solicitud_Mensaje] ([ID], [DescripcionAlumno], [RespuestaAdministrador], [FechaEmision], [FechaRespuesta], [SolicitudID], [AdministradorID]) VALUES (19, N'LÑKLÑK', N'lll', CAST(N'2023-10-14' AS Date), CAST(N'2023-10-14' AS Date), 8, 10)
SET IDENTITY_INSERT [dbo].[Solicitud_Mensaje] OFF
GO
SET IDENTITY_INSERT [dbo].[Solicitud_Soporte] ON 

INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (1, N'a', N'Consulta', CAST(N'2023-10-12' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (2, N'AAAAAAAAUU', N'Consulta', CAST(N'2023-10-12' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (3, N'Mi prueba', N'Consulta', CAST(N'2023-10-13' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (4, N'NEUVA PRUEBA PRUEBOSO', N'Sugerencia', CAST(N'2023-10-13' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (5, N'TEST PAR APROBAR FINAL', N'Otro', CAST(N'2023-10-13' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (6, N'NO SE LA PALTAFORMA FUNCIONA SABES', N'Problema', CAST(N'2023-10-13' AS Date), 0, 9)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (7, N'ULTIMO TEST DE LA NOCHE', N'Sugerencia', CAST(N'2023-10-13' AS Date), 0, 7)
INSERT [dbo].[Solicitud_Soporte] ([ID], [Asunto], [TipoConsulta], [Fecha], [Activo], [AlumnoID]) VALUES (8, N'MAULLANDO', N'Sugerencia', CAST(N'2023-10-14' AS Date), 0, 7)
SET IDENTITY_INSERT [dbo].[Solicitud_Soporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarjeta] ON 

INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (1, NULL, N'1', 1, 1)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (2, NULL, N'1', 1, 1)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (3, 1, N'1', 1, 1)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (4, 1, N'2', 2, 2)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (5, 1, N'8', 7, 7)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (6, 1, N'7', 3, 9)
INSERT [dbo].[Tarjeta] ([ID], [Tipo], [Numero], [FechaCaducidad], [CVV]) VALUES (7, 1, N'1', 1, 6)
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'12345678', CAST(N'2000-01-01' AS Date), N'a@a.com', 1, 1)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (2, N'of', N'S', N'1', N'1', N'92', NULL, N'a@a.com', 1, 1)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (3, N'of', N'f', N'1', N'1', N'92', CAST(N'2002-02-02' AS Date), N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (4, N'Carlos', N'Tevez', N'a', N'a', N'123a', CAST(N'2002-02-02' AS Date), N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (5, N'matias', N'coccaro', N'a', N'a', N'123a', CAST(N'2002-02-02' AS Date), N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (6, N'Juan', N'Gauto', N's', N's', N's', CAST(N'2002-02-02' AS Date), N'M@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (7, N'a', N'a', N'1', N'1', N'1', CAST(N'2002-02-02' AS Date), N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (8, N'f', N'1', N'1', N'1', N'h', CAST(N'2000-01-01' AS Date), N'a@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (9, N'Patetta', N'123', N'AGUSTIND', N'PATETTA', N'1', NULL, N'P@a.com', 0, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (10, N'NEW', N'1', N'1', N'1', N'1', NULL, N'NEW@a.com', 0, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (11, N'ggd', N'123', N'1', N'1', N'1', NULL, N'NEW@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (12, N'admin123', N'123', N'1', N'1', N'1', NULL, N'a@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (13, N'Agustina', N'123', N'Agustina', N'Patettonga', N'1', CAST(N'2000-10-20' AS Date), N'a@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (14, N'Ezequiel', N'123', N'Ezqeuiels', N'Eze', N'1', NULL, N'e@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (15, N'Maria', N'asdasd', N'GHF', N'SA', N'1', NULL, N'l@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (16, N'123', N'1', N'1', N'1', N'1', NULL, N'123@uwu.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (17, N'Alumno', N'123', N'a', N'a', N'a', NULL, N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (18, N'profe', N'1234', N'Darío', N'Cardacci', N'12345678', CAST(N'2010-10-10' AS Date), N'a@a.com', 1, 3)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (19, N'profe2', N'1234', N'Jorge', N'Scali', N'12345782', CAST(N'2010-10-10' AS Date), N'a@a.com', 0, 3)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (20, N'soyadmin', N'123', N'soyadmin', N'soyadmin', N'123', CAST(N'2023-10-20' AS Date), N'soyadmin@a.com', 1, 2)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (21, N'alumno2', N'123', N'a', N'a', N'a', NULL, N'a@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (22, N'merieugin', N'123', N'merieugin', N'merieugin', N'5', CAST(N'2023-10-26' AS Date), N'M@a.com', 1, 4)
INSERT [dbo].[Usuario] ([ID], [Username], [Password], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Email], [Activo], [RolID]) VALUES (23, N'PROFESOR', N'123', N'p', N'p', N'1', CAST(N'2023-10-06' AS Date), N'p@a.com', 1, 3)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
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
ALTER TABLE [dbo].[Solicitud_Mensaje]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Respuesta_Administrador] FOREIGN KEY([AdministradorID])
REFERENCES [dbo].[Administrador] ([ID])
GO
ALTER TABLE [dbo].[Solicitud_Mensaje] CHECK CONSTRAINT [FK_Solicitud_Respuesta_Administrador]
GO
ALTER TABLE [dbo].[Solicitud_Mensaje]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Respuesta_Solicitud_Soporte] FOREIGN KEY([SolicitudID])
REFERENCES [dbo].[Solicitud_Soporte] ([ID])
GO
ALTER TABLE [dbo].[Solicitud_Mensaje] CHECK CONSTRAINT [FK_Solicitud_Respuesta_Solicitud_Soporte]
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
