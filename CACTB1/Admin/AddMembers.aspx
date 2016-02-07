<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddMembers.aspx.cs" Inherits="CACTB1.Admin.AddMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
    <style>
        #warn h5 ul li {
            margin-top: 10px;
        }

        #panel {
            position: relative !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 farsi">
            <h1 class="page-header">افزودن عضو جدید</h1>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">




        <div class="col-md-6 col-sm-12 col-xs-12 pull-right">
            <div id="panel" class="panel panel-default farsi">
                <div class="panel-heading ">
                    لطفاً اطلاعات را با دقت وارد کنید
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="alert alert-warning alert-dismissible" id="warn" role="alert">
                                <button type="button" class="close" id="close_modal"><span>&times;</span></button>
                                <h5>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" />
                                </h5>
                            </div>
                            <div class="form-group">
                                <label>نام : </label>
                                <asp:RequiredFieldValidator
                                    ForeColor="#CC0000"
                                    ID="RequiredFieldValidator1"
                                    runat="server"
                                    ErrorMessage="نام را وارد نکرده‌اید"
                                    ControlToValidate="txtFirstName">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>نام‌خانوادگی : </label>
                                <asp:RequiredFieldValidator
                                    ForeColor="#CC0000"
                                    ID="RequiredFieldValidator2"
                                    runat="server"
                                    ErrorMessage="نام‌خانوادگی را وارد نکرده‌اید"
                                    ControlToValidate="txtLastName">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>شماره ملّی : </label>
                                <asp:RequiredFieldValidator
                                    ForeColor="#CC0000"
                                    ID="RequiredFieldValidator3"
                                    runat="server"
                                    ErrorMessage="شماره ملّی را وارد نکرده‌اید"
                                    ControlToValidate="txtNationalID">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server"
                                    ControlToValidate="txtNationalID"
                                    OnServerValidate="CustomValidator1_ServerValidate"
                                    ErrorMessage="کد ملی وارد شده معتبر نیست"
                                    ForeColor="#CC0000" ValidateEmptyText="True">*</asp:CustomValidator>
                                <asp:TextBox ID="txtNationalID" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>شماره دانشجویی : </label>
                                <asp:RequiredFieldValidator
                                    ForeColor="#CC0000"
                                    ID="RequiredFieldValidator6"
                                    runat="server"
                                    ErrorMessage=" شماره دانشجویی را وارد نکرده‌اید"
                                    ControlToValidate="txtStdentID">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator2" runat="server"
                                    ErrorMessage="شماره دانشجویی اشتباه است"
                                    ControlToValidate="txtStdentID"
                                    ForeColor="#CC0000" OnServerValidate="CustomValidator2_ServerValidate" ValidateEmptyText="True">*</asp:CustomValidator>
                                <asp:CustomValidator
                                    ID="CustomValidator3"
                                    runat="server"
                                    ControlToValidate="txtStdentID"
                                    ForeColor="#CC0000"
                                    ErrorMessage="عضو با این شماره دانشجویی موجود است" OnServerValidate="CustomValidator3_ServerValidate">*</asp:CustomValidator>
                                <asp:TextBox ID="txtStdentID" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>شماره تماس : </label>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator5"
                                    runat="server"
                                    ControlToValidate="txtPhoneNumber"
                                    ForeColor="#CC0000"
                                    ErrorMessage="شماره تماس را وارد نکرده‌اید">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2"
                                    runat="server"
                                    ControlToValidate="txtPhoneNumber"
                                    ValidationExpression="\d+"
                                    ForeColor="#CC0000"
                                    ErrorMessage="شماره تماس باید فاقد کاراکتر باشد">*</asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>رایانامه  : </label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="آدرس ایمیل اشتباه وارد شده"
                                    ForeColor="#CC0000">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    ForeColor="#CC0000"
                                    ErrorMessage="ایمیل را وارد نکرده‌اید">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>رشته / مقطع / گرایش  : </label>
                                <asp:DropDownList ID="ddlField" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="Title" DataValueField="ID"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CACTB1ConnectionString %>" SelectCommand="SELECT * FROM [Fields]"></asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                                <label>جنسیت  : </label>
                                <div style="margin-right: 10px;">
                                    <div>
                                        <asp:RadioButton ID="rdbmale" Checked="true" GroupName="Gender" runat="server" />&nbsp;&nbsp;مرد
                                    </div>
                                    <div>
                                        <asp:RadioButton ID="rdbFemale" GroupName="Gender" runat="server" />&nbsp;&nbsp;زن
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="btnAdd" runat="server" Text="افزودن" CssClass="btn btn-primary btn-block" OnClick="btnAdd_Click" />
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <div class="clearfix"></div>
        <!-- /.col-lg-12 -->
    </div>
    <script>
        $("input[type=submit]").click(function () {
            if ($("#warn h5 ul").length != 0) {
                $("#warn").fadeIn(500);
            }
        });
        $("#close_modal").click(function () {
            $("#warn").fadeOut(500);
        });
        $(document).ready(function () {
            $("#warn").hide();
            $("#seccess").hide();
            if ($("#warn h5 ul").length != 0) {
                $("#warn").fadeToggle(100);
            }
        });
    </script>
</asp:Content>
