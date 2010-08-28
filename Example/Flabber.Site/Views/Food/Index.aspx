<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EntriesMetaData>" %>
<%@ Import Namespace="Flabber.Site" %>
<%@ Import Namespace="Flabber.Core" %>
<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">Index</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>Food entries for <%:Model.Date %></h2>

<div id="list">
<%
	foreach (var entry in Model.Entries)
	{
%>
	<div class="delete">
		<a href="<%=Url.Action("Delete","Food",new { id=entry.Id }) %>" class="link-delete">
		<img src="/Assets/Images/delete.png" border="0" width="16" height="16" alt="" /></a>
	</div>
	<div class="title"><%=entry.Title %></div>
	<div class="calories"><%=entry.Calories %></div>
	<br style="clear: both" />
<%
	}
%>
</div>
<br />
<div id="calorietotal">Total calories: <%:Model.Calories %></div>
</asp:Content>