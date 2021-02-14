using LibraryUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryUI
{
    public partial class UserSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibraryUI.Models.User model = new LibraryUI.Models.User();
                string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.FetchAllUser);
                if (response != null)
                {
                    JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                    List<LibraryUI.Models.User> data = JsonConvert.DeserializeObject<List<LibraryUI.Models.User>>(responseData.Data.ToString());
                    DataSet ds = Utilities.Utilities.ToDataSet<LibraryUI.Models.User>(data);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    if (Session["RoleID"] != null)
                    {
                        if (Convert.ToInt32(Session["RoleID"].ToString()) != 1)
                        {
                            Add_new.Visible = false;
                            //Button3.Visible = false;
                            GridView1.Columns[0].Visible = false;
                        }
                    }
                }
            }
        }

        //[System.Web.Services.WebMethod]
        //[ScriptMethod]
        //[HttpGet]
        public void Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = Convert.ToInt32(row.Cells[1].Text);
            LibraryUI.Models.User model = new LibraryUI.Models.User();
            string url;
            url = "UpdateUser.aspx?ID=" + ID;
            Response.Redirect(url);
            //string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.FetchUserByID+"?ID="+ID);
            //if (response != null)
            //{
            //    JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
            //    List<LibraryUI.Models.User> data = JsonConvert.DeserializeObject<List<LibraryUI.Models.User>>(responseData.Data.ToString());
            //    if (responseData.Status == "S")
            //    {
            //        HttpContext CurrContext = HttpContext.Current;
            //        CurrContext.Items.Add("Data", data);
            //        //Server.Transfer("UpdateUser.aspx");
            //        string url;
            //        url = "UpdateUser.aspx?ID=" + ID;
            //        Response.Redirect(url);
            //    }
            //}
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = Convert.ToInt32(row.Cells[1].Text);
            LibraryUI.Models.User model = new LibraryUI.Models.User();
            string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.DeleteUSer + "?ID=" + ID);
            if (response != null)
            {
                JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                Response.Redirect("UserSummary.aspx");
            }
        }

        public void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx"); 
        }
        
        public void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookSummary.aspx"); 
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}