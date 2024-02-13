USE [GS_ALIMENT]
GO
/****** Object:  Table [dbo].[Approvisionnements]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Approvisionnements](
	[Num_lot] [varchar](20) NOT NULL,
	[Nom_prod] [varchar](150) NOT NULL,
	[Qte_sotock] [varchar](20) NOT NULL,
	[PA] [float] NOT NULL,
	[Date_enre] [date] NOT NULL,
	[StockEntre] [varchar](11) NULL,
	[Famille] [varchar](50) NULL,
	[Rayon] [varchar](3) NULL,
	[Date_exp] [date] NULL,
	[Unites] [varchar](10) NULL,
 CONSTRAINT [PK_Approvisionnements] PRIMARY KEY CLUSTERED 
(
	[Nom_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[Nom] [varchar](50) NULL,
	[Telephone] [varchar](25) NOT NULL,
	[Typeclient] [varchar](30) NULL,
	[Dateenre] [date] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Telephone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPTE]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPTE](
	[Nom] [varchar](30) NOT NULL,
	[Postnom] [varchar](30) NOT NULL,
	[Prenom] [varchar](30) NOT NULL,
	[Statut] [varchar](20) NOT NULL,
	[Telephone] [varchar](30) NOT NULL,
	[Password] [varchar](8) NOT NULL,
	[Confirme] [varchar](8) NOT NULL,
	[Adresse] [varchar](30) NOT NULL,
	[Site] [varchar](50) NULL,
 CONSTRAINT [PK_COMPTE] PRIMARY KEY CLUSTERED 
(
	[Telephone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Depense_prod]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Depense_prod](
	[Montant] [float] NULL,
	[Motif] [nvarchar](100) NULL,
	[Datedepense] [date] NULL,
	[Nom_Agent] [nvarchar](15) NULL,
	[Mois] [varchar](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factures]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factures](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [datetime] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](20) NOT NULL,
	[SommesV] [float] NOT NULL,
	[Heur] [time](7) NULL,
	[NumFacture] [varchar](10) NOT NULL,
	[Patient] [varchar](30) NULL,
	[Sites] [varchar](30) NULL,
	[Libelle] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fichestock]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fichestock](
	[Id_prod] [varchar](20) NOT NULL,
	[Nom_prod] [varchar](150) NOT NULL,
	[Qte_sotock] [varchar](10) NOT NULL,
	[Date_enre] [datetime] NOT NULL,
	[Mois] [varchar](10) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Liste_produit]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Liste_produit](
	[NOM_PROD] [nvarchar](255) NULL,
	[PA] [nvarchar](255) NULL,
	[DATE_ENRE] [date] NULL,
	[CATEGORIE] [varchar](50) NULL,
	[Num] [int] IDENTITY(1,1) NOT NULL,
	[Unites] [varchar](20) NULL,
 CONSTRAINT [PK_Sheet1$] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Liste_produits]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Liste_produits](
	[NOM_PROD] [nvarchar](255) NULL,
	[PA] [float] NULL,
	[DATE_ENRE] [nvarchar](255) NULL,
	[CATEGORIE] [nvarchar](255) NULL,
	[Num] [int] IDENTITY(1,1) NOT NULL,
	[Unites] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NRetour]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NRetour](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_retour] [int] NOT NULL,
	[Date_retour] [date] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](50) NOT NULL,
	[Heur] [time](7) NULL,
	[Num_Fac] [varchar](10) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NumOrdre]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NumOrdre](
	[N_Ordre] [int] IDENTITY(1,1) NOT NULL,
	[Users] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proforma]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proforma](
	[Nom_prod] [varchar](300) NOT NULL,
	[PV] [varchar](20) NOT NULL,
	[Qte_vendue] [varchar](20) NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Date_enre] [date] NOT NULL,
	[Qte_dispo] [varchar](20) NOT NULL,
	[Numprofo] [varchar](20) NOT NULL,
	[Numauto] [varchar](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rapportjour]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rapportjour](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [datetime] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](20) NOT NULL,
	[SommesV] [float] NOT NULL,
	[Heur] [time](7) NULL,
	[NumFacture] [varchar](10) NOT NULL,
	[Patient] [varchar](30) NULL,
	[Sites] [varchar](30) NULL,
	[Libelle] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requisition]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Requisition](
	[Articles] [varchar](100) NOT NULL,
	[Qtedispo] [int] NULL,
	[Qterequisit] [varchar](10) NULL,
	[Daterequis] [date] NULL,
	[Site] [varchar](50) NULL,
	[Demandeur] [varchar](50) NULL,
	[Prix] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sites]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sites](
	[Id_Site] [varchar](20) NOT NULL,
	[NomSite] [varchar](70) NOT NULL,
	[Date_Creation] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Site] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_benefice]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_benefice](
	[Nom_prod] [varchar](150) NULL,
	[Prix_tot] [varchar](15) NOT NULL,
	[Benefice] [float] NOT NULL,
	[Dateope] [date] NULL,
	[Mois] [varchar](20) NULL,
	[Nom_vend] [varchar](15) NULL,
	[Sites] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Depense]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Depense](
	[Montant] [float] NULL,
	[motif] [nvarchar](50) NULL,
	[DateDep] [datetime] NULL,
	[Nom_Agent] [nvarchar](50) NULL,
	[demandeur] [varchar](30) NULL,
	[Mois] [varchar](20) NULL,
	[Identifiant] [int] IDENTITY(1,1) NOT NULL,
	[Sites] [varchar](30) NULL,
 CONSTRAINT [PK_T_Depense] PRIMARY KEY CLUSTERED 
(
	[Identifiant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Depenseannees]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Depenseannees](
	[Montant] [float] NULL,
	[motif] [nvarchar](50) NULL,
	[DateDep] [datetime] NULL,
	[Nom_Agent] [nvarchar](50) NULL,
	[Heur] [time](7) NULL,
	[Mois] [varchar](20) NULL,
	[Sites] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_fontdeuter]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_fontdeuter](
	[Sommes_verssement] [float] NULL,
	[Rect] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_pourcentage]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_pourcentage](
	[Pourcentage] [varchar](10) NULL,
	[Ordre] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_VJour]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_VJour](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [date] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](50) NOT NULL,
	[Mois] [nvarchar](20) NOT NULL,
	[Heur] [time](7) NULL,
	[NumFacture] [varchar](15) NOT NULL,
	[Patient] [varchar](30) NULL,
	[Sites] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_VMois]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_VMois](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [datetime] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](20) NOT NULL,
	[Mois] [nvarchar](50) NOT NULL,
	[Heur] [time](7) NULL,
	[NumFacture] [varchar](15) NULL,
	[Patient] [varchar](30) NULL,
	[Sites] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_VSemain]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_VSemain](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [datetime] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](20) NOT NULL,
	[Mois] [nvarchar](50) NOT NULL,
	[Heur] [time](7) NULL,
	[NumFacture] [varchar](15) NOT NULL,
	[Sites] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Taux]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Taux](
	[franc] [varchar](10) NULL,
	[usd] [varchar](10) NULL,
	[Id_taux] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Taux] PRIMARY KEY CLUSTERED 
(
	[Id_taux] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vente_credit]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vente_credit](
	[Nom_prod] [varchar](150) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [date] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Pharmacien] [varchar](50) NOT NULL,
	[Mois] [nvarchar](50) NOT NULL,
	[Heur] [time](7) NULL,
	[Facture] [varchar](15) NOT NULL,
	[Client] [varchar](30) NULL,
	[Officine] [varchar](30) NULL,
	[Libelle] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ventes]    Script Date: 2023-06-01 23:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ventes](
	[Nom_prod] [varchar](100) NOT NULL,
	[PV] [float] NOT NULL,
	[Qte_vendue] [int] NOT NULL,
	[Date_vendu] [date] NOT NULL,
	[Prix_total] [float] NOT NULL,
	[Nom_vendeur] [varchar](50) NOT NULL,
	[Mois] [nvarchar](20) NOT NULL,
	[Heur] [time](7) NOT NULL,
	[NumFacture] [varchar](15) NOT NULL,
	[Patient] [varchar](30) NULL,
	[Sites] [varchar](30) NOT NULL,
	[Libelle] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
