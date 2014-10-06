using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SearchEngine.BusinessObjects;
using System.Text;

namespace SearchEngine
{
    public partial class SearchDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var da = new DataAccess();
            var dataCol = new DataCollection();
            dataCol = da.LoadDataBase();

            //if database is empty
            if (dataCol.Entities.Count == 0)
            {
                lblMsg.Text = "The database is empty, please add a text file to the database to continue (click back)";
                lblMsg.Visible = false;
                return;
            }

            var seList = Search.SearchDataBase(tbSearchCriteria.Text, dataCol);
            var resultStr = new StringBuilder();

            if (seList.Count == 0)
            {
                resultStr.Append("0 results found");         
            }

            //generate a single string for the results
            foreach (SearchEntity se in seList)
            {
                resultStr.Append(string.Format("<b>From {0}:</b><br />", se.Name));
                resultStr.Append(string.Format("{0}<br /><br />", se.Result));
            }

            //format specified keyword to bold
            string html = resultStr.ToString()
                .Replace(tbSearchCriteria.Text, string.Format("<b>{0}</b>", tbSearchCriteria.Text));

            divResults.InnerHtml = html;

            divResults.Visible = true;
            lblMsg.Visible = false;
        }
    }
}