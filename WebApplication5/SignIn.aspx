<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebApplication5.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn</title>

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
                        <li><a href="SignUp.aspx">SignUp</a></li>
                        <li class="active"><a href="SignIn.aspx">SignIn</a></li>
                    </ul>

                </div>


            </div>

        </div>
    </div>
            </div>
        <hr />
        <hr />
        
        <!----signin form start--->

        <div class="container" >
            <div class="form-horizontal">
                <h2>Login Form</h2>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" CssClass="col-md-2 control-label" runat="server" Text="User Name"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" CssClass="text-danger" ErrorMessage="Please Enter User Name" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" CssClass="col-md-2 control-label" runat="server" Text="Password"></asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" CssClass="text-danger" ErrorMessage="Please Enter Valid Password" ControlToValidate="txtPass" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" CssClass="control-label" runat="server" Text="Remember Me"></asp:Label>
                    </div>
                </div>

                

                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <asp:Button ID="btnLogin" CssClass="btn btn-success" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx">Sign Up</asp:HyperLink>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-md-2"></div>
                    <div class="col-md-6"></div>
                    <asp:Label ID="lblError" CssClass="text-danger" runat="server" ></asp:Label>

                </div>


            </div>

        </div>

        <!----signin form end--->
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <!---footer starts---->
    <br />
    <footer>
        <div class="container">
            <p class="pull-right"><a href="#">Back to Topk to Top</a></p>
            <p>&copy;2022 Faija.in &middot; <a href="Default.aspx">Home</a>&middot;<a href="Default.aspx">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
        </div>
    </footer>

    <!---footer ends--->

    </form>
</body>
</html>
