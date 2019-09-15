Executar o Script abaixo para função de gravação do design pattern Evet Sourcing
USE [teste_webmotors]
GO

/****** Object:  Table [dbo].[StoredEvent]    Script Date: 15/09/2019 14:47:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StoredEvent](
	[Id] [uniqueidentifier] NOT NULL,
	[AggregateId] [int] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[Action] [varchar](100) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[User] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

