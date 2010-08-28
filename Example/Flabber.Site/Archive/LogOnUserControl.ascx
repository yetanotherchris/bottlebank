<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Flabber.Site" %>
<%
    if (Request.IsAuthenticated) {
%>

        Welcome <b><a href=""><%= Html.Encode(FlabberHelper.CurrentUser().Name)%></a></b>!
        [ <%= Html.ActionLink("Log Off", "Logoff", "User") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log on", "Logon", "User") %> ]
<%
    }
%>
