﻿CREATE TABLE [dbo].[tAddress] (
    [iAddress_ID]                BIGINT        NOT NULL,
    [iState_ID]                  BIGINT        NULL,
    [sAddress1]                  VARCHAR (100) NULL,
    [sAddress2]                  VARCHAR (100) NULL,
    [sCity]                      VARCHAR (50)  NULL,
    [sZip]                       VARCHAR (10)  NULL,
    [dtValidated]                DATETIME      NULL,
    [bForeign]                   BIT           NULL,
    [sPhone]                     VARCHAR (50)  NULL,
    [sCellOrFax]                 VARCHAR (50)  NULL,
    [bActive]                    BIT           NOT NULL,
    [dtLastUpdated]              DATETIME      NULL,
    [sLastUpdatedBy]             VARCHAR (50)  NULL,
    [dtCreated]                  DATETIME      NULL,
    [sCreatedBy]                 VARCHAR (50)  NULL,
    [bValid]                     BIT           NOT NULL,
    [sUrbanization]              VARCHAR (50)  NULL,
    [sCarrierRoute]              VARCHAR (50)  NULL,
    [sCounty]                    VARCHAR (50)  NULL,
    [sCountyNumber]              VARCHAR (10)  NULL,
    [sCongressionalDistrict]     VARCHAR (50)  NULL,
    [fLatitude]                  FLOAT (53)    NULL,
    [fLongitude]                 FLOAT (53)    NULL,
    [iCreatedByUser_ID]          BIGINT        NULL,
    [iCreatedByDelegateUser_ID]  BIGINT        NULL,
    [iUpdatedByUser_ID]          BIGINT        NULL,
    [iUpdatedByDelegateUser_ID]  BIGINT        NULL,
    [sCountry]                   VARCHAR (30)  NULL,
    [sForeignState]              VARCHAR (30)  NULL,
    [sForeignPostalCode]         VARCHAR (20)  NULL,
    [sImportKey]                 VARCHAR (20)  NULL,
    [AddressScrubStatusID]       TINYINT       NULL,
    [AddressScrubOverrideUserID] INT           NULL,
    [sCellPhone]                 VARCHAR (50)  NULL,
    [sEmail]                     VARCHAR (100) NULL
);
