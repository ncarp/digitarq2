if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AplicationEmployee_Aplications]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AplicationEmployee] DROP CONSTRAINT FK_AplicationEmployee_Aplications
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Functions_Aplications]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Functions] DROP CONSTRAINT FK_Functions_Aplications
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Profiles_Aplications]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Profiles] DROP CONSTRAINT FK_Profiles_Aplications
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AplicationEmployee_Employees]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AplicationEmployee] DROP CONSTRAINT FK_AplicationEmployee_Employees
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Logs_Employees]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Logs] DROP CONSTRAINT FK_Logs_Employees
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProfileEmployee_Employees]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProfileEmployee] DROP CONSTRAINT FK_ProfileEmployee_Employees
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProfileFunction_Functions]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProfileFunction] DROP CONSTRAINT FK_ProfileFunction_Functions
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProfileEmployee_Profiles]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProfileEmployee] DROP CONSTRAINT FK_ProfileEmployee_Profiles
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProfileFunction_Profiles]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProfileFunction] DROP CONSTRAINT FK_ProfileFunction_Profiles
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_countEmployees]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_countEmployees]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_deleteAplicationsEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_deleteAplicationsEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_deleteEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_deleteEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_deleteProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_deleteProfile]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_deleteProfileFunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_deleteProfileFunctions]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_getAllProfileFunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_getAllProfileFunctions]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_getProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_getProfile]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_getProfileFunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_getProfileFunctions]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_insertAplicationEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_insertAplicationEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_insertProfileEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_insertProfileEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_insertProfileFunction]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_insertProfileFunction]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_isFunctionOfProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_isFunctionOfProfile]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadAplications]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadAplications]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadAplicationsEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadAplicationsEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadEmployeeByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadEmployeeByID]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadEmployeeByUN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadEmployeeByUN]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadEmployees]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadEmployees]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_loadProfiles]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_loadProfiles]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_storeEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_storeEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_storeFunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_storeFunctions]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_storeProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_storeProfile]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_updateEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_updateEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_updatePDEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_updatePDEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_updateProfile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_updateProfile]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_validateEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_validateEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_validateStoreEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_validateStoreEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AplicationEmployee]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AplicationEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Aplications]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Aplications]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Employees]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Employees]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Functions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Functions]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Logs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Logs]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProfileEmployee]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProfileEmployee]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProfileFunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProfileFunction]
;

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Profiles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Profiles]
;

CREATE TABLE [dbo].[AplicationEmployee] (
	[AplicationID] [smallint] NOT NULL ,
	[EmployeeID] [int] NOT NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[Aplications] (
	[AplicationID] [smallint] NOT NULL ,
	[AplicationName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Version] [nvarchar] (20) COLLATE Latin1_General_CI_AS NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[Employees] (
	[EmployeeID] [int] IDENTITY (1, 1) NOT NULL ,
	[FirstName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[LastName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[UserName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Password] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Active] [bit] NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[Functions] (
	[FunctionID] [int] NOT NULL ,
	[ParentID] [int] NULL ,
	[FunctionName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Reference] [nvarchar] (200) COLLATE Latin1_General_CI_AS NULL ,
	[Control] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Aplication] [smallint] NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[Logs] (
	[LogID] [bigint] NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Date] [datetime] NULL ,
	[Employee] [int] NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[ProfileEmployee] (
	[ProfileID] [smallint] NOT NULL ,
	[EmployeeID] [int] NOT NULL ,
	[Aplication] [smallint] NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[ProfileFunction] (
	[ProfileID] [smallint] NOT NULL ,
	[FunctionID] [int] NOT NULL 
) ON [PRIMARY]
;

CREATE TABLE [dbo].[Profiles] (
	[ProfileID] [smallint] IDENTITY (1, 1) NOT NULL ,
	[Profile] [nvarchar] (50) COLLATE Latin1_General_CI_AS NULL ,
	[Aplication] [smallint] NULL 
) ON [PRIMARY]
;

ALTER TABLE [dbo].[AplicationEmployee] WITH NOCHECK ADD 
	CONSTRAINT [PK_AplicationEmployee] PRIMARY KEY  CLUSTERED 
	(
		[AplicationID],
		[EmployeeID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[Aplications] WITH NOCHECK ADD 
	CONSTRAINT [PK_Aplicactions] PRIMARY KEY  CLUSTERED 
	(
		[AplicationID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[Employees] WITH NOCHECK ADD 
	CONSTRAINT [PK_Employees] PRIMARY KEY  CLUSTERED 
	(
		[EmployeeID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[Functions] WITH NOCHECK ADD 
	CONSTRAINT [PK_Functions] PRIMARY KEY  CLUSTERED 
	(
		[FunctionID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[Logs] WITH NOCHECK ADD 
	CONSTRAINT [PK_Logs] PRIMARY KEY  CLUSTERED 
	(
		[LogID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[ProfileEmployee] WITH NOCHECK ADD 
	CONSTRAINT [PK_ProfileEmployee] PRIMARY KEY  CLUSTERED 
	(
		[ProfileID],
		[EmployeeID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[ProfileFunction] WITH NOCHECK ADD 
	CONSTRAINT [PK_ProfileFunction] PRIMARY KEY  CLUSTERED 
	(
		[ProfileID],
		[FunctionID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[Profiles] WITH NOCHECK ADD 
	CONSTRAINT [PK_Profiles] PRIMARY KEY  CLUSTERED 
	(
		[ProfileID]
	)  ON [PRIMARY] 
;

ALTER TABLE [dbo].[AplicationEmployee] ADD 
	CONSTRAINT [FK_AplicationEmployee_Aplications] FOREIGN KEY 
	(
		[AplicationID]
	) REFERENCES [dbo].[Aplications] (
		[AplicationID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_AplicationEmployee_Employees] FOREIGN KEY 
	(
		[EmployeeID]
	) REFERENCES [dbo].[Employees] (
		[EmployeeID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
;

ALTER TABLE [dbo].[Functions] ADD 
	CONSTRAINT [FK_Functions_Aplications] FOREIGN KEY 
	(
		[Aplication]
	) REFERENCES [dbo].[Aplications] (
		[AplicationID]
	)
;

ALTER TABLE [dbo].[Logs] ADD 
	CONSTRAINT [FK_Logs_Employees] FOREIGN KEY 
	(
		[Employee]
	) REFERENCES [dbo].[Employees] (
		[EmployeeID]
	)
;

ALTER TABLE [dbo].[ProfileEmployee] ADD 
	CONSTRAINT [FK_ProfileEmployee_Employees] FOREIGN KEY 
	(
		[EmployeeID]
	) REFERENCES [dbo].[Employees] (
		[EmployeeID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_ProfileEmployee_Profiles] FOREIGN KEY 
	(
		[ProfileID]
	) REFERENCES [dbo].[Profiles] (
		[ProfileID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
;

ALTER TABLE [dbo].[ProfileFunction] ADD 
	CONSTRAINT [FK_ProfileFunction_Functions] FOREIGN KEY 
	(
		[FunctionID]
	) REFERENCES [dbo].[Functions] (
		[FunctionID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_ProfileFunction_Profiles] FOREIGN KEY 
	(
		[ProfileID]
	) REFERENCES [dbo].[Profiles] (
		[ProfileID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
;

ALTER TABLE [dbo].[Profiles] ADD 
	CONSTRAINT [FK_Profiles_Aplications] FOREIGN KEY 
	(
		[Aplication]
	) REFERENCES [dbo].[Aplications] (
		[AplicationID]
	)
;


