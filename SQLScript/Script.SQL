CREATE TABLE [dbo].[Emitente]
(
	[EmitenteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CNPJ] BIGINT NOT NULL, 
    [IE] NVARCHAR(50) NULL, 
    [NomeRazao] NVARCHAR(200) NOT NULL, 
    [NomeFantasia] NVARCHAR(200) NULL, 
    [Fone] NVARCHAR(50) NULL, 
    [CEP] INT NOT NULL, 
    [Logradouro] NVARCHAR(200) NULL, 
    [NumeroRua] INT NULL, 
    [Complemento] NVARCHAR(50) NULL, 
    [Bairro] NVARCHAR(200) NOT NULL, 
    [CodigoCidade] INT NOT NULL, 
    [Cidade] NVARCHAR(200) NOT NULL, 
    [UF] CHAR(2) NOT NULL, 
    [IM] NVARCHAR(50) NULL, 
    [CNAE] NVARCHAR(50) NULL, 
    [CodigoPais] INT NOT NULL, 
    [Pais] NVARCHAR(50) NOT NULL
)
ALTER TABLE [dbo].[Emitente] ALTER COLUMN [CNPJ] VARCHAR (14) NOT NULL;


CREATE TABLE [dbo].[Transportador]
(
    [TransportadorId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FretePorConta] BIT NOT NULL, 
    [CNPJCPF] BIGINT NOT NULL, 
    [InscricaoEstadual] NVARCHAR(50) NULL, 
    [NomeRazao] NVARCHAR(200) NOT NULL, 
    [Endereco] NVARCHAR(200) NULL, 
    [CodigoCidade] INT NOT NULL, 
    [Cidade] NVARCHAR(200) NOT NULL, 
    [UF] CHAR(2) NOT NULL, 
    [ValorServico] DECIMAL(18, 2) NULL, 
    [ValorBase] DECIMAL(18, 2) NULL, 
    [Aliquota] DECIMAL(18, 2) NULL, 
    [Valor] DECIMAL(18, 2) NULL, 
    [CFOP] NVARCHAR(50) NULL, 
    [CodigoCidadePlaca] INT NULL, 
    [Placa] NVARCHAR(14) NULL, 
    [UFPlaca] CHAR(2) NULL, 
    [RNTC] NVARCHAR(50) NULL
)
ALTER TABLE [dbo].[Transportador] ALTER COLUMN [CNPJCPF] VARCHAR (14) NOT NULL;

CREATE TABLE [dbo].[Destinatario] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [CNPJ]              VARCHAR (14)   NOT NULL,
    [IndIEDest]         INT            NULL,
    [InscricaoEstadual] VARCHAR (14)   NULL,
    [ISUF]              VARCHAR (50)   NULL,
    [NomeRazao]         NVARCHAR (200) NOT NULL,
    [Fone]              VARCHAR (12)   NULL,
    [CEP]               CHAR (8)       NOT NULL,
    [Logradouro]        NVARCHAR (200) NOT NULL,
    [NumeroCasa]        INT            NULL,
    [Complemento]       NVARCHAR (50)  NULL,
    [Bairro]            NVARCHAR (200) NOT NULL,
    [CidadeCodigo]      INT            NOT NULL,
    [Cidade]            NVARCHAR (200) NOT NULL,
    [UF]                CHAR (2)       NOT NULL,
    [PaisCodigo]        INT            NOT NULL,
    [Pais]              NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


