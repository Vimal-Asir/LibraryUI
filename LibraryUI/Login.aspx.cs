using LibraryUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void login()
        {
            string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.Login + "?userName=" + txt_user_name.Text + "&&Password=" + txt_password.Text);
            if (response != null)
            {
                JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                if (responseData.Status == "S")
                {
                    Session["RoleID"] = responseData.Data.ToString();
                    Response.Redirect("UserSummary.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txt_user_name.Text !="" && txt_password.Text != "")
            {
                login();
            }
            else
            {
                if (txt_user_name.Text == "")
                {
                    err_name.Text = "Please Enter Username";
                    err_name.Visible = true;
                }
                if (txt_password.Text == "")
                {
                    err_password.Text = "Please Enter Password";
                    err_password.Visible = true;
                }
            }
        }
    }
}