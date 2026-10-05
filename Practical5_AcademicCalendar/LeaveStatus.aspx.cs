using System;

public partial class LeaveStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpName"] != null)
        {
            lblName.Text = Session["EmpName"].ToString();
            lblType.Text = Session["LeaveType"].ToString();
            lblDate.Text = Session["LeaveDate"].ToString();
            lblReason.Text = Session["LeaveReason"].ToString();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
