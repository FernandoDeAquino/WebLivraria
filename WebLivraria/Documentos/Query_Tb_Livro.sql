USE [C:\USERS\FERNANDO\LIVRARIA.MDF]
GO

/****** Object: Table [dbo].[livro] Script Date: 04/09/2020 15:46:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[livro] (
    [Codl]          INT          NOT NULL,
    [Titulo]        VARCHAR (40) NULL,
    [Editora]       VARCHAR (40) NULL,
    [Edicao]        INT          NULL,
    [AnoPublicacao] VARCHAR (4)  NULL
);
