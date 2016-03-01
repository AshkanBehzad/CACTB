<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MembersStats.aspx.cs" Inherits="CACTB1.Admin.MembersStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bower_components/bootstrap-social/bootstrap-social.css" rel="stylesheet" type="text/css" />

    <style>
        #info-profile {
            padding: 30px 15px;
            background: white;
            direction:rtl;
            border-top: 6px solid #203472;
            box-shadow: 3px 6px 10px #cfcece;
        }

            #info-profile figure {
                position: relative;
                margin-bottom: 50px;
            }

                #info-profile figure a {
                    color: #333;
                }

                    #info-profile figure a:hover {
                        color: #f2f2f2;
                    }

            #info-profile #imgProfile:hover {
                opacity: 0.9;
            }

            #info-profile figure #btn-EditPic {
                position: absolute;
                bottom: -25px;
                right: 10px;
                background: #576ba7;
            }

            #info-profile figure #btn-DeletePic {
                background: #bb5021;
                position: absolute;
                bottom: -25px;
                right: 62px;
            }

        #portofilio {
            min-height: 500px;
            border-top: 6px solid #203472;
            padding: 20px;
            background: white;
            box-shadow: 0px 6px 15px #cfcece;
        }

            #portofilio table tr td:nth-child(2n+1) {
                font-weight: bold;
            }

            #portofilio div.col-lg-12 {
                border-bottom: 2px solid #333;
            }

                #portofilio div.col-lg-12 h2 {
                    font-weight: bold;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 40px;">
        <div id="info-profile" class="col-lg-3 center-block">
            <figure id="profile-figure">
                <asp:image id="imgProfile" cssclass="img-responsive center-block" imageurl="~/MyFiles/user.png" runat="server" />
                <button id="btn-EditPic" type="button" class="btn btn-info btn-circle btn-lg" data-toggle="tooltip" data-placement="bottom" title="ویرایش تصویر ">
                    <asp:linkbutton id="lbtnEditPic" runat="server"><i class="fa fa-pencil"></i></asp:linkbutton>
                </button>
                <button id="btn-DeletePic" type="button" class="btn btn-danger btn-circle btn-lg" data-toggle="tooltip" data-placement="bottom" title="حذف تصویر ">
                    <asp:linkbutton id="lbtnDeletePic" runat="server"><i class="fa fa-times"></i></asp:linkbutton>
                </button>
            </figure>
            <h1 style="font-weight: bold">
                <asp:label id="lblFullNameUP" runat="server" text=" "></asp:label>
            </h1>
            <small>
                <asp:label id="lblFieldUP" runat="server" text=""></asp:label>
            </small>
            <h5>عضو<span>
                <asp:label id="lblMembershipStatusUP" runat="server" text=""> </asp:label>
            </span><span style="color: #203472; font-weight: bold;">انجمن علمی مهندسی کامپیوتر </span></h5>
            <p class="text-justify margin-top-25">
                <asp:label cssclass="rtl" id="lblBioUP" runat="server" text=""></asp:label>
            </p>
            <a id="linkedin" class="btn btn-block btn-social btn-linkedin ltr" runat="server">
                <i class="fa fa-linkedin"></i>
                <asp:label id="lblLinkedin" runat="server" text="be"></asp:label>
            </a>
            <a id="github" class="btn btn-block btn-social btn-github ltr" runat="server">
                <i class="fa fa-github"></i>
                <asp:label id="lblgithub" runat="server" text="be"></asp:label>
            </a>
            <a id="twitter" class="btn btn-block btn-social btn-twitter ltr" runat="server">
                <i class="fa fa-twitter"></i>
                <asp:label id="lblTwitter" runat="server" text="be"></asp:label>
            </a>
            <script>
                $(function () {
                    $('[data-toggle="tooltip"]').tooltip()
                })
            </script>
        </div>
        <div id="portofilio" class="col-lg-8">
            <div class=" farsi">
                <!------مشخصات------->
                <div class="col-lg-12">
                    <h2>مشخصات
                            <asp:linkbutton id="LinkButton1" runat="server"><i class="fa fa-edit"></i></asp:linkbutton>
                    </h2>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12  col-xs-12 pull-right">
                    <table class="table">
                        <tr>
                            <td>نام:</td>
                            <td>
                                <asp:label id="lblFirstName" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>نام خانوادگی:</td>
                            <td>
                                <asp:label id="lblLastName" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>مقطع/گرایش:</td>
                            <td>
                                <asp:label id="lblField" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>شماره تماس  1:</td>
                            <td>
                                <asp:label id="lblPhone1" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 pull-right">
                    <table class="table ">
                        <tr>
                            <td>شماره دانشجویی:</td>
                            <td>
                                <asp:label id="lblStudentID" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>شماره ملّی :</td>
                            <td>
                                <asp:label id="lblNationalID" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>رایانامه:</td>
                            <td style="font-family: Arial; font-size: 10px;">
                                <asp:label id="lblEmail" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                        <tr>
                            <td>شماره تماس 2:</td>
                            <td>
                                <asp:label id="lblPhone2" runat="server" text=""></asp:label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clearfix"></div>
                <!-----//-مشخصات------->
                <!--------دانشها------->
                <div class="col-lg-12">
                    <h2>دانشها و مهارتها
                            <asp:linkbutton id="LinkButton2" runat="server"><i class="fa fa-edit"></i></asp:linkbutton>
                    </h2>
                </div>
                <div style="padding: 30px;" class="table-responsive">
                    <%--<asp:DataList ID="dlSkills" CssClass="" runat="server" RepeatColumns="5" OnItemCommand="dlSkills_ItemCommand">
                                <ItemTemplate>
                                    <div class="btn btn-success margin-5 ltr" style="background:#333 !important;cursor:default !important;">
                                        <asp:Label ID="lblSkillBut" runat="server" Title='<%#Eval("CatTile") %>' Text='<%#Eval("Title") %>'></asp:Label>
                                        <asp:LinkButton ID="lbtnDeleteSkill" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem" runat="server">&times;</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>--%>
                    <asp:datalist id="dlSkills" cssclass="" runat="server" repeatcolumns="5" runat="server" OnItemCommand="dlSkills_ItemCommand">
                        <ItemTemplate>
                            <div class="btn btn-success margin-5 ltr" style="background:#333 !important;cursor:default !important;">
                                        <asp:Label ID="lblSkillBut" runat="server" Title='<%#Eval("CatTile") %>' Text='<%#Eval("Title") %>'></asp:Label>
                                        <asp:LinkButton ID="lbtnDeleteSkill" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem" runat="server">&times;</asp:LinkButton>
                                    </div>
                        </ItemTemplate>
                    </asp:datalist>
                </div>
                <!--------//دانشها------->
                <!--------سوابق آموزشی------->
                <div class="col-lg-12">
                    <h2>سوابق آموزشی
                            <asp:linkbutton id="LinkButton3" runat="server"><i class="fa fa-edit"></i></asp:linkbutton>
                    </h2>
                </div>
                <div style="padding: 30px;">
                </div>
                <!--------//سوابق آموزشی------->
                <!--------سوابق کاری------->
                <div class="col-lg-12">
                    <h2>سوابق کاری
                            <asp:linkbutton id="LinkButton4" runat="server"><i class="fa fa-edit"></i></asp:linkbutton>
                    </h2>
                </div>
                <div style="padding: 30px;">
                </div>
                <!--------//سوابق کاری------->
            </div>
        </div>

    </div>

</asp:Content>
