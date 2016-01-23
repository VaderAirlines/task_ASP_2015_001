<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="bekijkAanbod.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.bekijkAanbod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <asp:ListView ID="lstvCourses" runat="server" OnItemCommand="lstvCourses_ItemCommand">
        <EmptyDataTemplate>
            Er zijn momenteel geen cursussen beschikbaar.
        </EmptyDataTemplate>

        <ItemTemplate>
            <div class="component-wrapper" runat="server">
                <div class="title"><%#Eval("name") %></div>
                <div class="content">
                    <div class="left photo"></div>
                    <div class="right">
                        <div class="form">
                            <table>
                                <tr>
                                    <td>beschrijving</td>
                                    <td><span class="large" /><%#Eval("description") %></td>
                                </tr>
                                <tr>
                                    <td>leeftijd</td>
                                    <td><span class="large" />vanaf <%#Eval("courseType.ageFrom") %> jaar tem <%#Eval("courseType.ageToInclusive") %> jaar</td>
                                </tr>
                                <tr>
                                    <td>wanneer</td>
                                    <td><span class="large" />van <%#Eval("startDate", "{0:dd MMMM yyyy}") %> tem <%#Eval("endDateInclusive", "{0:dd MMMM yyyy}") %></td>
                                </tr>
                                <tr>
                                    <td>locatie</td>
                                    <td><span class="large" /><%#Eval("location.name") %></td>
                                </tr>
                                <tr>
                                    <td>adres</td>
                                    <td><span class="large" /><%#Eval("location.street") %>&nbsp;<%#Eval("location.number") %>, <%#Eval("location.postalCode") %>&nbsp;<%#Eval("location.place") %></td>
                                </tr>
                                <tr>
                                    <td>beschikbare plaatsen</td>
                                    <td><span class="large" /><%#Eval("maxSubscriptions") %></td>
                                </tr>
                                <tr>
                                    <td>prijs</td>
                                    <td><span class="large" />€&nbsp;<%#Eval("price") %></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="buttons right">
                        <asp:LinkButton runat="server" ID="subscribeButton" CssClass="button bottom right"
                            Text="Add To List" CommandName="subscribeToCourse" CommandArgument='<%#Eval("id") %>' />
                        <%--<div id="subscribeButton" class="button bottom right" runat="server" CommandName="subscribeToCourse">
                            Ik schrijf me in!
                        </div>--%>
                    </div>
                </div>
            </div>

        </ItemTemplate>

    </asp:ListView>





    <%--<div class="component-wrapper" ng-repeat="course in cf.courses">
        <div class="title">{{ course.naam }}</div>
        <div class="content">
            <div class="left photo"></div>
            <div class="right">
                <div class="form">
                    <table>
                        <tr>
                            <td>beschrijving</td>
                            <td><span class="large" />{{ course.omschrijving }}</td>
                        </tr>
                        <tr>
                            <td>leeftijd</td>
                            <td><span class="large" />vanaf {{ course.leeftijdVanaf }} jaar tem {{ course.leeftijdTotEnMet }}</td>
                        </tr>
                        <tr>
                            <td>wanneer</td>
                            <td><span class="large" />van {{ course.datumVan }} tem {{ course.datumTot }}</td>
                        </tr>
                        <tr>
                            <td>locatie</td>
                            <td><span class="large" />{{ course.locatieNaam }}</td>
                        </tr>
                        <tr>
                            <td>adres</td>
                            <td><span class="large" />{{ course.locatieAdres }}</td>
                        </tr>
                        <tr>
                            <td>beschikbare plaatsen</td>
                            <td><span class="large" />{{ course.maxDeelnemers }}</td>
                        </tr>
                        <tr>
                            <td>prijs</td>
                            <td><span class="large" />{{ course.kostprijs }}</td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="buttons right">
                <div class="button bottom right" ng-click="subscribe(course);">
                    Ik schrijf me in!
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
