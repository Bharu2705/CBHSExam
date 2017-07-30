using log4net;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webform
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Page load
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("FirstName"), new DataColumn("LastName"), 
                                                        new DataColumn("Email"), new DataColumn("DateOfBirth") });
                ViewState["Members"] = dt;
                this.BindGrid();
            }
        }
        
        #endregion

        #region Event Handler
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the current row is a datarow or the footer row
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //cast the row back to a datarowview
                DataRowView row = e.Row.DataItem as DataRowView;
                var age = 0;
                //check if the current row's details is the oldest date
                if (!string.IsNullOrEmpty(row["DateOfBirth"].ToString()))
                    age = HelperUtility.DateTimeExtensions.Age(Convert.ToDateTime(row["DateOfBirth"]));

                if (age > oldestMemberAge)
                {
                    oldestMemberAge = age;
                    oldestMemberDetails = string.Concat(oldestMemberAge, ", ", Convert.ToString(row["FirstName"]), " ", Convert.ToString(row["LastName"]));
                }
            }

            lblOldestMember.InnerText = oldestMemberDetails;
        }

        protected void addMember_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                ILog logger = log4net.LogManager.GetLogger("ErrorLog");
                try
                {
                    localhost.MemberService memberService = new localhost.MemberService();
                    var memberList = memberService.InsertMember(txtFirstName.Value.Trim(), txtLastName.Value.Trim(), txtEmail.Value.Trim(), datepicker.Value);
                    if (memberList != null)
                    {
                        txtFirstName.Value = string.Empty;
                        txtLastName.Value = string.Empty;
                        txtEmail.Value = string.Empty;
                        datepicker.Value = string.Empty;
                    }
                    else
                    {
                        logger.Error("Member list is null");
                    }
                    ViewState["Members"] = memberList;
                    this.BindGrid();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
            }
        }
        #endregion

        #region Methods
        protected void BindGrid()
        {
            GridView1.DataSource = (DataTable)ViewState["Members"];
            GridView1.DataBind();
        }

        int oldestMemberAge = 0;
        string oldestMemberDetails = string.Empty;
        #endregion
    }
}