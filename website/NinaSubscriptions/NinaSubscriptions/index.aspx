<%@ Page Title="" Language="C#" MasterPageFile="~/Master pages/ninaSubscriptions.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NinaSubscriptions.index" %>

<asp:Content ID="ctHead" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="ctBody" ContentPlaceHolderID="phContent" runat="server">

    <div id="divMain" ng-controller="mainController">
        <div ng-view></div>
    </div>

</asp:Content>

<asp:Content id="ctScripts" ContentPlaceHolderID="phScripts" runat="server">
</asp:Content>
