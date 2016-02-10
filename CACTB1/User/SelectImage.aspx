<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SelectImage.aspx.cs" Inherits="CACTB1.User.SelectImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .file_upload{
            padding:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">&nbsp;</h3>
            <h3 class="panel-title text-center">انتخاب عکس</h3>
        </div>
        <div class="panel-body farsi">
            <div class="col-lg-12">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-circle img-responsive center-block loginPic  " Width="150" Height="150" />
            </div>
            <div class="form-group">
                <asp:FileUpload ID="fuProlileImage" CssClass="file_upload" runat="server" />
            </div>
            <asp:Label ID="lblwarn" CssClass="farsi" ForeColor="#CC0000" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnIgnore" CssClass="btn btn-lg btn-warning btn-block farsi margin-top-25" runat="server" Text="صرف نظر" OnClick="btnIgnore_Click"/>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-15" runat="server" Text="تایید" OnClick="btnNext_Click" />

        </div>
    </div>

</asp:Content>
