using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // Normally you would save data to DB here.
            // For practical demonstration, we redirect to success page.
            Session["UserName"] = txtName.Text;
            Response.Redirect("Success.aspx");
        }
    }
}
