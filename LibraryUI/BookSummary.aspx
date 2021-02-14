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
            margin-top: 10% !important;
            margin-left: 5% !important;
             margin-right: 5% !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="custom-form">
             <div style="margin-top: 10px;">
                <asp:Button ID="Add_new" runat="server" OnClick="btnAddNew_Click" Text="Add New" class="btn btn-success" Style="width: 10% !important" />
                <%--<asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />--%>
            </div>

            <div style="margin-top: 10px;">
                <asp:Button ID="Button3" runat="server" OnClick="btnUser_Click" Text="Go to user" class="btn btn-success" Style="width: 10% !important" />
                <%--<asp:Button ID="update" OnClick="btn_Update_Click" runat="server" Text="Update" class="btn btn-success" Style="width: 30% !important" />--%>
            </div>
            <%--<asp:GridView ID="GridView1" runat="server"></asp:GridView>--%>
            <asp:GridView style="margin-top: 10px;" ID="GridView1" class="table" runat="server" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" class="edit" OnClick="Edit_Click" Text="Edit" runat="server" />
                            <asp:Button ID="Button2" class="delete" OnClick="Delete_Click" Text="Change Status" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
