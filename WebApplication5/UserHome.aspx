<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="WebApplication5.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home Page</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE-edge">
    <link href="css/custom.css" rel="stylesheet" />


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>

                    </button>
                    <a class="navbar-brand" href="Default.aspx"><span>
                        <img src="icons/draw_svg20210625-19886-u8ghol.svg.png" alt="MyMedicineWebsite" height="30" width="30" /></span>MyMedicineShop</a>


                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="Default.aspx">Home</a></li>
                        <li class="#"><a href="Default.aspx">About</a></li>
                        <li class="#"><a href="Default.aspx">Contact Us</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown-header">Generics</li>
                                <li role="separator" class="divider"></li>
                                <li><a href="#">Baby and Mom Care</a></li>
                                <li><a href="#">Supplements and Vitamins</a></li>
                                <li><a href="#">Nutrition and Drinks</a></li>

                                <li role="separator" class="divider"></li>
                                <li class="dropdown-header">Pharmaceuticals</li>
                                <li role="separator" class="divider"></li>
                                <li><a href="#">Covid-19 Special</a></li>
                                <li><a href="#">Women Care</a></li>
                                <li><a href="#">Herbal and Homeopathy</a></li>



                            </ul>
                        </li>
                        <li>
                            <asp:Button ID="btnlogout" CssClass="btn btn-default navbar-btn" runat="server" Text="Sign Out" OnClick="btnlogout_Click" />
                        </li>
                        
                    </ul>

                </div>


            </div>

        </div>
    </div>
            </div>
        <br />
        <br />
        <br />
        <br />

        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>

        <!---footer starts---->
    <hr />
    <footer>
        <div class="container">
            <p class="pull-right"><a href="#">Back to Top</a></p>
            <p>&copy;2022 Faija.in &middot; <a href="Default.aspx">Home</a>&middot;<a href="Default.aspx">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
        </div>
    </footer>

    <!---footer ends--->

    </form>
</body>
</html>
