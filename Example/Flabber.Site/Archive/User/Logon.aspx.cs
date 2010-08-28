using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;
using System.Web.Security;
using System.Text;

namespace Flabber.Site.Views.Account
{
	public partial class Logon : ViewPage
	{
		protected void OpenIdLogin1_LoggedIn(object sender, OpenIdEventArgs e)
		{
			Session["OpenId"] = e.ClaimedIdentifier.ToString();
			FormsAuthentication.SetAuthCookie(e.ClaimedIdentifier.ToString(), false);

			
			Response.Redirect(Url.Action("Index", "Home"));
		}
	}
}
