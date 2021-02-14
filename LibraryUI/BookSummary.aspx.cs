using LibraryUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryUI
{
    public partial class BookSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LibraryUI.Models.Book model = new LibraryUI.Models.Book();
                string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.FetchAllBook);
                if (response != null)
                {
                    JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                    List<LibraryUI.Models.Book> data = JsonConvert.DeserializeObject<List<LibraryUI.Models.Book>>(responseData.Data.ToString());
                    DataSet ds = Utilities.Utilities.ToDataSet<LibraryUI.Models.Book>(data);
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

        public void Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = Convert.ToInt32(row.Cells[1].Text);
            LibraryUI.Models.Book model = new LibraryUI.Models.Book();
            string url;
            url = "Book.aspx?ID=" + ID;
            Response.Redirect(url);
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int ID = Convert.ToInt32(row.Cells[1].Text);
            LibraryUI.Models.Book model = new LibraryUI.Models.Book();
            string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.DeleteBook + "?ID=" + ID);
            if (response != null)
            {
                JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                Response.Redirect("BookSummary.aspx");
            }
        }

        public void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Book.aspx");
        }
        
        public void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSummary.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}