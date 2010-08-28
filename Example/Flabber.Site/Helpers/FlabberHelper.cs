using System.Collections.Generic;
using System.Web;
using FlabberUser = Flabber.Core.User;
using System;

namespace Flabber.Site
{
	public static class FlabberContext
	{
		public static FlabberUser CurrentUser
		{
			get
			{
				string openid = HttpContext.Current.User.Identity.Name;
				openid = "root";

				FlabberUser user = FlabberUser.Repository.First("@OpenId", openid);
				if (user == null)
				{
					user = new FlabberUser();
					user.Id = Guid.NewGuid();
					user.Name = openid;
					user.OpenId = openid;
					FlabberUser.Repository.SaveOrUpdate(user);
					return user;
				}
				else
					return user;
			}
		}
	}
}
