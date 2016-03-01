<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="WorkExp.aspx.cs" Inherits="CACTB1.User.WorkExp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .block {
            width: 100%;
            border: 1px solid #d9d9d9;
            border-radius: 5px;
            padding: 10px;
            margin: 5px 0;
        }

            .block:hover {
                background: #CCC;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="login-panel panel panel-default" style="margin-top: 30px;">
        <div class="panel-heading">
            <h3 class="panel-title text-center">تجربه کاری </h3>
        </div>
        <div class="panel-body farsi">
                <asp:Label ID="lblWarn" Visible="false" runat="server" ForeColor="#CC0000" Text="لطفاً ورودی‌های خود را چک کنید"></asp:Label>
            <div class="form-group">
                <label>نام موسسه/شرکت/..  :</label>
                <asp:TextBox ID="txtCoName" CssClass="form-control farsi" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>مدّت<span style="color: #CC0000;">(به ماه)</span> :</label> 
                <asp:TextBox ID="txtDutation" MaxLength="2" CssClass="form-control farsi" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>نوع تجربه :</label> 
                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="0">انتخاب</asp:ListItem>
                    <asp:ListItem>کارآموزی</asp:ListItem>
                    <asp:ListItem>داوطلبانه</asp:ListItem>
                    <asp:ListItem>سمتدار</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>توضیحات:</label>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="100" CssClass="form-control farsi" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="btnEdit" CssClass="btn btn-lg btn-warning btn-sm btn-block farsi " runat="server" Text=" ثبت اطلاعات" OnClick="btnEdit_Click" />

            <div class="form-group">
                <asp:DataList ID="dlSavedExps" CssClass="full-width" runat="server" OnItemCommand="dlSavedExps_ItemCommand">
                    <ItemTemplate>
                        <div>
                            <div class="block">
                                <%#Eval("CompanyName") %>
                                <asp:LinkButton CommandArgument='<%#Eval("ID") %>' CommandName="DeleteItem" ID="LinkButton1" CssClass="pull-left" runat="server"> 
                                 <span class="fa fa-times"></span>
                                </asp:LinkButton>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <a href="profile.aspx" class="btn btn-lg btn-primary btn-block farsi margin-top-25">بعدی</a>
        </div>
    </div>
</asp:Content>
