<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/NinaSubscriptionsMaster.Master" AutoEventWireup="true" CodeBehind="beheerCursussen.aspx.cs" Inherits="NinaSubscriptions.Pages.Admin.beheerCursussen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="phContent" runat="server">

    <asp:ListView ID="lstvCourses" runat="server" OnItemCommand="lstvCourses_ItemCommand">
        <ItemTemplate>
            <div class="component-wrapper" runat="server">
                <div class="title">
                    <div class="no-edit">
                        <span class="name-lbl"><%#Eval("name") %></span>
                    </div>
                    <div class="edit">
                        <asp:TextBox ID="txtName" MaxLength="50" CssClass="name" runat="server" Text='<%#Eval("name") %>' data-originalValue='<%#Eval("name") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="content">
                    <div class="left photo"></div>
                    <div class="right">
                        <div class="form">
                            <table>
                                <tr>
                                    <td>beschrijving</td>
                                    <td>
                                        <div class="no-edit">
                                            <span class="large description-lbl"><%#Eval("description") %></span>
                                        </div>
                                        <div class="edit">
                                            <asp:TextBox ID="txtDescription" MaxLength="200" CssClass="description" runat="server" Text='<%#Eval("description") %>' data-originalValue='<%#Eval("description") %>'></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>cursustype</td>
                                    <td>
                                        <div class="no-edit">
                                            <span class="large courseType-lbl"><%#Eval("courseType.referrer") %></span>
                                        </div>
                                        <div class="edit">
                                            <asp:Label ID="ddCourseTypeOriginalValue" CssClass="originalValue" runat="server" Text='<%#Eval("courseType.id") %>' />
                                            <asp:DropDownList ID="ddCourseType" CssClass="courseType" runat="server" OnLoad="ddCourseType_Load">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>datum van/tot</td>
                                    <td>
                                        <div class="no-edit">
                                            <span class="large">van <span class="startDate-lbl"><%#Eval("startDate", "{0:dd/MM/yyyy}") %></span> tem <span class="endDate-lbl"><%#Eval("endDateInclusive", "{0:dd/MM/yyyy}") %></span></span>
                                        </div>
                                        <div class="edit">
                                            van
                                            <asp:TextBox ID="txtStartDate" MaxLength="9" CssClass="startDate date" runat="server"
                                                Text='<%#Eval("startDate", "{0:dd/MM/yyyy}") %>' data-originalValue='<%#Eval("startDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>&nbsp;
                                            tem
                                            <asp:TextBox ID="txtEndDateInclusive" MaxLength="9" CssClass="endDate date" runat="server"
                                                Text='<%#Eval("endDateInclusive", "{0:dd/MM/yyyy}") %>' data-originalValue='<%#Eval("endDateInclusive", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>begin/einduur</td>
                                    <td>
                                        <div class="no-edit">
                                            <span class="large">van <span class="startHour-lbl"><%#Eval("startHour") %></span> tem <span class="endHour-lbl"><%#Eval("endHour") %></span></span>
                                        </div>
                                        <div class="edit">
                                            van
                                            <asp:TextBox ID="txtStartHour" MaxLength="5" CssClass="startHour hour" runat="server"
                                                Text='<%#Eval("startHour") %>' data-originalValue='<%#Eval("startHour") %>'></asp:TextBox>&nbsp;
                                            tem
                                            <asp:TextBox ID="txtEndHour" MaxLength="5" CssClass="endHour hour" runat="server"
                                                Text='<%#Eval("endHour") %>' data-originalValue='<%#Eval("endHour") %>'></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>locatie</td>
                                    <td>
                                        <div class="no-edit">
                                            <span class="large location-lbl"><%#Eval("location.name") %></span>
                                        </div>
                                        <div class="edit">
                                            <asp:Label ID="ddLocationOriginalValue" CssClass="originalValue" runat="server" Text='<%#Eval("location.id") %>' />
                                            <asp:DropDownList ID="ddLocation" CssClass="location" runat="server" OnLoad="ddLocation_Init">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>beschikbare plaatsen</td>
                                    <td>
                                        <span class="large">
                                            <div class="no-edit maxSubscriptions-lbl"><%#Eval("maxSubscriptions") %></div>
                                        </span>
                                        <div class="edit">
                                            <asp:TextBox ID="txtMaxSubscriptions" MaxLength="2" CssClass="maxSubscriptions" runat="server" Text='<%#Eval("maxSubscriptions") %>' data-originalValue='<%#Eval("maxSubscriptions") %>' TextMode="Number"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>prijs</td>
                                    <td>
                                        <div class="no-edit">
                                            €&nbsp;<span class="large price-lbl"><%#Eval("price") %></span>
                                        </div>
                                        <div class="edit">
                                            €&nbsp;<asp:TextBox ID="txtPrice" MaxLength="2" CssClass="price" runat="server" Text='<%#Eval("price") %>' data-originalValue='<%#Eval("price") %>' TextMode="Number"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="buttons right">
                        <div class="button bottom edit-course">Wijzigen</div>
                        <div class="button bottom no-edit-course">Wijzigingen ongedaan maken</div>
                        <div class="button bottom save-course">
                            <span class="ready">Wijzigingen opslaan</span><span class="saving">Bezig met opslaan ...</span>
                            <input type="hidden" class="course-id" value='<%#Eval("id") %>' />
                        </div>
                        <div class="callbackMessage"></div>
                        <asp:LinkButton runat="server" ID="btnRemoveCourse" CssClass="button bottom full"
                            Text="Verwijder cursus" CommandName="removeCourse" CommandArgument='<%#Eval("id") %>' />
                    </div>
                </div>
            </div>

        </ItemTemplate>

    </asp:ListView>

    <%-- NEW COURSE --%>
    <div id="divNewCourse" class="component-wrapper new-course" runat="server">
        <div class="title">
            Titel: <asp:TextBox ID="txtNewName" CssClass="description" runat="server" Text=""></asp:TextBox>
        </div>
        <div class="content">
            <div class="left photo"></div>
            <div class="right">
                <div class="form">
                    <table>
                        <tr>
                            <td>beschrijving</td>
                            <td>
                                <asp:TextBox ID="txtNewDescription" CssClass="description" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>cursustype</td>
                            <td>
                                <asp:DropDownList ID="ddNewCourseType" CssClass="courseType" runat="server" OnLoad="ddCourseType_Load"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>datum van/tot</td>
                            <td>van
                                <asp:TextBox ID="txtNewStartDate" CssClass="startDate date" runat="server" Text=""></asp:TextBox>&nbsp;
                                tem
                                <asp:TextBox ID="txtNewEndDateInclusive" CssClass="endDate date" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>begin/einduur</td>
                            <td>van
                                <asp:TextBox ID="txtNewStartHour" CssClass="startHour hour" runat="server" Text=""></asp:TextBox>&nbsp;
                                tem
                                <asp:TextBox ID="txtNewEndHour" CssClass="endHour hour" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>locatie</td>
                            <td>
                                <asp:DropDownList ID="ddNewLocation" CssClass="location" runat="server" OnLoad="ddLocation_Init">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>beschikbare plaatsen</td>
                            <td>
                                <asp:TextBox ID="txtNewMaxSubscriptions" CssClass="maxSubscriptions" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>prijs</td>
                            <td>€&nbsp;<asp:TextBox ID="txtNewPrice" CssClass="price" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="buttons right">
                <asp:LinkButton runat="server" ID="btnSaveNewCourse" CssClass="button bottom full save-new-course"
                    Text="Sla deze nieuwe cursus op" OnClientClick="return validateForm('component-wrapper.new-course');" OnClick="btnSaveNewCourse_Click" />
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="phScripts" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/beheerCursussen.js") %>" type="text/javascript"></script>
</asp:Content>
