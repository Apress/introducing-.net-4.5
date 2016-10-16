CREATE PROCEDURE [dbo].[AMeaninglessStoredProc]
	@AirportCode nvarchar(255)
AS
Select Id,AirportCode,AirportName,Location.Lat as Latitude, Location.Long as Longitude
 from Airports
where CityName in( 'Melbourne','Sydney','Canberra','Brisbane','Perth','Adelaide','Darwin')
and AirportCode is not null
and AirportName like'%intl'

declare @airportLocation geography
select @airportLocation = Location 
from Airports
where AirportCode = @AirportCode

select @AirportCode as Origin,
	   airportCode as Destination,
	   Round(Location.STDistance(@airportLocation)/1000,2) as distance
	   from Airports
	   where AirportName like'%intl'
	   and Country = 'Australia'




