<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookSummary.aspx.cs" Inherits="LibraryUI.BookSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style>
        .form-control {
            width: 30% !important;
        }

        .custom-form {
            margin-top: 0% !important;
            margin-left: 5% !important;
            margin-right: 5% !important;
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
        }
        table{
             background: linear-gradient(
245deg
, rgba(140,170,210,0.4), rgba(150,170,200,0.4), rgba(160,170,190,0.4), rgba(170,170,180,0.4), rgba(180,170,160,0.4));
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button5" runat="server" Text="Logout" OnClick="Button5_Click" class="btn btn-danger logout-button" />
        <div class="custom-form">
            <h3 class="static-header">Book Summary</h3>
            <div class="user-btn-align">
                <div style="margin-top: 10px;">
                    <asp:Button ID="Add_new" runat="server" OnClick="btnAddNew_Click" Text="Add New" class="btn btn-success" />
                    <%--<asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />--%>
                </div>

                <div style="margin-top: 10px;">
                    <asp:Button ID="Button3" runat="server" OnClick="btnUser_Click" Text="Go to user" class="btn btn-success" />
                    <%--<asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />--%>
                </div>
            </div>

            <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
            <asp:GridView Style="margin-top: 10px;" ID="GridView1" class="table" runat="server" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" class="edit btn btn-primary" OnClick="Edit_Click" Text="Edit" runat="server" />
                            <asp:Button ID="Button2" class="delete btn btn-warning" OnClick="Delete_Click" Text="Change Status" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
