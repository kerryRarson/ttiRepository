CREATE TABLE [dbo].[tEntityType] (
    [iEntityType_ID] INT          NOT NULL,
    [sDesc]          VARCHAR (50) NULL,
    [bActive]        BIT          NULL,
    [dtLastUpdated]  DATETIME     NULL,
    [sLastUpdatedBy] VARCHAR (50) NULL,
    [dtCreated]      DATETIME     NULL,
    [sCreatedBy]     VARCHAR (50) NULL
);

