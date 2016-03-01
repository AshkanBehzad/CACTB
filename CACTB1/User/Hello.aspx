<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="CACTB1.User.Hello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: #f8f7f7;
        }

        @-webkit-keyframes loading {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(370deg);
            }
        }

        @keyframes loading {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }

        .anime {
            animation-name: loading;
            animation-duration: 2s;
            animation-timing-function: ease-out;
            animation-iteration-count: infinite;
            animation-direction: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 30px;">
        <h2 class="farsi text-center">خوش آمدید!</h2>
        <h4 class="farsi text-center">صبور باشید</h4>
        <div class="center-block anime">
            <%--<img src="../MyFiles/T3Ht7S3.gif" style="opacity: 0.6;" class="img-responsive center-block" />--%>
            <img src="../MyFiles/cactb.png" width="100"  style="opacity: 0.6;" class="img-responsive center-block" />
        </div>
    </div>
</asp:Content>
