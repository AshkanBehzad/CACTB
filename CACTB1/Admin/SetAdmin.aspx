<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SetAdmin.aspx.cs" Inherits="CACTB1.Admin.SetAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 farsi">
            <h1 class="page-header">تعیین ادمین</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 col-sm-12 col-xs-12 pull-right">
            <div id="panel" class="panel panel-default farsi">
                <div class="panel-heading ">
                    لطفاً اطلاعات را با دقت وارد کنید
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:TextBox ID="txtName" placeHolder="جست و جو بر حسب نام" CssClass="form-control" runat="server" OnTextChanged="txtName_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtMemberID" placeHolder="جست و جو بر حسب شماره عضویت" CssClass="form-control" runat="server" OnTextChanged="txtName_TextChanged" AutoPostBack="True"></asp:TextBox>
                            </div>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>

        <div class="col-md-8 col-sm-12 col-xs-12 pull-right" id="result">
            <div class="panel panel-default ">
                <div class="panel-heading farsi">
                    <h4>نتایج</h4>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive farsi">
                        <label id="report"></label>
                        <asp:GridView ID="grdUserSearched" CssClass="table table-bordered table-hover rtl" runat="server" AutoGenerateColumns="False" OnRowCommand="grdUserSearched_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnSetAdmin" CommandArgument='<%#Eval("Mid") %>' CommandName="DeleteAdmin" runat="server"><i class="fa fa-plus-circle"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Mid" HeaderText="شماره عضویت" />
                                <asp:BoundField DataField="FullName" HeaderText="نام و نام‌خانوادگی" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <div class="clearfix"></div>
        <!-- /.col-lg-12 -->
    </div>
    <script>
        $(document).ready(function () {
            var rowCount = $('#ContentPlaceHolder1_grdUserSearched tr').length;
            if (rowCount == 0) {
                $("#result").hide(10);
            }
            $("#ContentPlaceHolder1_grdUserSearched td").addClass("rtl");
            $("#ContentPlaceHolder1_grdUserSearched th").addClass("text-center");
            $("#ContentPlaceHolder1_grdUserSearched td:last-child").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdUserSearched th:last-child").addClass("td-bordered");
        });

    </script>
</asp:Content>
