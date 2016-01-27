<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="subscribeToCourse.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.subscribeToCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <div class="component-wrapper">

        <div class="title">
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </div>
        <div class="content">
            <%-- COURSE DATA --%>
            <div class="content-top">
                <div class="left photo"></div>

                <div class="right">
                    <div class="form">
                        <table>
                            <tr>
                                <td>beschrijving</td>
                                <td>
                                    <span class="large">
                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>leeftijd</td>
                                <td>
                                    <span class="large">vanaf&nbsp;<asp:Label ID="lblAgeFrom" runat="server"></asp:Label>&nbsp;jaar 
                                        tem&nbsp;<asp:Label ID="lblAgeTo" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>wanneer</td>
                                <td>
                                    <span class="large">van&nbsp;<asp:Label ID="lblDateFrom" runat="server"></asp:Label>
                                        tem&nbsp;<asp:Label ID="lblDateTo" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>locatie</td>
                                <td>
                                    <span class="large">
                                        <asp:Label ID="lblLocationName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>adres</td>
                                <td>
                                    <span class="large">
                                        <asp:Label ID="lblLocationAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>beschikbare plaatsen</td>
                                <td>
                                    <span class="large">
                                        <asp:Label ID="lblSubscriptionsLeft" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>prijs</td>
                                <td>
                                    <span class="large">
                                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <%--SUBSCRIBED CHILDREN--%>
            <div class="subscriptions userdata subscribed-children">
                <asp:ListView ID="lstSubscribedChildren" runat="server" OnItemCommand="lstSubscribedChildren_ItemCommand">
                    <ItemTemplate>
                        <div class="component-wrapper">
                            <div class="title"><%#Eval("firstName") %> <%#Eval("name") %></div>
                            <div class="content">
                                <div class="top">
                                    <div class="center">
                                        <table>
                                            <tr>
                                                <td>Geboortedatum</td>
                                                <td>
                                                    <span class="large"><%#Eval("dateOfBirth") %></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="buttons">
                                    <asp:LinkButton runat="server" ID="btnRemoveChild" CssClass="button bottom"
                                        Text="verwijderen" CommandName="removeChild" CommandArgument='<%#Eval("id") %>' />
                                </div>
                            </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <%--CHILD ADDERS--%>
            <div id="divChildSelectors" runat="server">
                <%--EXISTING CHILDREN--%>
                <div id="divExistingChildSelectorAccordionButton" class="button-accordion title" runat="server"><span class="accordion-icon">+</span> Voeg een bestaand kind toe</div>
                <div id="divExistingChildSelector" class="subscriptions userdata all-children" runat="server">
                    <div class="component-wrapper">
                        <%--<div class="title">Voeg een bestaand kind toe</div>--%>
                        <div class="content">
                            <div class="top">
                                <div class="center">
                                    <table>
                                        <tr>
                                            <td>Kies een kind</td>
                                            <td>
                                                <asp:ListBox ID="lstAllChildren" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="buttons">
                            <asp:LinkButton ID="btnAddExistingChild" CssClass="button bottom" runat="server" OnClick="btnAddExistingChild_Click">
                                Voeg het gekozen kind toe aan de lijst
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <%--NEW CHILDREN--%>
                <div id="divNewChildSelectorAccordionButton" class="button-accordion title" runat="server"><span class="accordion-icon">+</span> Voeg een nieuw kind toe</div>
                <div id="divNewChildSelector" class="subscriptions userdata new-child" runat="server">
                    <div class="component-wrapper">
                        <%--<div class="title">Voeg een nieuw kind toe</div>--%>
                        <div class="content">
                            <div class="top">
                                <div class="center">
                                    <table>
                                        <tr>
                                            <td>Voornaam</td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" class="large" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Achternaam</td>
                                            <td>
                                                <asp:TextBox ID="txtName" class="large" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Geboortedatum</td>
                                            <td>
                                                <asp:TextBox ID="txtDateOfBirth" class="large" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="buttons">
                            <asp:LinkButton ID="btnAddNewChild" CssClass="button bottom" runat="server" OnClick="btnAddNewChild_Click">
                                Voeg dit kind toe aan de lijst
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <%--CONDITIONS--%>
            <div class="conditions button full">
                <label for="chkConditions">
                    <input type="checkbox" id="chkConditions" name="chkConditions" />
                    ik ga akkoord met de algemene voorwaarden
                </label>
            </div>

            <%--CONFIRM SUBSCRIPTIONS BUTTON--%>
            <div class="buttons">
                <div class="button bottom full" ng-click="subscribe(cf.subscriptionCourse.id, userData);">
                    Ik schrijf me in!
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/subscribeToCourse.js") %>" type="text/javascript"></script>
</asp:Content>
