using DataAccess;
using System;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
                    /*
                     Data gets parsed with the artisID given via URL, example:
                    http://localhost:56916/PageToSync/artistDetails.aspx?artistID=107
                     */
                    var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

                    //========= Artist field  =========//
                    var getArtistDetailsQuery = (from row in data.AsEnumerable()
                                                 where row.Field<int>("artistID") == targetArtistID
                                                 select new
                                                 {
                                                     ArtistBanner = row.Field<string>("artistBanner"),
                                                     ArtistIMG = row.Field<string>("artistIMG"),
                                                     ArtistName = row.Field<string>("artistName")
                                                 }).FirstOrDefault(); // Assuming there's only one result for the artist
                    if (getArtistDetailsQuery != null)
                    {
                        artistBannerImage.ImageUrl = getArtistDetailsQuery.ArtistBanner.ToString();
                        artistImage.ImageUrl = getArtistDetailsQuery.ArtistIMG.ToString();
                        artistNameLabel.Text = getArtistDetailsQuery.ArtistName.ToString();
                    }


                    //========= Artist and Song field  =========//
                    var getArtistAndSongDetailsQuery = from row in data.AsEnumerable()
                                                       where row.Field<int>("artistID") == targetArtistID
                                                       select new
                                                       {
                                                           AlbumIMG = row.Field<string>("albumIMG"),
                                                           SongName = row.Field<string>("songName"),
                                                           AlbumName = row.Field<string>("albumName"),
                                                           BPM = row.Field<decimal>("bpm").ToString() // Convert to string
                                                       };


                    var artistAndSongQueryList = getArtistAndSongDetailsQuery.ToList();

                    getArtistAndSongDetails.DataSource = artistAndSongQueryList;
                    getArtistAndSongDetails.DataBind();

                    //========= Album field  =========//
                    var getAlbumDetailsQuery = (from row in data.AsEnumerable()
                                                where row.Field<int>("artistID") == targetArtistID
                                                select new
                                                {
                                                    AlbumIMG = row.Field<string>("albumIMG"),
                                                    ArtistName = row.Field<string>("artistName"),
                                                    AlbumName = row.Field<string>("albumName")
                                                }).Distinct();

                    var albumDetailsQueryList = getAlbumDetailsQuery.ToList();

                    getAlbumDetails.DataSource = albumDetailsQueryList;
                    getAlbumDetails.DataBind();


                    //========= Biography field  =========//
                    // Retrieve the biography using LINQ
                    var biographyData = data.AsEnumerable()
                        .Where(row => row.Field<int>("artistID") == targetArtistID)
                        .Select(row => new
                        {
                            Biography = row.Field<string>("biography")
                        })
                        .FirstOrDefault();

                    if (biographyData != null)
                    {
                        // Set the biography text to the Label control
                        biographyLabel.Text = biographyData.Biography;
                    }

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
