<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<FoodEntry>" %>
<%@ Import Namespace="Flabber.Core" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">AddEntry</asp:Content>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
	$(document).ready(function () {
		$("#title").autocomplete("/Food/Autocomplete", { matchCase: false });

		$("#title").result(function (event, data, formatted) {
			var parts = data + "";
			var info = parts.split(",");
			$("#calories").val(info[1]);
			$("#button-add").focus();
		});
	});
	</script>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
<%using (Html.BeginForm("AddEntry","Food"))
{%>
<div id="addbox">	
	<div class="left">Date:</div>
	<div class="right"><input type="text" value="<%=DateTime.Now.ToString("dd/MM/yyyy")%>" id="date" name="date" tabindex="1" /></div>
	<br style="clear:both" />
	
	<div class="left">Description:</div>
	<div class="right"><input type="text" value="" id="title" name="title" tabindex="2" /></div>
	<br style="clear:both" />

	<div class="left">Calories (a guess):</div>
	<div class="right"><input type="text" value="" id="calories" name="calories" tabindex="3" /></div>
	<br style="clear:both" />
	
	<input type="submit" value="add" id="button-add" tabindex="4" />
</div>
<%} %>
</asp:Content>