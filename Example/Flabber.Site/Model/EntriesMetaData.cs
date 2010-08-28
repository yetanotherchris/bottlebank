using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flabber.Core;

namespace Flabber.Site
{
	public class EntriesMetaData
	{
		public List<FoodEntry> Entries { get; set; }
		public string Date { get; set; }
		public double Calories { get; set; }
	}
}