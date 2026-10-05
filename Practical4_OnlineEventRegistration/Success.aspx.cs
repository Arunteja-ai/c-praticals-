using System;

public partial class Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblName.Text = Session["UserName"].ToString();
        }
        else
        {
            lblName.Text = "Guest";
        }
    }
}
