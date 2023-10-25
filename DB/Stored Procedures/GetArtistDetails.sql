CREATE PROCEDURE GetArtistDetails
AS
BEGIN 

  SELECT DISTINCT AR.artistID, AR.title as artistName, AL.title as albumName, SO.title as songName, AR.imageURL as artistIMG, AL.imageURL as albumIMG, SO.bpm FROM Artist AR 
  LEFT JOIN Album AL ON AR.artistID = AL.artistID
  LEFT JOIN Song SO ON AL.artistID=SO.artistID

END ;