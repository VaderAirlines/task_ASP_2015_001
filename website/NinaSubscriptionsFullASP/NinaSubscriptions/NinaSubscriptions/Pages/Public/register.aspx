<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <div class="component-wrapper" id="componentWrapper" runat="server">
        <div class="title">Registreer jezelf</div>
        <div class="content">
            <div class="top">
                <div class="center">
                    <table>
                        <tr>
                            <td>gebruikersnaam</td>
                            <td>
                                <asp:TextBox ID="txtUsername" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>naam</td>
                            <td>
                                <asp:TextBox ID="txtName" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>voornaam</td>
                            <td>
                                <asp:TextBox ID="txtFirstName" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>emailadres</td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" MaxLength="50" class="large" runat="server" TextMode="Email"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>telefoon/gsm</td>
                            <td>
                                <asp:TextBox ID="txtPhone" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>straat</td>
                            <td>
                                <asp:TextBox ID="txtStreet" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>nummer</td>
                            <td>
                                <asp:TextBox ID="txtNumber" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>postcode</td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" MaxLength="50" class="large" runat="server" TextMode="Number"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>plaats</td>
                            <td>
                                <asp:TextBox ID="txtPlace" MaxLength="50" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>wachtwoord</td>
                            <td>
                                <asp:TextBox ID="txtPassword" MaxLength="50" class="large" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>herhaal wachtwoord</td>
                            <td>
                                <asp:TextBox ID="txtPasswordRepeat" MaxLength="50" class="large" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="buttons">
                <asp:LinkButton runat="server" ID="btnRegister" CssClass="button bottom full" Text="Registreer" OnClientClick="return validateForm('component-wrapper');" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/register.js") %>" type="text/javascript"></script>
</asp:Content>
