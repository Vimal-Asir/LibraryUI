<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="LibraryUI.Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style>
        .form-control {
            width: 30% !important;
        }
         #Back{
            position: absolute;
            left: 100px;
        }
        .custom-form {
            margin-top: 0% !important;
            margin-left: 34% !important;
        }

        #hidden_id {
            display: none;
        }

        .error-message {
            color: red;
            font-size: 12px;
            padding-left: 19px;
        }

        
          body {
            background: #262626;
            color: #fff
        }

        .edit {
            color: #262626;
        }

        .delete {
            color: #262626;
        }

        .user-btn-align {
            display: flex !important;
            justify-content: space-between !important;
        }

        .logout-button {
            position: absolute;
            /* left: 105px; */
            right: 6px;
            top: 5px;
        }

        .static-header {
            text-align: left;
            font-family: cursive;
            color: #03e9f4;
            padding-left:50px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button5" runat="server" Text="Logout" OnClick="Button5_Click" class="btn btn-danger logout-button" />
        <div class="custom-form">
            <h3 class="static-header">Manage Book</h3>
            <br />
            <div class="user-btn-align">
                <div style="margin-top: 10px;">
                    <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" class="btn btn-success" />
                </div>

                <div style="margin-top: 10px;">
                </div>
            </div>
            <div>
                <br /><br />
                <asp:TextBox ID="hidden_id" runat="server" class="form-control"></asp:TextBox>
                <label>Book Name</label><br />
                <asp:TextBox ID="txt_name" runat="server" class="form-control"></asp:TextBox>
                <asp:Label ID="err_name" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div>
                <label>Author Name</label><br />
                <asp:TextBox ID="txt_author_name" runat="server" class="form-control"></asp:TextBox>
                <asp:Label ID="err_author_name" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div>
                <label>Publisher Name</label><br />
                <asp:TextBox ID="txt_publisher" runat="server" class="form-control"></asp:TextBox>
                <asp:Label ID="err_publisher" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div>
                <label>Price</label><br />
                <asp:TextBox ID="txt_price" runat="server" class="form-control"></asp:TextBox>
                <asp:Label ID="err_price" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div>
                <label>Count</label><br />
                <asp:TextBox ID="txt_count" runat="server" class="form-control"></asp:TextBox>
                <asp:Label ID="err_count" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div>
                <label>Category</label><br />
                <asp:DropDownList ID="ddl_category" runat="server" class="form-control">
                    <asp:ListItem Enabled="true" Text="Select Category" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Sports" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Arts" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Novels" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="err_category" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <br />
            <div style="margin-top: 10px;">
                <asp:Button ID="add" OnClick="btn_save_Click" runat="server" Style="width: 30% !important" value="Save" class="btn btn-success" Text="Save" />
                <asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" CausesValidation="False" Style="width: 30% !important" />
            </div>
        </div>
    </form>
</body>
</html>
<script src="Scripts/jquery-3.4.1.js"></script>
<script>
    $(function () {
        //$.each(".form-control", function () {
        //    if ($(this).val() != "") {

        //    }
        //})
        $(".form-control").change(function () {
            if ($(this).val() != "") {
                $(this).parent().find(".error-message").text("");
            }
        });
    })
</script>
