using DataAccess;
using System;
using System.Web.UI.WebControls;

public partial class Default : MultitracksPage
{

    protected void Page_Load(Object sender, EventArgs e)
    {
        var sql = new SQL();

        try
        {
            //sql.Parameters.Add("@stepID", 1);
            var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

            GetArtistDetails.DataSource = data;
            GetArtistDetails.DataBind();

        }
        catch
        {
        }
    }
}
