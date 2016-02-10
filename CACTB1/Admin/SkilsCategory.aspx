<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SkilsCategory.aspx.cs" Inherits="CACTB1.Admin.SkilsCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../bower_components/jquery/dist/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 farsi">
                <h1 class="page-header">دسته بندی دانشها</h1>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblErrorMes" CssClass="farsi pull-right" ForeColor="#CC0000" runat="server" Text=""></asp:Label>
            <div class="container-fluid margin-top-25">
                <div class="panel panel-default">
                    <div class="panel-heading farsi">
                        <asp:LinkButton ID="lbtnAddCat" runat="server" data-toggle="modal" data-target="#add" CssClass="farsi pull-right"> <span class="glyphicon glyphicon-plus-sign"></span>افزودن&nbsp;&nbsp;</asp:LinkButton>
                        <div class="clearfix"></div>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" CssClass="farsi margin-top-25 pull-right" />
                        <div class="table-responsive farsi">
                            <label id="report"></label>
                            <asp:GridView CssClass="table table-striped table-bordered table-hover farsi" ID="grdSkillCat" runat="server" AutoGenerateColumns="False" OnRowCommand="grdSkillCat_RowCommand" OnRowDeleting="grdSkillCat_RowDeleting" OnRowEditing="grdSkillCat_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                    <asp:BoundField DataField="Title" HeaderText="عنوان" SortExpression="Title" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDeleteCat" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem">حذف</asp:LinkButton>
                                           / &nbsp;<asp:LinkButton ID="lbtnEditCat" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="EditItem">ویرایش</asp:LinkButton>
                                           / &nbsp;<a  style="cursor:pointer"
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
                        <asp:CustomValidator ID="cvTitleCheck" runat="server" ErrorMessage="دسته‌ بندی با این عنوان موجود است" ForeColor="#CC0000" Text="دسته‌بندی با این عنوان موجو است " ControlToValidate="txtAddTitle" OnServerValidate="cvTitleCheck_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="form-group">
                        <label>توضیحات‌ : </label>
                        <asp:TextBox ID="txtAddDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddCat" CssClass="btn btn-primary" runat="server" Text="ذخیره" OnClick="btnAddCat_Click" />
                </div>
            </div>
        </div>
    </div>
    <!------------------>
    <script>

        $(document).ready(function () {

            var rowCount = $('#ContentPlaceHolder1_grdSkillCat tr').length;
            if (rowCount == 0) {
                $("#report").html("هیچ رکوردی وجود ندارد");
            }


            $("#ContentPlaceHolder1_grdSkillCat td").addClass("farsi");
            $("#ContentPlaceHolder1_grdSkillCat th").addClass("text-center");
            $("#ContentPlaceHolder1_grdSkillCat td").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdSkillCat th").addClass("td-bordered");

        });

    </script>

</asp:Content>
