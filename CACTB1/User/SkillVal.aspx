<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeFile="SkillVal.aspx.cs" Inherits="CACTB1.User.SkillVal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
        <script src="../bower_components/jquery/dist/jquery.min.js"></script>

    <style>
        .no-border {
            border-color: transparent !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">به دانش خود نمره دهید</h3>
        </div>
        <div class="panel-body farsi">
            <h6 class="center-block">
                <asp:ValidationSummary ID="ValidationSummary1" ForeColor="#CC0000" runat="server" />
            <div class="container-fluid">

                <asp:GridView ID="grdSkill" DataKeyNames="ID" CssClass=" table farsi no-border" BorderStyle="None" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Title" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:TextBox ID="txtVal" CssClass="form-control" runat="server" TextMode="Number" ToolTip="1-10"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlVal" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0">&lt;--انتخاب سطح--&gt;</asp:ListItem>
                                    <asp:ListItem Value="1">مبتدی</asp:ListItem>
                                    <asp:ListItem Value="2">پیشرفته</asp:ListItem>
                                </asp:DropDownList>
                                <label id="warn"></label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class=" margin-top-25"></div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-15" runat="server" Text="تایید" OnClick="btnNext_Click" />

        </div>
    </div>



















</asp:Content>
