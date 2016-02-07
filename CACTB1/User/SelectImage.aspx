<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SelectImage.aspx.cs" Inherits="CACTB1.User.SelectImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">تایید اطلاعات</h3>
        </div>
        <div class="panel-body farsi">
            <div class="col-lg-12">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-circle img-responsive center-block loginPic" Width="150" Height="150" />
            </div>
            <div class="form-group">
                <asp:FileUpload ID="fuProlileImage" runat="server" />
            </div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-25" runat="server" Text="تایید" />

        </div>
    </div>

</asp:Content>
