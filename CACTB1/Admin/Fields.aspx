<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Fields.aspx.cs" Inherits="CACTB1.Admin.Fields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 farsi">
                <h1 class="page-header">‌مقاطع/گرایش‌ها</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 margin-top-25 pull-right">
                <div class="panel panel-default">
                    <div class="panel-heading farsi">
                        <asp:LinkButton ID="lbtnAddSkill" runat="server" data-toggle="modal" data-target="#add" CssClass="farsi pull-right"> <span class="glyphicon glyphicon-plus-sign"></span>افزودن&nbsp;&nbsp;</asp:LinkButton>
                        <asp:ValidationSummary runat="server" ForeColor="#CC0000" CssClass="farsi pull-left"></asp:ValidationSummary>
                        <asp:Label ID="lblError" CssClass="farsi pull-left" ForeColor="#CC0000" runat="server" Text=""></asp:Label>
                        <div class="clearfix"></div>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class=" table-responsive farsi">
                            <label id="report"></label>
                            <asp:GridView ID="grdFields" CssClass="table table-striped table-bordered table-hover farsi" runat="server" AutoGenerateColumns="False" OnRowCommand="grdFields_RowCommand" AllowPaging="True" OnPageIndexChanging="grdFields_PageIndexChanging" PageSize="8">
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" CommandArgument='<%#Eval("ID") %>' CommandName="EditItem" runat="server">ویرایش</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" CommandArgument='<%#Eval("ID") %>' CommandName="DeleteItem" runat="server">حذف</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="clearfix"></div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
            </div>
        </div>
    </div>
    <!---------------------Add Modal--------------------------->
    <div class="modal fade" id="add" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel1">افزودن دستع بندی </h4>
                </div>
                <div class="modal-body farsi">
                    <div class="form-group">
                        <label>عنوان‌ : </label>
                        <asp:CustomValidator
                             ID="cvTitle" 
                            runat="server" 
                            ForeColor="#CC0000"
                            ControlToValidate="txtAddTitle"
                            ErrorMessage="مقطع/گرایش با این عنوان موجود است" OnServerValidate="cvTitle_ServerValidate">*</asp:CustomValidator>
                        <asp:TextBox ID="txtAddTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddCSkill" CssClass="btn btn-primary" runat="server" Text="ذخیره" OnClick="btnAddCSkill_Click" />
                </div>
            </div>
        </div>
    </div>
    <!------------------>
    <script>

        $(document).ready(function () {

            var rowCount = $('#ContentPlaceHolder1_grdFields tr').length;
            if (rowCount == 0) {
                $("#report").html("هیچ رکوردی وجود ندارد");
            }

            $("#ContentPlaceHolder1_grdFields td").addClass("farsi");
            $("#ContentPlaceHolder1_grdFields th").addClass("text-center");
            $("#ContentPlaceHolder1_grdFields td").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdFields th").addClass("td-bordered");


        });

    </script>


</asp:Content>
