
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2020 00:10:20
-- Generated from EDMX file: I:\Test\DAL\SampleHotelData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestHotelsData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Hotels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotels];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Hotels'
CREATE TABLE [dbo].[Hotels] (
    [HotelId] int  NOT NULL,
    [DisplayName] nvarchar(150)  NOT NULL,
    [DisplayNameAr] nvarchar(200)  NULL,
    [CountryCode] char(2)  NOT NULL,
    [CountryName] varchar(50)  NOT NULL,
    [State] varchar(30)  NULL,
    [CityName] varchar(50)  NOT NULL,
    [Address] nvarchar(200)  NULL,
    [ZipCode] varchar(40)  NULL,
    [StarRating] tinyint  NULL,
    [Lat] float  NULL,
    [Lng] float  NULL,
    [RoomCount] smallint  NULL,
    [Phone] varchar(50)  NULL,
    [Fax] varchar(50)  NULL,
    [Email] varchar(150)  NULL,
    [Website] varchar(200)  NULL,
    [CreationTime] datetime  NOT NULL,
    [UpdateTime] datetime  NOT NULL,
    [PropertyCategory] varchar(10)  NULL,
    [ChainCode] nvarchar(10)  NULL,
    [AddressAr] nvarchar(200)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [HotelId] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [PK_Hotels]
    PRIMARY KEY CLUSTERED ([HotelId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------