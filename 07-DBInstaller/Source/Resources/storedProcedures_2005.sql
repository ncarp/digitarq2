SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadPFID2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadPFID2] @descr nvarchar(50), @descr2 nvarchar(50) as
	select ParentFondsID from components 
	where (otherlevel=@descr or otherlevel=@descr2)




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadPFID3]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadPFID3] @descr nvarchar(50), @descr2 nvarchar(50), @descr3 nvarchar(50) as
	select ParentFondsID from components 
	where (otherlevel=@descr or otherlevel=@descr2 or otherlevel=@descr3)




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadParochialRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadParochialRequest]
@EventID bigint
AS


SELECT PR.*,
KA.KindActionPrc
FROM ParochialRequest PR
LEFT JOIN KindActionPrc KA ON KA.KindActionPrcCode=PR.KindActionPrcCode
WHERE ParochialRequestID=@EventID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadProcessEvents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_loadProcessEvents]
@ProcessID int
AS

SELECT E.EventID, E.EntryExitID,  E.EventCode, CONVERT(VARCHAR(10),EventDate,126) AS EventDate, E.EmployeeID,
U.FullName AS FullNameUser
FROM Events E
LEFT JOIN Users U ON E.UserID=U.UserID
WHERE ProcessID=@ProcessID
ORDER BY SourceEventID






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadRelationshipInOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadRelationshipInOut]
@CorrespondenceInID bigint
AS
BEGIN TRANSACTION TranLoadRelationshipInOut
SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber, Type
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE CorrespondenceOutID in (SELECT CorrespondenceOut FROM RelationshipInOut WHERE CorrespondenceIn=@CorrespondenceInID)
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadRelationshipInOut
END
COMMIT TRANSACTION TranLoadRelationshipInOut





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadRelationshipOutIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadRelationshipOutIn]
@CorrespondenceOutID bigint
AS
BEGIN TRANSACTION TranLoadRelationshipOutIn
SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber, Type
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TypeID
WHERE CorrespondenceInID in (SELECT CorrespondenceIn FROM RelationshipInOut WHERE CorrespondenceOut=@CorrespondenceOutID )
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadRelationshipOutIn
END
COMMIT TRANSACTION TranLoadRelationshipOutIn





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDBLocation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getDBLocation]
	@DBLocation nvarchar(2000) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @path nvarchar(260)

	SET @Path = RTRIM((SELECT TOP 1 filename from digitarq2..sysfiles))
	SELECT @DBLocation=SUBSTRING(@path, 1, LEN(@path) - CHARINDEX(''\'', REVERSE(@path)))

END

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDBFilesLocation]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getDBFilesLocation] 
	-- Add the parameters for the stored procedure here
	@DBDataLocation nvarchar(2000) OUTPUT,
	@DBLogLocation nvarchar(2000) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @DBDataLocation=Filename FROM Digitarq2.dbo.sysfiles WHERE name LIKE ''%_Data''
	SELECT @DBLogLocation=Filename FROM Digitarq2.dbo.sysfiles WHERE name LIKE ''%_Log''
END
' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadRequests]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadRequests]
@RequestTypeCode int
AS

BEGIN TRANSACTION TranLoadRequests

IF (@RequestTypeCode=0)
BEGIN
SELECT EventID, E.EventCode, Status, U.UserID, FullName AS FullNameUser
FROM Events E INNER JOIN Users U ON E.UserID=U.UserID
END

ELSE
BEGIN
SELECT EventID, E.EventCode, U.UserID, FullName AS FullNameUser
FROM Events E INNER JOIN Users U ON E.UserID=U.UserID
WHERE E.EventCode=@RequestTypeCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadRequests
END

COMMIT TRANSACTION TranLoadRequests



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadServices]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'







CREATE PROCEDURE [dbo].[sp_loadServices]
@CategoryID int
AS

SELECT * FROM Services
WHERE CategoryID = @CategoryID






' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadUIDandCUID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadUIDandCUID] AS
	select UnitID, CompleteUnitID from components 




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadUserByUN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadUserByUN]
@UserName nvarchar(50)
AS
BEGIN TRANSACTION TranLoadUserByUN
SELECT * FROM Users
WHERE UserName = @UserName
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadUserByUN
END
COMMIT TRANSACTION TranLoadUserByUN



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadUIDandUITbyID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadUIDandUITbyID] @id int as
	select UnitID, UnitTitle from components 
	where ID=@id




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_searchCorrespondenceIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_searchCorrespondenceIn]
@ColumnNumber int,
@Term nvarchar(50)
AS
BEGIN TRANSACTION TranSearchCorrespondenceIn
DECLARE @ColumnName nvarchar(50)
SELECT @ColumnName=COL_NAME(OBJECT_ID(''CorrespondenceIn''), @ColumnNumber)
DECLARE @query nvarchar(500)
SET @query=''SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber FROM correspondencein WHERE '' + @ColumnName + '' LIKE '' + '''''''' + @Term + ''''''''
EXECUTE(@query)
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranSearchCorrespondenceIn
END
COMMIT TRANSACTION TranSearchCorrespondenceIn















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_searchCorrespondenceOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_searchCorrespondenceOut]
@ColumnNumber int,
@Term nvarchar(50)
AS
BEGIN TRANSACTION TranSearchCorrespondenceOut
DECLARE @ColumnName nvarchar(50)
SELECT @ColumnName=COL_NAME(OBJECT_ID(''CorrespondenceOut''), @ColumnNumber)
DECLARE @query nvarchar(500)
SET @query=''SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber FROM correspondenceOut WHERE '' + @ColumnName + '' LIKE '' + '''''''' + @Term + ''''''''
EXECUTE(@query)
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranSearchCorrespondenceOut
END
COMMIT TRANSACTION TranSearchCorrespondenceOut





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeBudget]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

















CREATE PROCEDURE [dbo].[sp_storeBudget]
@EventID bigint,
@Note nvarchar(100)
AS

INSERT INTO Budgets
VALUES(@EventID, @Note)
















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeBudgetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

















CREATE PROCEDURE [dbo].[sp_storeBudgetDetails]
@BudgetID bigint,
@ServiceID smallint,
@UnitPrice real,
@Quantity smallint
--@Discount real
AS

INSERT INTO BudgetDetails (BudgetID, ServiceID, Unitprice, Quantity)
VALUES(@BudgetID, @ServiceID, @UnitPrice, @Quantity)
















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcNumFundRev]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcNumFundRev] 
AS

SELECT COUNT(ID) AS Num FROM components 
WHERE OtherLevel=''F'' AND Valid=1





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcNumFundVis]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcNumFundVis] 
AS

SELECT COUNT(ID) AS Num FROM Components 
WHERE OtherLevel=''F'' AND Visible=1





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeCorrespondenceOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeCorrespondenceOut]
@EventID bigint,
@TypeExitCode nvarchar(20),
@YourDate datetime,
@Addressee nvarchar(200),
@YourReference nvarchar(50),
@Subject nvarchar(100),
@Attacheds text,
@Classification nvarchar(20),
@ProcessNumber int,
@Notes text,
@MaxID bigint OUTPUT
AS
BEGIN TRANSACTION TranStoreCorrespondenceOut
INSERT INTO CorrespondenceOut
VALUES(@EventID, @TypeExitCode, @YourDate, @Addressee, @YourReference,
@Subject, @Attacheds, @Classification, @ProcessNumber, @Notes)
SELECT @MaxID=@@IDENTITY
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreCorrespondenceOut
END
COMMIT TRANSACTION TranStoreCorrespondenceOut



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getLastEventID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getLastEventID]
	-- Add the parameters for the stored procedure here
	@EventID bigint,
	@LastEventID bigint OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @EntryExitID As BIGINT

    SELECT @EntryExitID=SourceEventID FROM Events
	WHERE EventID=@EventID

	SELECT @LastEventID=MAX(EventID) FROM Events
	WHERE SourceEventID=@EntryExitID
END

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotFunds]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcTotFunds]
AS

SELECT COUNT(*) AS Num FROM Components 
WHERE OtherLevel=''F''

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotFund]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotFund] 
AS

SELECT COUNT(ID) AS Num FROM components 
WHERE OtherLevel=''F''





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotReg]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_calcTotReg] AS
	select count(*) as Num from components




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotRegRev]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotRegRev] 
AS

SELECT COUNT(*) AS Num 
FROM components
WHERE valid=1





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotRegVis]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotRegVis] 
AS

SELECT COUNT(*) AS Num 
FROM Components
WHERE Visible=1





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcWarn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcWarn] 
AS

SELECT COUNT(*) AS Num 
FROM components 
WHERE NOT OtherLevel=''F'' AND (ParentID IS NULL OR ParentFondsID IS NULL)





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeRelationshipInOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeRelationshipInOut]
@CorrespondenceInID as bigint,
@CorrespondenceOutID as bigint
AS
BEGIN TRANSACTION TranStoreRelationshipInOut
INSERT INTO RelationshipInOut
VALUES (@CorrespondenceInID, @CorrespondenceOutID)
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreRelationshipInOut
END
COMMIT TRANSACTION TranStoreRelationshipInOut





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_changeStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_changeStatus]
@EventID bigint,
@Status int
AS

UPDATE Events 
SET 
Status=@Status
WHERE EventID=@EventID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeService]
@Service nvarchar(50),
@UnitPrice float,
@CategoryID int
AS

INSERT INTO Services
VALUES(@Service, @UnitPrice, @CategoryID)



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateBudget]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
















CREATE PROCEDURE [dbo].[sp_updateBudget]
@EventID bigint,
@Note nvarchar(100)
AS

DECLARE @BudgetID bigint

BEGIN TRANSACTION TranUpdateBudget

SELECT @BudgetID=BudgetID FROM Budgets
WHERE BudgetID=@EventID

IF (@BudgetID IS NULL)
BEGIN
INSERT INTO Budgets
VALUES(@EventID, @Note)
END
ELSE IF (@BudgetID IS NOT NULL)
BEGIN
UPDATE Budgets
SET Note=@Note
WHERE BudgetID=@EventID
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateBudget
END
COMMIT TRANSACTION TranUpdateBudget
















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateAplication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateAplication]
@AplicationCode nvarchar(50),
@AplicationName nvarchar(50),
@Version nvarchar(50)

AS

BEGIN TRANSACTION TranUpdateAplication

UPDATE Aplications
SET AplicationName=@AplicationName,
Version=@Version
WHERE AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateAplication
END

COMMIT TRANSACTION TranUpdateAplication



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteBudgetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteBudgetDetails]
@BudgetID int
AS
DELETE FROM BudgetDetails
WHERE BudgetID = @BudgetID

















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'














CREATE PROCEDURE [dbo].[sp_deleteService]
@ServiceID int
AS
DELETE FROM Services
WHERE ServiceID = @ServiceID














' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteTaskDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


















CREATE PROCEDURE [dbo].[sp_deleteTaskDetails]
@TaskID int
AS
DELETE FROM TaskDetails
WHERE TaskID = @TaskID

















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateService]
@ServiceID int,
@Service nvarchar(50),
@UnitPrice float
AS

UPDATE Services
SET Service=@Service,
UnitPrice=@Unitprice
WHERE ServiceID=@ServiceID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateSourceEventID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [dbo].[sp_updateSourceEventID]
@EventID bigint,
@SourceEventID bigint
AS

BEGIN TRANSACTION TranUpdateAplication

UPDATE Events
SET SourceEventID=@SourceEventID
WHERE EventID=@EventID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateAplication
END

COMMIT TRANSACTION TranUpdateAplication




' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getCompleteUnitIDFromID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_getCompleteUnitIDFromID]
@ID bigint
AS

SELECT CompleteUnitID 
FROM Components 
WHERE ID=@ID


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_updateUser]
@UserID int,
@FullName nvarchar(100),
@UserName nvarchar(50),
@Password nvarchar(50),
@Sex char(1),
@BirthDate nvarchar(20),
@Institution nvarchar(100),
@HomePhone nvarchar(20),
@MobilePhone nvarchar(20),
@Fax nvarchar(20),
@Email nvarchar(100),
@Address nvarchar(200),
@Locality nvarchar(75),
@PostalCode nvarchar(20),
@CountryCode int,
@Nationality nvarchar(75),
@IdentityCard bigint,
@ContributorNumber bigint,
@ProfessionID int,
@WorkAreaID int,
@ActivityAreaID int,
@AcademicsHabID int
AS

BEGIN TRANSACTION TranUpdateUser

UPDATE Users
SET 
FullName=@FullName, 
UserName=@UserName, 
Password=@Password, 
Sex=@Sex, 
Institution=@Institution, 
HomePhone=@HomePhone, 
MobilePhone=@MobilePhone, 
Fax=@Fax, 
Email=@Email, 
Address=@Address,
Locality=@Locality, 
PostalCode=@PostalCode, 
CountryCode=@CountryCode, 
Nationality=@Nationality, 
IdentityCard=@IdentityCard,
ContributorNumber=@ContributorNumber, 
ProfessionID=@ProfessionID, 
WorkAreaID=@WorkAreaID,
ActivityAreaID=@ActivityAreaID,
AcademicsHabID=@AcademicsHabID
WHERE UserID=@UserID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateUser
END

COMMIT TRANSACTION TranUpdateUser' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateUserPassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





















CREATE PROCEDURE [dbo].[sp_updateUserPassword]
@UserID int,
@Password nvarchar(50)
AS

UPDATE Users
SET 
Password=@Password
WHERE UserID=@UserID





















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDescrD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getDescrD] as
	SELECT UnitID, UnitTitle FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''DC'',''D''))
	ORDER BY UnitID




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDescrF]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_getDescrF] as
	SELECT UnitID, UnitTitle FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''F'',''SF'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''SC'',''SSC'',''SSSC'',''SR'',''SSR'',''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))
	ORDER BY UnitID




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDescrSC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getDescrSC] as
	SELECT UnitID, UnitTitle FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''SC'',''SSC'',''SSSC'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''SR'',''SSR'',''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))
	ORDER BY UnitID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_validateStoreUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_validateStoreUser]
@UserName nvarchar(50)
AS


BEGIN TRANSACTION TranValidateStoreUser

SELECT * FROM Users
WHERE UserName=@UserName
AND UserName<>''''

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranValidateStoreUser
END

COMMIT TRANSACTION TranValidateStoreUser



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDescrSR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getDescrSR] as
	SELECT UnitID, UnitTitle FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''SR'',''SSR'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))
	ORDER BY UnitID




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_validateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_validateUser]
@UserName nvarchar(50),
@Password nvarchar(50)
AS

BEGIN TRANSACTION TranValidateUser

IF (ISNUMERIC(@Username)=1)
BEGIN
SELECT UserID, UserType, UserName,  FullName, Institution
FROM Users
WHERE UserID=CONVERT(BIGINT,@UserName)
AND Password=@Password
END

ELSE IF (ISNUMERIC(@UserName)=0)
BEGIN
SELECT UserID, UserType, UserName,  FullName, Institution
FROM Users
WHERE Username=@UserName 
AND Password=@Password
END


IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranValidateUser
END

COMMIT TRANSACTION TranValidateUser


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDescrUI]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getDescrUI] as
	SELECT UnitID, UnitTitle FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''UI'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''DC'',''D'') AND ParentFondsID IS NOT NULL))
	ORDER BY UnitID




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_validateUserByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_validateUserByID]
@UserID int,
@Password nvarchar(50)
AS

BEGIN TRANSACTION TranValidateUser

SELECT UserID, UserName, FullName
FROM Users
WHERE UserID=@UserID
AND Password=@Password

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranValidateUser
END

COMMIT TRANSACTION TranValidateUser



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getIDFromCompleteUnitID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_getIDFromCompleteUnitID]
@CompleteUnitID nvarchar(200)
AS

SELECT ID 
FROM Components 
WHERE CountryCode + ''/'' + RepositoryCode + ''/'' + CompleteUnitID=@CompleteUnitID


























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNDescrD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getNDescrD] as
	SELECT count(UnitID) as Num FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''DC'',''D''))




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNDescrF]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getNDescrF] as
	SELECT count(UnitID) as Num FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''F'',''SF'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''SC'',''SSC'',''SSSC'',''SR'',''SSR'',''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNDescrSC]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getNDescrSC] as
	SELECT count(UnitID) as Num FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''SC'',''SSC'',''SSSC'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''SR'',''SSR'',''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNDescrSR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getNDescrSR] as
	SELECT count(UnitID) as Num FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''SR'',''SSR'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''UI'',''DC'',''D'') AND ParentFondsID IS NOT NULL))




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getNDescrUI]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





























CREATE PROCEDURE [dbo].[sp_getNDescrUI] as
	SELECT count(UnitID) as Num FROM Components WHERE ID IN(
	SELECT ParentFondsID FROM Components C
	WHERE OtherLevel IN (''UI'')
	AND ParentFondsID NOT IN (SELECT ParentFondsID FROM Components WHERE Otherlevel IN (''DC'',''D'') AND ParentFondsID IS NOT NULL))




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getOtherLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_getOtherLevel]
@CompleteUnitID nvarchar(100)
AS

BEGIN TRANSACTION TranGetOtherLevel

SELECT OtherLevel 
FROM Components 
WHERE CountryCode + ''/'' + RepositoryCode + ''/'' + CompleteUnitId =@CompleteUnitID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranGetOtherLevel
END

COMMIT TRANSACTION TranGetOtherLevel




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getYears]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_getYears] as
	select YEAR(date) y from Logs
	group by YEAR(date)


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getRequestSubType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getRequestSubType]
@RequestID bigint,
@RequestSubType int OUTPUT
AS
SELECT @RequestSubType FROM ReproductionRequest WHERE ReproductionRequestID = @RequestID





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getRequestType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getRequestType]
@RequestID bigint
AS

BEGIN TRANSACTION TranGetRequestType

SELECT EventCode
FROM Events WHERE EventID = @RequestID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranGetRequestType
END

COMMIT TRANSACTION TranGetRequestType



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAplication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadAplication]
@AplicationCode nvarchar(50)

AS

BEGIN TRANSACTION TranLoadAplication

SELECT * FROM Aplications
WHERE AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadAplication
END

COMMIT TRANSACTION TranLoadAplication



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAplications]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadAplications]
AS

BEGIN TRANSACTION TranLoadAplications

SELECT * FROM Aplications

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadAplications
END

COMMIT TRANSACTION TranLoadAplications



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadBudget]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
























CREATE PROCEDURE [dbo].[sp_loadBudget]
@EventID bigint
AS

select * from Budgets 
WHERE BudgetID=@EventID
























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadBudgetDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

















CREATE PROCEDURE [dbo].[sp_loadBudgetDetails]
@EventID bigint
AS

SELECT S.ServiceID, S.Service, C.Category,  BD.Quantity, BD.UnitPrice
FROM BudgetDetails BD
INNER JOIN Services S ON S.ServiceID=BD.ServiceID
INNER JOIN Categories C ON C.CategoryID=S.CategoryID
WHERE BD.BudgetID=@EventID
















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCUIDF]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




















CREATE PROCEDURE [dbo].[sp_loadCUIDF] AS
	select CompleteUnitID, ExtentMl from components
	where otherlevel=''F''




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCorrespondenceInOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'











CREATE PROCEDURE [dbo].[sp_loadCorrespondenceInOut]
@CorrespondenceInID bigint
--@ProcessNumber int,
--@Addressee nvarchar(200)
AS
BEGIN TRANSACTION TranLoadCorrespondenceInOut
DECLARE @ProcessNumber int, @Addressee nvarchar(200),
@Classification nvarchar(20), @YourDate smalldatetime
SELECT @ProcessNumber=ProcessNumber, @Addressee=Provenance,
@Classification=Classification, @YourDate=DocumentDate
FROM CorrespondenceIn
WHERE CorrespondenceInID=@CorrespondenceInID
IF(@ProcessNumber IS NULL AND @YourDate IS NULL)
BEGIN
SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber, Type
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE Addressee=@Addressee Or @Classification=Classification
END
ELSE IF(@ProcessNumber IS NULL)
BEGIN
SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber, Type
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE Addressee=@Addressee Or @Classification=Classification Or 
@YourDate=YourDate
END
ELSE IF(@YourDate IS NULL)
BEGIN
SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber, Type
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE ProcessNumber=@ProcessNumber OR Addressee=@Addressee Or
@Classification=Classification
END
ELSE 
BEGIN
SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
convert(varchar(10),ExitDate,126) as ExitDate, 
Addressee, YourReference, Classification, ProcessNumber, Type
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE ProcessNumber=@ProcessNumber OR Addressee=@Addressee Or
@Classification=Classification Or @YourDate=YourDate
END
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadCorrespondenceInOut
END
COMMIT TRANSACTION TranLoadCorrespondenceInOut











' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCorrespondenceOutIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadCorrespondenceOutIn]
@CorrespondenceOutID bigint
--@ProcessNumber int,
--@Provenance nvarchar(200)
AS
BEGIN TRANSACTION TranLoadCorrespondenceIn
DECLARE @ProcessNumber int, @Provenance nvarchar(200),
@Classification nvarchar(20), @DocumentDate smalldatetime
SELECT @ProcessNumber=ProcessNumber, @Provenance=Addressee,
@Classification=Classification, @DocumentDate=YourDate
FROM CorrespondenceOut
WHERE CorrespondenceOutID = @CorrespondenceOutID
IF (@ProcessNumber IS NULL AND @DocumentDate IS NULL)
BEGIN
SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber, Type
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TypeID
WHERE Provenance=@Provenance Or @Classification=Classification
END
IF (@ProcessNumber IS NULL)
BEGIN
SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber, Type
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TypeID
WHERE Provenance=@Provenance Or @Classification=Classification Or 
@DocumentDate=DocumentDate
END
IF (@DocumentDate IS NULL)
BEGIN
SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber, Type
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TypeID
WHERE ProcessNumber=@ProcessNumber OR Provenance=@Provenance Or
@Classification=Classification
END
ELSE
BEGIN
SELECT CorrespondenceInID, convert(varchar(10),DocumentDate,126) as DocumentDate, 
convert(varchar(10),EntryDate,126) as EntryDate, 
Provenance, Reference, Classification, ProcessNumber, Type
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TypeID
WHERE ProcessNumber=@ProcessNumber OR Provenance=@Provenance Or
@Classification=Classification Or @DocumentDate=DocumentDate
END
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadCorrespondenceIn
END
COMMIT TRANSACTION TranLoadCorrespondenceIn





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadDigitarqInfoFromCompleteUnitID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


























CREATE PROCEDURE [dbo].[sp_loadDigitarqInfoFromCompleteUnitID]
@Reference nvarchar(100)
AS

BEGIN TRANSACTION TranLoadDigitarqInfo

SELECT ID, PhysLoc 
FROM Components 
WHERE CompleteUnitID =@Reference

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadDigitarqInfo
END

COMMIT TRANSACTION TranLoadDigitarqInfo

























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadDigitarqInfoFromID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadDigitarqInfoFromID]
@ID bigint
AS

SELECT ID, CountryCode, RepositoryCode, CompleteUnitID, ParentID, UnitTitle, PhysLoc, OtherLevel,
UnitDateInitial, UnitDateInitialCertainty, UnitDateFinal, UnitDateFinalCertainty, AltFormAvail
FROM Components 
WHERE ID =@ID























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadDigitarqInfoFromParentID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


























CREATE PROCEDURE [dbo].[sp_loadDigitarqInfoFromParentID]
@ParentID bigint
AS

BEGIN TRANSACTION TranLoadDigitarqInfo

SELECT ParentID, UnitTitle, OtherLevel 
FROM Components 
WHERE ID =@ParentID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadDigitarqInfo
END

COMMIT TRANSACTION TranLoadDigitarqInfo

























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEventTypes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadEventTypes]
AS

SELECT * FROM EventTypes



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadFullCorrespondenceIn]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_loadFullCorrespondenceIn]
@CorrespondenceInID bigint
AS
BEGIN TRANSACTION TranLoadFullCorrespondenceIn
--SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
--convert(varchar(10),ExitDate,126) as ExitDate, 
--Addressee, YourReference, Classification, ProcessNumber, Type
SELECT * 
FROM CorrespondenceIn CI INNER JOIN TypesEntryExit TEE ON CI.TypeEntry=TEE.TypeID
WHERE CorrespondenceInID=@CorrespondenceInID
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadFullCorrespondenceIn
END
COMMIT TRANSACTION TranLoadFullCorrespondenceOut















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadFullCorrespondenceOut]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadFullCorrespondenceOut]
@CorrespondenceOutID bigint
AS
BEGIN TRANSACTION TranLoadFullCorrespondenceOut
--SELECT CorrespondenceOutID, convert(varchar(10),YourDate,126) as YourDate, 
--convert(varchar(10),ExitDate,126) as ExitDate, 
--Addressee, YourReference, Classification, ProcessNumber, Type
SELECT * 
FROM CorrespondenceOut CO INNER JOIN TypesEntryExit TEE ON CO.TypeExit=TEE.TypeID
WHERE CorrespondenceOutID=@CorrespondenceOutID
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadFullCorrespondenceOut
END
COMMIT TRANSACTION TranLoadFullCorrespondenceOut





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadIDFunds]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadIDFunds] as
	select ID from components 
	where otherlevel=''F''




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadIDUID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadIDUID] AS
	select ID, UnitId from components




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadNotaryRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadNotaryRequest]
@EventID bigint
AS

SELECT PR.*,
KA.KindActionNot
FROM NotaryRequest PR
LEFT JOIN KindActionNot KA ON KA.KindActionNotCode=PR.KindActionNotCode
WHERE NotaryRequestID=@EventID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadOtherRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadOtherRequest]
@EventID bigint
AS

SELECT *
FROM OtherRequest
WHERE OtherRequestID=@EventID



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadPFID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadPFID] @descr nvarchar(50) as
	select ParentFondsID from components 
	where otherlevel=@descr




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateEvent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_updateEvent]
@EventID bigint,
@DerivedFrom bigint,
@SourceEventID bigint,
@EntryExit bit,
@EventCode int,
@SourceEventCode int,
@Status int,
@Classification nvarchar(50),
@NoteToNext nvarchar(1500),
@Notification nvarchar(1000),
@UserID int,
@EmployeeID nvarchar(50),
@ProcessID bigint
AS

UPDATE Events 
SET 
DerivedFrom=@DerivedFrom,
SourceEventID=@SourceEventID,
EntryExit=@EntryExit,
EventCode=@EventCode,
SourceEventCode=@SourceEventCode,
Status=@Status,
Classification=@Classification,
NoteToNext=@NoteToNext,
Notification=@Notification,
UserID=@UserID,
EmployeeID=@EmployeeID,
ProcessID=@ProcessID
WHERE EventID=@EventID







' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadUserRequests]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadUserRequests]
@RequestTypeCode int,
@UserID int
AS

BEGIN TRANSACTION TranLoadRequests

DECLARE @ProfileID int

SELECT @ProfileID=ProfileID FROM Profiles
WHERE Profile=''Utilizador''

IF (@RequestTypeCode=0)
BEGIN
SELECT E.*, U.UserID, FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND E.UserID=@UserID
ORDER BY E.EventID DESC
END

ELSE
BEGIN
SELECT E.*, U.UserID, FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND E.UserID=@UserID
AND EventCode=@RequestTypeCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadRequests
END

COMMIT TRANSACTION TranLoadRequests







' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeEvent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeEvent]
@DerivedFrom bigint,
@SourceEventID bigint,
@EntryExit bit,
@EventCode int,
@SourceEventCode int,
@Status nvarchar(20),
@Classification nvarchar(20),
@NoteToNext nvarchar(1500),
@Notification nvarchar(1000),
@UserID int,
@EmployeeID nvarchar(50),
@ProcessID int,
@EventID bigint OUTPUT,
@EntryExitIDOUT bigint OUTPUT
AS

IF @EntryExit=0
BEGIN
INSERT INTO Events 
VALUES(NULL,@DerivedFrom,@SourceEventID,@EntryExit,getdate(),@EventCode,@SourceEventCode,
@Status,@Classification,@NoteToNext,@Notification,@UserID,@EmployeeID,@ProcessID)
END
ELSE IF @EntryExit=1
BEGIN
DECLARE @EntryExitID as bigint
SELECT @EntryExitID=MAX(EntryExitID) FROM Events
IF (@EntryExitID IS NULL)
BEGIN
SET @EntryExitID=0
END
INSERT INTO Events 
VALUES(@EntryExitID+1,@DerivedFrom,@SourceEventID,@EntryExit,getdate(),@EventCode,@SourceEventCode,
@Status,@Classification,@NoteToNext,@Notification,@UserID,@EmployeeID,@ProcessID)
END

SELECT @EventID = @@IDENTITY
SELECT @EntryExitIDOUT = Max(EntryExitID) FROM Events





' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEvent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadEvent]
@EventID int
AS

SELECT E.*, P.OtherProcessID,
U.FullName AS FullNameUser
FROM Events E
LEFT JOIN Users U ON E.UserID=U.UserID
LEFT JOIN Processes P ON E.ProcessID=P.ProcessID
WHERE EventID=@eventID



' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotLog] 
@y nvarchar(4), 
@op as nvarchar(50) 
AS
	
SELECT COUNT(*) AS Num FROM Logs
WHERE YEAR(date)=@y 
AND FunctionCode=@op





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcNumOpsPerUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcNumOpsPerUser] 
@y nvarchar(4), 
@op nvarchar(50)
AS

SELECT UserName, COUNT(*) AS Num FROM Logs 
WHERE YEAR(date)=@y 
AND FunctionCode=@op 
GROUP BY UserName





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotYear]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotYear] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@FunctionCode int, 
@y nvarchar(4)
AS
 
SELECT COUNT(*) AS Num 
FROM Logs
WHERE UserName=@UserName 
AND FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND YEAR(date)=@y





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotYearAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcTotYearAll] 
@descr as nvarchar(50), 
@FunctionCode nvarchar(50), 
@y nvarchar(4)
AS 
SELECT COUNT(*) AS Num
FROM Logs
WHERE FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND	YEAR(date)=@y






























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMon]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMon] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@FunctionCode nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4)
AS 

SELECT COUNT(*) AS Num FROM Logs
WHERE UserName=@UserName 
AND FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND	MONTH(date)=@m AND YEAR(date)=@y





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotDay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotDay] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@FunctionCode nvarchar(50), 
@d nvarchar(2), 
@m nvarchar(2), 
@y nvarchar(4) 
AS
 
SELECT COUNT(*) AS Num FROM Logs
where UserName=@UserName 
AND FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND DAY(date)=@d AND MONTH(date)=@m AND YEAR(date)=@y





























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMonAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMonAll] 
@descr nvarchar(50), 
@FunctionCode nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4) AS 

SELECT COUNT(*) AS Num FROM Logs
WHERE FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND MONTH(date)=@m AND YEAR(date)=@y






























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMonAll2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMonAll2] 
@FunctionCode nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4) 
AS 

SELECT COUNT(*) AS Num 
FROM Logs
WHERE FunctionCode=@FunctionCode
AND	MONTH(date)=@m AND YEAR(date)=@y

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMonAll2Al]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMonAll2Al] 
@m nvarchar(2), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE (FunctionCode=4 or FunctionCode=8)
AND	MONTH(date)=@m AND YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotYearAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotYearAl] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE UserName=@UserName 
AND (FunctionCode=4 OR FunctionCode=8) 
AND Description LIKE @descr
AND YEAR(date)=@y
Group by Description


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotPeriod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotPeriod] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@FunctionCode int, 
@from nvarchar(10), 
@to nvarchar(10) 
AS
 
SELECT COUNT(*) AS Num FROM Logs
WHERE UserName=@UserName 
AND FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND	date>=@from AND date<=@to

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotYearAllAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotYearAllAl] 
@descr as nvarchar(50), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE (FunctionCode=4 OR FunctionCode=8) 
AND Description LIKE @descr 
AND	YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotPeriodAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotPeriodAll] 
@descr nvarchar(50), 
@FunctionCode nvarchar(50), 
@from nvarchar(10), 
@to nvarchar(10) 
AS 

SELECT COUNT(*) AS Num 
FROM Logs
WHERE FunctionCode=@FunctionCode 
AND Description LIKE @descr 
AND	date>@from AND date<@to

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotPeriodAllAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcTotPeriodAllAl] 
@descr nvarchar(50), 
@from nvarchar(10), 
@to nvarchar(10) 
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE (FunctionCode=4 OR FunctionCode=8)
AND Description LIKE @descr
AND	date>@from AND date<@to
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotPeriodAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotPeriodAl] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@from nvarchar(10), 
@to nvarchar(10) 
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE UserName=@UserName 
AND (FunctionCode=4 OR FunctionCode=8) 
AND Description LIKE @descr 
AND date>=@from AND date<=@to
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMonAllAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcTotMonAllAl] 
@descr nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE (FunctionCode=4 or FunctionCode=8) 
AND Description LIKE @descr 
AND	MONTH(date)=@m AND YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotDayAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotDayAl] 
@UserName nvarchar(50), 
@descr as nvarchar(50), 
@d nvarchar(2), 
@m nvarchar(2), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num FROM Logs
WHERE UserName=@UserName 
AND (FunctionCode=4 OR FunctionCode=8) 
AND Description LIKE @descr 
AND DAY(date)=@d AND MONTH(date)=@m AND YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMon2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_calcTotMon2] 
@UserName nvarchar(50), 
@FunctionCode nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4) 
AS 

SELECT COUNT(*) AS Num FROM Logs
WHERE UserName=@UserName 
AND FunctionCode=@FunctionCode 
AND MONTH(date)=@m AND YEAR(date)=@y

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMonAl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMonAl] 
@UserName nvarchar(50), 
@descr nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4)
AS 

SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE UserName=@UserName
AND (FunctionCode=4 OR FunctionCode=8) 
AND Description LIKE @descr 
AND MONTH(date)=@m AND YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_calcTotMon2Al]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_calcTotMon2Al] 
@UserName nvarchar(50), 
@m nvarchar(2), 
@y nvarchar(4)
AS 
	
SELECT Description, COUNT(*) AS Num 
FROM Logs
WHERE UserName=@UserName 
AND (FunctionCode=4 OR FunctionCode=8) 
AND	MONTH(date)=@m AND YEAR(date)=@y
GROUP BY Description

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countLogsByUsername]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Luís Miguel Ferros
-- Create date: 2008-01-10
-- Description:	Count logs and group by Username
-- =============================================
CREATE PROCEDURE [dbo].[sp_countLogsByUsername]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Username, COUNT(*) LogCount 
	FROM Logs
	GROUP BY Username

END
' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countLogsByYear]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_countLogsByYear] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DATEPART(YY, Date) AS LogYear, COUNT(*) LogCount 
	FROM Logs
	GROUP BY DATEPART(YY, Date)
END
' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadTaskDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadTaskDetails]
@EventID bigint
AS

SELECT S.ServiceID, S.Service, C.Category,  TD.Quantity, TD.UnitPrice,
TD.Attached, TD.AttachedName, TD.AttachedType, TD.AttachedLength
FROM TaskDetails TD
INNER JOIN Services S ON S.ServiceID=TD.ServiceID
INNER JOIN Categories C ON C.CategoryID=S.CategoryID
WHERE TD.TaskID=@EventID


















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeReproductionRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeReproductionRequest]
@EventID bigint,
@ReferenceDigitarq nvarchar(200),
@Search bit,
@Reproduction bit,
@TypeReproductionCode int,
@Certificate bit,
@TypeCertificateCode int,
@Destination nvarchar(100),
@RedutionsCosts nvarchar(100),
@NumberCopies int,
@AdditionalInformation nvarchar(1000),
@RequestSubTypeCode tinyint
AS

BEGIN TRANSACTION TranStoreReproductionReq

INSERT INTO ReproductionRequest 
VALUES(@EventID,@ReferenceDigitarq,@Search,@Reproduction,@TypeReproductionCode,
@Certificate,@TypeCertificateCode,@Destination,@RedutionsCosts,@NumberCopies,
@AdditionalInformation,@RequestSubTypeCode)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreReproductionReq
END

COMMIT TRANSACTION TranStoreReproductionReq






























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateReproductionRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_updateReproductionRequest]
@EventID bigint,
@ReferenceDigitarq nvarchar(100),
@Search bit,
@Reproduction bit,
@TypeReproductionCode int,
@Certificate bit,
@TypeCertificateCode int,
@Destination nvarchar(200),
@RedutionsCosts nvarchar(50),
@NumberCopies int,
@AdditionalInformation nvarchar(1000),
@RequestSubTypeCode nvarchar(20)
AS

DECLARE @RepReqID bigint

BEGIN TRANSACTION TranUpdateReproductionReq

SELECT @RepReqID=ReproductionRequestID FROM ReproductionRequest
WHERE ReproductionRequestID=@EventID

IF (@RepReqID IS NULL)
BEGIN
INSERT INTO ReproductionRequest 
VALUES(@EventID,@ReferenceDigitarq,@Search,@Reproduction,@TypeReproductionCode,
@Certificate,@TypeCertificateCode,@Destination,@RedutionsCosts,@NumberCopies,
@AdditionalInformation,@RequestSubTypeCode)
END
ELSE IF (@RepReqID IS NOT NULL)
BEGIN
UPDATE ReproductionRequest 
SET ReproductionRequestID=@EventID,
ReferenceDigitarq=@ReferenceDigitarq,
Search=@Search,
Reproduction=@Reproduction,
TypeReproductionCode=@TypeReproductionCode,
Certificate=@Certificate,
TypeCertificateCode=@TypeCertificateCode,
Destination=@Destination,
RedutionsCosts=@RedutionsCosts,
NumberCopies=@NumberCopies,
AdditionalInformation=@AdditionalInformation,
RequestSubTypeCode=@RequestSubTypeCode
WHERE ReproductionRequestID=@EventID
END


IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateReproductionReq
END

COMMIT TRANSACTION TranUpdateReproductionReq






























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeTaskDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeTaskDetails]
@TaskID bigint,
@ServiceID smallint,
@UnitPrice float,
@Quantity smallint,
@Attached image,
@AttachedName nvarchar(300),
@AttachedType nvarchar(200),
@AttachedLength bigint
AS

INSERT INTO TaskDetails 
(TaskID, ServiceID, Unitprice, Quantity, Attached, AttachedName, AttachedType, AttachedLength)
VALUES(@TaskID, @ServiceID, @UnitPrice, @Quantity, 
@Attached, @AttachedName, @AttachedType, @AttachedLength)

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_accessFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_accessFunction]
@UserName nvarchar(50),
@FunctionCode nvarchar(50)
AS

BEGIN TRANSACTION TranAccessFunction

SELECT F.*
FROM Functions F INNER JOIN ProfileFunction PF ON F.FunctionCode=PF.FunctionCode
INNER JOIN Profiles P ON PF.ProfileID=P.ProfileID
INNER JOIN AplicationEmployee AE ON P.ProfileID=AE.ProfileID
INNER JOIN Employees E ON AE.UserName=E.UserName
WHERE E.UserName=@UserName AND F.FunctionCode=@FunctionCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranAccessFunction
END

COMMIT TRANSACTION TranAccessFunction




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeFunction]
@FunctionCode nvarchar(50),
@ParentCode nvarchar(50),
@FunctionName nvarchar(50),
@AplicationCode nvarchar(50)
AS

BEGIN TRANSACTION TranStoreFunction

IF (@ParentCode=''null'')
BEGIN
INSERT INTO Functions (FunctionCode,ParentCode,FunctionName,AplicationCode)
VALUES(@FunctionCode,NULL,@FunctionName,@AplicationCode)
END
ELSE
BEGIN
INSERT INTO Functions (FunctionCode,ParentCode,FunctionName,AplicationCode)
VALUES(@FunctionCode,@ParentCode,@FunctionName,@AplicationCode)
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreFunction
END

COMMIT TRANSACTION TranStoreFunction



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteAplication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteAplication]
@AplicationCode nvarchar(50)

AS

BEGIN TRANSACTION TranDeleteAplication

DELETE FROM ProfileFunction
WHERE ProfileID IN (SELECT ProfileID FROM Profiles WHERE AplicationCode=@AplicationCode)

DELETE FROM Profiles
WHERE AplicationCode=@AplicationCode

DELETE FROM Functions
WHERE AplicationCode=@AplicationCode

DELETE FROM AplicationEmployee
WHERE AplicationCode=@AplicationCode

DELETE FROM Aplications
WHERE AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteAplication
END

COMMIT TRANSACTION TranDeleteAplication




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateFunction]
@FunctionCode nvarchar(50),
@ParentCode nvarchar(50),
@FunctionName nvarchar(50)
AS


BEGIN TRANSACTION TranUpdateFunction

UPDATE Functions 
SET ParentCode=@ParentCode,
FunctionName=@FunctionName
WHERE FunctionCode=@FunctionCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateFunction
END

COMMIT TRANSACTION TranUpdateFunction



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteFunction]
@FunctionCode nvarchar(50),
@AplicationCode as nvarchar(50)
AS

BEGIN TRANSACTION TranDeleteFunction

--DELETE FROM ProfileFunction
--WHERE FunctionCode=@FunctionCode

DELETE Functions
WHERE (FunctionCode=@FunctionCode
OR ParentCode=@FunctionCode
OR ParentCode in (SELECT FunctionCode FROM Functions WHERE ParentCode=@FunctionCode)
OR ParentCode in (SELECT FunctionCode FROM Functions WHERE ParentCode in (SELECT FunctionCode FROM Functions WHERE ParentCode=@FunctionCode)))
AND AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteFunction
END

COMMIT TRANSACTION TranDeleteFunction




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_functionsChildren]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_functionsChildren]
@FunctionCode nvarchar(50)
AS

BEGIN TRANSACTION TranFunctionsChildren

SELECT * FROM Functions
WHERE ParentCode=@FunctionCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranFunctionsChildren
END

COMMIT TRANSACTION TranfunctionsChildren



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getAplicationFunctions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getAplicationFunctions]
@AplicationCode nvarchar(50),
@ParentCode nvarchar(50)
AS

BEGIN TRANSACTION TranGetAplicationFunctions

IF (@ParentCode=''null'')
BEGIN
SELECT * FROM Functions 
WHERE AplicationCode=@AplicationCode
AND ParentCode IS NULL
END
ELSE
BEGIN
SELECT * FROM Functions 
WHERE AplicationCode=@AplicationCode
AND ParentCode=@ParentCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranGetAplicationFunctions
END

COMMIT TRANSACTION TranGetAplicationFunctions



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getAllProfileFunctions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getAllProfileFunctions]
@AplicationCode nvarchar(50),
@ProfileID int,
@ParentCode nvarchar(50)
AS

BEGIN TRANSACTION TranAllProfileFunctions

IF (@ParentCode=''null'')
BEGIN
SELECT FunctionCode,  FunctionName, Exist=1 FROM Functions 
WHERE FunctionCode in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID=@ProfileID) 
AND ParentCode IS NULL AND AplicationCode=@AplicationCode
UNION
SELECT FunctionCode,  FunctionName, Exist=0 FROM Functions 
WHERE FunctionCode not in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID=@ProfileID) 
AND ParentCode IS NULL AND AplicationCode=@AplicationCode
END
ELSE
BEGIN
SELECT FunctionCode,  FunctionName, Exist=1 FROM Functions 
WHERE FunctionCode in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID=@ProfileID) 
AND ParentCode=@ParentCode AND AplicationCode=@AplicationCode
UNION
SELECT FunctionCode,  FunctionName, Exist=0 FROM Functions 
WHERE FunctionCode not in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID=@ProfileID) 
AND ParentCode=@ParentCode AND AplicationCode=@AplicationCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranAllProfileFunctions
END

COMMIT TRANSACTION TranAllProfileFunctions



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getFunction]
@FunctionCode nvarchar(50)

AS

BEGIN TRANSACTION TranGetAplicationFunctions

SELECT * FROM Functions 
WHERE FunctionCode=@FunctionCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranGetAplicationFunctions
END

COMMIT TRANSACTION TranGetAplicationFunctions




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getProfileFunctions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_getProfileFunctions]
@ProfileID int,
@ParentCode nvarchar(50)
AS

BEGIN TRANSACTION TranProfileFunctions

IF (@ParentCode=''null'')
BEGIN
SELECT * FROM Functions 
WHERE FunctionCode in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID= @ProfileID)
AND ParentCode IS NULL
END
ELSE
BEGIN
SELECT * FROM Functions 
WHERE FunctionCode in (SELECT FunctionCode FROM ProfileFunction WHERE ProfileID= @ProfileID)
AND ParentCode=@ParentCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranProfileFunctions
END

COMMIT TRANSACTION TranProfileFunctions



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[sp_getProfile]
@UserName nvarchar(50),
@AplicationCode nvarchar(50)

AS

BEGIN TRANSACTION TranGetProfile

SELECT P.* 
FROM Profiles P INNER JOIN AplicationEmployee AE ON P.ProfileID=AE.ProfileID
INNER JOIN Employees E ON AE.UserName=E.UserName
WHERE E.UserName=@UserName AND AE.AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranGetProfile
END

COMMIT TRANSACTION TranGetProfile


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_loadEmployees]
@ListType int,
@AplicationCode nvarchar(50)
AS

BEGIN TRANSACTION TranLoadEmployees

IF (@ListType=0)
BEGIN
SELECT E.Username, FirstName + '' '' + Lastname AS FullName, Active, P.Profile
FROM Employees E INNER JOIN AplicationEmployee AE ON E.UserName=AE.UserName 
LEFT JOIN Profiles P ON AE.ProfileID=P.ProfileID
WHERE AE.AplicationCode=@AplicationCode
AND Active=1

END

ELSE IF(@ListType=1)
BEGIN
SELECT E.Username, FirstName + '' '' + Lastname AS FullName, Active, P.Profile
FROM Employees E INNER JOIN AplicationEmployee AE ON E.UserName=AE.UserName 
LEFT JOIN Profiles P ON AE.ProfileID=P.ProfileID
WHERE AE.AplicationCode=@AplicationCode
AND Active=0
END

ELSE IF (@ListType=2)
BEGIN
SELECT E.Username, FirstName + '' '' + Lastname AS FullName, Active, P.Profile
FROM Employees E INNER JOIN AplicationEmployee AE ON E.Username=AE.UserName 
LEFT JOIN Profiles P ON AE.ProfileID=P.ProfileID
WHERE AE.AplicationCode=@AplicationCode
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadEmployees
END

COMMIT TRANSACTION TranLoadEmployees






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeeByUN]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadEmployeeByUN]
@UserName nvarchar(50)
AS

BEGIN TRANSACTION TranLoadEmployeeByUN

SELECT * FROM Employees
WHERE UserName = @UserName

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadEmployeeByUN
END

COMMIT TRANSACTION TranLoadEmployeeByUN



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updatePDEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updatePDEmployee]
@UserName nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Obs nvarchar(100),
@Password nvarchar(50)

AS

BEGIN TRANSACTION TranUpdatePDEmployee

UPDATE Employees
SET FirstName=@FirstName,
LastName=@LastName,
Obs=@Obs,
--UserName=@UserName,
Password=@Password
WHERE UserName=@UserName

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdatePDEmployee
END

COMMIT TRANSACTION TranUpdatePDEmployee



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_validateStoreEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_validateStoreEmployee]
@UserName nvarchar(50)
AS


BEGIN TRANSACTION TranValidateStoreEmployee

SELECT * FROM Employees
WHERE UserName=@UserName

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranValidateStoreEmployee
END

COMMIT TRANSACTION TranValidateStoreEmployee



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_validateEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[sp_validateEmployee]
@UserName nvarchar(50),
@Password nvarchar(50)

AS


BEGIN TRANSACTION TranValidateEmployee

SELECT * 
FROM Employees 
WHERE Username=@UserName 
AND Password=@Password

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranValidateEmployee
END

COMMIT TRANSACTION TranValidateEmployee


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateEmployee]
@UserName nvarchar(50),
@ProfileID int,
@AplicationCode nvarchar(50),
@Active bit
AS

BEGIN TRANSACTION TranUpdateEmployee

UPDATE Employees
SET Active=@Active
WHERE UserName=@UserName

UPDATE AplicationEmployee
SET ProfileID=@ProfileID
WHERE UserName=@UserName AND AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateEmployee
END

COMMIT TRANSACTION TranUpdateEmployee



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_countEmployees]
@Count int OUTPUT
AS

BEGIN TRANSACTION TranCountEmployees

SELECT @Count=Count(*) FROM Employees

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranCountEmployees
END

COMMIT TRANSACTION TranCountEmployees




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadProcess]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadProcess]
@ProcessID as int
AS

SELECT P.*, E.FirstName + '' '' + E.LastName AS Employee, U.UserID, U.FullName
FROM Processes P
LEFT JOIN Employees E ON P.EmployeeID=E.Username
LEFT JOIN Users U ON P.UserID=U.UserID
WHERE ProcessID=@ProcessID
' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadFullEmployees]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadFullEmployees]
AS 

SELECT UserName, FirstName + '' '' + LastName AS FullName FROM Employees
WHERE Active=1

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeesUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadEmployeesUserName] as 
	SELECT UserName FROM Employees




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeesNames]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadEmployeesNames] as
	SELECT Username, FirstName + '' '' + Lastname AS FullName
	FROM Employees
	ORDER by FullName




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeeFullName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_loadEmployeeFullName] 
@usrn nvarchar(50) 
AS 

SELECT FirstName + '' '' + LastName AS FullName FROM Employees
WHERE UserName=@usrn






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeesByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'














CREATE PROCEDURE [dbo].[sp_loadEmployeesByProfile]
@ProfileID int,
@AplicationCode nvarchar(50)
AS

SELECT E.UserName, E.FirstName + '' '' + E.LastName AS FullName
FROM Employees E
INNER JOIN AplicationEmployee AE ON E.UserName=AE.UserName
--INNER JOIN Profiles P ON AE.ProfileID=P.ProfileID
WHERE AE.AplicationCode=@AplicationCode
AND AE.ProfileID=@ProfileID














' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmployeesProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadEmployeesProduction] 
@Year as nvarchar(10)
AS
SELECT Username, Count(FileID) AS Total
FROM DOFiles
WHERE CONVERT(varchar(4),CreationDateTime)=@Year
GROUP BY Username
ORDER BY 1
' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadDaoGrpFromID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_loadDaoGrpFromID]
@ID bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, DG.Type, DO.Name AS DOName, 
		DO.ArchiveID, DO.TopographicalQuota, DO.Active , DOF.Name AS DOFileName 
		FROM DaoGrp DG INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID 
		INNER JOIN DOFiles DOF ON DOF.FileID=DG.FileID 
		WHERE DG.ComponentID = @ID AND DG.Type = 1 
	UNION 
	SELECT DISTINCT DG.ComponentID, DG.DigitalObjectID, DG.FileID, Type, DO.Name AS DOName, 
		DO.ArchiveID, DO.TopographicalQuota, DO.Active, '''' 
		FROM DaoGrp DG INNER JOIN DigitalObjects DO ON DO.DigitalObjectID=DG.DigitalObjectID 
		WHERE DG.ComponentID=@ID AND DG.Type = 0
END	
' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadTotalImagesByOtherLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadTotalImagesByOtherLevel]
AS

BEGIN TRANSACTION TranLoadTotalImagesByOtherLevel


SELECT 1, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''F''
GROUP BY OtherLevel
UNION
SELECT 2, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SF''
GROUP BY OtherLevel
UNION
SELECT 3, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SC''
GROUP BY OtherLevel
UNION
SELECT 4, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SSC''
GROUP BY OtherLevel
UNION
SELECT 5, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SSSC''
GROUP BY OtherLevel
UNION
SELECT 6, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SR''
GROUP BY OtherLevel
UNION
SELECT 7, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''SSR''
GROUP BY OtherLevel
UNION
SELECT 8, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''UI''
GROUP BY OtherLevel
UNION
SELECT 9, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''DC''
GROUP BY OtherLevel
UNION
SELECT 10, OtherLevel, COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
RIGHT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel=''D''
GROUP BY OtherLevel
UNION
SELECT 11, ISNULL(OtherLevel,''Nenhum''), COUNT(DOF.FileID) AS TotalImages
FROM DOFiles DOF 
LEFT JOIN DigitalObjects DO ON DO.DigitalObjectID=DOF.DigitalObjectID
LEFT JOIN DaoGrp DG ON DG.DigitalObjectID=DO.DigitalObjectID 
LEFT JOIN Components C ON C.ID=DG.ComponentID 
WHERE OtherLevel='''' OR OtherLevel IS NULL
GROUP BY OtherLevel
ORDER BY 1

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadTotalImagesByOtherLevel
END

COMMIT TRANSACTION TranLoadTotalImagesByOtherLevel

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countDerivatives]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_countDerivatives]
@Count int OUTPUT
AS

SELECT @Count=COUNT(FileID)
FROM DOFiles
WHERE Image IS NOT NULL


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getDOFilesYears]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_getDOFilesYears] 
AS

SELECT DISTINCT CONVERT(varchar(4),CreationDateTime) FROM DOFiles
WHERE CreationDateTime IS NOT NULL AND CreationDateTime <>''''
ORDER BY 1
' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countImages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_countImages]
@Count int OUTPUT
AS

SELECT @Count=COUNT(FileID)
FROM DOFiles


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadArchiveProduction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadArchiveProduction] 
@Year as nvarchar(10)
AS

SELECT SUBSTRING(CreationDateTime, 6, 2) AS DateMonth, COUNT(FileID) TotalMonth, CONVERT(REAL,COUNT(FileID)/20.0) AvgMonth FROM DoFiles
WHERE CONVERT(varchar(4), CreationDateTime)=@Year
GROUP BY SUBSTRING(CreationDateTime, 6, 2)
ORDER BY 1
' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadMessages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_loadMessages]
@CategoryID int
AS

SELECT * FROM Messages
WHERE MsgCategoryID = @CategoryID















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAllRequestsPendentsByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadAllRequestsPendentsByProfile]
@ProfileID int
AS

SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID,
U.FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND (Status=2 OR Status=4 OR Status=5) AND SourceEventCode=3

UNION
SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID,
U.FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND (Status=2 OR Status=4 OR Status=5) AND SourceEventCode=1
AND CONVERT(VARCHAR(10),EventDate,126)=CONVERT(VARCHAR(10),GETDATE(),126)

UNION
SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID,
U.FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND (Status=2 OR Status=4 OR Status=5) AND SourceEventCode=2
AND CONVERT(VARCHAR(10),EventDate,126)=CONVERT(VARCHAR(10),GETDATE(),126)
ORDER BY E.SourceEventID DESC







' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadConsultationRequestsPendentsByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadConsultationRequestsPendentsByProfile]
@ProfileID INT
AS

SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID,
FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
WHERE EP.ProfileID=@ProfileID
AND SourceEventCode=1
AND CONVERT(VARCHAR(10),EventDate,126)=CONVERT(VARCHAR(10),GETDATE(),126)
AND (Status=2 OR Status=4 OR Status=5)
ORDER BY E.SourceEventID DESC




' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_storeUser]
@UserType tinyint,
@FullName nvarchar(100),
@UserName nvarchar(50),
@Password nvarchar(50),
@Sex char(1),
@BirthDate nvarchar(20),
@Institution nvarchar(100),
@HomePhone nvarchar(20),
@MobilePhone nvarchar(20),
@Fax nvarchar(20),
@Email nvarchar(100),
@Address nvarchar(200),
@Locality nvarchar(75),
@PostalCode nvarchar(20),
@CountryCode int,
@Nationality nvarchar(75),
@IdentityCard nvarchar(50),
@ContributorNumber nvarchar(50),
@ProfessionID int,
@WorkAreaID int,
@ActivityAreaID int,
@AcademicsHabID int,
@UserID int OUTPUT
AS

BEGIN TRANSACTION TranStoreUser

INSERT INTO Users
VALUES(@UserType, @FullName, @UserName, @Password, @Sex, @BirthDate,
@Institution, @HomePhone, @MobilePhone, @Fax, @Email, @Address,
@Locality, @PostalCode, @CountryCode, @Nationality, @IdentityCard,
@ContributorNumber, @ProfessionID, @WorkAreaID, @ActivityAreaID, @AcademicsHabID)


SELECT @UserID=@@IDENTITY
/*
IF (@Username IS NULL)
BEGIN
UPDATE UsersCRAV
SET Username=@UserID
WHERE UserID=@UserID
END
*/
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreUser
END

COMMIT TRANSACTION TranStoreUser








' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadReservationRequestsPendentsByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadReservationRequestsPendentsByProfile]
@ProfileID INT
AS

SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID, P.OtherProcessID,
U.FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
LEFT JOIN Processes P ON E.ProcessID=P.ProcessID
WHERE EP.ProfileID=@ProfileID
AND SourceEventCode=2 
AND CONVERT(VARCHAR(10),EventDate,126)=CONVERT(VARCHAR(10),GETDATE(),126)
AND (Status=2 OR Status=4 OR Status=5)
ORDER BY E.SourceEventID DESC





' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadRequestsPendentsByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadRequestsPendentsByProfile]
@RequestTypeCode int,
@ProfileID int
AS

BEGIN TRANSACTION TranLoadRequests

IF (@RequestTypeCode=0)
BEGIN
SELECT E.*, U.UserID, FullName AS FullNameUser, P.InitialDate, P.OtherProcessID
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
INNER JOIN Processes P ON E.ProcessID=P.ProcessID
WHERE EP.ProfileID=@ProfileID
AND (Status=2 OR Status=4 OR Status=5)
ORDER BY E.EventID DESC
END

ELSE
BEGIN
SELECT E.*, U.UserID, FullName AS FullNameUser, P.InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
INNER JOIN Processes P ON E.ProcessID=P.ProcessID
WHERE EP.ProfileID=@ProfileID
AND E.DerivedFrom IN (SELECT EventID FROM Events WHERE EventCode=@RequestTypeCode)
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadRequests
END

COMMIT TRANSACTION TranLoadRequests












' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadReproductionRequestsPendentsByProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadReproductionRequestsPendentsByProfile]
@ProfileID INT
AS

SELECT E.EventID, E.SourceEventID, E.EventCode, E.Status, E.EmployeeID, E.ProcessID,
U.FullName AS FullNameUser, CONVERT(VARCHAR(10),EventDate,126) AS InitialDate
FROM Events E 
INNER JOIN Users U ON E.UserID=U.UserID
INNER JOIN EventsProfiles EP ON E.EventID = EP.EventID
INNER JOIN Processes P ON E.ProcessID=P.ProcessID
WHERE EP.ProfileID=@ProfileID
AND SourceEventCode=3
AND (Status=2 OR Status=4 OR Status=5)
ORDER BY E.SourceEventID DESC



' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadTypesEntryExit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadTypesEntryExit]
AS

SELECT * FROM TypesEntryExit



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeCorrespondence]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_storeCorrespondence]
@EventID bigint,
@TypeEntryExitCode nvarchar(20),
@DocumentDate nvarchar(20),
@ProvDest nvarchar(200),
@Reference nvarchar(50),
@Subject nvarchar(100),
@Note nvarchar(200),
@ManualEntryExitID bigint OUTPUT
AS

BEGIN TRANSACTION TranStoreCorrespondence

INSERT INTO Correspondence
VALUES(@EventID, NULL, @TypeEntryExitCode, @DocumentDate, 
@ProvDest, @Reference, @Subject, @Note)

SELECT @ManualEntryExitID=ManualEntryExitID FROM Correspondence

UPDATE Events
SET EntryExitID=@ManualEntryExitID
WHERE EventID=@EventID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreCorrespondence
END

COMMIT TRANSACTION TranStoreCorrespondence
' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateCorrespondence]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[sp_updateCorrespondence]
@CorrespondenceID bigint,
@TypeEntryExitCode nvarchar(20),
@DocumentDate nvarchar(20),
@ProvDest nvarchar(100),
@Reference nvarchar(50),
@Subject nvarchar(100),
@Note nvarchar(200)
AS

UPDATE Correspondence
SET 
TypeEntryExitCode=@TypeEntryExitCode,
DocumentDate=@DocumentDate,
ProvDest=@ProvDest,
Reference=@Reference,
Subject=@Subject,
Note=@Note
WHERE  CorrespondenceID=@CorrespondenceID








' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCorrespondence]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_loadCorrespondence]
@EventID int
AS

SELECT * FROM Correspondence
WHERE CorrespondenceID = @EventID















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCorrespondenceRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




CREATE PROCEDURE [dbo].[sp_loadCorrespondenceRelated]
@CorrespondenceID bigint
AS
BEGIN TRANSACTION TranLoadCorrespondenceRelated
DECLARE @ProcessID int, 
@ProvDest nvarchar(100),
@Classification nvarchar(50),
@DocumentDate nvarchar(20)

SELECT @ProcessID=ProcessID, @ProvDest=ProvDest,
@Classification=Classification, @DocumentDate=DocumentDate
FROM Correspondence C INNER JOIN Events E ON CorrespondenceID=EventID
WHERE CorrespondenceID=@CorrespondenceID

SELECT CorrespondenceID, ManualEntryExitID, Subject
FROM Correspondence C INNER JOIN Events E ON CorrespondenceID=EventID
WHERE (ProcessID=@ProcessID OR
ProvDest=@ProvDest OR
Classification=@Classification OR
DocumentDate=@DocumentDate)
AND CorrespondenceID<>@CorrespondenceID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadCorrespondenceRelatedt
END
COMMIT TRANSACTION TranLoadCorrespondenceRelated




' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_insertRelationship]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'










CREATE PROCEDURE [dbo].[sp_insertRelationship]
@CorrespondenceID int,
@ParentID int
AS

UPDATE Correspondence
SET 
ParentID=@ParentID
WHERE  CorrespondenceID=@CorrespondenceID










' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'










CREATE PROCEDURE [dbo].[sp_updateTask]
@EventID bigint,
@Type int,
@Note nvarchar(100)
AS

DECLARE @TaskID bigint

BEGIN TRANSACTION TranUpdateTask

SELECT @TaskID=TaskID FROM Tasks
WHERE TaskID=@EventID

IF (@TaskID IS NULL)
BEGIN
INSERT INTO Tasks
VALUES(@EventID, @Type, @Note)
END
ELSE IF (@TaskID IS NOT NULL)
BEGIN
UPDATE Tasks
SET 
Type=@Type,
Note=@Note
WHERE TaskID=@EventID
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateTask
END
COMMIT TRANSACTION TranUpdateTask










' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadTask]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

















CREATE PROCEDURE [dbo].[sp_loadTask]
@EventID bigint
AS

SELECT * FROM Tasks 
WHERE TaskID=@EventID

















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeProcess]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeProcess]
@ProcessType tinyint,
@Classification nvarchar(50),
@Subject nvarchar(200),
@FolderID nvarchar(100),
@EmployeeID nvarchar(50),
@InitialDate nvarchar(20),
@FinalDate nvarchar(20),
@UserID int,
@ProcessID bigint OUTPUT,
@OtherProcessID bigint OUTPUT
AS

BEGIN TRANSACTION TranStoreProcess

IF @ProcessType=1
BEGIN
SELECT @OtherProcessID=MAX(OtherProcessID) 
FROM Processes
WHERE ProcessType=1
IF (@OtherProcessID IS NULL)
BEGIN
SET @OtherProcessID=0
END
INSERT INTO Processes
VALUES(@OtherProcessID+1,@ProcessType,@Classification,@Subject,@FolderID,
@InitialDate,@FinalDate,@EmployeeID,@UserID)

END

ELSE IF @ProcessType=0
BEGIN
INSERT INTO Processes
VALUES(NULL,@ProcessType,@Classification,@Subject,@FolderID,
@InitialDate,@FinalDate,@EmployeeID,@UserID)

SELECT @ProcessID = @@IDENTITY
UPDATE Processes
SET OtherProcessID=@ProcessID
WHERE ProcessID=@ProcessID
END

SELECT @ProcessID = @@IDENTITY
SELECT @OtherProcessID = OtherProcessID
FROM Processes
WHERE ProcessID=@ProcessID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreProcess
END

COMMIT TRANSACTION TranConsultationReq




' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getProcessID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getProcessID]
	-- Add the parameters for the stored procedure here
	@OtherProcessID bigint,
	@ProcessID bigint OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT @ProcessID=ProcessID FROM Processes
	WHERE OtherProcessID=@OtherProcessID
END

' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteProcess]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteProcess]
@ProcessID int
AS
DELETE FROM Processes
WHERE ProcessID = @ProcessID













' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateProcess]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_updateProcess]
@ProcessID int,
@ProcessType tinyint,
@Classification nvarchar(200),
@Subject nvarchar(200),
@FolderID nvarchar(200),
@EmployeeID nvarchar(50),
@InitialDate nvarchar(20),
@FinalDate nvarchar(20),
@UserID int
AS

UPDATE Processes
SET
ProcessType=@ProcessType,
Classification=@Classification,
Subject=@Subject,
FolderID=@FolderID,
EmployeeID=@EmployeeID,
InitialDate=@InitialDate,
FinalDate=@FinalDate,
UserID=@UserID
WHERE  ProcessID=@ProcessID




' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadReproductionRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_loadReproductionRequest]
@EventID bigint
AS

SELECT RR.*,
TC.TypeCertificate,
TP.TypeReproduction
FROM ((ReproductionRequest RR
LEFT JOIN TypesCertificate TC ON TC.TypeCertificateCode=RR.TypeCertificateCode)
LEFT JOIN TypesReproduction TP ON TP.TypeReproductionCode=RR.TypeReproductionCode)
WHERE ReproductionRequestID=@EventID



' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeNote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'












CREATE PROCEDURE [dbo].[sp_storeNote]
@NoteTitle nvarchar(200),
@NoteDate nvarchar(20),
@Note nvarchar(2000),
@UserID int

AS
INSERT INTO Notes
VALUES(@NoteTitle,@NoteDate,@Note,@UserID)












' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateNote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[sp_updateNote]
@NoteID int,
@NoteTitle nvarchar(200),
@NoteDate nvarchar(20),
@Note nvarchar(2000)
AS

UPDATE Notes
SET 
NoteTitle=@NoteTitle,
NoteDate=@NoteDate,
Note=@Note
WHERE  NoteID=@NoteID








' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteNote]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_deleteNote]
@NoteID int
AS
DELETE FROM Notes
WHERE NoteID = @NoteID



' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadNotes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_loadNotes]
@UserID as int
AS

SELECT * FROM Notes
WHERE UserID=@UserID


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeReservationRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_storeReservationRequest]
@EventID as bigint,
@ReferenceDigitarq nvarchar(100),
@ReserveDate datetime,
@PartDay char(1)
AS

BEGIN TRANSACTION TranStoreReservationReq

INSERT INTO ReservationRequest 
VALUES(@EventID,@ReferenceDigitarq,@ReserveDate,@PartDay)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreReservationReq
END

COMMIT TRANSACTION TranStoreReservationReq






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_IsUnavailableResReq]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'







CREATE PROCEDURE [dbo].[sp_IsUnavailableResReq]
@ReferenceDigitarq nvarchar(200),
@ReserveDate as nvarchar(20),
@PartDay as char(1)
AS

SELECT E.EventID FROM Events E
INNER JOIN ReservationRequest RR ON E.EventID=RR.ReservationRequestID
WHERE ReferenceDigitarq=@ReferenceDigitarq
AND ReserveDate=@ReserveDate
AND Partday=@PartDay






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadReservationRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_loadReservationRequest]
@EventID bigint
AS

SELECT *
FROM ReservationRequest
WHERE ReservationRequestID=@EventID






' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadProfiles]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadProfiles]
@AplicationCode nvarchar(50)
AS

BEGIN TRANSACTION TranLoadProfiles

SELECT * FROM Profiles
WHERE AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadProfiles
END

COMMIT TRANSACTION TranLoadProfiles

' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeProfile]
@ProfileName nvarchar(50),
@AplicationCode nvarchar(50)
AS


BEGIN TRANSACTION TranStoreProfile

INSERT INTO Profiles
VALUES(@ProfileName,@AplicationCode)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreProfile
END

COMMIT TRANSACTION TranStoreProfile



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeEventProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeEventProfile]
@EventID bigint,
@UserGroup nvarchar(50),
@AplicationCode nvarchar(50)
AS

BEGIN TRANSACTION TranStoreEventProfile

DECLARE @ProfileID smallint

SELECT @ProfileID=ProfileID FROM Profiles 
WHERE Profile=@UserGroup AND AplicationCode=@AplicationCode

INSERT INTO EventsProfiles
VALUES (@EventID, @ProfileID)


IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreEventProfile
END

COMMIT TRANSACTION TranStoreEventProfile



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_deleteProfile]
@ProfileID int
AS

BEGIN TRANSACTION TranDeleteProfile

UPDATE AplicationEmployee
SET ProfileID=NULL
Where ProfileID=@ProfileID

DELETE FROM ProfileFunction
WHERE ProfileID=@ProfileID

DELETE FROM Profiles
WHERE ProfileID = @ProfileID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteProfile
END

COMMIT TRANSACTION TranDeleteProfile



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateProfile]
@ProfileID int,
@ProfileName nvarchar(50)
AS

BEGIN TRANSACTION TranUpdateProfile

UPDATE Profiles
SET Profile=@ProfileName
WHERE ProfileID=@ProfileID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateProfile
END

COMMIT TRANSACTION TranUpdateProfile



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmoluments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_loadEmoluments]
AS
SELECT EmolumentID, EmolumentDate, ReceiptNumber, C.CategoryID, 
Category, CertificateNumber, Exemption, IVA, Cost, Note 
FROM Emoluments E
INNER JOIN Categories C ON E.CategoryID=C.CategoryID
ORDER BY 1 ASC


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_loadCategories]
AS
BEGIN TRANSACTION TranLoadCategories
SELECT CategoryID, Category FROM Categories
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadCategories
END
COMMIT TRANSACTION TranLoadCategories













' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_countCategories]
@Count int OUTPUT
AS
BEGIN TRANSACTION TranCountCategories
SELECT @Count=Count(*) FROM Categories
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranCountCategories
END
COMMIT TRANSACTION TranCountCategories


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteCategory]
@CategoryID int
AS
BEGIN TRANSACTION TranDeleteCategory
DELETE FROM Categories
WHERE CategoryID = @CategoryID
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteCategory
END
COMMIT TRANSACTION TranDeleteCategory













' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_updateCategory]
@CategoryID int,
@CategoryName nvarchar(50)
AS
BEGIN TRANSACTION TranUpdateCategory
UPDATE Categories
SET Category=@CategoryName
WHERE CategoryID=@CategoryID
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateCategory
END
COMMIT TRANSACTION TranUpdateCategory





























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeEmolument]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_storeEmolument]
@EmolumentDate nvarchar(20),
@ReceiptNumber bigint,
@IVA smallint,
@Cost float,
@Exemption nvarchar(100),
@Note nvarchar(100),
@CategoryID smallint,
@EmolumentID bigint OUTPUT
AS

BEGIN TRANSACTION TranStoreEmolument

DECLARE @Category nvarchar(50)
DECLARE @CertificateNumber bigint

SELECT @Category=Category FROM Categories
WHERE CategoryID=@CategoryID

IF (@Category=''Certidão'')
BEGIN
SELECT @CertificateNumber=MAX(CertificateNumber) 
FROM Emoluments
IF (@CertificateNumber IS NULL)
BEGIN
SET @CertificateNumber=0
END
INSERT INTO Emoluments
VALUES(@EmolumentDate, @ReceiptNumber, @IVA, @Cost, @CertificateNumber+1,
@Exemption, @Note, @CategoryID)

END

ELSE IF (@Category<>''Certidão'')
BEGIN

INSERT INTO Emoluments
VALUES(@EmolumentDate, @ReceiptNumber, @IVA, @Cost, NULL,
@Exemption, @Note, @CategoryID)

END

SELECT @EmolumentID=@@IDENTITY

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreEmolument
END

COMMIT TRANSACTION TranStoreEmolument


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

















CREATE PROCEDURE [dbo].[sp_storeCategory]
@CategoryName nvarchar(50)
AS
BEGIN TRANSACTION TranStoreCategory
INSERT INTO Categories
VALUES(@CategoryName)
IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreCategory
END
COMMIT TRANSACTION TranStoreCategory












' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




















CREATE PROCEDURE [dbo].[sp_loadUser]
@UserID nvarchar(50)
AS

BEGIN TRANSACTION TranLoadUserByUN

IF (ISNUMERIC(@UserID)=1)
BEGIN
SELECT *
FROM Users U
LEFT JOIN Countries C ON U.CountryCode=C.CountryCode
LEFT JOIN Professions P ON U.ProfessionID=P.ProfessionID
LEFT JOIN WorkAreas WA ON U.WorkAreaID=WA.WorkAreaID
LEFT JOIN AcademicsHab AH ON U.AcademicsHabID=AH.AcademicsHabID
LEFT JOIN ActivityAreas AA ON U.ActivityAreaID=AA.ActivityAreaID
WHERE UserID=CONVERT(BIGINT,@UserID)
END

ELSE IF (ISNUMERIC(@UserID)=0)
BEGIN
SELECT *
FROM Users U
LEFT JOIN Countries C ON U.CountryCode=C.CountryCode
LEFT JOIN Professions P ON U.ProfessionID=P.ProfessionID
LEFT JOIN WorkAreas WA ON U.WorkAreaID=WA.WorkAreaID
LEFT JOIN AcademicsHab AH ON U.AcademicsHabID=AH.AcademicsHabID
LEFT JOIN ActivityAreas AA ON U.ActivityAreaID=AA.ActivityAreaID
WHERE Username=@UserID
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadUserByUN
END
COMMIT TRANSACTION TranLoadUserByUN



















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countDigitalObjects]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_countDigitalObjects]
@Count int OUTPUT
AS

SELECT @Count=COUNT(DigitalObjectID)
FROM DigitalObjects


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_accessAplication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_accessAplication]
@UserName nvarchar(50),
@AplicationCode nvarchar(50)
AS

BEGIN TRANSACTION TranAccessAplication

SELECT *
FROM AplicationEmployee
WHERE UserName=@UserName
AND AplicationCode=@AplicationCode

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranAccessAplication
END

COMMIT TRANSACTION TranAccessAplication




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteAplicationsEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteAplicationsEmployee]
@UserName as nvarchar(50)
AS

BEGIN TRANSACTION TranDeleteAplicationsEmployee

DELETE FROM AplicationEmployee
WHERE UserName=@UserName

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteAplicationsEmployee
END

COMMIT TRANSACTION TranDeleteAplicationsEmployee




























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_insertAplicationEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_insertAplicationEmployee]
@UserName nvarchar(50),
@AplicationCode nvarchar(50),
@Checked int
AS

BEGIN TRANSACTION TranInsertAplicationEmployee

IF (@Checked=1)
BEGIN
IF NOT EXISTS (SELECT * FROM AplicationEmployee WHERE AplicationCode=@AplicationCode AND UserName=@UserName )
INSERT INTO AplicationEmployee
VALUES (@AplicationCode, @UserName, NULL)
END
ELSE

BEGIN
IF EXISTS (SELECT * FROM AplicationEmployee WHERE AplicationCode=@AplicationCode AND UserName=@UserName)
DELETE FROM AplicationEmployee
WHERE AplicationCode=@AplicationCode AND UserName=@UserName
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranInsertAplicationEmployee
END

COMMIT TRANSACTION TranInsertAplicationEmployee



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAplicationsEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_loadAplicationsEmployee]
@UserName nvarchar(50)
AS

BEGIN TRANSACTION TranLoadAplicationsEmployee

SELECT AplicationCode
FROM AplicationEmployee
WHERE UserName=@UserName

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranLoadAplicationsEmployee
END

COMMIT TRANSACTION TranLoadAplicationsEmployee



























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeParochialRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeParochialRequest]
@EventID bigint,
@KindActionPrcCode int,
@Address nvarchar(100),
@Region nvarchar(100),
@Name nvarchar(100),
@FiliationFather nvarchar(100),
@FiliationMather nvarchar(100),
@Spouse nvarchar(100),
@SeatNumber nvarchar(50),
@SeatYear int,
@PageNumber nvarchar(50),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

BEGIN TRANSACTION TranStoreParochialReq

INSERT INTO ParochialRequest 
VALUES(@EventID,@KindActionPrcCode,@Address,@Region,@Name,
@FiliationFather,@FiliationMather,@Spouse,@SeatNumber,@SeatYear,
@PageNumber,@InitialDate,@Finaldate)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreParochialReq
END
COMMIT TRANSACTION TranStoreParochialReq































' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateParochialRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_updateParochialRequest]
@EventID bigint,
@KindActionPrcCode int,
@Address nvarchar(100),
@Region nvarchar(100),
@Name nvarchar(100),
@FiliationFather nvarchar(100),
@FiliationMather nvarchar(100),
@Spouse nvarchar(100),
@SeatNumber nvarchar(50),
@SeatYear int,
@PageNumber nvarchar(50),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

DECLARE @ParochialReqID bigint

BEGIN TRANSACTION TranUpdateParochialReq

SELECT @ParochialReqID=ParochialRequestID FROM ParochialRequest
WHERE ParochialRequestID=@EventID

IF (@ParochialReqID IS NULL)
BEGIN
INSERT INTO ParochialRequest 
VALUES(@EventID,@KindActionPrcCode,@Address,@Region,@Name,
@FiliationFather,@FiliationMather,@Spouse,@SeatNumber,@SeatYear,
@PageNumber,@InitialDate,@Finaldate)
END
ELSE IF (@ParochialReqID IS NOT NULL)
BEGIN
UPDATE ParochialRequest 
SET 
KindActionPrcCode=@KindActionPrcCode,
Address=@Address,
Region=@Region,
Name=@Name,
FiliationFather=@FiliationFather,
FiliationMather=@FiliationMather,
Spouse=@Spouse,
SeatNumber=@SeatNumber,
SeatYear=@SeatYear,
PageNumber=@PageNumber,
InitialDate=@InitialDate,
Finaldate=@Finaldate
WHERE ParochialRequestID=@EventID
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateParochialReq
END
COMMIT TRANSACTION TranUpdateParochialReq
































' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getEmolumentsYears]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[sp_getEmolumentsYears]

AS
SELECT DISTINCT SUBSTRING(EmolumentDate,0,5)  AS Years
FROM Emoluments



' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteEmolument]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_deleteEmolument]
@EmolumentID int
AS
DELETE FROM Emoluments
WHERE EmolumentID = @EmolumentID



' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_getTotalCostEmoluments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_getTotalCostEmoluments]
AS

SELECT SUM(Cost) 
FROM Emoluments


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadEmolumentsGroupByReceiptNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_loadEmolumentsGroupByReceiptNumber]
AS
SELECT ReceiptNumber AS "Número recibo", 
CAST(SUM(Cost)-(IVA*SUM(Cost)/(100+IVA)) AS DECIMAL(4,2)) AS "Valor Líquido", 
CAST(IVA AS NVARCHAR(5)) + ''%'' AS IVA, 
CAST(IVA*SUM(Cost)/(100+IVA) AS DECIMAL(4,2)) AS "Valor IVA", 
CAST(SUM(Cost) AS DECIMAL(4,2)) AS "Valor Total"
FROM Emoluments
GROUP BY ReceiptNumber, IVA


' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeOtherRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_storeOtherRequest]
@EventID bigint,
@Fonds nvarchar(100),
@Name nvarchar(100),
@TermsWords nvarchar(100),
@Document nvarchar(100),
@Localities nvarchar(100),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

BEGIN TRANSACTION TranStoreOtherReq

INSERT INTO OtherRequest 
VALUES(@EventID,@Fonds,@Name,@TermsWords,
@Document,@Localities,@InitialDate,@FinalDate)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreOtherReq
END
COMMIT TRANSACTION TranStoreOtherReq































' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateOtherRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[sp_updateOtherRequest]
@EventID bigint,
@Fonds nvarchar(100),
@Name nvarchar(100),
@TermsWords nvarchar(100),
@Document nvarchar(100),
@Localities nvarchar(100),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

DECLARE @OtherReqID bigint

BEGIN TRANSACTION TranUpdateOtherReq

SELECT @OtherReqID=OtherRequestID FROM OtherRequest
WHERE OtherRequestID=@EventID

IF (@OtherReqID IS NULL)
BEGIN 
INSERT INTO OtherRequest 
VALUES(@EventID,@Fonds,@Name,@TermsWords,
@Document,@Localities,@InitialDate,@FinalDate)
END
ELSE IF (@OtherReqID IS NOT NULL)
BEGIN 
UPDATE OtherRequest 
SET Fonds=@Fonds,
Name=@Name,
TermsWords=@TermsWords,
Document=@Document,
Localities=@Localities,
InitialDate=@InitialDate,
FinalDate=@FinalDate
WHERE OtherRequestID=@EventID
END

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateOtherReq
END
COMMIT TRANSACTION TranUpdateOtherReq


































' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadConsultationRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



























CREATE PROCEDURE [dbo].[sp_loadConsultationRequest]
@EventID bigint
AS

SELECT *
FROM ConsultationRequest
WHERE ConsultationRequestID=@EventID



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeConsultationRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_storeConsultationRequest]
@EventID bigint,
@ReferenceDigitarq nvarchar(100)
AS

BEGIN TRANSACTION TranStoreConsultationReq

INSERT INTO ConsultationRequest 
VALUES(@EventID,@ReferenceDigitarq)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreConsultationReq
END

COMMIT TRANSACTION TranConsultationReq



' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateNotaryRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[sp_updateNotaryRequest]
@EventID bigint,
@KindActionNotCode int,
@Notary nvarchar(100),
@CartoryNumber nvarchar(50),
@Locality nvarchar(100),
@ParticipantsAction nvarchar(500),
@PageNumber nvarchar(50),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

DECLARE @NotaryReqID bigint

BEGIN TRANSACTION TranStoreNotaryReq

SELECT @NotaryReqID=NotaryRequestID FROM NotaryRequest
WHERE NotaryRequestID=@EventID

IF (@NotaryReqID IS NULL)
BEGIN
INSERT INTO NotaryRequest 
VALUES(@EventID,@KindActionNotCode,@Notary,@CartoryNumber,@Locality,
@ParticipantsAction,@PageNumber,@InitialDate,@FinalDate)
END
ELSE IF (@NotaryReqID IS NOT NULL)
BEGIN
UPDATE NotaryRequest 
SET KindActionNotCode=@KindActionNotCode,
Notary=@Notary,
CartoryNumber=@CartoryNumber,
Locality=@Locality,
ParticipantsAction=@ParticipantsAction,
PageNumber=@PageNumber,
InitialDate=@InitialDate,
FinalDate=@FinalDate
WHERE NotaryRequestID=@EventID
END


IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreNotaryReq
END
COMMIT TRANSACTION TranStoreNotaryReq

























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeNotaryRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_storeNotaryRequest]
@EventID bigint,
@KindActionNotCode int,
@Notary nvarchar(100),
@CartoryNumber nvarchar(50),
@Locality nvarchar(100),
@ParticipantsAction nvarchar(1000),
@PageNumber nvarchar(50),
@InitialDate nvarchar(10),
@FinalDate nvarchar(10)
AS

BEGIN TRANSACTION TranStoreNotaryReq

INSERT INTO NotaryRequest 
VALUES(@EventID,@KindActionNotCode,@Notary,@CartoryNumber,@Locality,
@ParticipantsAction,@PageNumber,@InitialDate,@FinalDate)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreNotaryReq
END
COMMIT TRANSACTION TranStoreNotaryReq
































' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteProfileFunctions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_deleteProfileFunctions]
@ProfileID as integer
AS

BEGIN TRANSACTION TranDeleteProfileFunctions

DELETE FROM ProfileFunction
WHERE ProfileID=@ProfileID

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranDeleteProfileFunctions
END

COMMIT TRANSACTION TranDeleteProfileFunctions



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_insertProfileFunction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




























CREATE PROCEDURE [dbo].[sp_insertProfileFunction]
@ProfileID as integer,
@FunctionCode as nvarchar(50)
AS

BEGIN TRANSACTION TranInsertProfileFunction

INSERT INTO ProfileFunction
VALUES (@ProfileID, @FunctionCode)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranInsertProfileFunction
END

COMMIT TRANSACTION TranInsertProfileFunctions



























' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAttached]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_loadAttached]
@AttachedID int
AS

SELECT * FROM Attacheds
WHERE AttachedID = @AttachedID














' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_loadAttacheds]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'















CREATE PROCEDURE [dbo].[sp_loadAttacheds]
@EventID int
AS

SELECT * FROM Attacheds
WHERE CorrespondenceID = @EventID















' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_deleteAttached]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_deleteAttached]
@AttachedID int
AS
DELETE FROM Attacheds
WHERE AttachedID = @AttachedID















' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeAttached]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[sp_storeAttached]
@Attached image,
@FileName nvarchar(200),
@ContentType nvarchar(200),
@ContentLength int,
@CorrespondenceID bigint
AS

INSERT INTO Attacheds
VALUES(@Attached, @FileName, @ContentType, 
@ContentLength, @CorrespondenceID)








' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeAplication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_storeAplication]
@AplicationCode nvarchar(50),
@AplicationName nvarchar(50),
@Version nvarchar(50)

AS

BEGIN TRANSACTION TranStoreAplication

INSERT INTO Aplications
VALUES(@AplicationCode, @AplicationName, @Version)

IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranUpdateAplication
END

COMMIT TRANSACTION TranUpdateAplication




























' 
END
;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_countProjects]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[sp_countProjects]
@Count int OUTPUT
AS

SELECT @Count=COUNT(ProjectID)
FROM Projects


' 
END
;
SET ANSI_NULLS OFF
;
SET QUOTED_IDENTIFIER OFF
;
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_storeEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[sp_storeEmployee]
@FirstName nvarchar(50),
@LastName nvarchar(50),
@UserName nvarchar(50),
@Password nvarchar(50),
@Obs nvarchar(100)

AS


BEGIN TRANSACTION TranStoreEmployee

DECLARE @Count int
DECLARE @AdminProfileID int
DECLARE @AplicationCode nvarchar(50)
EXEC sp_countEmployees @Count OUTPUT

IF(@Count=0)
BEGIN
	--INSERT INTO Aplications
	--VALUES (''GPU'',''1'')

	SELECT @AplicationCode=AplicationCode
	FROM Aplications
	WHERE AplicationName=''GPU''

	INSERT INTO Profiles
	VALUES (''Administrador'',@AplicationCode)

	SELECT @AdminProfileID=ProfileID
	FROM Profiles
	WHERE Profile=''Administrador''

	INSERT INTO Employees 
	VALUES(@FirstName, @LastName, @UserName, @Password,@Obs, 1)
	--SELECT @MaxID=@@IDENTITY

	INSERT INTO ProfileFunction
	SELECT @AdminProfileID, FunctionCode FROM functions WHERE AplicationCode=@AplicationCode

	--EXEC sp_insertProfileEmployee @AdminProfileID, @MaxID, @AplicationID
END

ELSE 

BEGIN
	INSERT INTO Employees (UserName, FirstName, LastName, Password, Obs, Active)
	VALUES(@UserName, @FirstName, @LastName, @Password, @Obs, 1)

	--SELECT @MaxID=@@IDENTITY
END


IF (@@ERROR <> 0)
BEGIN
	ROLLBACK TRANSACTION TranStoreEmployee
END

COMMIT TRANSACTION TranStoreEmployee






' 
END
