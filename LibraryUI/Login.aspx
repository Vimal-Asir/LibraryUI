<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* .form-control {
            width: 30% !important;
        }

        .custom-form {
            margin-top: 10% !important;
            margin-left: 34% !important;
        }

        #hidden_id {
            display: none;
        }*/

        .error-message {
            color: red;
            font-size: 12px;
            padding-left: 19px;
        }

        body {
            background: #262626
        }

        #Login {
            width: 50%;
            position: fixed;
            left: 20%;
            background: linear-gradient(245deg, rgba(140,170,210,0.4), rgba(150,170,200,0.4), rgba(160,170,190,0.4), rgba(170,170,180,0.4), rgba(180,170,160,0.4));
            border-radius: 12px;
            height: 400px;
            padding-top: 10px;
            margin-top: 80px;
        }

            #Login > form {
                border: 1px solid rgba(180,120,160,0.3);
                width: 90%;
                margin-left: 3%;
                padding: 10px;
                border-radius: 5px;
            }

        .user-box {
            font-family: cursive;
        }

            .user-box > label {
                position: absolute;
                left: 10%;
                margin-top: 20px;
                transition: 1s ease;
                color: rgba(46,142,202,0.5);
            }

            .user-box > input {
                border: none;
                background: none;
                padding: 10px 5%;
                border-bottom: 2px solid rgba(180,190,170,0.7);
                margin-bottom: 30px;
                width: 400px;
                border-radius: 3px;
                transition: 1s ease;
                margin-left: 20px;
            }

                .user-box > input:first-child {
                    margin-top: 10px;
                }

                .user-box > input:focus ~ label, .user-box > input:valid ~ label {
                    margin-top: 0px;
                    color: rgba(20,220,158,90%);
                    font-weight: bolder;
                }

                .user-box > input:focus, .user-box > input:valid {
                    border-color: rgb(30,144,255,0.7);
                    color: darksalmon;
                    font-family: cursive;
                    outline: none !important
                }

            .user-box > a {
                text-decoration: none;
                color: darkturquoise;
                margin-left: 20px;
                cursor: pointer;
            }

                .user-box > a:hover {
                    color: darkcyan;
                }

        .user-box-button {
            display: inline-block;
            padding-left: 40%
        }

            .user-box-button > .buttonLogin {
                text-decoration: none;
                transition: 0.5s ease;
                margin-top: 20px;
                position: relative;
                display: inline-block;
                padding: 10px 10px;
                filter: hue-rotate(300deg);
                color: #03e9f4;
                height: 45px;
                position: relative;
                display: inline-block;
                padding: 10px 10px;
                color: #03e9f4;
                font-size: 16px;
                border: none;
                text-transform: uppercase;
                overflow: hidden;
                transition: .5s;
                margin-top: 40px;
                letter-spacing: 2px;
                width: 80px;
                text-align: center;
                margin-left: 10px;
                font-family: cursive;
                background: linear-gradient( 245deg, rgba(140,170,210,0.4), rgba(150,170,200,0.4), rgba(160,170,190,0.4), rgba(170,170,180,0.4), rgba(180,170,160,0.4));
                border-radius: 5px
            }

                .user-box-button > .buttonLogin:hover {
                    background: #03e9f4;
                    color: #fff;
                    box-shadow: 0 0 2px #03e9f4, 0 0 10px #03e9f4, 0 0 20px #03e9f4, 0 0 60px #03e9f4;
                    -webkit-box-reflect: below 1px linear-gradient(transparent, #0005);
                }

            .user-box-button > a:focus {
                color: aliceblue;
            }

            .user-box-button > a > span {
                position: absolute;
                display: block;
            }

                .user-box-button > a > span:nth-child(1) {
                    top: 0;
                    left: -100px;
                    width: 100%;
                    height: 2px;
                    background: linear-gradient(90deg, transparent, #03e9f4);
                    animation: btn-anim1 2s linear infinite;
                }

        @keyframes btn-anim1 {
            0% {
                left: -100%;
            }

            50%,100% {
                left: 100%;
            }
        }

        .user-box-button > a > span:nth-child(2) {
            top: -100%;
            right: 0;
            width: 2px;
            height: 100%;
            background: linear-gradient(180deg, transparent, #03e9f4);
            animation: btn-anim2 2s linear infinite;
            animation-delay: 0.50s;
        }

        @keyframes btn-anim2 {
            0% {
                top: -100%;
            }

            50%,100% {
                top: 100%;
            }
        }

        .user-box-button > a > span:nth-child(3) {
            top: 94.7%;
            right: -100%;
            width: 100%;
            height: 2px;
            background: linear-gradient(270deg, transparent, #03e9f4);
            animation: btn-anim3 2s linear infinite;
            animation-delay: 1s;
        }

        @keyframes btn-anim3 {
            0% {
                right: -100%;
            }

            50%,100% {
                right: 100%;
            }
        }

        .user-box-button > a > span:nth-child(4) {
            top: 100%;
            left: 0;
            width: 2px;
            height: 100%;
            background: linear-gradient(180deg, transparent, #03e9f4);
            animation: btn-anim4 2s linear infinite;
            animation-delay: 1.45s;
        }

        @keyframes btn-anim4 {
            0% {
                top: 100%;
            }

            50%,100% {
                top: -100%;
            }
        }

        .login-header {
            text-align: center;
            font-family: cursive;
            color: #03e9f4;
        }
    </style>
</head>
<body>


    <div id="Login">
        <h3 class="login-header">Login to Library Management</h3>
        <form runat="server">
            <div class="user-box">
                <asp:TextBox ID="txt_user_name" Class="validate-text" runat="server" placeholder="Username"></asp:TextBox>
                <br />
                <asp:Label ID="err_name" runat="server" Class="error-message" Text=""></asp:Label>
            </div>
            <div class="user-box">
                <asp:TextBox ID="txt_password" runat="server" Class="validate-text" placeholder="Password"></asp:TextBox>
                <br />
                <asp:Label ID="err_password" Class="error-message" runat="server" Text=""></asp:Label>
            </div>
            <div class="user-box-button">
                <asp:Button ID="Button1" OnClick="Button1_Click" class="buttonLogin" runat="server" Text="Login" />
            </div>
        </form>
    </div>

</body>
</html>
<script src="Scripts/jquery-3.4.1.js"></script>
<script>
    $(function () {
        $(".validate-text").change(function () {
            if ($(this).val() != "") {
                $(this).parent().find(".error-message").text("");
            }
        });
    })
</script>