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
                                <asp:TextBox ID="txtUsername" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>naam</td>
                            <td>
                                <asp:TextBox ID="txtName" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>voornaam</td>
                            <td>
                                <asp:TextBox ID="txtFirstName" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>emailadres</td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>telefoon/gsm</td>
                            <td>
                                <asp:TextBox ID="txtPhone" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>straat</td>
                            <td>
                                <asp:TextBox ID="txtStreet" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>nummer</td>
                            <td>
                                <asp:TextBox ID="txtNumber" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>postcode</td>
                            <td>
                                <asp:TextBox ID="txtPostalCode" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>plaats</td>
                            <td>
                                <asp:TextBox ID="txtPlace" class="large" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label for="chkShowPassword">
                                    <asp:CheckBox ID="chkShowPassword" runat="server" />
                                    toon wachtwoord
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>wachtwoord</td>
                            <td>
                                <asp:TextBox ID="txtPassword" class="large" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>herhaal wachtwoord</td>
                            <td>
                                <asp:TextBox ID="txtPasswordRepeat" class="large" TextMode="Password" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="errorMessage">
                                <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="successMessage">
                                <div id="successMessage" runat="server"></div></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="buttons">
                <asp:LinkButton runat="server" ID="btnRegister" CssClass="button bottom" Text="Registreer" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
