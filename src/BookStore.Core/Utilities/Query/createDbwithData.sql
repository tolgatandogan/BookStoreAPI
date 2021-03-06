USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 11.05.2021 00:14:19 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = OFF
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 11.05.2021 00:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](32) NULL,
	[MiddleName] [nvarchar](32) NULL,
	[LastName] [nvarchar](32) NULL,
	[Country] [nvarchar](32) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11.05.2021 00:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[ISBN] [nvarchar](13) NULL,
	[Name] [nvarchar](256) NULL,
	[IsValidISBN] [bit] NULL,
	[AuthorId] [uniqueidentifier] NULL,
	[PublisherId] [uniqueidentifier] NULL,
	[FormatId] [uniqueidentifier] NULL,
	[ReleaseDate] [date] NULL,
	[Version] [nvarchar](16) NULL,
	[Preface] [nvarchar](512) NULL,
	[QuantityLeft] [int] NULL,
	[WarehouseLocation] [int] NULL,
	[NextStockDate] [date] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormatType]    Script Date: 11.05.2021 00:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormatType](
	[Id] [uniqueidentifier] NOT NULL,
	[FormatId] [int] NULL,
	[Name] [nvarchar](16) NULL,
 CONSTRAINT [PK_FormatType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 11.05.2021 00:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](32) NULL,
	[Country] [nvarchar](32) NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Author] ([Id], [FirstName], [MiddleName], [LastName], [Country]) VALUES (N'60aef3a2-a922-487f-922f-3f1aaeeb567f', N'Stefan', NULL, N'Zweig', N'Avusturya')
INSERT [dbo].[Author] ([Id], [FirstName], [MiddleName], [LastName], [Country]) VALUES (N'4386d23e-34db-48d6-b1bc-6dbf94123700', N'Bülent', NULL, N'Çobanoğlu', N'Türkiye')
INSERT [dbo].[Author] ([Id], [FirstName], [MiddleName], [LastName], [Country]) VALUES (N'5c1e0316-51f8-448b-942e-8d310ef0c859', N'Zehra', NULL, N'Başkaya', N'Türkiye')
INSERT [dbo].[Author] ([Id], [FirstName], [MiddleName], [LastName], [Country]) VALUES (N'992f8a42-8aa5-4adb-930c-ac218e4c0fb0', N'Namık', N'Kemal', N'Erdoğan', N'Türkiye')
INSERT [dbo].[Author] ([Id], [FirstName], [MiddleName], [LastName], [Country]) VALUES (N'448a210c-6857-4603-86a4-c978179d1e3a', N'Ceren', NULL, N'Akman', N'Türkiye')
GO
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'e8285090-b0e2-4cf2-8476-0ee4a93de86a', N'9786059681858', N'Satranç', 1, N'60aef3a2-a922-487f-922f-3f1aaeeb567f', N'2a7fb136-f878-488f-8078-e6477d55d4d9', N'579e1292-9bc9-42cd-a792-a0bdac17b7c4', CAST(N'2021-01-29' AS Date), N'2.2', N'Belki hücremde kendime bir çeşit satranç tahtası yapıp, oyunları oynamayı deneyebilirim diye düşündüm; gökten gelen bir işaret gibi, yatak örtümün kare desenli olması beni şaşırtmıştı.', 2, 99, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'3d5d734b-a7aa-4d38-8032-15cbdc5ff55d', N'9786254481901', N'Bir Kadının Yaşamından Yirmi Dört Saat', 1, N'60aef3a2-a922-487f-922f-3f1aaeeb567f', N'2a7fb136-f878-488f-8078-e6477d55d4d9', N'579e1292-9bc9-42cd-a792-a0bdac17b7c4', CAST(N'2021-01-29' AS Date), N'2.1', N'Tüm acılar korkaktır ve kendisinden çok daha güçlü olan yaşam isteği karşısında geri çekilirler.
Bayan C''nin hayatında olağanüstü bir gün başlıyor – uzun bir evliliğin yarattığı iç sıkıntısından kaçış, heyecan ve anlam arayışı. Bir kumarhanenin parlak ışıkları altındaki çaresiz bir yabancının tutkusuna kapılan kadın, arzu ettiği serüveni yaşayabilecek midir?', 1, 99, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'b1ba8c09-c145-48d4-9a51-5977e049e39e', N'9786059393935', N'R Programlama ile Fraktal Analiz', 1, N'992f8a42-8aa5-4adb-930c-ac218e4c0fb0', N'9b2a3ea2-2f8d-4064-ac0f-da6426f3694f', N'2303d716-7c9d-4ed3-838f-57df68c3fe09', CAST(N'2019-11-07' AS Date), N'1.1', N'Kısa açıklama yok', 10, 4, CAST(N'2021-07-02' AS Date))
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'084e8c0b-2e47-4b9f-a431-647f1b6c088e', N'9781234567897', N'Kotlin ile Android Programlama', 1, N'448a210c-6857-4603-86a4-c978179d1e3a', N'67c7f315-e536-4f69-a373-9d41b2514189', N'5ef59cf9-605c-4fba-890e-3013183fc92c', CAST(N'2019-10-23' AS Date), N'3.2', N'Kotlin ile Android Programlama öğrenmeniz için ihtiyacınız olan tek kitap! Durmadan gelişen teknoloji çağında Android uygulamaların sayısı gün geçtikçe artmaktadır. Android uygulama geliştirenler ya da uygulama geliştirmek isteyenler bu kitapta öğreneceği Android’in yeni ve taze dili olan Kotlin’in ilgi çekici, sıkmayan ve geliştiriciler için kodlama aşamasında sağlamış olduğu avantajlarla hayalinizde tasarlamış olduğunuz uygulamaları kolayca geliştirebilir ve tüm Dünya ile paylaşabilirsiniz..', 2, 3, CAST(N'2021-07-02' AS Date))
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'00eef590-eedf-4155-8384-9dc2b406486e', N'9786052359846', N'JAVA ile Programlama ve Veri Yapıları', 1, N'4386d23e-34db-48d6-b1bc-6dbf94123700', N'865c4338-1867-4f14-a0cf-909bdd23d5f7', N'579e1292-9bc9-42cd-a792-a0bdac17b7c4', CAST(N'2020-08-04' AS Date), N'1.2', N'Algoritma Geliştirme ve Veri Yapıları kitabının yazarı Bülent Çobanoğlu’ndan aynı sade ve akıcı anlatıma sahip bir diğer kitap. Bu kitapla Java''''yı temellerinden kavrayıp, programlamaya giriş yapabilir, mevcut bilgilerinizi şekillendirip Java''''yı daha iyi öğrenebilirsiniz.', 0, 2, CAST(N'2021-06-01' AS Date))
INSERT [dbo].[Book] ([Id], [ISBN], [Name], [IsValidISBN], [AuthorId], [PublisherId], [FormatId], [ReleaseDate], [Version], [Preface], [QuantityLeft], [WarehouseLocation], [NextStockDate]) VALUES (N'5aefe792-9daa-450a-880a-be628a695fec', N'9786055335052', N'Bulanık Doğrusal Programlama', 1, N'5c1e0316-51f8-448b-942e-8d310ef0c859', N'413d30b1-1f85-48ae-a11a-305f258a9d71', N'2303d716-7c9d-4ed3-838f-57df68c3fe09', CAST(N'2011-11-01' AS Date), N'0.1', N'Bilgi eksikliği ve belirsizlikler karar alma süreçlerinde subjektif kararlar alınmasına neden olmaktadır. Klasik mantıkta belirsizliklere yer yoktur. Bir şey “var” ya da “yok” tur. Bilgi kesin sınırlar çerçevesinde değerlendirilir. Dolayısıyla klasik bir doğrusal programlama modelinde amaç ve kısıtlar net olarak belirlenmiş olmalıdır.', 4, 1, CAST(N'2021-07-02' AS Date))
GO
INSERT [dbo].[FormatType] ([Id], [FormatId], [Name]) VALUES (N'5ef59cf9-605c-4fba-890e-3013183fc92c', 1, N'Digital')
INSERT [dbo].[FormatType] ([Id], [FormatId], [Name]) VALUES (N'2303d716-7c9d-4ed3-838f-57df68c3fe09', 2, N'Print')
INSERT [dbo].[FormatType] ([Id], [FormatId], [Name]) VALUES (N'579e1292-9bc9-42cd-a792-a0bdac17b7c4', 3, N'Both')
GO
INSERT [dbo].[Publisher] ([Id], [Name], [Country]) VALUES (N'413d30b1-1f85-48ae-a11a-305f258a9d71', N'Ekin Kitabevi Yayınları', N'Türkiye')
INSERT [dbo].[Publisher] ([Id], [Name], [Country]) VALUES (N'865c4338-1867-4f14-a0cf-909bdd23d5f7', N'Pusula Yayıncılık ve İletişim', N'Türkiye')
INSERT [dbo].[Publisher] ([Id], [Name], [Country]) VALUES (N'67c7f315-e536-4f69-a373-9d41b2514189', N'Dikeyeksen Yayıncılık', N'Türkiye')
INSERT [dbo].[Publisher] ([Id], [Name], [Country]) VALUES (N'9b2a3ea2-2f8d-4064-ac0f-da6426f3694f', N'Nisan Kitabevi', N'Türkiye')
INSERT [dbo].[Publisher] ([Id], [Name], [Country]) VALUES (N'2a7fb136-f878-488f-8078-e6477d55d4d9', N'Martı Yayınları', N'Türkiye')
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_FormatType] FOREIGN KEY([FormatId])
REFERENCES [dbo].[FormatType] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_FormatType]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publisher] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
