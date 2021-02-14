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
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hidden_id.Text = "0";
            update.Visible = false;
            add.Visible = true;
            if (!IsPostBack)
            {
                string ID = Request.QueryString["ID"];
                if (Convert.ToInt64(ID) != 0)
                {
                    List<LibraryUI.Models.Book> data = FetchData(Convert.ToInt64(ID));
                    if (data != null)
                    {
                        hidden_id.Text = data[0].ID.ToString();
                        txt_name.Text = data[0].Name;
                        txt_author_name.Text = data[0].Aauthor;
                        txt_publisher.Text = data[0].Publisher;
                        txt_price.Text = data[0].Price.ToString();
                        ddl_category.Text = data[0].Category.ToString();
                        txt_count.Text = data[0].Count.ToString();
                        add.Visible = false;
                        update.Visible = true;
                    }
                    else
                    {
                        hidden_id.Text = "0";
                        update.Visible = false;
                        add.Visible = true;
                    }
                }
            }
        }

        public List<LibraryUI.Models.Book> FetchData(long ID)
        {
            LibraryUI.Models.Book model = new LibraryUI.Models.Book();
            List<LibraryUI.Models.Book> data = new List<Models.Book>();
            string response = Utilities.Utilities.GetAPICall(Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.FetchBookByID + "?ID=" + ID);
            if (response != null)
            {
                JsonResponse responseData = JsonConvert.DeserializeObject<JsonResponse>(response);
                data = JsonConvert.DeserializeObject<List<LibraryUI.Models.Book>>(responseData.Data.ToString());
            }
            return data;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            JsonResponse jsonResponse = new JsonResponse();
            LibraryUI.Models.Book model = new LibraryUI.Models.Book();
            if (txt_name.Text != "" && txt_author_name.Text != "" && txt_publisher.Text != "" && txt_price.Text != "" && txt_count.Text != "" && ddl_category.Text != "")
            {
                model.ID = Convert.ToInt64(hidden_id.Text);
                model.Name = txt_name.Text.ToString();
                model.Aauthor = txt_author_name.Text.ToString();
                model.Publisher = txt_publisher.Text.ToString();
                model.Price = Convert.ToInt32(txt_price.Text.ToString());
                model.Count = Convert.ToInt32(txt_count.Text.ToString());
                model.Category = Convert.ToInt32(ddl_category.Text.ToString());
                string response = string.Empty;
                if (model.ID != 0)
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.Book>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.UpdateBook);
                }
                else
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.Book>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.AddBook);
                }
                jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(response);
                if (jsonResponse.Status == "S")
                {
                    Server.Transfer("BookSummary.aspx");
                }
            }
            else
            {
                if (txt_name.Text == "")
                {
                    err_name.Text = "Please Enter Name";
                }
                if (txt_author_name.Text == "")
                {
                    err_author_name.Text = "Please Enter Author Name";
                }
                if (txt_publisher.Text == "")
                {
                    err_publisher.Text = "Please Enter Publisher";
                }
                if (txt_price.Text == "")
                {
                    err_price.Text = "Please Enter Price";
                } 
                if (txt_count.Text == "")
                {
                    err_count.Text = "Please Enter Count";
                }
                if (ddl_category.Text == "-1")
                {
                    err_category.Text = "Please Enter Category";
                }

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            JsonResponse jsonResponse = new JsonResponse();
            LibraryUI.Models.Book model = new LibraryUI.Models.Book();
            if (txt_name.Text != "" && txt_author_name.Text != "" && txt_publisher.Text != "" && txt_price.Text != "" && txt_count.Text != "" && ddl_category.Text != "")
            {
                model.ID = Convert.ToInt64(hidden_id.Text);
                model.Name = txt_name.Text.ToString();
                model.Aauthor = txt_author_name.Text.ToString();
                model.Publisher = txt_publisher.Text.ToString();
                model.Price = Convert.ToInt32(txt_price.Text.ToString());
                model.Count = Convert.ToInt32(txt_count.Text.ToString());
                model.Category = Convert.ToInt32(ddl_category.Text.ToString());
                string response = string.Empty;
                if (model.ID != 0)
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.Book>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.UpdateBook);
                }
                else
                {
                    response = Utilities.PostAPICallWithParam<LibraryUI.Models.Book>.APICall(model, Utilities.Utilities.GetAPIPath() + Utilities.Utilities.APIPath.AddBook);
                }
                jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(response);
                if (jsonResponse.Status == "S")
                {
                    Server.Transfer("BookSummary.aspx");
                }
            }
            else
            {
                if (txt_name.Text == "")
                {
                    err_name.Text = "Please Enter Name";
                }
                if (txt_author_name.Text == "")
                {
                    err_author_name.Text = "Please Enter Author Name";
                }
                if (txt_publisher.Text == "")
                {
                    err_publisher.Text = "Please Enter Publisher";
                }
                if (txt_price.Text == "")
                {
                    err_price.Text = "Please Enter Price";
                }
                if (txt_count.Text == "")
                {
                    err_count.Text = "Please Enter Count";
                }
                if (ddl_category.Text == "-1")
                {
                    err_category.Text = "Please Enter Category";
                }
            }
        }
    }
}