<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="CACTB1.User.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحه مدیریتی سایت انجمن علمی مهندسی کامپیوتر</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="../MyFiles/cactb.png" />
    <link href="../bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../bower_components/metisMenu/dist/metisMenu.min.css" rel="stylesheet" />
    <link href="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="../bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../MyFiles/StyleSheet1.css" rel="stylesheet" />
    <link href="../bower_components/bootstrap-social/bootstrap-social.css" rel="stylesheet" type="text/css" />
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../bower_components/metisMenu/dist/metisMenu.min.js"></script>
    <script src="../bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <script src="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"></script>
    <script src="../dist/js/sb-admin-2.js"></script>
    <style>
        body {
            background: #f5f5f5 !important;
            color: #333;
        }

        li.dropdown {
            position: relative;
        }

            li.dropdown ul {
                position: absolute;
                right: 0px;
            }

        #heading {
            height: 85px;
            padding: 5px;
            border-bottom: 2px solid white;
            /*border-top: 2px solid white;*/
            background: #eaeaea;
            margin-bottom: 45px;
        }

            #heading h1 {
                margin-right: 30px;
            }

        #info-profile {
            padding: 30px 15px;
            background: white;
            border-top: 6px solid #203472;
            box-shadow: 3px 6px 10px #cfcece;
            /*margin-right: 40px;
            margin-left: 40px;*/
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

        .block {
            border: 1px solid #cfcece;
            border-radius: 5px;
            padding: 0px;
        }

        .inner-block {
            padding: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper" class="rtl farsi">
            <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
                <ul class="nav navbar-nav navbar-right">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><i class="fa fa-user"></i></a>
                        <ul class="dropdown-menu farsi">
                            <li>
                                <asp:LinkButton CssClass="pull-right" ID="lbtnChangePass" runat="server"><i class="fa fa-key"></i>&nbsp;تغییر رمز عبور</asp:LinkButton></li>
                            <li class="clearfix"></li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <asp:LinkButton CssClass="pull-right" ID="lbtnSignOut" runat="server" OnClick="lbtnSignOut_Click"><i class="fa fa-power-off"></i>&nbsp;خروج</asp:LinkButton></li>
                        </ul>
                    </li>
                </ul>
            </nav>
            <div id="heading" class="col-lg-12">
                <h1>نمایه...</h1>
            </div>
            <div class="container-fluid">
                <div id="info-profile" class="col-lg-3 col-md-3 center-block">
                    <figure id="profile-figure">
                        <asp:Image ID="imgProfile" CssClass="img-responsive center-block" ImageUrl="~/MyFiles/user.png" runat="server" />
                        <button id="btn-EditPic" type="button" class="btn btn-info btn-circle btn-lg" data-toggle="tooltip" data-placement="bottom" title="ویرایش تصویر ">
                            <asp:LinkButton ID="lbtnEditPic" runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                        </button>
                        <button id="btn-DeletePic" type="button" class="btn btn-danger btn-circle btn-lg" data-toggle="tooltip" data-placement="bottom" title="حذف تصویر ">
                            <asp:LinkButton ID="lbtnDeletePic" runat="server"><i class="fa fa-times"></i></asp:LinkButton>
                        </button>
                    </figure>
                    <h1 style="font-weight: bold">
                        <asp:Label ID="lblFullNameUP" runat="server" Text=" "></asp:Label></h1>
                    <small>
                        <asp:Label ID="lblFieldUP" runat="server" Text=""></asp:Label></small>
                    <h5>عضو<span>
                        <asp:Label ID="lblMembershipStatusUP" runat="server" Text=""> </asp:Label></span><span style="color: #203472; font-weight: bold;"> انجمن علمی مهندسی کامپیوتر </span></h5>
                    <p class="text-justify margin-top-25">
                        <asp:Label CssClass="rtl" ID="lblBioUP" runat="server" Text=""></asp:Label>
                    </p>
                    <a id="linkedin" class="btn btn-block btn-social btn-linkedin ltr" target="_blank" runat="server">
                        <i class="fa fa-linkedin"></i>
                        <asp:Label ID="lblLinkedin" runat="server" Text=""></asp:Label>
                    </a>
                    <a id="github" class="btn btn-block btn-social btn-github ltr" target="_blank" runat="server">
                        <i class="fa fa-github"></i>
                        <asp:Label ID="lblgithub" runat="server" Text=""></asp:Label>
                    </a>
                    <a id="twitter" class="btn btn-block btn-social btn-twitter ltr" target="_blank" runat="server">
                        <i class="fa fa-twitter"></i>
                        <asp:Label ID="lblTwitter" runat="server" Text=""></asp:Label>
                    </a>
                    <script>
                        $(function () {
                            $('[data-toggle="tooltip"]').tooltip()
                        })
                    </script>
                </div>
                <%--<div class="col-lg-1" style="/*width: 70px !important; height: 120px; */"></div>--%>
                <div id="portofilio" class="col-lg-9 col-md-9">
                    <div class=" farsi">
                        <!------مشخصات------->
                        <div class="col-lg-12">
                            <h2>مشخصات
                            <asp:LinkButton ID="LinkButton1" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                            </h2>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12  col-xs-12 pull-right">
                            <table class="table">
                                <tr>
                                    <td>نام:</td>
                                    <td>
                                        <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>نام خانوادگی:</td>
                                    <td>
                                        <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>مقطع/گرایش:</td>
                                    <td>
                                        <asp:Label ID="lblField" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>شماره تماس  1:</td>
                                    <td>
                                        <asp:Label ID="lblPhone1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 pull-right">
                            <table class="table ">
                                <tr>
                                    <td>شماره دانشجویی:</td>
                                    <td>
                                        <asp:Label ID="lblStudentID" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>شماره ملّی :</td>
                                    <td>
                                        <asp:Label ID="lblNationalID" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>رایانامه:</td>
                                    <td style="font-family: Arial; font-size: 10px;">
                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>شماره تماس 2:</td>
                                    <td>
                                        <asp:Label ID="lblPhone2" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clearfix"></div>
                        <!-----//-مشخصات------->
                        <!--------دانشها------->
                        <div class="col-lg-12">
                            <h2>دانشها و مهارتها
                            <asp:LinkButton ID="LinkButton2" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>

                            </h2>
                        </div>
                        <div style="padding: 30px;" class="table-responsive">
                            <asp:DataList ID="dlSkills" CssClass="" runat="server" RepeatColumns="5" OnItemCommand="dlSkills_ItemCommand">
                                <ItemTemplate>
                                    <div class="btn btn-success margin-5 ltr" title="سطح  <%#Eval("Value") %>" style="border-radius: 40px; background: #333 !important; cursor: default !important; box-shadow: inset 0 0 9px #282828;">
                                        <asp:Label ID="lblSkillBut" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                                        <asp:LinkButton ID="lbtnDeleteSkill" CssClass="lbtnDeleteSkills" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem" runat="server">&times;</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <!--------//دانشها------->

                        <!--------سوابق آموزشی------->
                        <div class="col-lg-12">
                            <h2>سوابق آموزشی
                            <asp:LinkButton ID="LinkButton3" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                            </h2>
                        </div>
                        <div style="padding: 30px; height: 300px;">
                        </div>
                        <!--------//سوابق آموزشی------->

                        <!--------سوابق کاری------->
                        <div class="col-lg-12">
                            <h2>سوابق کاری
                            <asp:LinkButton ID="LinkButton4" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                            </h2>
                        </div>
                        <div class="clearfix"></div>

                        <div style="margin:40px 0;">
                            <asp:DataList ID="dlExp" runat="server">
                                <ItemTemplate>
                            <div class="block full-width">
                                <div class="name pull-right col-lg-3  col-md-3  col-sm-3 inner-block" style="border-left: 1px solid #cfcece;"></div>
                                <div class="duration col-lg-1  col-md-1 col-sm-1  pull-right inner-block">5ماه</div>
                                <div class="des  col-lg-7 col-md-7 col-sm-7 pull-right inner-block" style="border-left: 1px solid #cfcece; border-right: 1px solid #cfcece;">asp.net & ssmsasp.net & ssmsasp.net & s & ssmsaasp.net & ssms</div>
                                <div class="col-lg-1 col-md-1 col-sm-1  pull-left" style="padding-top:10px;text-align:center;"><span class="fa fa-times"></span></div>
                                <div style="clear: both"></div>
                            </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <!--------//سوابق کاری------->
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
