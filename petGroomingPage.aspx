﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="petGroomingPage.aspx.cs" Inherits="PE_Final_Assignment.petGroomingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container start-page">
        <div class="row">
            <div class="col">
                <asp:Image ID="dogGroomImg" runat="server" ImageUrl="~/images/dogGroomImg.png" />
            </div>
            <div class="col text-center" style="margin-top: 3rem">
                <h1 style="font-family: coiny;">Dog Grooming Services</h1>
                <p style="font-size:1.1rem">Here at Paws N' Claws, we provide professional grooming services. We micro focus on our pets grooming and boarding services to provide the best for your beloved pets.  
                    With over 800 hours of hands-on grooming instruction over a 20-week course, our passionate groomers provide the best care for your dog.</p>
                <p style="font-size:1.1rem">Our grooming services for dogs include bath, cut, aromatheraphy system, aroma oil massages, and so on, so feel free to check us out!</p>
                <asp:ImageButton ID="dogServiceBtn" CssClass="rotateBtn" runat="server" ImageUrl="~/images/shop_now_dog.png" OnClick="dogServiceBtn_Click" />
            </div>
        </div>
    </div>
    <div class="grass" style="height: 100vh">
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <h1 style="font-family: coiny;">Cat Grooming Services</h1>
                    <p style="font-size:1.1rem">Here at Paws N' Claws, we provide professional grooming services.  We offer experienced groomer where they are expert in cat grooming for all breed and local cats. Our cat grooming and cat boarding place was created with the comfort, safety and fun of your pets in mind.</p>
                    <p style="font-size:1.1rem">We provide bath and cut services, among other services such as tick treatment, scissor cut, and detangling. Rest assure that we will help your lovely cat look and feel great with a refreshing grooming appointment.</p>
                    <asp:ImageButton ID="catServiceBtn" CssClass="rotateBtn" runat="server" ImageUrl="~/images/shop_now_cat.png" OnClick="catServiceBtn_Click" />
                </div>
                <div class="col">
                    <asp:Image ID="catGroomImg" runat="server" ImageUrl="~/images/catGroomImg.png" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
