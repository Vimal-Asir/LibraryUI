using LibraryUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryUI
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hidden_id.Text = "0";
            //if (!IsPostBack)
            //{
            //    HttpContext CurrContext = HttpContext.Current;
            //    List<LibraryUI.Models.User> data = (List<LibraryUI.Models.User>)CurrContext.Items["Data"];
            //    if (data != null)
            //    {
            //        hidden_id.Text = data[0].ID.ToString();
            //        txt_name.Text = data[0].Name;
            //        txt_user_name.Text = data[0].UserName;
            //        txt_password.Text = data[0].Password;
            //        ddl_role.Text = data[0].Role.ToString();
            //        add.Visible = false;
            //        update.Visible = true;
            //    }
            //    else
            //    {
            //        hidden_id.Text = "0";
            //        update.Visible = false;
            //        add.Visible = true;
            //    }
            //}
        }

        public void btn_save_Click(object sender, EventArgs e)
        {
            JsonResponse jsonResponse = new JsonResponse();
            LibraryUI.Models.User model = new LibraryUI.Models.User();
            if (txt_user_name.Text !="" && txt_name.Text !="" && txt_password.Text !="" && ddl_role.Text !="")
            {
                model.ID = Convert.ToInt64(hidden_id.Text);
                model.Name = txt_name.Text.ToString();
                model.UserName = txt_user_name.Text.ToString();
                model.Password = txt_password.Text.ToString();
                model.Role = Convert.ToInt32(ddl_role.Text.ToString());
                string response = string.Empty;
                if (model.ID != 0)
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.User>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.UpdateUser);
                }
                else
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.User>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.AddUser);
                }
                jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(response);
                if (jsonResponse.Status == "S")
                {
                    Server.Transfer("UserSummary.aspx");
                }
            }
            else
            {
                if (txt_name.Text=="")
                {
                    err_name.Text = "Please Enter Name";
                }
                if (txt_user_name.Text == "")
                {
                    err_user_name.Text = "Please Enter Username";
                }
                if (txt_password.Text == "")
                {
                    err_password.Text = "Please Enter Password";
                }
                if (ddl_role.Text == "-1")
                {
                    err_role.Text = "Please Enter Role";
                }
            }
        }
    }
}