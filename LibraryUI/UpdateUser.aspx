<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="LibraryUI.UpdateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style>
        .form-control {
            width: 30% !important;
        }

        .custom-form {
            margin-top: 0% !important;
            margin-left: 5% !important;
            margin-right: 5% !important;
            
        }
        .row{
            padding-left:30%;
          }
        #hidden_id {
            display: none;
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
            text-align: center;
            font-family: cursive;
            color: #03e9f4;
                padding-right: 15%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="btn_Update_Click">
        <asp:Button ID="Button5" runat="server" Text="Logout" OnClick="Button5_Click" class="btn btn-danger logout-button" />
        <h3 class="static-header">Manage User</h3>
        <div class="custom-form">
            <div class="user-btn-align">
                <div style="margin-top: 10px;">
                    <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" class="btn btn-success" />
                </div>
                <br /><br />
                <div style="margin-top: 10px;">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div>
                        <asp:TextBox ID="hidden_id" runat="server" class="form-control"></asp:TextBox>
                        <label>Name</label><br />
                        <asp:TextBox ID="txt_name" runat="server" class="form-control"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="err_name" ErrorMessage="Email cannot be blank" ForeColor="Red" runat="server" ControlToValidate="txt_name"
                    InitialValue="-1">
                </asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <label>User Name</label><br />
                        <asp:TextBox ID="txt_user_name" runat="server" class="form-control"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator ID="err_user_name" runat="server" ControlToValidate="txt_user_name"
                InitialValue="-1">
            </asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <label>Passowrd</label><br />
                        <asp:TextBox ID="txt_password" runat="server" class="form-control"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="err_password" runat="server" ControlToValidate="txt_password"
                InitialValue="-1">
            </asp:RequiredFieldValidator>--%>
                    </div>
                    <div>
                        <label>Role</label><br />
                        <asp:DropDownList ID="ddl_role" runat="server" class="form-control">
                            <asp:ListItem Enabled="true" Text="Select Role" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                            <asp:ListItem Text="User" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="ReqMonth" runat="server" ControlToValidate="ddl_role"
                InitialValue="-1">
            </asp:RequiredFieldValidator>--%>
                    </div>
                    <br /><br />
                    <div style="margin-top: 10px;">
                        <asp:Button ID="Button1" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />
                        <%--<asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
