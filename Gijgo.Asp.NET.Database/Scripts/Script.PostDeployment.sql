/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Players] ([Name], [PlaceOfBirth], [DateOfBirth]) VALUES
	('Hristo Stoichkov', 'Plovdiv, Bulgaria', '1966-02-08'),
	('Ronaldo Luís Nazário de Lima', 'Rio de Janeiro, Brazil', '1976-09-18'),
	('David Platt', 'Chadderton, Lancashire, England', '1966-06-10'),
	('Manuel Neuer', 'Gelsenkirchen, West Germany', '1986-03-27'),
	('James Rodríguez', 'Cúcuta, Colombia', '1991-07-12'),
	('Dimitar Berbatov', 'Blagoevgrad, Bulgaria', '1981-01-30'),
	('Robert Lewandowski', 'Warsaw, Poland', '1988-08-21');

DECLARE @PlayerID INT;

SET @PlayerID = (SELECT [ID] FROM [dbo].[Players] WHERE [Name]='Hristo Stoichkov');
INSERT INTO [dbo].[PlayerTeams] ([PlayerID], [FromYear], [ToYear], [Team], [Apps], [Goals]) VALUES
	(@PlayerID, 1982, 1984, 'Hebros Harmanli', 32, 14),
	(@PlayerID, 1984, 1990, 'CSKA Sofia', 119, 81),
	(@PlayerID, 1990, 1995, 'Barcelona', 149, 77),
	(@PlayerID, 1995, 1996, 'Parma', 23, 5),
	(@PlayerID, 1996, 1998, 'Barcelona', 26, 7),
	(@PlayerID, 1998, 1998, 'CSKA Sofia', 4, 1),
	(@PlayerID, 1998, 1998, 'Al-Nassr', 2, 1),
	(@PlayerID, 1998, 1999, 'Kashiwa Reysol', 27, 12),
	(@PlayerID, 2000, 2002, 'Chicago Fire', 51, 17),
	(@PlayerID, 2003, 2003, 'D.C. United', 21, 5);


SET @PlayerID = (SELECT [ID] FROM [dbo].[Players] WHERE [Name]='Ronaldo Luís Nazário de Lima');
INSERT INTO [dbo].[PlayerTeams] ([PlayerID], [FromYear], [ToYear], [Team], [Apps], [Goals]) VALUES
	(@PlayerID, 1993, 1994, 'Cruzeiro', 14, 12),
	(@PlayerID, 1994, 1996, 'PSV', 46, 42),
	(@PlayerID, 1996, 1997, 'Barcelona', 37, 34),
	(@PlayerID, 1997, 2002, 'Inter Milan', 68, 49),
	(@PlayerID, 2002, 2007, 'Real Madrid', 127, 83),
	(@PlayerID, 2007, 2008, 'Milan', 20, 9),
	(@PlayerID, 2009, 2011, 'Corinthians', 31, 18);

SET @PlayerID = (SELECT [ID] FROM [dbo].[Players] WHERE [Name]='David Platt');
INSERT INTO [dbo].[PlayerTeams] ([PlayerID], [FromYear], [ToYear], [Team], [Apps], [Goals]) VALUES
	(@PlayerID, 1985, 1988, 'Crewe Alexandra', 134, 56),
	(@PlayerID, 1988, 1991, 'Aston Villa', 121, 50),
	(@PlayerID, 1991, 1992, 'Bari', 29, 11),
	(@PlayerID, 1992, 1993, 'Juventus', 16, 3),
	(@PlayerID, 1993, 1995, 'Sampdoria', 55, 17),
	(@PlayerID, 1995, 1998, 'Arsenal', 88, 13),
	(@PlayerID, 1999, 2001, 'Nottingham Forest', 5, 1);