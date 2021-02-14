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
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ID= Request.QueryString["ID"];
                //HttpContext CurrContext = HttpContext.Current;
                //List<LibraryUI.Models.User> data = (List<LibraryUI.Models.User>)CurrContext.Items["Data"];
                if (Convert.ToInt64(ID) != 0)
                {
                    List<LibraryUI.Models.User> data = FetchData(Convert.ToInt64(ID));
                    if (data != null)
                    {
                        hidden_id.Text = data[0].ID.ToString();
                        txt_name.Text = data[0].Name;
                        txt_user_name.Text = data[0].UserName;
                        txt_password.Text = data[0].Password;
                        ddl_role.Text = data[0].Role.ToString();
                        //hidden_id.Text = "1";
                        //txt_name.Text = "Name";
                        //txt_user_name.Text = "User name";
                        //txt_password.Text = "dd";
                        //ddl_role.Text ="s";
                    }
                }
                else
                {
                    //btn_Update_Click(
                }
            }
        }

        public List<LibraryUI.Models.User> FetchData(long ID)
        {
            LibraryUI.Models.User model = new LibraryUI.Models.User();
            List<LibraryUI.Models.User> data = new List<Models.User>();
            string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.FetchUserByID + "?ID=" + ID);
            if (response != null)
            {
                JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                data = JsonConvert.DeserializeObject<List<LibraryUI.Models.User>>(responseData.Data.ToString());
            }
            return data;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            JsonResponse jsonResponse = new JsonResponse();
            LibraryUI.Models.User model = new LibraryUI.Models.User();
            model.ID = Convert.ToInt64(hidden_id.Text);
            model.Name = txt_name.Text.ToString();
            model.UserName = txt_user_name.Text.ToString();
            model.Password = txt_password.Text.ToString();
            model.Role = Convert.ToInt32(ddl_role.Text.ToString());
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
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
    }
}