<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="bekijkInschrijvingen.aspx.cs" Inherits="NinaSubscriptions.Pages.Admin.bekijkInschrijvingen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <div class="component-wrapper">
        <div class="title">Filter</div>
        <div class="content">
            <div class="top">
                <div class="center">
                    Zoek inschrijvingen op
                    <ul>
                        <li>
                            <div class="filter label">cursusnaam</div>
                            <div class="filter input">
                                <asp:DropDownList ID="ddCourseNames" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCourseNames_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </li>
                        <li>
                            <div class="filter label">gebruikersnaam</div>
                            <div class="filter input">
                                <asp:DropDownList ID="ddUserProfiles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddUserProfiles_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </li>
                        <li>
                            <div class="filter label">datum</div>
                            <div class="filter input">
                                <asp:Calendar ID="cldrDates" runat="server" OnSelectionChanged="cldrDates_SelectionChanged"></asp:Calendar>
                            </div>
                        </li>
                    </ul>

                    <div class="component-wrapper second-wrapper">
                        <div class="title">Resultaten voor <span id="resultsFor" runat="server"></span></div>
                        <div class="content">
                            <div class="top">
                                <div class="center">
                                    <asp:GridView ID="grdResults" runat="server" AutoGenerateColumns="False" OnRowCommand="grdResults_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="ID" />
                                            <asp:BoundField DataField="cursusNaam" HeaderText="Cursusnaam" />
                                            <asp:BoundField DataField="kindAchternaam" HeaderText="Achternaam" />
                                            <asp:BoundField DataField="kindVoornaam" HeaderText="Voornaam" />
                                            <asp:CheckBoxField DataField="heeftBetaald" HeaderText="Heeft betaald?">
                                            <ControlStyle CssClass="gridview-checkbox" />
                                            </asp:CheckBoxField>
                                            <asp:ButtonField ButtonType="Button" CommandName="paySubscription" HeaderText="Betalen" Text="betalen" />
                                            <asp:ButtonField ButtonType="Button" CommandName="removeSubscription" HeaderText="Verwijderen" Text="verwijderen" />
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
