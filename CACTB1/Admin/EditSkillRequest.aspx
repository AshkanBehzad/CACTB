<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditSkillRequest.aspx.cs" Inherits="CACTB1.Admin.EditSkillRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-6 pull-right">
        <div class="panel panel-default" style="margin-top: 30px;">
            <div class="panel-heading">
                <h3 class="panel-title text-center">ویرایش دانش درخواستی
                </h3>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="#CC0000" runat="server" />
            <div class="panel-body farsi">
                <div class="form-group">
                    <label>عنوان  :</label>
                    <asp:TextBox ID="txtTitle" CssClass="form-control farsi" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>توضیحات  :</label>
                    <asp:TextBox ID="txtDescription" CssClass="form-control farsi" runat="server"></asp:TextBox>
                </div>
                <div class="form-group" runat="server" id="cstm">
                    <label>دسته بندی  :</label>
                    <asp:DropDownList ID="ddlSkillCat" CssClass="form-control" runat="server" >
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnDelete" CssClass=" btn btn-block btn-danger margin-top-25" runat="server" Text="حذف" OnClick="btnDelete_Click" />
                <asp:Button ID="btnEdit" CssClass=" btn btn-block btn-info" runat="server" Text="افزودن" OnClick="btnEdit_Click" />
            </div>
        </div>
    </div>
    <div class="clearfix"></div>
</asp:Content>
