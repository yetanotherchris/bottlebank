using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Caching;
using System.Threading;
using System.Globalization;

using FlabberUser = Flabber.Core.User;
using Flabber.Core;
using BottleBank;
using System.Text;

namespace Flabber.Site.Controllers
{
    public class FoodController : Controller
    {
		[HttpGet]
		public ActionResult Index(string id)
		{
			DateTime localDate = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Local);

			EntriesMetaData metadata = new EntriesMetaData();
			metadata.Entries = EntriesForDate(localDate);
			metadata.Calories = metadata.Entries.Sum(i => i.Calories);
			metadata.Date = FriendlyDate(localDate);

			return View(metadata);
		}

		[HttpGet]
		public ActionResult ForDate(string id)
		{
			DateTime parsedDate = DateTime.Parse(id);
			parsedDate = DateTime.SpecifyKind(parsedDate, DateTimeKind.Local);

			EntriesMetaData metadata = new EntriesMetaData();
			metadata.Entries = EntriesForDate(parsedDate);
			metadata.Calories = metadata.Entries.Sum(i => i.Calories);
			metadata.Date = FriendlyDate(parsedDate);

			return View("Index", metadata);
		}

		[HttpGet]
		public ActionResult AllFood(string id)
		{
			List<FoodItem> list = FoodItem.Repository.ForUser(FlabberContext.CurrentUser);
			return View(list);
		}

		[HttpGet]
		public ActionResult Wipe()
		{
			FlabberUser.Configure(FlabberApplication.ConnectionString,true);
			return RedirectToAction("Index");
		}

		private List<FoodEntry> EntriesForDate(DateTime dateTime)
		{
			return FoodEntry.Repository.List("@Date", dateTime).ToList();
		}


		private string FriendlyDate(DateTime datetime)
		{
			string format = datetime.ToString("dd-MM-yyyy");
			string phrase = format;

			if (format == DateTime.Today.ToString("dd-MM-yyyy"))
				phrase = "Today";
			else if (format == DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy"))
				phrase = "Yesterday ";
			else if (format == DateTime.Today.AddDays(1).ToString("dd-MM-yyyy"))
				phrase = "Tomorrow";

			return phrase;
		}

		[HttpGet]
		public ActionResult AddEntry()
		{
			return View();
		}

		[HttpPost]
        public ActionResult AddEntry(string date,string title,float calories)
        {
			FlabberUser user = FlabberContext.CurrentUser;
			if (user == null)
				return RedirectToAction("Index", "Home");

			// Get the date. Force to UTC.
			DateTime userDate = DateTime.Parse(date);
			userDate = DateTime.SpecifyKind(userDate, DateTimeKind.Local);

			// Add the entry
			FoodEntry entry = new FoodEntry();
			entry.Calories = calories;
			entry.Title = title;
			entry.Date = userDate;
			entry.User = user;
			entry.Id = Guid.NewGuid();
			FoodEntry.Repository.SaveOrUpdate(entry);

			// Add to the autocomplete list
			title = title.Trim();
			FoodItem item = FoodItem.Repository.First("@Title", title);
			if (item == null)
			{
				item = new FoodItem();
				item.Title = title;
				item.User = user;
				item.Brand = "Notset";
				item.Calories = calories;
				item.Id = Guid.NewGuid();
				FoodItem.Repository.SaveOrUpdate(item);

				// Update the cache if it exists
				string cacheKey = string.Format("FoodItems{0}", user.Id);
				if (HttpContext.Cache[cacheKey] != null)
				{
					List<FoodItem> list = (List<FoodItem>)HttpContext.Cache[cacheKey];
					list.Add(item);

					HttpContext.Cache[cacheKey] = list;
				}
			}

			return RedirectToAction("Index", "Food");
        }

		public ActionResult Delete(Guid id)
		{
			FlabberUser user = FlabberContext.CurrentUser;
			if (user == null)
				return RedirectToAction("Index", "Home");

			if (id != Guid.Empty)
			{
				FoodEntry entry = FoodEntry.Repository.Read(id);
				FoodEntry.Repository.Delete(entry);
			}

			return RedirectToAction("Index", "Food");
		}

		#region Ajax
		public ActionResult AutoComplete(string q, int? limit)
		{
			FlabberUser user = FlabberContext.CurrentUser;
			if (user == null)
				return Content("");

			List<FoodItem> list = FoodItem.Repository.ForUser(user);
			return Content(list.AutoCompleteList(q));
		}
		#endregion
	}
}