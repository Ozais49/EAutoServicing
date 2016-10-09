
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/06/2016 19:07:51
-- Generated from EDMX file: E:\EAutoServicing\EAutoServicing\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EAutoServicing];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AppUser_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppUser] DROP CONSTRAINT [FK_AppUser_UserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Employeetype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Employeetype];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Gender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Gender];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_AppUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Costumer] DROP CONSTRAINT [FK_ServiceBooking_AppUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_AppUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Costumer] DROP CONSTRAINT [FK_ServiceBooking_AppUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_AppUser2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceBooking] DROP CONSTRAINT [FK_ServiceBooking_AppUser2];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_AppUser3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceBooking] DROP CONSTRAINT [FK_ServiceBooking_AppUser3];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_Costumer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceBooking] DROP CONSTRAINT [FK_ServiceBooking_Costumer];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceBooking] DROP CONSTRAINT [FK_ServiceBooking_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceBooking_Gender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Costumer] DROP CONSTRAINT [FK_ServiceBooking_Gender];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AppUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppUser];
GO
IF OBJECT_ID(N'[dbo].[Costumer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Costumer];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Employeetype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employeetype];
GO
IF OBJECT_ID(N'[dbo].[Gender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gender];
GO
IF OBJECT_ID(N'[dbo].[ServiceBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceBooking];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AppUsers'
CREATE TABLE [dbo].[AppUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(400)  NOT NULL,
    [Password] nvarchar(max)  NULL,
    [UserRoleId] int  NULL,
    [Status] int  NULL
);
GO

-- Creating table 'Costumers'
CREATE TABLE [dbo].[Costumers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [GenderId] int  NOT NULL,
    [Address] nvarchar(400)  NULL,
    [Email] nvarchar(400)  NULL,
    [PhoneNumber] nvarchar(400)  NULL,
    [Status] int  NOT NULL,
    [EntryBy] int  NOT NULL,
    [EntryDate] datetime  NOT NULL,
    [DeletedBy] int  NULL,
    [DeletedDate] datetime  NULL,
    [Photo] nvarchar(max)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [GenderId] int  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(400)  NULL,
    [DOB] datetime  NULL,
    [DateJoined] datetime  NULL,
    [EmployeeTypeId] int  NULL,
    [Photo] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [EntryBy] int  NOT NULL,
    [EntryDate] datetime  NOT NULL,
    [DeletedBy] int  NULL,
    [DeletedDate] datetime  NULL
);
GO

-- Creating table 'Employeetypes'
CREATE TABLE [dbo].[Employeetypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Genders'
CREATE TABLE [dbo].[Genders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'ServiceBookings'
CREATE TABLE [dbo].[ServiceBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CostumerId] int  NOT NULL,
    [VehicleNumber] nvarchar(400)  NOT NULL,
    [ServicedDate] datetime  NULL,
    [ServicedBy] int  NOT NULL,
    [NextServiceDate] datetime  NULL,
    [Status] int  NOT NULL,
    [EntryBy] int  NOT NULL,
    [EntryDate] datetime  NOT NULL,
    [DeletedBy] int  NULL,
    [DeletedDate] datetime  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(400)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [PK_AppUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Costumers'
ALTER TABLE [dbo].[Costumers]
ADD CONSTRAINT [PK_Costumers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employeetypes'
ALTER TABLE [dbo].[Employeetypes]
ADD CONSTRAINT [PK_Employeetypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genders'
ALTER TABLE [dbo].[Genders]
ADD CONSTRAINT [PK_Genders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceBookings'
ALTER TABLE [dbo].[ServiceBookings]
ADD CONSTRAINT [PK_ServiceBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserRoleId] in table 'AppUsers'
ALTER TABLE [dbo].[AppUsers]
ADD CONSTRAINT [FK_AppUser_UserRole]
    FOREIGN KEY ([UserRoleId])
    REFERENCES [dbo].[UserRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppUser_UserRole'
CREATE INDEX [IX_FK_AppUser_UserRole]
ON [dbo].[AppUsers]
    ([UserRoleId]);
GO

-- Creating foreign key on [EntryBy] in table 'Costumers'
ALTER TABLE [dbo].[Costumers]
ADD CONSTRAINT [FK_ServiceBooking_AppUser]
    FOREIGN KEY ([EntryBy])
    REFERENCES [dbo].[AppUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_AppUser'
CREATE INDEX [IX_FK_ServiceBooking_AppUser]
ON [dbo].[Costumers]
    ([EntryBy]);
GO

-- Creating foreign key on [DeletedBy] in table 'Costumers'
ALTER TABLE [dbo].[Costumers]
ADD CONSTRAINT [FK_ServiceBooking_AppUser1]
    FOREIGN KEY ([DeletedBy])
    REFERENCES [dbo].[AppUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_AppUser1'
CREATE INDEX [IX_FK_ServiceBooking_AppUser1]
ON [dbo].[Costumers]
    ([DeletedBy]);
GO

-- Creating foreign key on [EntryBy] in table 'ServiceBookings'
ALTER TABLE [dbo].[ServiceBookings]
ADD CONSTRAINT [FK_ServiceBooking_AppUser2]
    FOREIGN KEY ([EntryBy])
    REFERENCES [dbo].[AppUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_AppUser2'
CREATE INDEX [IX_FK_ServiceBooking_AppUser2]
ON [dbo].[ServiceBookings]
    ([EntryBy]);
GO

-- Creating foreign key on [DeletedBy] in table 'ServiceBookings'
ALTER TABLE [dbo].[ServiceBookings]
ADD CONSTRAINT [FK_ServiceBooking_AppUser3]
    FOREIGN KEY ([DeletedBy])
    REFERENCES [dbo].[AppUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_AppUser3'
CREATE INDEX [IX_FK_ServiceBooking_AppUser3]
ON [dbo].[ServiceBookings]
    ([DeletedBy]);
GO

-- Creating foreign key on [CostumerId] in table 'ServiceBookings'
ALTER TABLE [dbo].[ServiceBookings]
ADD CONSTRAINT [FK_ServiceBooking_Costumer]
    FOREIGN KEY ([CostumerId])
    REFERENCES [dbo].[Costumers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_Costumer'
CREATE INDEX [IX_FK_ServiceBooking_Costumer]
ON [dbo].[ServiceBookings]
    ([CostumerId]);
GO

-- Creating foreign key on [GenderId] in table 'Costumers'
ALTER TABLE [dbo].[Costumers]
ADD CONSTRAINT [FK_ServiceBooking_Gender]
    FOREIGN KEY ([GenderId])
    REFERENCES [dbo].[Genders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_Gender'
CREATE INDEX [IX_FK_ServiceBooking_Gender]
ON [dbo].[Costumers]
    ([GenderId]);
GO

-- Creating foreign key on [EmployeeTypeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Employeetype]
    FOREIGN KEY ([EmployeeTypeId])
    REFERENCES [dbo].[Employeetypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Employeetype'
CREATE INDEX [IX_FK_Employee_Employeetype]
ON [dbo].[Employees]
    ([EmployeeTypeId]);
GO

-- Creating foreign key on [GenderId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Gender]
    FOREIGN KEY ([GenderId])
    REFERENCES [dbo].[Genders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Gender'
CREATE INDEX [IX_FK_Employee_Gender]
ON [dbo].[Employees]
    ([GenderId]);
GO

-- Creating foreign key on [ServicedBy] in table 'ServiceBookings'
ALTER TABLE [dbo].[ServiceBookings]
ADD CONSTRAINT [FK_ServiceBooking_Employee]
    FOREIGN KEY ([ServicedBy])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceBooking_Employee'
CREATE INDEX [IX_FK_ServiceBooking_Employee]
ON [dbo].[ServiceBookings]
    ([ServicedBy]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------