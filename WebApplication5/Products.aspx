<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication5.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    
    <h3 style="background-color: gray"><b>Welcome to view all products</h3></b>

    <div class="row" style="padding-top:50px">
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <div class="thumbnail">
                <img src ="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# ("Extension") %>" alt="<%# Eval("ImageName") %>" />
                <div class="caption">
                    <div class="probrand"><%# Eval("BrandName") %>  </div>
                    <div class="proName"><%# Eval("PName") %>   </div>
                    <div class="proPrice">
                        <span class="proOgPrice"><%# Eval("PPrice") %></span><%# Eval("PSellPrice") %><span class="proPriceDiscount">(<%# Eval("DiscAmount") %> off)</span>
                    </div>
                    </div>
                    </div>
                    


                </div>
                        </ItemTemplate>
            </asp:Repeater>

            

        </div>
        

    

</asp:Content>
