IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Airports]') AND type in (N'U'))
Delete [dbo].[Airports]
