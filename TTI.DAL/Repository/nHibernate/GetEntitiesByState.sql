create proc GetEntitiesByState @state varchar(2) as begin
	set nocount on
	select distinct e.iEntity_ID, e.iCompany_ID, e.iEntityType_ID, e.iParent_ID, e.sName, e.sLegalName, e.sPhoneNumber, e.sEmailAddress, e.sWebsite, e.bActive,
		e.sspecialinstructions, e.sstatelicensenumber, e.dtSEtup, e.brochureUrl
	from tentity e
	inner join tAddress a on e.iAddress_ID = a.iAddress_ID
	inner join tState s on a.iState_ID = s.iState_ID
	where e.bActive = 1 
	and s.sName = @state
end
