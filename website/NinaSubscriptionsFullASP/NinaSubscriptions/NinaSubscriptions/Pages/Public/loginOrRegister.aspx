<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="loginOrRegister.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.loginOrRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">
    <div class="component-wrapper">
    <div class="title">Log in of registreer</div>
    <div class="content">
        <div class="top">
            <div class="center">
                <table>
                    <tr>
                        <td>gebruikersnaam</td>
                        <td><asp:TextBox ID="txtUsername" class="large" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>wachtwoord</td>
                        <td><asp:TextBox ID="txtPassword" class="large" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="errorMessage">
                            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="buttons">
            <asp:LinkButton runat="server" ID="btnLogin" CssClass="button top full" Text="Aanmelden" OnClick="btnLogin_Click" />
            <asp:LinkButton runat="server" ID="btnRegister" CssClass="button bottom full smaller-text" Text="Of registreren" OnClick="btnRegister_Click"/>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
