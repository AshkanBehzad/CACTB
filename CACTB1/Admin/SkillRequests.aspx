<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SkillRequests.aspx.cs" Inherits="CACTB1.Admin.SkillRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 farsi">
                <h1 class="page-header">درخواست‌ها</h1>
            </div>
        </div>
        <div class="row">

            <div class="container-fluid margin-top-25">
                <div class="panel panel-default">
                    <div class="panel-heading farsi">
                        <label>تعداد درخواستها: </label>
                        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
                        <div class="clearfix"></div>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive farsi">
                            <asp:GridView ID="grdSkills" CssClass="table rtl table-striped table-bordered table-hover farsi" AutoGenerateColumns="False"  runat="server" OnRowCommand="grdSkills_RowCommand" OnRowUpdated="grdSkills_RowUpdated">
                                <Columns>
                                    <asp:BoundField DataField="FullName" HeaderText="نام درخواست دهنده" />
                                    <asp:BoundField DataField="Member_ID" HeaderText="شماره عضویت درخواست دهنده" />
                                    <asp:BoundField DataField="SRTitle" HeaderText="دانش پیشنهادی" />
                                    <asp:BoundField DataField="Description" HeaderText="توضیحات" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDelete" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem" runat="server">حذف</asp:LinkButton>&nbsp;/&nbsp;
                                            <asp:LinkButton ID="lbtnEtidSubmit" CommandArgument='<%#Eval("ID")%>' CommandName="EditSubmit" runat="server">ویرایش و تایید</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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


        });

    </script>

</asp:Content>
