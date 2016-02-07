<%@ Page Title="" Language="C#" MasterPageFile="~/UserLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CACTB1.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>صفحه ورود</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="login-panel panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title text-center">ورود</h3>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <img src="../MyFiles/user.png" class="center-block img-responsive img-circle loginPic" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUserName" CssClass="form-control farsi" placeholder="نام کاربری/شماره عضویت" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvUsername" runat="server" Text="کاربری با این نام کاربری وجود ندارد" ForeColor="#CC0000" OnServerValidate="cvUsername_ServerValidate"></asp:CustomValidator>
            </div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi" runat="server" Text="بعدی" OnClick="btnNext_Click" />

        </div>
    </div>



</asp:Content>
