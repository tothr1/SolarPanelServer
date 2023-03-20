
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE AddComponent
	-- Add the parameters for the stored procedure here
	@material int,
	@shelf int,
	@count int
AS
BEGIN
	
	IF (SELECT part_count FROM Shelves WHERE shelf_id = @shelf) <= ((SELECT shelf_limit + @count FROM Materials WHERE material_id = @material))
	--IF ((SELECT part_count FROM Shelves WHERE shelf_id = 8) <= (SELECT shelf_limit + 12 FROM Materials WHERE material_id = 1))
		BEGIN

		DECLARE @idx int = 1
		WHILE @idx <= @count
			BEGIN
				INSERT INTO Components (material, shelf, project, row_updated)
					VALUES(@material, @shelf, NULL, CURRENT_TIMESTAMP)
				SET @idx = @idx+1
			END
			UPDATE Shelves SET part_count = (SELECT part_count + @count FROM Shelves WHERE shelf_id = @shelf) WHERE shelf_id = @shelf

		END

	ELSE

		return -1
END
GO
