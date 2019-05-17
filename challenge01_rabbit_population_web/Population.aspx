<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Population.aspx.cs" Inherits="challenge01_rabbit_population_web.Population" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Population Explosion</h1>

    <p>Please enter the desired maximum population ceiling.</p>
    <asp:TextBox ID="maxPop" runat="server"></asp:TextBox>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Results: "></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    
</asp:Content>
