<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CACTB1.User.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    input[type="text"] {
        border: none;
        box-shadow: inset 0 0 10px #ccc;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="login-panel panel panel-default farsi">
        <div class="panel-heading">
            <h3 class="panel-title text-center">تغییر رمز عبور</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <asp:TextBox ID="txtPassword" CssClass="margin-top-25 form-control" placeholder="رمز عبور جدید" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="#CC0000" ControlToValidate="txtPassword" runat="server" ErrorMessage="رمز عبور را حتما باید تغییر دهید"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassCheck" CssClass="margin-top-25 form-control" placeholder="تکرار رمز عبور" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="margin-top-15" ForeColor="#CC0000" ErrorMessage="عدم مطابقت رمز عبور" ControlToCompare="txtPassCheck" ControlToValidate="txtPassword"></asp:CompareValidator><br />
            </div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi" runat="server" Text="بعدی" OnClick="btnNext_Click" />

        </div>
    </div>
</asp:Content>
