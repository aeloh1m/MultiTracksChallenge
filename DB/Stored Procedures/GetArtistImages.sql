CREATE PROCEDURE dbo.GetArtistImages
	@artistID INT = -1
AS
BEGIN

	SELECT [imageURL]
	FROM Artist
	WHERE
		@artistID = -1 OR
		artistID = @artistID

END
