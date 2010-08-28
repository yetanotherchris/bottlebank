using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;
using BottleBank;
using Flabber.Core;
using FlabberUser = Flabber.Core.User;

namespace Flabber.Site
{
	public class FlabberApplication : System.Web.HttpApplication
	{
		internal static string ConnectionString
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			}
		}

		protected void Application_Start()
		{
			FlabberUser.Configure(ConnectionString,true);
			RegisterRoutes(RouteTable.Routes);
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Default", "{controller}/{action}/{id}",
				new { controller = "Food", action = "Index", id = "" }
			);
		}
	}
}