CREATE TABLE [dbo].[tState] (
    [iState_ID]      INT          NOT NULL,
    [sName]          VARCHAR (50) NULL,
    [sCode]          CHAR (2)     NULL,
    [bActive]        BIT          NULL,
    [dtLastUpdated]  DATETIME     NULL,
    [sLastUpdatedBy] VARCHAR (50) NULL,
    [dtCreated]      DATETIME     NULL,
    [sCreatedBy]     VARCHAR (50) NULL,
    [sFullName]      VARCHAR (35) NULL
);

