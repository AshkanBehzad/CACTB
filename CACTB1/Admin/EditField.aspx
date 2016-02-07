<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditField.aspx.cs" Inherits="CACTB1.Admin.EditField" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       <div class="col-lg-6 pull-right">

        <div class="panel panel-default" style="margin-top: 30px;">
            <div class="panel-heading">
                <h3 class="panel-title text-center">
                    ویرایش مقطع/گرایش  
                </h3>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="#CC0000" runat="server" />
            <div class="panel-body farsi">
                <div class="form-group">
                    <label>عنوان  :</label>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1"
                        runat="server"
                        ControlToValidate="txtTitle"
                        ForeColor="#CC0000"
                        ErrorMessage="عنوان مقطع/گرایش را وارد کنید">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvTitle"
                        runat="server"
                        ControlToValidate="txtTitle"
                        ForeColor="#CC0000"
                        ErrorMessage="این مقطع/گرایش موجود است" OnServerValidate="cvTitle_ServerValidate">*</asp:CustomValidator>
                    <asp:TextBox ID="txtTitle" CssClass="form-control farsi" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnEdit" CssClass=" btn btn-block btn-info margin-top-25" runat="server" Text="ویرایش" OnClick="btnEdit_Click"/>
            </div>
        </div>

    </div>
    <div class="clearfix"></div>


</asp:Content>
