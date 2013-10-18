USE [TestData]
GO
/****** Object:  Table [lookup].[EntityType]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [lookup].[EntityType]
GO
/****** Object:  Table [dbo].[tUser]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tUser]
GO
/****** Object:  Table [dbo].[tState]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tState]
GO
/****** Object:  Table [dbo].[tEntityType]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tEntityType]
GO
/****** Object:  Table [dbo].[tEntity]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tEntity]
GO
/****** Object:  Table [dbo].[tCompanyType]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tCompanyType]
GO
/****** Object:  Table [dbo].[tCompany]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tCompany]
GO
/****** Object:  Table [dbo].[tAddress]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP TABLE [dbo].[tAddress]
GO
/****** Object:  StoredProcedure [dbo].[GetEntitiesByStateSlowly]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP PROCEDURE [dbo].[GetEntitiesByStateSlowly]
GO
/****** Object:  StoredProcedure [dbo].[GetEntitiesByState]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP PROCEDURE [dbo].[GetEntitiesByState]
GO
/****** Object:  Schema [lookup]    Script Date: 10/18/2013 10:58:36 AM ******/
DROP SCHEMA [lookup]
GO
/****** Object:  Schema [lookup]    Script Date: 10/18/2013 10:58:36 AM ******/
CREATE SCHEMA [lookup]
GO
/****** Object:  StoredProcedure [dbo].[GetEntitiesByState]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetEntitiesByState] @state varchar(2) as begin
	set nocount on
	select distinct e.iEntity_ID, e.iCompany_ID, e.iEntityType_ID, e.iParent_ID, e.sName, e.sLegalName, e.sPhoneNumber, e.sEmailAddress, e.sWebsite, e.bActive,
		e.sspecialinstructions, e.sstatelicensenumber, e.dtSEtup, e.BrochureURL
	from tentity e
	inner join tAddress a on e.iAddress_ID = a.iAddress_ID
	inner join tState s on a.iState_ID = s.iState_ID
	where e.bActive = 1 
	and s.sName = @state
end

GO
/****** Object:  StoredProcedure [dbo].[GetEntitiesByStateSlowly]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetEntitiesByStateSlowly] @state varchar(2) as begin
	set nocount on
	WAITFOR DELAY '00:00:05';
	select distinct e.iEntity_ID, e.iCompany_ID, e.iEntityType_ID, e.iParent_ID, e.sName, e.sLegalName, e.sPhoneNumber, e.sEmailAddress, e.sWebsite, e.bActive,
		e.sspecialinstructions, e.sstatelicensenumber, e.dtSEtup, e.BrochureURL
	from tentity e
	inner join tAddress a on e.iAddress_ID = a.iAddress_ID
	inner join tState s on a.iState_ID = s.iState_ID
	where e.bActive = 1 
	and s.sName = @state
end


GO
/****** Object:  Table [dbo].[tAddress]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tAddress](
	[iAddress_ID] [bigint] NOT NULL,
	[iState_ID] [bigint] NULL,
	[sAddress1] [varchar](100) NULL,
	[sAddress2] [varchar](100) NULL,
	[sCity] [varchar](50) NULL,
	[sZip] [varchar](10) NULL,
	[dtValidated] [datetime] NULL,
	[bForeign] [bit] NULL,
	[sPhone] [varchar](50) NULL,
	[sCellOrFax] [varchar](50) NULL,
	[bActive] [bit] NOT NULL,
	[dtLastUpdated] [datetime] NULL,
	[sLastUpdatedBy] [varchar](50) NULL,
	[dtCreated] [datetime] NULL,
	[sCreatedBy] [varchar](50) NULL,
	[bValid] [bit] NOT NULL,
	[sUrbanization] [varchar](50) NULL,
	[sCarrierRoute] [varchar](50) NULL,
	[sCounty] [varchar](50) NULL,
	[sCountyNumber] [varchar](10) NULL,
	[sCongressionalDistrict] [varchar](50) NULL,
	[fLatitude] [float] NULL,
	[fLongitude] [float] NULL,
	[iCreatedByUser_ID] [bigint] NULL,
	[iCreatedByDelegateUser_ID] [bigint] NULL,
	[iUpdatedByUser_ID] [bigint] NULL,
	[iUpdatedByDelegateUser_ID] [bigint] NULL,
	[sCountry] [varchar](30) NULL,
	[sForeignState] [varchar](30) NULL,
	[sForeignPostalCode] [varchar](20) NULL,
	[sImportKey] [varchar](20) NULL,
	[AddressScrubStatusID] [tinyint] NULL,
	[AddressScrubOverrideUserID] [int] NULL,
	[sCellPhone] [varchar](50) NULL,
	[sEmail] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tCompany]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tCompany](
	[iCompany_ID] [bigint] NOT NULL,
	[iCompanyType_ID] [int] NOT NULL,
	[iMailingAddress_ID] [bigint] NOT NULL,
	[iAddress_ID] [bigint] NOT NULL,
	[iBankAccount_ID] [bigint] NOT NULL,
	[iEO_ID] [bigint] NOT NULL,
	[iResidencyState_ID] [int] NOT NULL,
	[sWYO] [varchar](5) NULL,
	[sName] [varchar](120) NULL,
	[sLegalName] [varchar](50) NULL,
	[sPhone] [varchar](50) NULL,
	[sFax] [varchar](50) NULL,
	[sWebsite] [varchar](50) NULL,
	[sAmBestRating] [varchar](5) NULL,
	[bMpppOnFile] [bit] NOT NULL,
	[bGenerateCommissions] [bit] NOT NULL,
	[bPayCommissionsAtInception] [bit] NOT NULL,
	[bEnforceNonResLicensing] [bit] NOT NULL,
	[bCommissionOverage] [bit] NOT NULL,
	[bCommissionPaidAtInception] [bit] NOT NULL,
	[bNonResidentsLicense] [bit] NOT NULL,
	[bNewAgencySetup] [bit] NOT NULL,
	[bMaintain1099] [bit] NOT NULL,
	[bUpdateAgencyInfo] [bit] NOT NULL,
	[bRequireAgentEo] [bit] NOT NULL,
	[bRequireAgentLicense] [bit] NOT NULL,
	[bPolicyTransfers] [bit] NOT NULL,
	[bAgentTerminations] [bit] NOT NULL,
	[bBookOfBusinessTransfer] [bit] NOT NULL,
	[bCommissionCap] [bit] NOT NULL,
	[mCommissionCapAmount] [money] NOT NULL,
	[bPayCommissionsToCompany] [bit] NOT NULL,
	[dtSetup] [datetime] NOT NULL,
	[dtTermination] [datetime] NULL,
	[dtReinstate] [datetime] NULL,
	[dtRenewalStartDate] [datetime] NULL,
	[dtRenewalEndDate] [datetime] NULL,
	[iDaysToPendForMoney] [int] NOT NULL,
	[iDaysToPendForDocuments] [int] NOT NULL,
	[iDocumentVolume_ID] [int] NULL,
	[sLogo] [varchar](50) NULL,
	[bActive] [bit] NULL,
	[iCreatedByUser_ID] [bigint] NULL,
	[dtCreated] [datetime] NULL,
	[iLastUpdatedByUser_ID] [bigint] NULL,
	[dtLastUpdated] [datetime] NULL,
	[iOperatingAccount_ID] [bigint] NULL,
	[iRestrictedAccount_ID] [bigint] NULL,
	[iLockboxAddress_ID] [bigint] NULL,
	[iPolicy_ID] [bigint] NULL,
	[GP_Link] [varchar](2) NULL,
	[bOnlineRenewal] [bit] NULL,
	[sRedirectUrl] [varchar](255) NULL,
	[sTerminationMessage] [varchar](5000) NULL,
	[shortname] [varchar](50) NULL,
	[ApplicationID] [bigint] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tCompanyType]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tCompanyType](
	[iCompanyType_ID] [int] NOT NULL,
	[sCompanyType] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tEntity]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tEntity](
	[iEntity_ID] [bigint] NOT NULL,
	[iCompany_ID] [bigint] NULL,
	[iEntityType_ID] [int] NOT NULL,
	[iParent_ID] [bigint] NULL,
	[iAddress_ID] [bigint] NOT NULL,
	[iMailingAddress_ID] [bigint] NOT NULL,
	[iEo_ID] [bigint] NOT NULL,
	[iBankAccount_ID] [bigint] NOT NULL,
	[iMga_ID] [bigint] NULL,
	[iState_ID] [bigint] NOT NULL,
	[sName] [varchar](120) NULL,
	[sLegalName] [varchar](120) NULL,
	[sPrinciple] [varchar](50) NULL,
	[sPhoneNumber] [varchar](50) NULL,
	[sFaxNumber] [varchar](50) NULL,
	[sEmailAddress] [varchar](250) NULL,
	[sWebsite] [varchar](50) NULL,
	[sProducerNumber] [varchar](50) NOT NULL,
	[sOldProducerNumber] [varchar](50) NULL,
	[bShowMGA] [bit] NOT NULL,
	[fMgaCommissionPercentage] [float] NOT NULL,
	[sSpecialInstructions] [varchar](2000) NULL,
	[sStateLicenseNumber] [varchar](50) NOT NULL,
	[dtSetup] [datetime] NULL,
	[dtTermination] [datetime] NULL,
	[dtReinstate] [datetime] NULL,
	[dtRenewalStart] [datetime] NULL,
	[dtRenewalEnd] [datetime] NULL,
	[dtRolloverStart] [datetime] NULL,
	[dtRolloverEnd] [datetime] NULL,
	[bActive] [bit] NOT NULL,
	[iCreatedByUser_ID] [bigint] NOT NULL,
	[dtCreated] [datetime] NOT NULL,
	[iUpdatedByUser_ID] [bigint] NOT NULL,
	[dtLastUpdated] [datetime] NOT NULL,
	[sEIN] [varchar](12) NULL,
	[bAchCommission] [bit] NOT NULL,
	[sBaseUrl] [varchar](75) NULL,
	[sThemeName] [varchar](50) NULL,
	[iPayCommissionToEntity_ID] [bigint] NULL,
	[iBeginIndex_ID] [int] NULL,
	[iEndIndex_ID] [int] NULL,
	[iACHBankAccount_ID] [int] NULL,
	[bReportable] [bit] NOT NULL,
	[bAllowIssue] [bit] NOT NULL,
	[iLockBoxAddress_ID] [bigint] NULL,
	[sFax_Override] [varchar](20) NULL,
	[ClaimAssignmentWebServiceURL] [varchar](250) NULL,
	[IsClaimAssignmentSubscriber] [bit] NULL,
	[BrochureURL] [varchar](75) NULL,
	[CommissionGroup] [varchar](3) NULL,
	[sCommissionMessage] [varchar](110) NULL,
	[bPayCommissionToAgent] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tEntityType]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tEntityType](
	[iEntityType_ID] [int] NOT NULL,
	[sDesc] [varchar](50) NULL,
	[bActive] [bit] NULL,
	[dtLastUpdated] [datetime] NULL,
	[sLastUpdatedBy] [varchar](50) NULL,
	[dtCreated] [datetime] NULL,
	[sCreatedBy] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tState]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tState](
	[iState_ID] [int] NOT NULL,
	[sName] [varchar](50) NULL,
	[sCode] [char](2) NULL,
	[bActive] [bit] NULL,
	[dtLastUpdated] [datetime] NULL,
	[sLastUpdatedBy] [varchar](50) NULL,
	[dtCreated] [datetime] NULL,
	[sCreatedBy] [varchar](50) NULL,
	[sFullName] [varchar](35) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tUser]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tUser](
	[iUser_ID] [bigint] NOT NULL,
	[sUsername] [varchar](50) NOT NULL,
	[sPassword] [varchar](100) NOT NULL,
	[bActive] [bit] NOT NULL,
	[dtLastUpdated] [datetime] NULL,
	[sLastUpdatedBy] [varchar](50) NULL,
	[sSecurityQuestion] [varchar](500) NULL,
	[sSecurityAnswer] [varchar](500) NULL,
	[dtCreated] [datetime] NULL,
	[sCreatedBy] [varchar](50) NULL,
	[iEntity_ID] [bigint] NOT NULL,
	[iUserType_ID] [int] NULL,
	[iCreatedByUser_ID] [bigint] NULL,
	[iLastUpdatedByUser_ID] [bigint] NULL,
	[bIsLockedOut] [bit] NOT NULL,
	[dtLastLoginDate] [datetime] NULL,
	[dtLastActivityDate] [datetime] NULL,
	[dtLastPasswordChangedDate] [datetime] NULL,
	[dtLastLockoutDate] [datetime] NULL,
	[iFailedPasswordAttemptCount] [int] NOT NULL,
	[dtFailedPasswordAttemptWindowStart] [datetime] NULL,
	[iFailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[dtFailedPasswordAnswerAttemptWindowStart] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [lookup].[EntityType]    Script Date: 10/18/2013 10:58:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [lookup].[EntityType](
	[EntityTypeID] [tinyint] NOT NULL,
	[EntityTypeDesc] [varchar](25) NOT NULL,
 CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED 
(
	[EntityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
