<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Skills.aspx.cs" Inherits="CACTB1.Admin.Skills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 farsi">
                <h1 class="page-header">دانشها</h1>
            </div>
        </div>
        <div class="row">

            <div class="container-fluid margin-top-25">
                <div class="panel panel-default">
                    <div class="panel-heading farsi">
                        <asp:LinkButton ID="lbtnAddSkill" runat="server" data-toggle="modal" data-target="#add" CssClass="farsi pull-right"> <span class="glyphicon glyphicon-plus-sign"></span>افزودن&nbsp;&nbsp;</asp:LinkButton>
                        <asp:ValidationSummary runat="server" ForeColor="#CC0000" CssClass="farsi pull-left"></asp:ValidationSummary>
                        <div class="clearfix"></div>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive farsi">
                            <label id="report"></label>
                            <asp:GridView CssClass="table table-striped table-bordered table-hover farsi" ID="grdSkills" runat="server" AutoGenerateColumns="False" OnRowCommand="grdSkills_RowCommand" OnRowDeleting="grdSkills_RowDeleting" OnRowEditing="grdSkills_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title" />
                                    <asp:BoundField DataField="CatTile" HeaderText="دسته بندی" SortExpression="CatTile" />
                                    <asp:TemplateField>

                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDelete" CommandArgument='<%#Eval("Sid") %>' CommandName="DeleteItem" runat="server">حذف</asp:LinkButton>&nbsp;/&nbsp;
                                            <asp:LinkButton ID="lbtnEdit" CommandArgument='<%#Eval("Sid") %>' CommandName="EditItem" runat="server">ویرایش</asp:LinkButton>&nbsp;/&nbsp;
                                            <a  style="cursor:pointer"
                                                data-toggle="tooltip"
                                                data-placement="left"
                                                title='<%#Eval("Description") %>'>توضیحات</a>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <script>
                                $(function () {
                                    $('[data-toggle="tooltip"]').tooltip()
                                })
                            </script>
                        </div>
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
                        <asp:TextBox ID="txtAddTitle" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="دانش با این نام موجود است" ID="cvSkillTitleCheck" ControlToValidate="txtAddTitle" OnServerValidate="cvSkillTitleCheck_ServerValidate" ForeColor="#CC0000">دانش با این نام موجود است</asp:CustomValidator>
                    </div>
                    <div class="form-group">
                        <label>عنوان‌ : </label>
                        <asp:DropDownList CssClass="farsi form-control" ID="ddlSkillCat" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>توضیحات‌ : </label>
                        <asp:TextBox ID="txtAddDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
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

            var rowCount = $('#ContentPlaceHolder1_grdSkills tr').length;
            if (rowCount == 0) {
                $("#report").html("هیچ رکوردی وجود ندارد");
            }
            $("#ContentPlaceHolder1_grdSkills td").addClass("farsi");
            $("#ContentPlaceHolder1_grdSkills th").addClass("text-center");
            $("#ContentPlaceHolder1_grdSkills td").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdSkills th").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdSkills tr td:nth-child(1)").removeClass("farsi");
            $("#ContentPlaceHolder1_grdSkills tr td:nth-child(1)").addClass("ltr");


        });

    </script>

</asp:Content>
