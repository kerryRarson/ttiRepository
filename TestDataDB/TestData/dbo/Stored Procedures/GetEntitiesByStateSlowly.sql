
CREATE proc [dbo].[GetEntitiesByStateSlowly] @state varchar(2) as begin
/*
KLL this sproc will return entities by state after waiting 5 seconds
    to simulate a large slow query.
*/
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