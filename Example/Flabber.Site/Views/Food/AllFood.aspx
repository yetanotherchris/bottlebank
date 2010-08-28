<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<FoodItem>>" %>
<%@ Import Namespace="Flabber.Core" %>
<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">All food items</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>All foods</h2>
	
<div id="list">
<%
	foreach (var item in Model)
	{
%>
	<div class="title"><%: item.Title %></div>
	<div class="calories"><%: item.Calories %></div>
	<br style="clear: both" />
<%
	}
%>
</div>
</asp:Content>