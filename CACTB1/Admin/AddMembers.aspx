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
                                    <asp:validationsummary id="ValidationSummary1" runat="server" forecolor="#CC0000" />
                                </h5>
                            </div>
                            <!----------Form Controls && Validations------------>
                            <div class="form-group">
                                <label>نام : </label>
                                <asp:requiredfieldvalidator
                                    forecolor="#CC0000"
                                    id="RequiredFieldValidator1"
                                    runat="server"
                                    errormessage="نام را وارد نکرده‌اید"
                                    controltovalidate="txtFirstName">*</asp:requiredfieldvalidator>
                                <asp:textbox id="txtFirstName" cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                            <div class="form-group">
                                <label>نام‌خانوادگی : </label>
                                <asp:requiredfieldvalidator
                                    forecolor="#CC0000"
                                    id="RequiredFieldValidator2"
                                    runat="server"
                                    errormessage="نام‌خانوادگی را وارد نکرده‌اید"
                                    controltovalidate="txtLastName">*</asp:requiredfieldvalidator>
                                <asp:textbox id="txtLastName" cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                            <div class="form-group">
                                <label>شماره ملّی : </label>
                                <asp:requiredfieldvalidator
                                    forecolor="#CC0000"
                                    id="RequiredFieldValidator3"
                                    runat="server"
                                    errormessage="شماره ملّی را وارد نکرده‌اید"
                                    controltovalidate="txtNationalID">*</asp:requiredfieldvalidator>
                                <asp:customvalidator id="CustomValidator1" runat="server"
                                    controltovalidate="txtNationalID"
                                    onservervalidate="CustomValidator1_ServerValidate"
                                    errormessage="کد ملی وارد شده معتبر نیست"
                                    forecolor="#CC0000" validateemptytext="True">*</asp:customvalidator>
                                <asp:textbox id="txtNationalID" cssclass="form-control" runat="server"></asp:textbox>

                            </div>
                            <div class="form-group">
                                <label>شماره دانشجویی : </label>
                                <asp:requiredfieldvalidator
                                    forecolor="#CC0000"
                                    id="RequiredFieldValidator6"
                                    runat="server"
                                    errormessage=" شماره دانشجویی را وارد نکرده‌اید"
                                    controltovalidate="txtStdentID">*</asp:requiredfieldvalidator>
                                <asp:customvalidator
                                    id="CustomValidator3"
                                    runat="server"
                                    controltovalidate="txtStdentID"
                                    forecolor="#CC0000"
                                    errormessage="عضو با این شماره دانشجویی موجود است" onservervalidate="CustomValidator3_ServerValidate">*</asp:customvalidator>
                                <asp:textbox id="txtStdentID" cssclass="form-control" runat="server"></asp:textbox>

                            </div>
                            <div class="form-group">
                                <label>شماره تماس : </label>
                                <asp:requiredfieldvalidator
                                    id="RequiredFieldValidator5"
                                    runat="server"
                                    controltovalidate="txtPhoneNumber"
                                    forecolor="#CC0000"
                                    errormessage="شماره تماس را وارد نکرده‌اید">*</asp:requiredfieldvalidator>
                                <asp:regularexpressionvalidator
                                    id="RegularExpressionValidator2"
                                    runat="server"
                                    controltovalidate="txtPhoneNumber"
                                    validationexpression="\d+"
                                    forecolor="#CC0000"
                                    errormessage="شماره تماس باید فاقد کاراکتر باشد">*</asp:regularexpressionvalidator>
                                <asp:textbox id="txtPhoneNumber" cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                            <div class="form-group">
                                <label>رایانامه  : </label>
                                <asp:regularexpressionvalidator id="RegularExpressionValidator1"
                                    runat="server"
                                    controltovalidate="txtEmail"
                                    validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    errormessage="آدرس ایمیل اشتباه وارد شده"
                                    forecolor="#CC0000">*</asp:regularexpressionvalidator>
                                <asp:requiredfieldvalidator
                                    id="RequiredFieldValidator4"
                                    runat="server"
                                    controltovalidate="txtEmail"
                                    forecolor="#CC0000"
                                    errormessage="ایمیل را وارد نکرده‌اید">*</asp:requiredfieldvalidator>
                                <asp:textbox id="txtEmail" cssclass="form-control" runat="server"></asp:textbox>
                            </div>
                            <div class="form-group">
                                <label>رشته / مقطع / گرایش  : </label>
                                <asp:dropdownlist id="ddlField" runat="server" cssclass="form-control" datasourceid="SqlDataSource1" datatextfield="Title" datavaluefield="ID"></asp:dropdownlist>
                                <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:CACTB1ConnectionString %>" selectcommand="SELECT * FROM [Fields]"></asp:sqldatasource>
                            </div>
                            <div class="form-group">
                                <label>جنسیت  : </label>
                                <div style="margin-right: 10px;">
                                    <div>
                                        <asp:radiobutton id="rdbmale" checked="true" groupname="Gender" runat="server" />
                                        &nbsp;&nbsp;مرد
                                    </div>
                                    <div>
                                        <asp:radiobutton id="rdbFemale" groupname="Gender" runat="server" />
                                        &nbsp;&nbsp;زن
                                    </div>
                                </div>
                            </div>
                            <asp:button id="btnAdd" runat="server" text="افزودن" cssclass="btn btn-primary btn-block" onclick="btnAdd_Click" />
                        </div>
                        <!----------// Form Controls && Validations------------>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>

    <!-------------Display Validation Summery--------------->
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
    <!-------------// Display Validation Summery--------------->
</asp:Content>
