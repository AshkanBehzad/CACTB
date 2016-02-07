<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MemberStats.aspx.cs" Inherits="CACTB1.Admin.MemberStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#editName').modal(options)
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top: 40px;">
        <div class="row farsi">
            <div class="col-lg-3 pull-right">
                <asp:image class="img-responsive loginPic img-circle" width="200px" imageurl="~/MyFiles/user.png" id="Image1" runat="server" />
                <asp:button id="btnDeleteImage" runat="server" cssclass="btn farsi pull-left" text="حذف تصویر" />
                <div class="clearfix"></div>
            </div>
            <div class="col-lg-9">
                <asp:label id="lblName" cssclass="h1 bold-font-50" runat="server" text="بهزاد چیذری"></asp:label>
                <asp:linkbutton id="lbtnEditName" runat="server" data-toggle="modal" data-target="#editName"><span class=" glyphicon glyphicon-edit" style="font-size:20px;"></span></asp:linkbutton>
                <ul style="margin-top:25px;">
                    <li>
                        <asp:label id="lblField" cssclass="h5" forecolor="#666666" runat="server" text=" کارشناسی نرم افزار"></asp:label>
                        <asp:linkbutton id="lctnEditField" runat="server" data-toggle="modal" data-target="#editField"><span class="glyphicon glyphicon-edit" style="font-size:11px;"></span></asp:linkbutton>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!---------------------EdtName Modal--------------------------->
    <div class="modal fade" id="editName" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">ویرایش نام </h4>
                </div>
                <div class="modal-body farsi">
                    <div class="form-group">
                        <label>نام‌ : </label>
                        <asp:textbox id="txtFirstName" cssclass="form-control" runat="server"></asp:textbox>
                    </div>
                    <div class="form-group">
                        <label>نام‌خانوادگی : </label>
                        <asp:textbox id="txtLastName" cssclass="form-control" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:button id="btnSaveEditedName" cssclass="btn btn-primary" runat="server" text="ذخیره" onclick="btnSaveEditedName_Click" />
                </div>
            </div>
        </div>
    </div>
    <!----->
    <!---------------------EditField Modal--------------------------->
    <div class="modal fade" id="editField" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel2">ویرایش مقطع/گرایش </h4>
                </div>
                <div class="modal-body farsi">
                    <div class="form-group">
                        <label>مقطع/رشته‌ : </label>
                        <asp:dropdownlist cssclass="form-control" id="ddlField" runat="server" datasourceid="SqlDataSource1" datatextfield="Title" datavaluefield="ID"></asp:dropdownlist>
                        <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:CACTB1ConnectionString %>" selectcommand="SELECT * FROM [Fields]"></asp:sqldatasource>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:button id="btnEditfield" cssclass="btn btn-primary" runat="server" text="ذخیره" onclick="btnEditfield_Click" />
                </div>
            </div>
        </div>
    </div>
    <!----->
</asp:Content>
