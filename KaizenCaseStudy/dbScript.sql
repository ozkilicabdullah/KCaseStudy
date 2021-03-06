USE [KCaseStudy]
GO
/****** Object:  Table [dbo].[News]    Script Date: 1.07.2022 12:11:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsDetail]    Script Date: 1.07.2022 12:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Detail] [nvarchar](max) NULL,
	[Category] [nvarchar](50) NULL,
	[NewsId] [int] NULL,
	[Lang] [int] NULL,
 CONSTRAINT [PK_NewsDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsImg]    Script Date: 1.07.2022 12:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsImg](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[NewsDetailId] [int] NULL,
 CONSTRAINT [PK_NewsImg] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Name]) VALUES (1, N'AmericanCars')
INSERT [dbo].[News] ([ID], [Name]) VALUES (2, N'FlyingFerries')
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[NewsDetail] ON 

INSERT [dbo].[NewsDetail] ([ID], [Title], [Detail], [Category], [NewsId], [Lang]) VALUES (1, N'The South African company building beloved American supercars', N'
In the 1960s, Carroll Shelby left an indelible mark on motorsport history, with his cars winning the FIA World Sportscar Championship and the 24 Hours of Le Mans race for an American manufacturer for the first time. But their engineering prowess relied upon resourcefulness as well as skill. The Ford GT40 featured an oil cap from a tractor and an identification light from an airplane, and the Shelby Cobra''s indicator switch came from a humble German family car, according to replica car builder Jimmy Price. So when it comes to recreating these and other rare vehicles, he has his work cut out.', N'Cars', 1, 2)
INSERT [dbo].[NewsDetail] ([ID], [Title], [Detail], [Category], [NewsId], [Lang]) VALUES (2, N'Güney Afrikalı şirket, sevilen Amerikan süper arabalarını üretiyor', N'1960''larda Carroll Shelby, otomobilleri FIA Dünya Spor Araba Şampiyonası''nı ve ilk kez bir Amerikalı üretici için 24 Saatlik Le Mans yarışını kazanarak motor sporları tarihinde silinmez bir iz bıraktı. Ancak mühendislik hünerleri beceri kadar beceriye de dayanıyordu. Ford GT40, bir traktörden bir yağ kapağına ve bir uçaktan bir tanımlama ışığına sahipti ve replika otomobil üreticisi Jimmy Price''a göre Shelby Cobra''nın gösterge anahtarı mütevazi bir Alman aile otomobilinden geldi. Bu ve diğer nadir araçları yeniden yaratmaya gelince, işini yarıda kesiyor.', N'Arabalar', 1, 1)
INSERT [dbo].[NewsDetail] ([ID], [Title], [Detail], [Category], [NewsId], [Lang]) VALUES (3, N'These ''flying'' ferries could get you to work in half the time', N'Inhabitants of the Swedish capital, an archipelago of 14 islands connected by 57 bridges, have a long history of using watercraft to get around. With an estimated fleet of 756,000 leisure craft, Sweden''s recreational boating sector is one of the largest in the world per capita. But that comes with a big environmental cost. Waves from fast-moving boats damage the seabed, engine noise disturbs wildlife, and leisure boating accounted for over 25% of Sweden''s CO2 emissions from shipping in 2020.', N'Tech', 2, 2)
INSERT [dbo].[NewsDetail] ([ID], [Title], [Detail], [Category], [NewsId], [Lang]) VALUES (4, N'Bu ''uçan'' feribotlar sizi yarı yarıya işe alabilir', N'57 köprüyle birbirine bağlanan 14 adadan oluşan bir takımada olan İsveç başkentinin sakinleri, etrafta dolaşmak için deniz taşıtlarını kullanma konusunda uzun bir geçmişe sahiptir. Tahmini 756.000 eğlence teknesi filosu ile İsveç''in eğlence amaçlı teknecilik sektörü, kişi başına düşen dünyanın en büyüklerinden biridir. Ancak bu büyük bir çevresel maliyetle birlikte geliyor. Hızlı hareket eden teknelerden gelen dalgalar deniz yatağına zarar veriyor, motor gürültüsü vahşi yaşamı rahatsız ediyor ve 2020''de İsveç''in denizcilikten kaynaklanan CO2 emisyonlarının %25''inden fazlasını tekne gezintisi oluşturuyor.', N'Teknoloji', 2, 1)
SET IDENTITY_INSERT [dbo].[NewsDetail] OFF
SET IDENTITY_INSERT [dbo].[NewsImg] ON 

INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (1, N'en-ImageUrl-1', 1)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (2, N'en-ImageUrl-2', 1)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (3, N'tr-ImageUrl-1', 2)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (4, N'tr-ImageUrl-2', 2)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (5, N'en-ImageUrl-1', 3)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (6, N'en-ImageUrl-2', 3)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (7, N'en-ImageUrl-3', 3)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (8, N'tr-ImageUrl-1', 4)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (9, N'tr-ImageUrl-2', 4)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (10, N'tr-ImageUrl-2', 4)
INSERT [dbo].[NewsImg] ([ID], [ImagePath], [NewsDetailId]) VALUES (11, N'tr-ImageUrl-2', 4)
SET IDENTITY_INSERT [dbo].[NewsImg] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [Unique_NewsName]    Script Date: 1.07.2022 12:11:48 ******/
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [Unique_NewsName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetNewsByLang]    Script Date: 1.07.2022 12:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- Exec [dbo].[GetNewsByLang] 1
CREATE PROCEDURE [dbo].[GetNewsByLang]  @lang int

AS
BEGIN
		Select 
		nd.[Title],
		nd.[Detail],
		nd.[Category],
		n.[Name],
		(Select STRING_AGG ([ImagePath],',') From [dbo].[NewsImg] i with (nolock) where i.[NewsDetailId]=nd.[ID]) AS ImageUrls
		 From [dbo].[News] n with(nolock) 
		 Inner Join [dbo].[NewsDetail] nd with(nolock) on n.[ID]=nd.[NewsId] and  nd.[Lang]=@lang

END
GO
/****** Object:  StoredProcedure [dbo].[GetNewsByName]    Script Date: 1.07.2022 12:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--  Exec  [dbo].[GetNewsByName] 'AmericanCars',1
CREATE PROCEDURE [dbo].[GetNewsByName] @Name nvarchar(50), @lang int

AS
BEGIN
		Select 
		nd.[Title],
		nd.[Detail],
		nd.[Category],
		n.[Name],
		(Select STRING_AGG ([ImagePath],',') From [dbo].[NewsImg] i with (nolock) where i.[NewsDetailId]=nd.[ID]) AS ImageUrls
		 From [dbo].[News] n with(nolock) 
		 Inner Join [dbo].[NewsDetail] nd with(nolock) on n.[ID]=nd.[NewsId] and  nd.[Lang]=@lang
		Where n.[Name]=@Name 
END
GO
