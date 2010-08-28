using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.Caching;

using FlabberUser = Flabber.Core.User;
using Flabber.Core;

namespace Flabber.Site
{
	[HandleError]
	public class UserController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Login()
		{
			if (Session["OpenId"] == null)
				return View("Logon");

			string openId = Session["OpenId"].ToString();

			if (string.IsNullOrEmpty(openId))
				return View("Logon");

			// Normalise it
			openId = openId.ToLower();

			// Find it, and add the user if they don't exist
			FlabberUser user = FlabberUser.Repository.First("@OpenId", openId);
			string name = "No name set";

			if (user == null)
			{
				user = new FlabberUser();
				user.Id = Guid.NewGuid();
				user.OpenId = openId;
				user.Name = name;
				FlabberUser.Repository.SaveOrUpdate(user);
			}
			else
			{
				name = user.Name;
			}

			Session["LoginName"] = name;

			return View("Index");
		}

		public ActionResult Logon()
		{
			return View("Logon");
		}

		public ActionResult Logoff()
		{
			Session["LoginName"] = "";
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Home");
		}
	}
}
