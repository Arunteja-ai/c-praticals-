using System;
using System.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check for Cookie
            if (Request.Cookies["UserInfo"] != null)
            {
                string userName = Request.Cookies["UserInfo"]["UserName"];
                txtName.Text = userName;
                lblWelcome.Text = userName;
            }
            else
            {
                lblWelcome.Text = "Guest";
            }
            // Ensure HTML5 placeholder attributes are present on the rendered inputs
            txtName.Attributes["placeholder"] = "Enter your name";
            txtReason.Attributes["placeholder"] = "Enter reason";
        }
    }

    protected void calLeaveDate_SelectionChanged(object sender, EventArgs e)
    {
        lblSelectedDate.Text = calLeaveDate.SelectedDate.ToShortDateString();
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (calLeaveDate.SelectedDate == DateTime.MinValue)
            {
                lblSelectedDate.Text = "Please select a date from the calendar!";
                lblSelectedDate.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Create Cookie to remember the user
            HttpCookie userInfo = new HttpCookie("UserInfo");
            userInfo["UserName"] = txtName.Text;
            userInfo.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(userInfo);

            // Store leave application details in Session
            Session["EmpName"] = txtName.Text;
            Session["LeaveType"] = ddlLeaveType.SelectedValue;
            Session["LeaveDate"] = calLeaveDate.SelectedDate.ToShortDateString();
            Session["LeaveReason"] = txtReason.Text;

            // Redirect to status page
            Response.Redirect("LeaveStatus.aspx");
        }
    }
}
