﻿/*
Deployment script for StudentRegistration

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "StudentRegistration"
:setvar DefaultFilePrefix "StudentRegistration"
:setvar DefaultDataPath "C:\Users\hy398\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\hy398\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Departments]...';


GO
CREATE TABLE [dbo].[Departments] (
    [DepartmentCode] NVARCHAR (10) NOT NULL,
    [DepartmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentCode] ASC)
);


GO
PRINT N'Creating [dbo].[Students]...';


GO
CREATE TABLE [dbo].[Students] (
    [StudentId]        INT           IDENTITY (1, 1) NOT NULL,
    [StudentFirstName] NVARCHAR (50) NOT NULL,
    [StudentLastName]  NVARCHAR (50) NOT NULL,
    [StudentMajor]     NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Students_Departments]...';


GO
ALTER TABLE [dbo].[Students]
    ADD CONSTRAINT [FK_Students_Departments] FOREIGN KEY ([StudentMajor]) REFERENCES [dbo].[Departments] ([DepartmentCode]);


GO
PRINT N'Creating [dbo].[DepartmentMajorsCount]...';


GO
CREATE VIEW [dbo].[DepartmentMajorsCount]
	AS SELECT [Departments].DepartmentName AS DepartmentName, COUNT(*) AS NumberOfMajors 
	FROM [Departments] 
	INNER JOIN [Students] ON [Students].StudentMajor = [Departments].DepartmentCode
	GROUP BY DepartmentCode
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use StudentRegistration
GO

INSERT INTO Departments([DepartmentCode],[DepartmentName]) VALUES('ACCT', 'Accounting');
INSERT INTO Departments([DepartmentCode],[DepartmentName]) VALUES('FINC', 'Finance');
INSERT INTO Departments([DepartmentCode],[DepartmentName]) VALUES('MKTG', 'Marketing');
INSERT INTO Departments([DepartmentCode],[DepartmentName]) VALUES('CSIS', 'Computing Studies and Information Systems');
GO

INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Troy','Acosta','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Kevyn','Newman','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Lillith','Johnston','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Hayfa','Guerra','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Brenden','Norton','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Kevin','Best','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Shad','Malone','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Colleen','Nielsen','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Zane','May','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Garth','Newman','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Illiana','Baird','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Ariel','Guerra','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Lynn','Carroll','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Jeanette','Ratliff','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Reese','Quinn','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Herman','Serrano','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Sophia','Sutton','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Brett','Blair','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Hop','Vang','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Uta','Anthony','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Sean','Bates','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Lucas','Guy','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Pandora','Brock','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Virginia','Molina','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Drake','Black','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Fredericka','Fernandez','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Hoyt','Le','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Gavin','Logan','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Raja','Browning','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Beck','Oneil','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Erin','Ewing','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Keelie','Weiss','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Upton','Hewitt','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Marshall','Irwin','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Caleb','Hooper','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Simon','Harmon','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Elton','Turner','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Felicia','Puckett','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Jada','Kim','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Tatyana','Silva','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Hashim','Pacheco','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Skyler','Cherry','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Driscoll','Morris','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Quyn','Raymond','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Rhona','Marsh','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Nash','Sellers','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Wynne','Horn','MKTG');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Nathan','Cooke','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Sarah','Brady','CSIS');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Nehru','Carlson','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Macaulay','Bell','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Tanner','Morgan','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Leilani','Lloyd','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Wynne','Thompson','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Ivor','Fry','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Patience','Bennett','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Isaac','Duffy','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Sawyer','Guerra','ACCT');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Clementine','Lopez','FINC');
INSERT INTO Students([StudentFirstName],[StudentLastName],[StudentMajor]) VALUES('Hyacinth','Burch','ACCT');
GO




GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
