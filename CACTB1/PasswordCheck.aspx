<%@ Page Title="" Language="C#" MasterPageFile="~/UserLogin.Master" AutoEventWireup="true" CodeBehind="PasswordCheck.aspx.cs" Inherits="CACTB1.User.PasswordCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>رمز عبور</title>
    <style>
        input[type="text"] {
            border: none;
            box-shadow: inset 0 0 10px #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="login-panel panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title text-center">رمز عبور خود را وارد کنید</h3>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-circle img-responsive center-block loginPic" Width="150" Height="150" />
                <div style="margin:20px auto 30px auto;">
                    <div class="filterPic"></div>
                    <asp:Label ID="lblName" CssClass="farsi text-center center-block bold-font-20" runat="server" Text="نام نام‌خانوادگی "></asp:Label>
                    <asp:Label ID="lblEmail" CssClass="farsi text-center center-block lblEmail" runat="server" Text="YourEmail@Inc.com"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" CssClass="form-control farsi" placeholder="رمز عبور" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CustomValidator ID="cvPassword" runat="server" ErrorMessage="رمز عبور اشتباه است" ForeColor="#CC0000" OnServerValidate="cvPassword_ServerValidate">رمز عبور اشتباه است</asp:CustomValidator>
            </div>
            <asp:Button ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block farsi" runat="server" Text="ورود" OnClick="btnLogin_Click" />
            <asp:LinkButton ID="lbtnForgotPass" CssClass="pull-right off-10" runat="server" OnClick="lbtnForgotPass_Click">رمز عبور خود را فراموش کرده‌اید؟&nbsp;&nbsp;<i class="fa fa-arrow-left"></i></asp:LinkButton>
           
        </div>
    </div>



</asp:Content>
