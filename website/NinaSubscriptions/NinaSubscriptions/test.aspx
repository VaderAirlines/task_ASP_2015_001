<%@ Page Title="" Language="C#" MasterPageFile="~/master pages/ninaSubscriptions.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="NinaSubscriptions.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">
    dit is een test, userid uit session = <%= Session["userID"] %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
