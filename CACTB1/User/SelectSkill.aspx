<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SelectSkill.aspx.cs" Inherits="CACTB1.User.SelectSkill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">انتخاب دانشها</h3>
        </div>
        <div class="panel-body farsi">
            <h6 class="center-block">
                <asp:Label ID="lblWarn" ForeColor="#CC0000" runat="server" Text=""></asp:Label></h6>
            <div class="container-fluid">



                <asp:GridView ID="grdCat" CssClass="container-fluid full-width ltr" DataKeyNames="ID" runat="server"  AutoGenerateColumns="False" OnRowDataBound="grdCat_RowDataBound" BorderStyle="None" GridLines="None" Width="163px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <h4 id="s<%#Eval("ID") %>" class="btn btn-block btn-outline btn-default collapse-btn">
                                    <%#Eval("Title") %>
                                </h4>
                                <div id="s<%# Eval("ID") %>c" class="collapse-panel">
                                    <asp:GridView ID="grdSkill" DataKeyNames="ID" CssClass="pull-right full-width" runat="server" AutoGenerateColumns="False" GridLines="None" BorderStyle="None">
                                        <Columns>
                                            <asp:BoundField DataField="Title" />
                                            <asp:TemplateField>

                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ckbSkill" CssClass="pull-right text-right" runat="server" />
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $(".collapse-panel").hide();
                    });
                    $(".collapse-btn").click(function () {
                        $(".collapse-panel").slideUp();
                        var btnID = $(this).attr('id');
                        if ($("#" + btnID + "c").css("display") == "none") {
                            $("#" + btnID + "c").slideDown();
                        }
                        else {
                            $("#" + btnID + "c").slideUp();
                        }
                    });
                </script>
            </div>
            <div class=" margin-top-25"></div>
            <asp:LinkButton ID="lbtnSkillRequest" data-toggle="modal" data-target="#add" runat="server">دانش خود را پیدا نکردم !</asp:LinkButton>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-15" runat="server" Text="تایید" OnClick="btnNext_Click" />

        </div>
    </div>
    <!---------------------Modal--------------------------->
    <div class="modal fade farsi" id="add" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close pull-left" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h5 class="modal-title pull-right" id="myModalLabel1">لطفاٌ دانش پیشنهادی خود را وارد کنید تا بعد از تایید به دانشهای شما افزوده شود</h5>
                </div>
                <div class="modal-body farsi">
                    <div class="form-group">
                        <label>عنوان‌ : </label>
                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-body farsi">
                    <div class="form-group">
                        <label>توضیحات‌ : </label>
                        <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSuggest" CssClass="btn btn-primary" runat="server" Text="ذخیره" OnClick="btnSuggest_Click" />
                </div>
            </div>
        </div>
    </div>
    <!------------------>
</asp:Content>
