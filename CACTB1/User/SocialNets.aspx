<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SocialNets.aspx.cs" Inherits="CACTB1.User.SocialNets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        span i {
            width: 15px !important;
            font-size: 15px !important;
        }

        #ad-google:hover {
            background: #d96658 !important;
        }

        #ad-facebook:hover {
            background: #5876b5 !important;
        }

        #ad-github:hover {
            background: #444242 !important;
        }

        #ad-instagram:hover {
            background: #587c9a !important;
        }

        #ad-linkedin:hover {
            background: #207ba7 !important;
        }

        #ad-twitter:hover {
            background: #84bbe4 !important;
        }

        input[type="text"] {
            border: none;
            box-shadow: inset 0 0 10px #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-panel panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title text-center h6"><span style="font-weight: bolder">کاملاً اختیاری:</span>حساب کاربری شبکه‌های اجتماعی شما</h6>
        </div>
        <div class="panel-body">
            <div class="form-group input-group">
                <asp:TextBox ID="txtGit" class="form-control" runat="server" placeholder="Github" title="github"></asp:TextBox>
                <span title="github" id="ad-github" class="input-group-addon" style="color: #fff; background: #2b2b2b;"><i class="fa fa-github"></i></span>
            </div>
            <div class="form-group input-group">
                <asp:TextBox ID="txtLinedin" class="form-control" runat="server" placeholder="Linkedin" title="linkedin"></asp:TextBox>
                <span title="linkedin" id="ad-linkedin" class="input-group-addon" style="color: #fff; background: #005983;"><i class="fa fa-linkedin"></i></span>
            </div>
            <div class="form-group input-group">
                <asp:TextBox ID="txtTwitter" class="form-control" runat="server" placeholder="Twitter" title="twitter"></asp:TextBox>
                <span title="twitter" id="ad-twitter" class="input-group-addon" style="color: #fff; background: #55acee;"><i class="fa fa-twitter"></i></span>
            </div>
            <div class="form-group input-group">
                <asp:TextBox ID="txtWebsite" class="form-control" runat="server" placeholder="Website Or Weblog" title="twitter"></asp:TextBox>
                <span title="twitter" id="ad-website" class="input-group-addon" style="color: #fff; background: #69806f;"><i class="fa fa-globe"></i></span>
            </div>
            <asp:Button ID="btnNext" CssClass="btn btn-lg btn-primary btn-block farsi" runat="server" Text="بعدی" OnClick="btnNext_Click" />
        </div>
    </div>
</asp:Content>
