<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="bekijkAanbod.aspx.cs" Inherits="NinaSubscriptions.Pages.Public.bekijkAanbod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <asp:ListView ID="lstvCourses" runat="server" OnItemCommand="lstvCourses_ItemCommand">
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
                                    <td><span class="large"><%#Eval("description") %></span></td>
                                </tr>
                                <tr>
                                    <td>leeftijd</td>
                                    <td><span class="large">vanaf <%#Eval("courseType.ageFrom") %> jaar tem <%#Eval("courseType.ageToInclusive") %> jaar</span></td>
                                </tr>
                                <tr>
                                    <td>datum van/tot</td>
                                    <td><span class="large">van <%#Eval("startDate", "{0:dd MMMM yyyy}") %> tem <%#Eval("endDateInclusive", "{0:dd MMMM yyyy}") %></span></td>
                                </tr>
                                <tr>
                                    <td>begin/einduur</td>
                                    <td><span class="large">van <%#Eval("startHour") %> tem <%#Eval("endHour") %></span></td>
                                </tr>
                                <tr>
                                    <td>locatie</td>
                                    <td><span class="large"><%#Eval("location.name") %></span></td>
                                </tr>
                                <tr>
                                    <td>adres</td>
                                    <td><span class="large"><%#Eval("location.street") %>&nbsp;<%#Eval("location.number") %>, <%#Eval("location.postalCode") %>&nbsp;<%#Eval("location.place") %></span></td>
                                </tr>
                                <tr>
                                    <td>beschikbare plaatsen</td>
                                    <td><span class="large"><%#Eval("openSubscriptions") %>/<%#Eval("maxSubscriptions") %></span></td>
                                </tr>
                                <tr>
                                    <td>prijs</td>
                                    <td><span class="large">€&nbsp;<%#Eval("price") %></span></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="buttons right">
                        <asp:LinkButton runat="server" ID="btnSubscribe" CssClass="button bottom right"
                            Text="Ik schrijf me in!" CommandName="subscribeToCourse" CommandArgument='<%#Eval("id") %>' Enabled='<%#Eval("hasOpenSpots") %>'/>
                    </div>
                </div>
            </div>

        </ItemTemplate>

    </asp:ListView>

    <div id="divNoCourses" class="component-wrapper" runat="server">
        <div class="title">Spijtig&hellip;</div>
        <div class="content">
            Er zijn op dit moment nog geen nieuwe cursussen gepland. Probeer het later nog eens!
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/bekijkAanbod.js") %>" type="text/javascript"></script>
</asp:Content>
