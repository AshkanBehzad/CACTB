<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SelectSkills.aspx.cs" Inherits="CACTB1.User.SelectSkills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    .no_border{
        border:none !important;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">انتخاب دانشها</h3>
        </div>
        <div class="panel-body farsi">
            <div class="container-fluid">
                <asp:GridView ID="grdSkills" DataKeyNames="Sid" CssClass="no_border" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" Width="247px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckbSkills" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Title" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi margin-top-25" runat="server" Text="تایید" OnClick="btnNext_Click" />

        </div>
    </div>

</asp:Content>
