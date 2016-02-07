<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="CompeletInformations.aspx.cs" Inherits="CACTB1.User.CompeletInformations1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">تایید اطلاعات</h3>
        </div>
        <div class="panel-body farsi">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
            <div class="form-group">
                <label>نام  :</label>
                <asp:RequiredFieldValidator ControlToValidate="txtFirstName"
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ErrorMessage=" نام خود را وارد کنید"
                    ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtFirstName" CssClass="form-control farsi" placeholder="نام" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>نام‌خانوادگی  :</label>
                <asp:RequiredFieldValidator
                    ControlToValidate="txtLastName"
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ErrorMessage="نام‌خانوادگی خود را وارد کنید"
                    ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="txtLastName" CssClass="form-control farsi" placeholder="نام‌خانوادگی" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>شماره عضویت :</label>
                <asp:RequiredFieldValidator
                    ControlToValidate="txtMemberID"
                    ID="RequiredFieldValidator3"
                    runat="server"
                    ErrorMessage="شماره دانشجویی خود را وارد کنید"
                    ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ControlToValidate="txtMemberID"
                    ID="cvMemberID"
                    runat="server"
                    ErrorMessage="شماره عضویت/دانشجویی معتبر نیست"
                    ForeColor="#CC0000"
                    OnServerValidate="cvMemberID_ServerValidate">*</asp:CustomValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtMemberID"
                    ErrorMessage="شماره عضویت/دانشجویی معتبر نیست"
                    ValidationExpression="\d+"
                    ID="RegularExpressionValidator5"
                    ForeColor="#CC0000"
                    runat="server">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtMemberID" CssClass="form-control farsi" placeholder="شماره عضویت/دانشجویی" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>شماره ملّی :</label>
                <asp:RequiredFieldValidator
                    ControlToValidate="txtNatioanlID"
                    ID="RequiredFieldValidator4"
                    runat="server"
                    ErrorMessage="شماره ملی خود را وارد کنید"
                    ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                <asp:CustomValidator 
                    ControlToValidate="txtNatioanlID" 
                    ID="cvNationalID" 
                    runat="server" 
                    ErrorMessage="شماره ملّی معتبر نیست" 
                    ForeColor="#CC0000" 
                    OnServerValidate="cvNationalID_ServerValidate">*</asp:CustomValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtNatioanlID"
                    ErrorMessage="شماره ملّی معتبر نیست"
                    ValidationExpression="\d+"
                    ID="RegularExpressionValidator4"
                    ForeColor="#CC0000"
                    runat="server">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtNatioanlID" CssClass="form-control farsi" placeholder="شماره ملّی" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>رایانامه :</label>
                <asp:RequiredFieldValidator 
                    ControlToValidate="txtEmail" 
                    ID="RequiredFieldValidator5" 
                    runat="server" 
                    ErrorMessage="رایانامه خود را وارد کنید" 
                    ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator1" 
                    runat="server" 
                    ControlToValidate="txtEmail" 
                    ForeColor="#CC0000" 
                    ErrorMessage="رایانامه معتبر نیست"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtEmail" CssClass="form-control farsi" placeholder="رایانامه" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label> شمارۀ تماس(همراه)      :</label>
                <asp:RegularExpressionValidator ControlToValidate="txtPhoneNumber"
                    ErrorMessage="شماره تماس معتبر نیست"
                    ValidationExpression="\d+"
                    ID="RegularExpressionValidator2"
                    ForeColor="#CC0000"
                    runat="server">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control farsi" placeholder="شماره تماس" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>شمارۀ تماس(همراه) :</label>
                <asp:RegularExpressionValidator ControlToValidate="txtAltPhoneNumber"
                    ErrorMessage="شماره تماس معتبر نیست"
                    ValidationExpression="\d+"
                    ID="RegularExpressionValidator3"
                    ForeColor="#CC0000"
                    runat="server">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="txtAltPhoneNumber" CssClass="form-control farsi" placeholder=" شمارۀ تماس 2  " runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>مقطع/گرایش :</label>
                <asp:DropDownList ID="ddlField" CssClass="form-control farsi" runat="server" DataSourceID="SqlDataSource1" DataTextField="Title" DataValueField="ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CACTB1ConnectionString %>" SelectCommand="SELECT * FROM [Fields]"></asp:SqlDataSource>
            </div>
            <asp:Button ID="btnEdit" CssClass="btn btn-lg btn-warning btn-block farsi " runat="server" Text="ویرایش اطلاعات" OnClick="btnEdit_Click" />
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-25" runat="server" Text="تایید" />

        </div>
    </div>

</asp:Content>
