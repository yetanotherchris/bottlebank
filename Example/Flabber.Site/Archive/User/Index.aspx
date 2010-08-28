<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Flabber.Site" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
	<% using (Html.BeginForm("Save")){ %>
	<div id="form-save">
		<div class="left">Your name</div>
		<div class="right"><input type="text" name="friendlyname" value="<%= Session["LoginName"]%>" /></div>
		<br style="clear:both" />
		
		<div class="left">Your name</div>
		<div class="right"><input type="text" name="friendlyname" value="<%= Session["LoginName"]%>" /></div>
		<br style="clear:both" />
		
		<div class="left">OpenId</div>
		<div class="right"><%=FlabberContext.CurrentUser.OpenId%></div>
		<br style="clear:both" />
		
		<input type="submit" value="save" />
	</div>
	<%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
