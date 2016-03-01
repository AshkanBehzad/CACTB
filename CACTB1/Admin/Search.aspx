<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CACTB1.Admin.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 farsi">
            <h1 class="page-header">جست و جوی اعضا</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div id="panel" class="panel panel-default farsi">
                <div class="panel-heading ">
                    لطفاً اطلاعات را با دقت وارد کنید
                </div>
                <div class="panel-body farsi">
                    <div class="row">
                        <div class="col-lg-3 pull-right">
                            <div class="form-group">
                                <asp:TextBox ID="txtName" CssClass="form-control" placeHolder="نام" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtMemberID" CssClass="form-control" placeHolder="شماره عضویت" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 pull-right">
                            <div class="form-group">
                                <asp:DropDownList ID="drpField" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNetionalID" CssClass="form-control" placeHolder="کدملی" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 pull-right">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlStatuse" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="Status" DataValueField="ID" AppendDataBoundItems="True"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CACTB1ConnectionString %>" SelectCommand="SELECT [ID], [Status] FROM [MembershipStatus]"></asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-lg-3 pull-right">
                            <div class="form-group">
                            </div>
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <asp:Button ID="btnSearch" CssClass="btn btn-info btn-block" runat="server" Text="جست و جو" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
    </div>



    <div id="result" class="container-fluid">
        <div class="panel panel-default ">
            <div class="panel-heading farsi">
                <h4>نتایج</h4>
            </div>
            <div class="panel-body">
                <div class="table-responsive farsi">
                    <label id="report"></label>
                    <asp:GridView CssClass="table table-bordered table-hover rtl" ID="grdSearchedList" runat="server" AllowPaging="True" OnPageIndexChanging="grdSearchedList_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="grdSearchedList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Mid" HeaderText="شماره دانشجویی" />
                            <asp:BoundField DataField="FullName" HeaderText="نام" />
                            <asp:BoundField DataField="NationalID" HeaderText="شماره ملّی" />
                            <asp:BoundField DataField="Email" HeaderText="رایانامه" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="شماره تماس" />
                            <asp:BoundField DataField="AltPhoneNumber" HeaderText="شماره تماس 2" />
                            <asp:BoundField DataField="Gender" HeaderText="جنسیت" />
                            <asp:BoundField DataField="Title" HeaderText="مقطع/گرایش" />
                            <asp:BoundField DataField="Linkedin" HeaderText="لینکداین" />
                            <asp:BoundField DataField="Type" HeaderText="نوع کاربر" />
                            <asp:BoundField DataField="Status_ID" HeaderText="وضعیت عضو" />
                            <asp:TemplateField HeaderText="اطلاعات تکمیل شده؟">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" Enabled="false" Checked='<%#Eval("IsCompeleted") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnShow" CommandArgument='<%#Eval("Mid")%>' CommandName="Show" runat="server">نمایش اطلاعات و تنظیمات</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            var rowCount = $('#ContentPlaceHolder1_grdSearchedList tr').length;
            if (rowCount == 0) {
                $("#result").hide(10);
            }
            $("#ContentPlaceHolder1_grdSearchedList td").addClass("rtl");
            $("#ContentPlaceHolder1_grdSearchedList th").addClass("text-center");
            $("#ContentPlaceHolder1_grdSearchedList td:last-child").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdSearchedList th:last-child").addClass("td-bordered");
            $("#ContentPlaceHolder1_grdSearchedList tr:last-child td:last-child").removeClass("td-bordered");
            $("#ContentPlaceHolder1_grdSearchedList tr:last-child th:last-child").removeClass("td-bordered");
        });

    </script>


</asp:Content>
