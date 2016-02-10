<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MembersList.aspx.cs" Inherits="CACTB1.Admin.MembersList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 farsi">
            <h1 class="page-header">لیست اعضا</h1>
        </div>
    </div>
    <!-- /.row -->


    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default ">
                <div class="panel-heading farsi">
                    <asp:Label ID="Label2" CssClass="farsi" runat="server" Text="تعداد اعضا   :   "></asp:Label>
                    <asp:Label ID="lblCount" CssClass="farsi" runat="server" Text=""></asp:Label>
                </div>
                <!-- /.panel-heading -table table-bordered table-hover rtl-->
                <div class="panel-body">
                    <div class="table-responsive farsi">
                        <label id="report"></label>
                        <asp:GridView CssClass="table table-striped table-bordered table-hover dataTable no-footer farsi" ID="grdMemberList" runat="server" AutoGenerateColumns="False" OnRowCommand="grdMemberList_RowCommand" AllowPaging="True" OnPageIndexChanging="grdMemberList_PageIndexChanging" PageSize="4">
                            <Columns>
                                <asp:BoundField DataField="Mid" HeaderText="شماره عضویت" />
                                <asp:BoundField DataField="FirstName" HeaderText="نام" />
                                <asp:BoundField DataField="LastName" HeaderText="نام‌خانوادگی" />
                                <asp:BoundField DataField="NationalID" HeaderText="کد ملّی" />
                                <asp:BoundField DataField="Email" HeaderText="رایانامه" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="شماره تلفن" />
                                <asp:BoundField DataField="Title" HeaderText="مقطع/گرایش" />
                                <asp:BoundField DataField="Gender" HeaderText="جنسیت" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnShow" CommandArgument='<%#Eval("Mid") %>' CommandName="Show" runat="server">نمایش اطلاعات و تنظیمات</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <script>
        $(document).ready(function () {
            var rowCount = $('#ContentPlaceHolder1_grdMemberList tr').length;
            if (rowCount == 0) {
                $("#report").html("هیچ رکوردی وجود ندارد");
            }
            $("#ContentPlaceHolder1_grdMemberList td").addClass("rtl");
            $("#ContentPlaceHolder1_grdMemberList th").addClass("text-center");
            $("#ContentPlaceHolder1_grdMemberList td:last-child").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdMemberList th:last-child").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdMemberList tr:last-Child td:last-child").removeClass("td-bordered");

            $('[data-toggle="tooltip"]').tooltip()

        });

    </script>
</asp:Content>
