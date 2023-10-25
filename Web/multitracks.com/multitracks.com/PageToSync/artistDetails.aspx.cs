using DataAccess;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Default : MultitracksPage
{

    protected void Page_Load(Object sender, EventArgs e)
    {
        var sql = new SQL();

        if (!IsPostBack)
        {
            string artistID = Request.QueryString["artistID"];

            if (!string.IsNullOrEmpty(artistID))
            {
                // Convert artistID to the desired data type (e.g., int)
                int targetArtistID;
                if (int.TryParse(artistID, out targetArtistID))
                {
                    var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");
                    // Use artistIDValue to retrieve and display artist details
                    // Perform the database query using artistIDValue
                    // Display the artist details on the page

                    //========= Artist and Song field  =========//
                    var artistAndSongData = data.AsEnumerable()
                        .Where(row => row.Field<int>("artistID") == targetArtistID)
                        .Select(row => new
                        {
                            AlbumIMG = row.Field<string>("albumIMG"),
                            AlbumName = row.Field<string>("albumName"),
                            ArtistName = row.Field<string>("artistName"),
                            ArtistBanner = row.Field<string>("artistBanner"),
                            SongName = row.Field<string>("songName"),
                            Bpm = row.Field<decimal>("bpm")



                        })
                        .ToList();

                    GetArtistAndSong.DataSource = artistAndSongData;
                    GetArtistAndSong.DataBind();

                    bpmLabel.Text = artistAndSongData.BPM.ToString();
                    albumImage.ImageUrl = artistAndSongData.AlbumIMG;
                    artistBanner.ImageUrl = artistAndSongData.ArtistBanner;


                    //========= Album field  =========//
                    var albumData = data.AsEnumerable()
                        .Where(row => row.Field<int>("artistID") == targetArtistID)
                        .Select(row => new
                        {
                            AlbumIMG = row.Field<string>("albumIMG"),
                            AlbumName = row.Field<string>("albumName"),
                            ArtistName = row.Field<string>("artistName")
                        })
                        .ToList();

                    // Now 'albumData' contains the desired fields

                    // You can bind this data to a control or display it as needed
                    GetAlbumDetails.DataSource = albumData;
                    GetAlbumDetails.DataBind();
                    //========= Biography field  =========//

                    var biography = data.AsEnumerable()
                    .Where(row => row.Field<int>("artistID") == targetArtistID)
                    .Select(row => row.Field<string>("biography"))
                    .FirstOrDefault(); // Assuming there is one biography per artist

                    // Now 'biography' contains the desired biography

                    // You can display it or use it as needed
                    biographyLabel.Text = biography;

                }
                else
                {
                    // Handle invalid artistID
                    //invalidArtist.Visible = true;
                }
            }
            else
            {
                // Handle missing artistID
                // error505.Visible = true;
            }
        }

    }
}
