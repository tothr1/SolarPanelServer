SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		tothr1
-- Create date: 2023-03-15
-- Description:	Adds a new shelf. Row number increments automatically, column and level count needs to be specified.
-- Default (C:8, L:5) x 5
-- =============================================
ALTER PROCEDURE AddShelfRow
	-- Add the parameters for the stored procedure here
	@columns int,
	@levels int
AS
BEGIN
	
	DECLARE @row int = (SELECT MAX(shelf_row)+1 FROM Shelves) 
	DECLARE @idx int = 1;
	DECLARE @char int = 1;

	WHILE @char <= @columns
	BEGIN
		SET @idx = 1;
		WHILE @idx <= @levels
		BEGIN
			--PRINT CONCAT('Column: ', CHAR(@char+64), 'level: ', @idx)
			INSERT INTO dbo.Shelves VALUES(@row, CHAR(@char+64), @idx, 0, CURRENT_TIMESTAMP)
			SET @idx = @idx+1
		END;
		SET @char = @char+1
	END;

END
GO
