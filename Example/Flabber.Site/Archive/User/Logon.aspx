<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="Flabber.Site.Views.Account.Logon" %>
<%@ Register assembly="DotNetOpenAuth" namespace="DotNetOpenAuth.OpenId.RelyingParty" tagprefix="rp" %>
<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
	<form runat="server">
	    <h2>Log On</h2>  
	    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

	    <rp:OpenIdLogin ID="OpenIdLogin1" runat="server" onloggedin="OpenIdLogin1_LoggedIn" Text="https://www.google.com/accounts/o8/id"  />
	</form>
</asp:Content>
