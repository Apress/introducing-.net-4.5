CREATE VIEW [dbo].[SimpleAirportView]
	AS SELECT
	Id,
	Country,
	AirportCode,
	AirportName,
	Location 
FROM [Airports]
