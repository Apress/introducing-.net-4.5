CREATE PROCEDURE [dbo].[DistancesFromAustraliaStoredProc]
	@Destination varchar(255)
	
AS
Declare @DestinationLocation Geography
Select @DestinationLocation = Location From Airports
Where AirportCode = @Destination

Select AirportName as Origin, 
	AirportCode as OriginAirportCode, 
	@Destination as Destination,
	Location.STDistance(@DestinationLocation)
From Airports
Where AirportName Like('%intl')
And Country = 'Australia'


