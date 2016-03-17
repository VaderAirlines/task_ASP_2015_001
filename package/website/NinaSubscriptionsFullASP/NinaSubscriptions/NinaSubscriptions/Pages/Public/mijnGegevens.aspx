<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="mijnGegevens.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.mijnGegevens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <div class="component-wrapper" id="componentWrapper" runat="server">
        <div class="title">Mijn gegevens</div>
        <div class="content">
            <div class="top">
                <div class="center">
                    <table>
                        <tr>
                            <td>gebruikersnaam</td>
                            <td>
                                <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>naam</td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>voornaam</td>
                            <td>
                                <asp:Label ID="lblFirstname" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>emailadres</td>
                            <td>
                                <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>telefoon/gsm</td>
                            <td>
                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>straat</td>
                            <td>
                                <asp:Label ID="lblStreet" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>nummer</td>
                            <td>
                                <asp:Label ID="lblNumber" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>postcode</td>
                            <td>
                                <asp:Label ID="lblPostalCode" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>plaats</td>
                            <td>
                                <asp:Label ID="lblPlace" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="component-wrapper">
        <div class="title">Geregistreerde kinderen</div>
        <div class="content">
            <div class="top">
                <div class="center">
                    <asp:ListView ID="lstvChildren" runat="server">
                        <ItemTemplate>
                            <div class="component-wrapper second-wrapper">
                                <div class="title"><%#Eval("firstName") %> <%#Eval("name") %></div>
                                <div class="content">
                                    <div class="top">
                                        <div class="center">
                                            <table>
                                                <tr>
                                                    <td>Geboortedatum</td>
                                                    <td>
                                                        <span class="large"><%#Eval("dateOfBirth", "{0:dd MMMM yyyy}") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

    <div class="component-wrapper">
        <div class="title">Mijn inschrijvingen</div>
        <div class="content">
            <div class="top">
                <div class="center">
                    <asp:ListView ID="lstvSubscriptions" runat="server">
                        <ItemTemplate>
                            <div class="component-wrapper second-wrapper">
                                <div class="title"><%#Eval("course.name") %> van <%#Eval("course.startDate", "{0:dd MMMM yyyy}") %> tem <%#Eval("course.endDateInclusive", "{0:dd MMMM yyyy}") %></div>
                                <div class="content">
                                    <div class="top">
                                        <div class="center">
                                            <table>
                                                <tr>
                                                    <td><strong>Ingeschreven kind</strong></td>
                                                    <td>
                                                        <span class="large"><%#Eval("child.name") %> <%#Eval("child.firstName") %></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
